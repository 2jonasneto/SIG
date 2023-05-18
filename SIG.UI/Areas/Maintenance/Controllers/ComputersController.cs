using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Data.Base;
using SIG.Services;

namespace SIG.UI.Areas.Maintenance
{
    [Area("Maintenance")]
    //  [Route("Maintenance")]
    public class ComputersController : Controller
    {

        private readonly IComputerRepository _computer;
        private readonly IMapper _mapper;

        public ComputersController(IComputerRepository computer, IMapper mapper)
        {

            _computer = computer;
            _mapper = mapper;
        }
        //    [Route("Computers")]
        // GET: Maintenance/Computers
        public async Task<IActionResult> Index()
        {

            var cp = await _computer.GetAll();
            var cpm = _mapper.Map<IEnumerable<ComputerViewModel>>(cp);

            return View(cpm);

        }

        // GET: Maintenance/Computers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            return View();
            /* if (id == null || _context.Computers == null)
             {
                 return NotFound();
             }

             var computer = await _context.Computers
                 .FirstOrDefaultAsync(m => m.Id == id);
             if (computer == null)
             {
                 return NotFound();
             }

             return View(computer);*/
        }
        // [Route("Computers/Create")]
        // GET: Maintenance/Computers/Create
        public IActionResult Create()
        {
            return View(new ComputerViewModel());
        }

        // POST: Maintenance/Computers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Processor,MemoryType,DiskType,DiskSize,MemorySize,BrandId,BrandName,TypeId,TypeName,SerialNumber,LocacityId,AreaId,SectorId,Id,ModifiedBy,ModifyDate,IsActive")] Computer computer)
        {return View(computer);
            /*  if (ModelState.IsValid)
              {
                  computer.Id = Guid.NewGuid();
                  _context.Add(computer);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              return View(computer);*/
        }

        // GET: Maintenance/Computers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
           
            return View();
        }

        // POST: Maintenance/Computers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,Processor,MemoryType,DiskType,DiskSize,MemorySize,BrandId,BrandName,TypeId,TypeName,SerialNumber,LocacityId,LocacityName,AreaId,AreaName,SectorId,SectorName,Id,ModifiedBy,ModifyDate,IsActive")] Computer computer)
        {
           
            return View(computer);
        }

        // GET: Maintenance/Computers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
          

            return View();
        }

        // POST: Maintenance/Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(Guid id)
        {
            return false;
        }
    }
}
