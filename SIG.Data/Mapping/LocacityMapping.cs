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
    public class LocacityMapping: IEntityTypeConfiguration<Locacity>
    {
        public void Configure(EntityTypeBuilder<Locacity> builder)
        {
            builder.HasKey(c => c.Id);

        }
    }
}
