using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gerenciamento.Data;
using Gerenciamento.Models;

namespace Gerenciamento.Controllers
{
    public class PeixeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeixeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Peixes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Peixe.ToListAsync());
        }

        // GET: Peixes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peixe = await _context.Peixe
                .FirstOrDefaultAsync(m => m.id == id);
            if (peixe == null)
            {
                return NotFound();
            }

            return View(peixe);
        }

        // GET: Peixes/Create
        public IActionResult Create()
        {
            var naturalidades = _context.Naturalidade.ToList();
            ViewBag.nat = naturalidades;
            return View();
        }

        // POST: Peixes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Nome,Ph,Temperatura,TamanhoMin,TamanhoMax,Informacoes,DataCriacao,NaturalidadeId")] Peixe peixe)
        {
            if (ModelState.IsValid)
            {
                peixe.DataCriacao = DateTime.Now;
                _context.Add(peixe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(peixe);
        }

        // GET: Peixes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var naturalidades = _context.Naturalidade.ToList();
            ViewBag.nat = naturalidades;
            if (id == null)
            {
                return NotFound();
            }

            var peixe = await _context.Peixe.FindAsync(id);
            if (peixe == null)
            {
                return NotFound();
            }
            return View(peixe);
        }

        // POST: Peixes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Nome,Ph,Temperatura,TamanhoMin,TamanhoMax,Informacoes,NaturalidadeId")] Peixe peixe)
        {
            if (id != peixe.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(peixe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeixeExists(peixe.id))
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
            return View(peixe);
        }

        // GET: Peixes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var peixe = await _context.Peixe
                .FirstOrDefaultAsync(m => m.id == id);
            if (peixe == null)
            {
                return NotFound();
            }

            return View(peixe);
        }

        // POST: Peixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var peixe = await _context.Peixe.FindAsync(id);
            _context.Peixe.Remove(peixe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeixeExists(int id)
        {
            return _context.Peixe.Any(e => e.id == id);
        }
    }
}
