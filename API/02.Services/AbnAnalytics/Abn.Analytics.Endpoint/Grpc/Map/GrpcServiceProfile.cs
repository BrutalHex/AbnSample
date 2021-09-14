using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abn.Analytics.Endpoint.Grpc.Map
{

    public class GrpcServiceProfile : AutoMapper.Profile
    {
        public GrpcServiceProfile()
        {
            CreateMap<Domain.StatusObject, Abn.Analytics.Endpoint.Grpc.StatusObject>()
                .ForMember(a=>a.Id,b=>b.MapFrom(c=>c.Id.ToString())).
                ForMember(a => a.Status, b => b.MapFrom(c => c.Status.ToString()))
                .ForMember(a=>a.Result, b=>b.MapFrom(c=> string.IsNullOrEmpty( c.Result) ? string.Empty: c.Result));
            CreateMap<Abn.Analytics.Endpoint.Grpc.DataInput, Domain.StatusObject>().ReverseMap();

            

        }
    }
}
