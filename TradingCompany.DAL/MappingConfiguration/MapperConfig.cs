using AutoMapper;

namespace TradingCompany.DAL
{
    public abstract class MapperConfig<T, U>
        where T : class, new()
        where U : class, new()
    {
        protected IMapper _mapper;

        public MapperConfig()
        {
            var config = new MapperConfiguration(c => c.AddProfiles(typeof(T), typeof(U)));
            _mapper = config.CreateMapper();
        }
    }
}
