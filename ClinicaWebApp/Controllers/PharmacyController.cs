using ClinicaWebApp.Models;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicesLayer.Interfaces;

namespace ClinicaWebApp.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClinicaDbContext _context;
        private readonly IPetService _petService;
        private readonly IAcceptanceService _acceptanceService;
        private readonly IRecoveryService _recoveryService;
        private readonly IExaminationService _examinationService;

        public PharmacyController(ILogger<HomeController> logger, ClinicaDbContext context, IPetService petService, IAcceptanceService acceptanceService, IRecoveryService recoveryService, IExaminationService examinationService)
        {
            _logger = logger;
            _context = context;
            _petService = petService;
            _acceptanceService = acceptanceService;
            _recoveryService = recoveryService;
            _examinationService = examinationService;
        }


        public async Task<IActionResult> Index()
        {
            var providers = await _context.Providers.ToListAsync();

            return View(providers);
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Provider provider)
        {
            if (ModelState.IsValid)
            {
                _context.Providers.Add(provider);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(provider);
        }


        public async Task<IActionResult> Delete(long id)
        {
            var provider = await _context.Providers.SingleAsync(x => x.Id == id);
            _context.Providers.Remove(provider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ProductsList(long id)
        {
            var products = await _context.Products.Where(x => x.Provider.Id == id).Include(x => x.Provider).ToListAsync();
            var provider = await _context.Providers.SingleAsync(x => x.Id == id);
            var model = new ProductsProviderViewModel
            {
                Provider = provider,
                Products = products
            };

            return View(model);
        }


        public async Task<IActionResult> AddProduct(long id)
        {
            Provider provider = await _context.Providers.SingleAsync(x => x.Id == id);
            AddProductViewModel model = new AddProductViewModel() { Id = provider.Id };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(AddProductViewModel product)
        {
            if(ModelState.IsValid)
            {
                var prod = new Product
                {
                    Name = product.Name,
                    Type = product.Type,
                    Description = product.Description,
                    Provider = await _context.Providers.SingleAsync(x => x.Id == product.Id)
                };

                _context.Products.Add(prod);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }


        public async Task<IActionResult> ProductDetail(long id)
        {
            var product = await _context.Products.SingleAsync(x => x.Id == id);

            return View(product);
        }


        public async Task<IActionResult> DeleteProduct(long id)
        {
            var prod = await _context.Products.SingleAsync(x => x.Id == id);
            _context.Products.Remove(prod);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
