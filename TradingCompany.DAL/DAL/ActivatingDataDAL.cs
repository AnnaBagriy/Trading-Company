using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.DAL.DALAbstractions;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public class ActivatingDataDAL : CommonDAL<ActivatingDataDTO, tblActivatingData>,
        IActivatingDataDAL
    {
        public ActivatingDataDAL()
        {
            Includes = new List<string>() { nameof(tblActivatingData.tblUser) };
        }

        public ActivatingDataDTO GetByUserId(int id)
        {
            var entity = new ActivatingDataDTO();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<ActivatingDataDTO>(entities.Set<tblActivatingData>().Where(data => data.UserId == id).FirstOrDefault());
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(ActivatingDataDTO));
            }

            return entity;
        }
    }
}
