using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public abstract class CommonDAL<dto, tbl> : MapperConfig<dto, tbl>, ICommonDAL<dto>
        where dto : class, new()
        where tbl : class, new()
    {
        public List<string> Includes { get; set; }

        public List<dto> Get()
        {
            var data = new List<dto>();

            using (var entities = new TradingCompanyEntities())
            {
                data = _mapper.Map<List<dto>>(entities.Set<tbl>().ToList());

                if (Includes != null)
                {
                    DbQuery<tbl> query = entities.Set<tbl>();
                    Includes.ForEach(x => query = query.Include(x));
                }
            }

            if (data == null)
            {
                throw new NullReferenceException(nameof(dto));
            }

            return data;
        }

        public dto GetById(int id)
        {
            var entity = new dto();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<dto>(entities.Set<tbl>().FindAsync(id).Result);

                if (Includes != null)
                {
                    DbQuery<tbl> query = entities.Set<tbl>();
                    Includes.ForEach(x => query = query.Include(x));
                }
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(dto));
            }

            return entity;
        }

        public async void Add(dto entity)
        {
            using (var entities = new TradingCompanyEntities())
            {
                entities.Set<tbl>().Add(_mapper.Map<tbl>(entity));

                await entities.SaveChangesAsync();
            }
        }

        public async void Update(dto entity, int entityId)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var data = entities.Set<tbl>().FindAsync(entityId).Result;

                if (data == null)
                {
                    throw new NullReferenceException(nameof(dto));
                }

                var jpa = _mapper.Map<tbl>(entity);
                entities.Entry(data).CurrentValues.SetValues(jpa);
                entities.Entry(data).State = EntityState.Detached;
                entities.Entry(data).State = EntityState.Modified;

                await entities.SaveChangesAsync();
            }
        }

        public async void Delete(int id)
        {
            using (var entities = new TradingCompanyEntities())
            {
                var data = entities.Set<tbl>().FindAsync(id).Result;

                if (data == null)
                {
                    throw new NullReferenceException(nameof(tbl));
                }

                entities.Entry(data).State = EntityState.Deleted;
                entities.Set<tbl>().Remove(data);// _mapper.Map<tbl>(entity));
                await entities.SaveChangesAsync();
            }
        }
    }
}
