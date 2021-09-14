using Abn.Analytics.Domain;
using Abn.Framework.Core.Ef;
using Abn.Framework.Core.Extenions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abn.Analytics.Data.Map
{
   public class StatusObjectMap : BaseMap<StatusObject>
    {
        public StatusObjectMap() : base("StatusObject")
        {

        }
        public override void Configure(EntityTypeBuilder<StatusObject> builder)
        {
            builder.ToTable(TableName);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasFormattedColumnName(TableName);

            builder.Property(a => a.Email).HasFormattedColumnName(TableName);
            builder.Property(a => a.Name).HasFormattedColumnName(TableName);
            builder.Property(a => a.Progress).HasFormattedColumnName(TableName);
            builder.Property(a => a.Result).HasFormattedColumnName(TableName);
            builder.Property(a => a.Status).HasFormattedColumnName(TableName);
            
        }
   



    }
}
