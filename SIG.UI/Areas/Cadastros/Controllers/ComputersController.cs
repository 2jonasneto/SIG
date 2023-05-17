using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SIG.Core.Domain;
using SIG.Core.Domain.Interfaces;
using SIG.Data;
using SIG.Services;
using SIG.UI.Base;

namespace SIG.UI.Areas.Cadastros.Controllers
{
    //  [Route("Home/"+Program.guid)]
    [Area("Cadastros")]
    public class ComputersController : Controller
    {
        private readonly IComputerRepository _computerRepository;
        private readonly IMapper _mapper;
        public ComputersController(IComputerRepository computerRepository, IMapper mapper)
        {
            _computerRepository = computerRepository;
            _mapper = mapper;
        }

        // GET: Computers
        [Route("computers")]
        public async Task<IActionResult> Index()
        {
            // return View(_mapper.Map<IEnumerable<ComputerViewModel>>(await _computerRepository.GetAll()));
            return View(new List<ComputerViewModel>());
        }

        // GET: Computers/Details/5
        [Route(GuidRoutes.Details)]

        public async Task<IActionResult> Details(Guid id)
        {
            var computerViewModel = await GetComputer(id);
            if (computerViewModel == null) return NotFound();

            return View(computerViewModel);
        }

        // GET: Computers/Create
        [Route("~/computers/create")]
        [Route(GuidRoutes.Create)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Computers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ComputerViewModel computerViewModel)
        {
            if (!ModelState.IsValid) return View(computerViewModel);

            var computer = _mapper.Map<Computer>(computerViewModel);
            await _computerRepository.Add(computer);
            return RedirectToAction("Index");
        }

        // GET: Computers/Edit/5
        [Route(GuidRoutes.Edit)]
        public async Task<IActionResult> Edit(Guid id)
        {
            var computerViewModel = await GetComputer(id);
            if (computerViewModel == null) return NotFound();

            return View(computerViewModel);


        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ComputerViewModel computerViewModel)
        {
            if (id != computerViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(computerViewModel);

            var computer = _mapper.Map<Computer>(computerViewModel);
            await _computerRepository.Update(computer);
            return RedirectToAction("Index");
        }

        // GET: Computers/Delete/5
        [Route(GuidRoutes.Delete)]

        public async Task<IActionResult> Delete(Guid id)
        {
            var computerViewModel = await GetComputer(id);
            if (computerViewModel == null) return NotFound();

            return View(computerViewModel);

        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var computerViewModel = await GetComputer(id);
            if (computerViewModel == null) return NotFound();

            await _computerRepository.Remove(id);
            return RedirectToAction("index");
        }


        private async Task<ComputerViewModel> GetComputer(Guid id)
        {
            return _mapper.Map<ComputerViewModel>(await _computerRepository.GetById(id));
        }
    }
}
