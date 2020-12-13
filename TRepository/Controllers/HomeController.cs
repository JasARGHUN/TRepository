using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TRepository.Models;
using TRepository.Models.Repositories.IRepositories;
using TRepository.Models.ViewModels;

namespace TRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _repository;

        public HomeController(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _repository.Item.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                var item = new Item
                {
                    Name = model.Name,
                    Description = model.Description
                };

                await _repository.Item.AddAsync(item);
                await _repository.SaveAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public async Task<ViewResult> Details(int? id)
        {
            var model = await _repository.Item.GetFirstOrDefaultAsync(x => x.Id == id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _repository.Item.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            var item = new ItemUpdateViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ItemUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var item = await _repository.Item.GetAsync(model.Id);

                item.Name = model.Name;
                item.Description = model.Description;

                await _repository.Item.UpdateAsync(item);

                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _repository.Item.GetAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            _repository.Item.Remove(model);

            await _repository.SaveAsync();

            return RedirectToAction("Index");
        }
    }
}
