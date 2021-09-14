using Abn.Framework.Core.Extenions;
using Abn.Analytics.ApplicationContract;
using Abn.Analytics.Domain;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abn.Analytics.Application.Exceptions;
using Abn.Analytics.Domain.StatusObjectAggregate;
using Abn.Framework.Core.Ef;
using AutoMapper;
 
using System.Threading;

namespace Abn.Analytics.Application
{
    public class DataCalculatorService : IDataCalculatorService
    {

        private readonly IStatusObjectRepository _statusObjectRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
    
        public DataCalculatorService (IStatusObjectRepository statusObjectRepository, IUnitOfWork unitOfWork,IMapper mapper )
        {
            _statusObjectRepository = statusObjectRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        
        }

        Random _random = new Random(0);
        Random _randomStatus = new Random(0);

        /// <summary>
        /// gets the status of an item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StatusObject> GetStatus(Guid id)
        {
            var item = await _statusObjectRepository.FindAsync(id);
            if (item == null)
            {
                throw new NotFoundException(id);
            }
            await ProcessCalculation(item);
            return item;
        }

        /// <summary>
        /// calculates output based on input data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<StatusObject> StartCalculation(StatusObject model)
        {
          
            var validation = model.Validate();
            if(!validation.Success)
            {
                throw new InvalidInputException(validation.Messages);
            }
            //store it into Db
            model = await SaveToDb(model);

       


            return model;
        }


        /// <summary>
        /// wrapper method for simulation
        /// </summary>
        /// <param name="input">input model</param>
        /// <param name="connectionId">signalR connection Id</param>
        /// <returns></returns>
        public async Task ProcessCalculation(StatusObject input)
        {

            await Simulate(10000, input, 10,Status.Running);
            await Simulate(5000, input, 40, Status.Running);
            var waitNumber = GetWait();
            await Simulate(10000 * waitNumber, input, 60, (Status)Getstatus());

        }

        /// <summary>
        /// simulates changes to input object
        /// </summary>
        /// <param name="seconds">seconds to sleep current thread</param>
        /// <param name="data">input data</param>
        /// <param name="percent">progressed amount</param>
        /// <param name="connectionId">signalR hub connection Id</param>
        /// <param name="status">random status</param>
        /// <returns></returns>
        private async Task Simulate(int seconds, StatusObject data,int percent, Status status)
        {
            Thread.Sleep(seconds);
            data.IncreseProgress(percent);
            data.Status = status;
            if(data.Status==Status.Completed)
            {
                data.Result = data.GetHashCode().ToString();
            }

            await SaveToDb(data);
           
        }

        /// <summary>
        /// stores into Db
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task<StatusObject> SaveToDb(StatusObject model)
        {
            var exist = _statusObjectRepository.FindAll().Where(a => a.Id == model.Id).FirstOrDefault();
            if(exist != null)
            {
                model = _mapper.Map(model, exist);
                await _statusObjectRepository.UpdateAsync(model);
            }
            else
            {
             
                 await _statusObjectRepository.AddAsync(model);
            }
         
           await _unitOfWork.SaveChangesAsync();
            return model;
        }

        private int GetWait()
        {
            return _random.Next(1, 3);
        }
       
        private int Getstatus()
        {
            return _randomStatus.Next(1, 2);
        }


    }
}
