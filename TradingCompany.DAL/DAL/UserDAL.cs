using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public class UserDAL : CommonDAL<UserDTO, tblUser>
    {
        public UserDAL()
        {
            Includes = new List<string>() { nameof(tblUser.tblAddresses),
                                            nameof(tblUser.tblActivatingData),
                                            nameof(tblUser.tblBlockingData) };
        }

        //public async override void Update(UserDTO entity, int entityId)
        //{
        //    using (var entities = new TradingCompanyEntities())
        //    {
        //        var data = entities.Set<tblUser>().FindAsync(entityId).Result as tblUser;

        //        if (data == null)
        //        {
        //            throw new NullReferenceException(nameof(UserDTO));
        //        }

        //        var jpa = _mapper.Map<tblUser>(entity);
        //        entities.Entry(data).State = EntityState.Modified;

        //        entities.Entry(data).CurrentValues.SetValues(jpa);
        //        entities.ChangeTracker.DetectChanges();
        //        await entities.SaveChangesAsync();
        //    }
        //}

        public UserDTO GetByEmail(string email)
        {
            var entity = new UserDTO();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<UserDTO>(entities.tblUsers.Where(user => user.Email == email).FirstOrDefaultAsync().Result);

                if (Includes != null)
                {
                    DbQuery<tblUser> query = entities.Set<tblUser>();
                    Includes.ForEach(x => query = query.Include(x));
                }
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(UserDTO));
            }

            return entity;
        }

        public UserDTO GetByNumber(string number)
        {
            var entity = new UserDTO();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<UserDTO>(entities.tblUsers.Where(user => user.PhoneNumber == number).FirstOrDefaultAsync().Result);

                if (Includes != null)
                {
                    DbQuery<tblUser> query = entities.Set<tblUser>();
                    Includes.ForEach(x => query = query.Include(x));
                }
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(UserDTO));
            }

            return entity;
        }
        
        public List<UserDTO> GetByCountry(string country)
        {
            var entity = new List<UserDTO>();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<List<UserDTO>>(entities.tblUsers.Where(user => user.tblAddresses.Any(x => x.Country == country)).FirstOrDefaultAsync().Result);

                if (Includes != null)
                {
                    DbQuery<tblUser> query = entities.Set<tblUser>();
                    Includes.ForEach(x => query = query.Include(x));
                }
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(List<UserDTO>));
            }

            return entity;
        }
    }
}
