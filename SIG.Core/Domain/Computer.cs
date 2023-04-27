﻿using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain
{
    public sealed class Computer : Entity
    {
        public Computer(string name, string description, string processor,
            EMemoryType memoryType, EDiskType diskType, int diskSize,
            int memorySize, Guid brandId, string brandName, Guid typeId,
            string typeName, string serialNumber, Guid locacityId,
            string locacityName, Guid areaId, string areaName,
            Guid sectorId, string sectorName, string modifiedBy) : base(modifiedBy)
        {
            Name = name;
            Description = description;
            Processor = processor;
            MemoryType = memoryType;
            DiskType = diskType;
            DiskSize = diskSize;
            MemorySize = memorySize;
            BrandId = brandId;
            BrandName = brandName;
            TypeId = typeId;
            TypeName = typeName;
            SerialNumber = serialNumber;
            LocacityId = locacityId;
            LocacityName = locacityName;
            AreaId = areaId;
            AreaName = areaName;
            SectorId = sectorId;
            SectorName = sectorName;
        }
        public void Update(string name, string description, string processor,
           EMemoryType memoryType, EDiskType diskType, int diskSize,
           int memorySize, Guid brandId, string brandName, Guid typeId,
           string typeName, string serialNumber, Guid locacityId,
           string locacityName, Guid areaId, string areaName,
           Guid sectorId, string sectorName, bool isActive, string modifiedBy,
           DateTime modifyDate)
        {
            Name = name;
            Description = description;
            Processor = processor;
            MemoryType = memoryType;
            DiskType = diskType;
            DiskSize = diskSize;
            MemorySize = memorySize;
            BrandId = brandId;
            BrandName = brandName;
            TypeId = typeId;
            TypeName = typeName;
            SerialNumber = serialNumber;
            LocacityId = locacityId;
            LocacityName = locacityName;
            AreaId = areaId;
            AreaName = areaName;
            SectorId = sectorId;
            SectorName = sectorName;
            ModifiedBy = modifiedBy;
            ModifyDate = modifyDate;
            IsActive = isActive;
        }
        private void Deactivate()
        {
            IsActive = false;
        }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Processor { get; private set; } = string.Empty;
        public EMemoryType MemoryType { get; private set; }
        public EDiskType DiskType { get; private set; }
        public int DiskSize { get; private set; }
        public int MemorySize { get; private set; }
        public Guid BrandId { get; private set; }
        public string BrandName { get; private set; } = string.Empty;
        public Guid TypeId { get; private set; }
        public string TypeName { get; private set; } = string.Empty;
        public string SerialNumber { get; private set; } = string.Empty;
        public Guid LocacityId { get; private set; }
        public string LocacityName { get; private set; } = string.Empty;
        public Guid AreaId { get; private set; }
        public string AreaName { get; private set; } = string.Empty;
        public Guid SectorId { get; private set; }
        public string SectorName { get; private set; } = string.Empty;

    }
}
