using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleCondominal.Database;
using ControleCondominal.Models;

namespace ControleCondominal.Controllers
{
    public class MoradorsController : Controller
    {
        private readonly DatabaseContext _context;

        public MoradorsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Moradors.Include(f => f.Familia).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Moradors
                .Include(f => f.Familia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        public IActionResult Create()
        {
            var fams = _context.Familias.ToList();
            var list = new List<SelectListItem>();
            foreach (var item in fams)
                list.Add(new SelectListItem(item.Nome, item.Id.ToString()));
            
            ViewBag.familias = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,QtdPets,Familia")] string Nome, int QtdPets, int Familia)
        {
            var morador = new Morador()
                {
                    Nome = Nome,
                    QtdPets = QtdPets,
                    Familia = _context.Familias.FirstOrDefault(f => f.Id == Familia)
                };

            if (ModelState.IsValid)
            {
                _context.Add(morador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(morador);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Moradors.Include(f => f.Familia)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            var fams = _context.Familias.ToList();
            var list = new List<SelectListItem>();
            foreach (var item in fams)
                list.Add(new SelectListItem(item.Nome, item.Id.ToString(), item.Id == morador.Familia.Id));

            ViewBag.familias = list;
            return View(morador);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,QtdPets, Familia")] string Nome, int QtdPets, int Familia)
        {
            var morador = new Morador()
            {
                Id = id,
                Nome = Nome,
                QtdPets = QtdPets,
                Familia = _context.Familias.FirstOrDefault(f => f.Id == Familia)
            };
            if (id != morador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(morador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorExists(morador.Id))
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
            return View(morador);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = await _context.Moradors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (morador == null)
            {
                return NotFound();
            }

            return View(morador);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var morador = await _context.Moradors.FindAsync(id);
            _context.Moradors.Remove(morador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoradorExists(int id)
        {
            return _context.Moradors.Any(e => e.Id == id);
        }
    }
}
