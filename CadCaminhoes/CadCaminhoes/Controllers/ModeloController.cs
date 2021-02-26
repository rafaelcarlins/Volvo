using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadCaminhoes.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadCaminhoes.Controllers
{
    public class ModeloController : Controller
    {
        private readonly IModelo _modelo;
 
        public ModeloController(IModelo modelo)
        {
            _modelo = modelo;
        }
        public ActionResult Index()
        {
            return View(_modelo.ObterTodos());
        }

        // GET: ModeloController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ModeloController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ModeloController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ModeloController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ModeloController/Edit/5
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

        // GET: ModeloController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ModeloController/Delete/5
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
