using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abn.Analytics.Endpoint.Controller.Maps
{
    public class AnalyticsMapperProfile : AutoMapper.Profile
    {
        public AnalyticsMapperProfile()
        {
            
                CreateMap<Dto.DataInput, Domain.StatusObject>().ReverseMap();
                
        }
    }
}
