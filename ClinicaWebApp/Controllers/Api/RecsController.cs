using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ServicesLayer.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClinicaWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecsController : ControllerBase
    {
        private readonly ClinicaDbContext _context;
        private readonly IPetService _petService;
        private readonly IAcceptanceService _acceptanceService;
        private readonly IRecoveryService _recoveryService;
        private readonly IExaminationService _examinationService;

        public RecsController(ClinicaDbContext context, IPetService petService, IAcceptanceService acceptanceService, IRecoveryService recoveryService, IExaminationService examinationService)
        {
            _context = context;
            _petService = petService;
            _acceptanceService = acceptanceService;
            _recoveryService = recoveryService;
            _examinationService = examinationService;
        }


        [HttpGet("allrecs")]
        public async Task<IActionResult> GetAllRecs()
        {
            var recs = await _recoveryService.GetAll();

            return Ok(recs);
        }

        [HttpGet("allpets")]
        public async Task<IActionResult> GetAllPets()
        {
            var pets = await _petService.GetAll();

            return Ok(pets);
        }
    }
}
