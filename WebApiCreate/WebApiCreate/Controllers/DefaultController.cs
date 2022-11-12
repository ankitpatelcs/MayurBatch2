using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApiCreate.EDM;

namespace WebApiCreate.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public async Task<ActionResult> Index()
        {
            List<tblemployee> li = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389/");
                var response = await client.GetAsync("api/Emp");
                if (response.IsSuccessStatusCode)
                {
                    li = await response.Content.ReadAsAsync<List<tblemployee>>();
                }
            }
            return View(li);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(tblemployee obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389/");
                var response = await client.PostAsJsonAsync<tblemployee>($"api/emp", obj);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error.!");
            return View();
        }
        public async Task<ActionResult> Edit(int id)
        {
            tblemployee li = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389/");
                var response = await client.GetAsync($"api/emp/{id}");
                if (response.IsSuccessStatusCode)
                {
                    li = await response.Content.ReadAsAsync<tblemployee>();
                }
            }
            return View(li);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(tblemployee obj)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389/");
                var response = await client.PutAsJsonAsync<tblemployee>($"api/emp/{obj.emp_id}", obj);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error.!");
            return View();
        }

        public async Task<ActionResult> Delete(int id)
        {
            tblemployee li = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389/");
                var response = await client.GetAsync($"api/emp/{id}");
                if (response.IsSuccessStatusCode)
                {
                    li = await response.Content.ReadAsAsync<tblemployee>();
                }
            }
            return View(li);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteRec(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44389/");
                var response = await client.DeleteAsync($"api/emp/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error.!");
            return View();
        }
    }
}