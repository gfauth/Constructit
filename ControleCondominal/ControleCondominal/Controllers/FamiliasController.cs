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
    public class FamiliasController : Controller
    {
        private readonly DatabaseContext _context;

        public FamiliasController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Familias.Include(f => f.Condominio).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familias
                .Include(c => c.Condominio)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familia == null)
            {
                return NotFound();
            }

            return View(familia);
        }

        public IActionResult Create()
        {
            var conds = _context.Condominios.ToList();
            var list = new List<SelectListItem>();
            foreach (var item in conds)
                list.Add(new SelectListItem(item.Nome, item.Id.ToString()));

            ViewBag.condominios = list;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Apartamento,Condominio")] string Nome, int Apartamento, int Condominio)
        { 
            var familia = new Familia()
            {
                Nome = Nome,
                Apartamento = Apartamento,
                Condominio = _context.Condominios.FirstOrDefault(c => c.Id == Condominio)
            };

            if (ModelState.IsValid)
            {
                _context.Add(familia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(familia);
        }

        // GET: Familias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familias
                .Include(c => c.Condominio)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (familia == null)
            {
                return NotFound();
            }

            var conds = _context.Condominios.ToList();
            var list = new List<SelectListItem>();
            foreach (var item in conds)
                list.Add(new SelectListItem(item.Nome, item.Id.ToString()));

            ViewBag.condominios = list;
            return View(familia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Apartamento,Condominio")] string Nome, int Apartamento, int Condominio)
        {
            var familia = new Familia()
            {
                Id = id,
                Nome = Nome,
                Apartamento = Apartamento,
                Condominio = _context.Condominios.FirstOrDefault(c => c.Id == Condominio)
            };

            if (id != familia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(familia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamiliaExists(familia.Id))
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
            return View(familia);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var familia = await _context.Familias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (familia == null)
            {
                return NotFound();
            }

            var conds = _context.Condominios.ToList();
            ViewData.Add("condominios", conds);
            return View(familia);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var familia = await _context.Familias.FindAsync(id);
            _context.Familias.Remove(familia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FamiliaExists(int id)
        {
            return _context.Familias.Any(e => e.Id == id);
        }
    }
}
