using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using TradingCompany.DAL.DAL.DALAbstractions;
using TradingCompany.Database;

namespace TradingCompany.DAL
{
    public class BlockingDataDAL : CommonDAL<BlockingDataDTO, tblBlockingData>, 
        IBlockingDataDAL
    {
        public BlockingDataDAL()
        {
            Includes = new List<string>() { nameof(tblBlockingData.tblUser) };
        }

        public BlockingDataDTO GetByUserId(int id)
        {
            var entity = new BlockingDataDTO();

            using (var entities = new TradingCompanyEntities())
            {
                entity = _mapper.Map<BlockingDataDTO>(entities.Set<tblBlockingData>().Where(data => data.UserId == id).FirstOrDefault());
            }

            if (entity == null)
            {
                throw new NullReferenceException(nameof(BlockingDataDTO));
            }

            return entity;
        }
    }
}
