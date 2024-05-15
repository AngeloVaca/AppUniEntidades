﻿using AppUni.ConsumeAPI;
using AppUni.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppUni.WEB.MVC.Controllers
{
    public class CarrerasController : Controller
    {
        private readonly string urlApi;
        public CarrerasController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/Carreras";
        }
        // GET: CarrerasController
        public ActionResult Index()
        {
            var data = Crud<Carrera>.Read(urlApi);
            return View(data);
        }

        // GET: CarrerasController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Carrera>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: CarrerasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarrerasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Carrera data)
        {
            try
            {
                var newData = Crud<Carrera>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: CarrerasController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Carrera>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: CarrerasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Carrera data)
        {
            try
            {
                Crud<Carrera>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: CarrerasController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Carrera>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: CarrerasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Carrera data)
        {
            try
            {
                Crud<Carrera>.Delete(urlApi, id);
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
