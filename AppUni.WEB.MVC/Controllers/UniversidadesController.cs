using AppUni.ConsumeAPI;
using AppUni.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppUni.WEB.MVC.Controllers
{
    public class UniversidadesController : Controller
    {
        private readonly string urlApi;
        public UniversidadesController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Universidades";
        }
        // GET: UniversidadesController
        public ActionResult Index()
        {
            var data = Crud<Universidad>.Read(urlApi);
            return View(data);
        }

        // GET: UniversidadesController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Universidad>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: UniversidadesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniversidadesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Universidad data)
        {
            try
            {
                var newData = Crud<Universidad>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: UniversidadesController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Universidad>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: UniversidadesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Universidad data)
        {
            try
            {
                Crud<Universidad>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: UniversidadesController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Universidad>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: UniversidadesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Universidad data)
        {
            try
            {
                Crud<Universidad>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
