using LMS.DataAccess;
using LMS.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services.Services
{
    public class LMSService: ILMSService
    {
        private readonly AppDbContext dbContext;

        public LMSService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<LMSEntityModel>> GetLMSEntities()
        {
            var entities = await (from entity in dbContext.LMSEntities
                                  select new LMSEntityModel()
                                  {
                                      Id = entity.Id,
                                      Name = entity.Name,
                                      Description = entity.Description,
                                      Salary = entity.Salary,
                                  }).ToListAsync();
            return entities;
        }
    }
}
