using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyectoABMC.Database;
using proyectoABMC.Models;

namespace proyectoABMC.Controllers
{
    public class TelefonosController : Controller
    {
        private readonly ProyectoAbmcDbContext _context;

        public TelefonosController(ProyectoAbmcDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            if (id != 0)
            {
                return View(nameof(Index),_context.Telefonos.Where(P => P.PersonaID.Equals(id)).ToList());
            }
            return View(_context.Telefonos.ToList());
        }

        public IActionResult Create(int id)
        {
            ViewData["PersonaId"] = new SelectList(_context.Personas.Where(P => P.PersonaId.Equals(id)), "PersonaId", "Nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefono);
                _context.SaveChanges();
                return Index(id:telefono.PersonaID);
            }
            ViewData["PersonaID"] = new SelectList(_context.Personas, "PersonaId", "Nombre", telefono.PersonaID);
            return View(telefono);
        }

        public IActionResult Edit(int? id)
        {
            ViewData["PersonaId"] = new SelectList(_context.Personas, "PersonaId", "Nombre");
            if (id == null)
            {
                return NotFound();
            }

            var telefono = _context.Telefonos.Find(id);
            if (telefono == null)
            {
                return NotFound();
            }
            return View(telefono);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Telefono telefono)
        {
            if (id != telefono.TelefonoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefono);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonoExists(telefono.TelefonoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonaID"] = new SelectList(_context.Personas, "PersonaId", "Nombre", telefono.PersonaID);
            return View(telefono);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefono = _context.Telefonos
                .FirstOrDefault(m => m.TelefonoId == id);
            if (telefono == null)
            {
                return NotFound();
            }

            return View(telefono);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var telefono = _context.Telefonos.Find(id);
            _context.Telefonos.Remove(telefono);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool TelefonoExists(int id)
        {
            return _context.Telefonos.Any(e => e.TelefonoId == id);
        }
    }
}
