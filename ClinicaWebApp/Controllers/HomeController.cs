using ClinicaWebApp.Models;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Interfaces;
using System.Diagnostics;

namespace ClinicaWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClinicaDbContext _context;
        private readonly IPetService _petService;
        private readonly IAcceptanceService _acceptanceService;
        private readonly IRecoveryService _recoveryService;
        private readonly IExaminationService _examinationService;

        public HomeController(ILogger<HomeController> logger, ClinicaDbContext ctx, IPetService ptsrvc, IAcceptanceService acceptanceService, IRecoveryService recoveryService, IExaminationService examinationService)
        {
            _logger = logger;
            _context = ctx;
            _petService = ptsrvc;
            _acceptanceService = acceptanceService;
            _recoveryService = recoveryService;
            _examinationService = examinationService;
        }


        public async Task<IActionResult> Cerca()
        {
            var model = await _petService.GetAll();

            return View(model);
        }


        public async Task<IActionResult> Index()
        {
            var pets = await _petService.GetAll();

            return View(pets);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pet = new Pet
                {
                    RegisterDate = DateTime.Now,
                    Name = model.Name,
                    Race = model.Race,
                    FurColor = model.FurColor,
                    Birthdate = model.Birthdate,
                    HasMicrochip = model.HasMicrochip,
                    MicrochipNumber = model.MicrochipNumber,
                    CustomerFirstname = model.CustomerFirstname,
                    CustomerLastname = model.CustomerLastname,
                };

                await _petService.AddPet(pet);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }


        public async Task<IActionResult> Delete(long id)
        {
            await _petService.DeletePet(id);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Accettazione(long id)
        {
            var pet = await _petService.GetPetById(id);
            var examPet = _context.Examinations.Where(x => x.Pet.Id == pet.Id).Include(pet => pet.Id).ToList();

            var view = new AcceptanceViewModel
            {
                Pet = pet,
                Examinations = examPet
            }; 

            return View(view);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accettazione(long id, [Bind("Id")] AcceptanceViewModel acceptance)
        {

            if (ModelState.IsValid)
            {
                var acc = new Acceptance
                {
                    Pet = acceptance.Pet
                };

                await _acceptanceService.AddAcceptance(acc);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(acceptance);
        }


        public async Task<IActionResult> Details(long id)
        {
            var exam = await _examinationService.GetExamById(id);

            return View(exam);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}