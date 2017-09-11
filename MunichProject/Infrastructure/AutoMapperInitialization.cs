
using AutoMapper;
using MunichProject.Models;

namespace MunichProject.Infrastructure
{
    public class AutoMapperInitialization
    {
        public static IMapper Current
        {
            get
            {
                if (Singleton<IMapper>.Instance != null) return Singleton<IMapper>.Instance;

                var config = new MapperConfiguration(cfg => {
                    // Object mapping will be defined here
                    cfg.CreateMap<FormModel, InternalDataObject>();
                });
                var mapper = new Mapper(config);

                Singleton<IMapper>.Instance = mapper;
                return Singleton<IMapper>.Instance;
            }
        }
    }
}