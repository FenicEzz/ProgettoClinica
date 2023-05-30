using ClinicaWebApp.Models;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Interfaces;

namespace ClinicaWebApp.Controllers
{
    public class RecoveriesController : Controller
    {

        private readonly IPetService _petService;
        private readonly ClinicaDbContext _context;
        private readonly IAcceptanceService _acceptanceService;
        private readonly IRecoveryService _recoveryService;
        private readonly IExaminationService _examinationService;


        public RecoveriesController(IPetService srvc, ClinicaDbContext ctx, IAcceptanceService acceptanceService, IRecoveryService recoveryService, IExaminationService examinationService)
        {
            _petService = srvc;
            _context = ctx;
            _acceptanceService = acceptanceService;
            _recoveryService = recoveryService;
            _examinationService = examinationService;
        }


        public async Task<IActionResult> Index()
        {
            var model = await _context.Recoveries.Include(x => x.Pet).ToListAsync();
            ViewBag.Count = model.Count;
            return View(model);
        }


        public ActionResult Details(int id)
        {
            return View();
        }


        public async Task<IActionResult> Recovery(long id)
        {
            var pet = await _petService.GetPetById(id);
            var model = new RecoveryViewModel
            {
                PetId = pet.Id
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Recovery(RecoveryViewModel recovery)
        {
            if (ModelState.IsValid)
            {
                var acc = await _context.Acceptances.Where(x => x.Pet.Id == recovery.PetId).SingleAsync();

                var reco = new Recovery
                {
                    RecoveryDate = recovery.RecoveryDate,
                    UrlPetPicture = recovery.UrlPicture,
                    Pet = await _petService.GetPetById(recovery.PetId)
                };

                await _recoveryService.AddRecovery(reco);
                await _acceptanceService.DeleteAcceptance(acc.Id);

                return RedirectToAction(nameof(Index));
            }

            return View(recovery);
        }


        public async Task<IActionResult> Dimetti(long id)
        {
            var recovery = await _recoveryService.GetById(id);
            await _recoveryService.DeleteRecovery(recovery.Id);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Dettagli(long id)
        {
            var recovery = await _context.Recoveries.Include(x => x.Pet).SingleAsync(x => x.Id == id);

            return View(recovery);
        }
    }
}
