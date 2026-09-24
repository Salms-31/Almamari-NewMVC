using Microsoft.AspNetCore.Mvc;
using Almamari_NewMVC.Data;
using Almamari_NewMVC.Models;

namespace Almamari_NewMVC.Controllers

{

    public class ProductsController : Controller

    {

        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db) { _db = db; }

        // shows the list
        public IActionResult Index()

        {
            var products = _db.Products.ToList();
            return View(products);
        }

        // shows the empty add-form
        public IActionResult Create()

        {
            return View();
        }

        // saves a new product
        [HttpPost]

        public IActionResult Create(Product product)

        {
            _db.Products.Add(product);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }

}