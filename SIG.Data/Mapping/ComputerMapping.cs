﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
    public class ComputerMapping: IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(f => f.Historics).WithOne(b => b.Computer).HasForeignKey(b => b.ComputerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
