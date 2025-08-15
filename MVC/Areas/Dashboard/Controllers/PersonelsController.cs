using AutoMapper;
using BLL.DTOs;
using BLL.Services.Abstracts;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Areas.Dashboard.Controllers;
using MVC.Areas.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class PersonelsController : Controller
    {
        private readonly IPersonelService _personelService;
        private readonly IGorevYeriService _gorevYeriService;
        private readonly IMapper _mapper;

        public PersonelsController(IPersonelService personelService, IGorevYeriService gorevYeriService, IMapper mapper)
        {
            _personelService = personelService;
            _gorevYeriService = gorevYeriService;
            _mapper = mapper;
        }

        // GET: Dashboard/Personels
        public async Task<IActionResult> Index()
        {
            var result = await _personelService.GetAllAsync();
            if (!result.Success)
            {
                TempData["Error"] = result.StatusMessage;
                return View(Enumerable.Empty<PersonelVM>());
            }

            var vmList = _mapper.Map<IEnumerable<PersonelVM>>(result.Data);
            return View(vmList);
        }

        // GET: Dashboard/Personels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _personelService.GetByIdAsync(id);
            if (!result.Success)
            {
                TempData["Error"] = result.StatusMessage;
                return RedirectToAction(nameof(Index));
            }

            var vm = _mapper.Map<PersonelVM>(result.Data);
            return View(vm);
        }

        // GET: Dashboard/Personels/Create
        public async Task<IActionResult> Create()
        {
            await LoadGorevYeriList();
            return View();
        }

        // POST: Dashboard/Personels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonelVM vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadGorevYeriList();
                return View(vm);
            }

            var dto = _mapper.Map<PersonelDTO>(vm);
            var result = await _personelService.CreateAsync(dto);

            if (!result.Success)
            {
                TempData["Error"] = result.StatusMessage;
                await LoadGorevYeriList();
                return View(vm);
            }

            TempData["Success"] = result.StatusMessage;
            return RedirectToAction(nameof(Index));
        }

        // GET: Dashboard/Personels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _personelService.GetByIdAsync(id);
            if (!result.Success)
            {
                TempData["Error"] = result.StatusMessage;
                return RedirectToAction(nameof(Index));
            }

            var vm = _mapper.Map<PersonelVM>(result.Data);
            await LoadGorevYeriList(vm.GorevYeriId);
            return View(vm);
        }

        // POST: Dashboard/Personels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PersonelVM vm)
        {
            if (!ModelState.IsValid)
            {
                await LoadGorevYeriList(vm.GorevYeriId);
                return View(vm);
            }

            var dto = _mapper.Map<PersonelDTO>(vm);
            var result = await _personelService.UpdateAsync(dto.Id, dto);

            if (!result.Success)
            {
                TempData["Error"] = result.StatusMessage;
                await LoadGorevYeriList(vm.GorevYeriId);
                return View(vm);
            }

            TempData["Success"] = result.StatusMessage;
            return RedirectToAction(nameof(Index));
        }

        // GET: Dashboard/Personels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _personelService.GetByIdAsync(id);
            if (!result.Success)
            {
                TempData["Error"] = result.StatusMessage;
                return RedirectToAction(nameof(Index));
            }

            var vm = _mapper.Map<PersonelVM>(result.Data);
            return View(vm);
        }

        // POST: Dashboard/Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _personelService.DeleteAsync(id);
            TempData[result.Success ? "Success" : "Error"] = result.StatusMessage;
            return RedirectToAction(nameof(Index));
        }

        private async Task LoadGorevYeriList(int? selectedId = null)
        {
            var gorevYerleri = await _gorevYeriService.GetAllAsync();
            ViewData["GorevYeriId"] = new SelectList(gorevYerleri.Data, "Id", "Ad", selectedId);
        }
    }
}
