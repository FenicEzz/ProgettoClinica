using ClinicaWebApp.Models;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.Entities;
using ServicesLayer.Interfaces;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ClinicaWebApp.Controllers
{
    public class AcceptancesController : Controller
    {
        private readonly ClinicaDbContext _context;
        private readonly IPetService _petService;
        private readonly IAcceptanceService _acceptanceService;
        private readonly IRecoveryService _recoveryService;
        private readonly IExaminationService _examinationService;

        public AcceptancesController(ClinicaDbContext context, IPetService petService, IAcceptanceService acceptanceService, IRecoveryService recoveryService, IExaminationService examinationService)
        {
            _context = context;
            _petService = petService;
            _acceptanceService = acceptanceService;
            _recoveryService = recoveryService;
            _examinationService = examinationService;
        }

        public async Task<IActionResult> Details(long id)
        {
            var pet = await _petService.GetPetById(id);

            return View(pet);
        }


        public async Task<IActionResult> Index()
        {
            var view = await _context.Acceptances.Include(m => m.Pet).ToListAsync();

            return View(view);
        }


        public async Task<IActionResult> Delete(int id)
        {
            await _acceptanceService.DeleteAcceptance(id);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Accettazione(long id)
        {
            var pet = await _context.Pets.Where(x => x.Id == id).Include(x => x.Examinations).SingleAsync();

            return View(pet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accettazione(long id, IFormCollection collection)
        {
            try
            {
                var pet = await _petService.GetPetById(id);

                var acc = new Acceptance
                {
                    Pet = pet
                };

                await _acceptanceService.AddAcceptance(acc);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<IActionResult> Examination(long id)
        {
            var pet = await _petService.GetPetById(id);

            var model = new ExaminationViewModel { PetId = pet.Id };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Examination(ExaminationViewModel exam)
        {

            if (ModelState.IsValid)
            {
                var pet = await _petService.GetPetById(exam.PetId);
                var acc = await _context.Acceptances.Where(x => x.Pet.Id == exam.PetId).SingleAsync();

                var visit = new Examination
                {
                    Treatment = exam.Treatment,
                    Disease = exam.Disease,
                    ExaminationDate = exam.ExamDate,
                    Pet = pet
                };

                await _examinationService.AddExam(visit);
                await _acceptanceService.DeleteAcceptance(acc.Id);

                return RedirectToAction(nameof(Index));
            }

            return View(exam);
        }
    }
}
