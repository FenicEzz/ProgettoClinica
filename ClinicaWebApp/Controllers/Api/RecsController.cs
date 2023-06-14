using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using ServicesLayer.Interfaces;


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


        [HttpGet("petmicrochip/{microchipNumber}")]
        public async Task<IActionResult> GetPetByMicrochipNumber(int microchipNumber)
        {
            var pet = await _context.Pets.SingleAsync(x => x.MicrochipNumber == microchipNumber);

            if (pet != null)
            {
                return Ok(pet);
            }

            return BadRequest("Non esiste un animale con questo numero");
        }
    }
}
