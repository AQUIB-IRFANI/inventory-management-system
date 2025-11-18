using Microsoft.AspNetCore.Mvc;
using InventoryManagementSystem.DAL;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        ProductDAL dal = new ProductDAL();

        public IActionResult Index()
        {
            List<Product> products = dal.GetAllProducts();
            return View(products);
        }
        // GET: Create Product
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create Product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                bool result = dal.InsertProduct(product);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }
        // GET: /Product/Edit/5
        public IActionResult Edit(int id)
        {
            var product = dal.GetAllProducts().FirstOrDefault(p => p.ProductID == id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: /Product/Edit
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                bool result = dal.UpdateProduct(product);
                if (result)
                    return RedirectToAction("Index");
            }

            return View(product);
        }
        // GET: /Product/Delete/5
        public IActionResult Delete(int id)
        {
            bool result = dal.DeleteProduct(id);
            return RedirectToAction("Index");
        }


    }
}
