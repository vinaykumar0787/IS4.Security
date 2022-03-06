using LMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Services.Services
{
    public interface ILMSService
    {
        Task<List<LMSEntityModel>> GetLMSEntities();
    }
}
