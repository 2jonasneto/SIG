﻿using SIG.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SIG.Core.Domain.Interfaces
{
    public interface IComputerRepository:IRepository<Computer>
    {
        Task<Computer> GetAllIncludeHistoric(Guid id);
    }
}
