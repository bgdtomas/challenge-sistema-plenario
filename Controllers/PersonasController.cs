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
    public class PersonasController : Controller
    {
        private readonly ProyectoAbmcDbContext _context;

        public PersonasController(ProyectoAbmcDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? nombre)
        {
            if (nombre != null)
            {
                return View(nameof(Index), _context.Personas.Where(P => P.Nombre.Equals(nombre)).ToList());
            }
            return View(_context.Personas.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = _context.Personas
                .FirstOrDefault(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PersonaId,Nombre,FechaNacimiento,CreditoMaximo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(persona);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(persona);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = _context.Personas.Find(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("PersonaId,Nombre,FechaNacimiento,CreditoMaximo")] Persona persona)
        {
            if (id != persona.PersonaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonaExists(persona.PersonaId))
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
            return View(persona);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var persona = _context.Personas
                .FirstOrDefault(m => m.PersonaId == id);
            if (persona == null)
            {
                return NotFound();
            }

            return View(persona);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var persona = _context.Personas.Find(id);
            _context.Personas.Remove(persona);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.PersonaId == id);
        }
    }
}
