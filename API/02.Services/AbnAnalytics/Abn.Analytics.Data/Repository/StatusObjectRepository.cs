using Abn.Analytics.Domain;
using Abn.Analytics.Domain.StatusObjectAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Data.Repository
{
   public class StatusObjectRepository:BaseRepository<StatusObject,Guid>,  IStatusObjectRepository
    {
        public StatusObjectRepository(DbContext dbContext):base(dbContext)
        {

        }
    }
}
