using SIG.Core.Base;
using SIG.Shared.Enums;
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
            int memorySize, Guid brandId,  Guid typeId,
           string serialNumber, Guid locacityId,
             Guid areaId, Guid sectorId, string modifiedBy) : base(modifiedBy)
        {
            Name = name;
            Description = description;
            Processor = processor;
            MemoryType = memoryType;
            DiskType = diskType;
            DiskSize = diskSize;
            MemorySize = memorySize;
            BrandId = brandId;
            TypeId = typeId;
            SerialNumber = serialNumber;
            LocacityId = locacityId;
            AreaId = areaId;
            SectorId = sectorId;
        }
        public void Update(string name, string description, string processor,
           EMemoryType memoryType, EDiskType diskType, int diskSize,
           int memorySize, Guid brandId,  Guid typeId,
           string serialNumber, Guid locacityId,
            Guid areaId,Guid sectorId, bool isActive, string modifiedBy,
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
            TypeId = typeId;
            SerialNumber = serialNumber;
            LocacityId = locacityId;
            AreaId = areaId;
            SectorId = sectorId;
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
        public string SerialNumber { get; private set; } = string.Empty;


        public Guid LocacityId { get; private set; }
        public Guid AreaId { get; private set; }
        public Guid SectorId { get; private set; }
        public Guid BrandId { get; private set; }
        public Guid TypeId { get; private set; }

        public ICollection<Historic> Historics { get; set; }
    }
}
