using Abn.Analytics.Application;
using Abn.Analytics.Application.Exceptions;
using Abn.Analytics.Domain.StatusObjectAggregate;
using Abn.Framework.Core.Ef;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Abn.Analytics.UnitTest
{
    public class DataCalculatorServiceTests
    {

        



        [Theory(DisplayName = "email verification test")]
        [InlineData("jefrymail")]
        [InlineData("mk23552")]
        public async Task DataCalculatorServiceEmailValidationTest(string email)
        {
            var statusObjectRepository = new Mock<IStatusObjectRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();

            
          await  Assert.ThrowsAnyAsync<InvalidInputException>(async () => {

                DataCalculatorService service = new DataCalculatorService(statusObjectRepository.Object, unitOfWork.Object, mapper.Object);
              await  service.StartCalculation(new Domain.StatusObject { Name = "jack", Email = email });


            });
           
        }
        [Theory(DisplayName = "email verification test")]
        [InlineData("brad1")]
        [InlineData("g@brad")]
        [InlineData(".brad")]
        public async Task DataCalculatorServiceNameValidationTest(string name)
        {
            var statusObjectRepository = new Mock<IStatusObjectRepository>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var mapper = new Mock<IMapper>();


            await Assert.ThrowsAnyAsync<InvalidInputException>(async () => {

                DataCalculatorService service = new DataCalculatorService(statusObjectRepository.Object, unitOfWork.Object, mapper.Object);
                await service.StartCalculation(new Domain.StatusObject { Name = name, Email = "test@yahoo.com" });


            });

        }


    }
}
