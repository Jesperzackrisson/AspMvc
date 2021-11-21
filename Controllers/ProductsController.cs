using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMvc.Helper;
using ProjectMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ProjectMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: ProductsController
        ProductApi _api = new ProductApi();
        public async Task<ActionResult> Index()
        {
            List<Product> products = new List<Product>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/products");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(results);
            }
            return View(products);
            //var http = new HttpClient();
            //var products = await http.GetFromJsonAsync<List<Product>>("http://localhost:41649/api/Products");
            //return View(products);


        }





        // GET: ProductsController/Details/5
        public async Task<IActionResult> Details(int Id)
        {

            var product = new Product();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/products/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<Product>(result);
            }
            return View(product);

        }










        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }





        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            HttpClient client = _api.Initial();

            var postProduct = client.PostAsJsonAsync<Product>("api/products", product);
            postProduct.Wait();

            var result = postProduct.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }




        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
