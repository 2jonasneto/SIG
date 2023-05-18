using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using SIG.Core.Domain;

namespace SIG.Data.Mapping
{
    public class EquipTypeMapping: IEntityTypeConfiguration<EquipType>
    {
        public void Configure(EntityTypeBuilder<EquipType> builder)
        {
            builder.HasKey(c => c.Id);

        }
    }
}
