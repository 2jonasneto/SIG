using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        private readonly IEquipTypeRepository _equipType;
        private readonly ILocacityRepository _locacity;
        private readonly IBrandRepository _brand;
        private readonly ISectorRepository _sector;
        private readonly IActingAreaRepository _actingArea;
        private readonly IHistoricRepository _historic;

        public ComputersController(IComputerRepository computer, IMapper mapper,
            IEquipTypeRepository equipType, ILocacityRepository locacity,
            IBrandRepository brand, ISectorRepository sector, IActingAreaRepository actingArea, IHistoricRepository historic)
        {

            _computer = computer;
            _mapper = mapper;
            _equipType = equipType;
            _locacity = locacity;
            _brand = brand;
            _sector = sector;
            _actingArea = actingArea;
            _historic = historic;
        }
        //    [Route("Computers")]
        // GET: Maintenance/Computers
        [Route("/Maintenance/Computers/")]
        public async Task<IActionResult> Index(string SearchString,Guid LocacityId, Guid TypeId)
        {
            var types = await _equipType.GetAll();
            var brands = await _brand.GetAll();
            var locacities = await _locacity.GetAll();
            var areas = await _actingArea.GetAll();
            var sectors = await _sector.GetAll();
            ViewBag.AreaId = new SelectList(_mapper.Map<IEnumerable<ActingAreaViewModel>>(areas), "Id", "Name");
            ViewBag.BrandId = new SelectList(_mapper.Map<IEnumerable<BrandViewModel>>(brands), "Id", "Name");
            ViewBag.SectorId = new SelectList(_mapper.Map<IEnumerable<SectorViewModel>>(sectors), "Id", "Name");
            ViewBag.LocacityId = new SelectList(_mapper.Map<IEnumerable<LocacityViewModel>>(locacities), "Id", "Name");
            ViewBag.TypeId = new SelectList(_mapper.Map<IEnumerable<EquipTypeViewModel>>(types), "Id", "Name");

            var cp = await _computer.GetByQueryReturnIEnumerable(x => x.Name.Contains(SearchString??""));

            var cpm = _mapper.Map<IEnumerable<ComputerViewModel>>(cp);
           
            return View(cpm);

        }

     
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {


            var computer = _mapper.Map<ComputerViewModel>(await _computer.GetById(id));
               
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }
     
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var types = await _equipType.GetAll();
            var brands = await _brand.GetAll();
            var locacities = await _locacity.GetAll();
            var areas = await _actingArea.GetAll();
            var sectors = await _sector.GetAll();
            ViewBag.AreaId = new SelectList(_mapper.Map<IEnumerable<ActingAreaViewModel>>(areas), "Id", "Name");
            ViewBag.BrandId = new SelectList(_mapper.Map<IEnumerable<BrandViewModel>>(brands), "Id", "Name");
            ViewBag.SectorId = new SelectList(_mapper.Map<IEnumerable<SectorViewModel>>(sectors), "Id", "Name");
            ViewBag.LocacityId = new SelectList(_mapper.Map<IEnumerable<LocacityViewModel>>(locacities), "Id", "Name");
            ViewBag.TypeId = new SelectList(_mapper.Map<IEnumerable<EquipTypeViewModel>>(types), "Id", "Name");

            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComputerViewModel model)
        {
            ModelState.Remove("Historics");
            if (!ModelState.IsValid) return View(model);
            
                await _computer.Add(_mapper.Map<Computer>(model));
                return RedirectToAction(nameof(Index));
            
           
        }
        [HttpGet]
        // GET: Maintenance/Computers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var types = await _equipType.GetAll();
            var brands = await _brand.GetAll();
            var locacities = await _locacity.GetAll();
            var areas = await _actingArea.GetAll();
            var sectors = await _sector.GetAll();
            ViewBag.AreaId = new SelectList(_mapper.Map<IEnumerable<ActingAreaViewModel>>(areas), "Id", "Name");
            ViewBag.BrandId = new SelectList(_mapper.Map<IEnumerable<BrandViewModel>>(brands), "Id", "Name");
            ViewBag.SectorId = new SelectList(_mapper.Map<IEnumerable<SectorViewModel>>(sectors), "Id", "Name");
            ViewBag.LocacityId = new SelectList(_mapper.Map<IEnumerable<LocacityViewModel>>(locacities), "Id", "Name");
            ViewBag.TypeId = new SelectList(_mapper.Map<IEnumerable<EquipTypeViewModel>>(types), "Id", "Name");
            return View(_mapper.Map<ComputerViewModel>(await _computer.GetById(id)));
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ComputerViewModel model)
        {
            ModelState.Remove("Historics");
            if (!ModelState.IsValid) return View();

            await _computer.Update(_mapper.Map<Computer>(model));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            return View(_mapper.Map<ComputerViewModel>(await _computer.GetById(id)));
        }
        // GET: Maintenance/Computers/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(ComputerViewModel model)
        {
            await _computer.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }

        // POST: Maintenance/Computers/Delete/5


        [HttpGet]
        public async Task<IActionResult> Historics(Guid id)
        {
            var pc =await _computer.GetAllIncludeHistoric(id);
           
            return View(_mapper.Map<IEnumerable<HistoricViewModel>>(pc.Historics));
        }

    }
}
