﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIG.Shared.Enums;

namespace SIG.Services
{
    public class ComputerViewModel
    {
        public Guid Id { get; set; }
        public string ModifiedBy { get; set; } = string.Empty;
        public DateTime ModifyDate { get; set; }
        public bool IsActive { get; set; } 

        public string Name { get;  set; } = string.Empty;
        public string Description { get;  set; } = string.Empty;
        public string Processor { get;  set; } = string.Empty;
        public int MemoryType { get;  set; }
        public int DiskType { get;  set; }
        public int DiskSize { get;  set; }
        public int MemorySize { get;  set; }
        public Guid BrandId { get;  set; }
        public string BrandName { get;  set; } = string.Empty;
        public Guid TypeId { get;  set; }
        public string TypeName { get;  set; } = string.Empty;
        public string SerialNumber { get;  set; } = string.Empty;
        public Guid LocacityId { get;  set; }
        public string LocacityName { get;  set; } = string.Empty;
        public Guid AreaId { get;  set; }
        public string AreaName { get;  set; } = string.Empty;
        public Guid SectorId { get;  set; }
        public string SectorName { get;  set; } = string.Empty;
    }
}