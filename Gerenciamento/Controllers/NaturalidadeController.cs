using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gerenciamento.Data;
using Gerenciamento.Models;
using Gerenciamento.Utils.Response;

namespace Gerenciamento.Controllers
{
    public class NaturalidadeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NaturalidadeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Naturalidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Naturalidade.ToListAsync());
        }

        // GET: Naturalidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturalidade = await _context.Naturalidade
                .FirstOrDefaultAsync(m => m.id == id);
            if (naturalidade == null)
            {
                return NotFound();
            }

            return View(naturalidade);
        }

        // GET: Naturalidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Naturalidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Descricao,DataCriacao")] Naturalidade naturalidade)
        {
            if (ModelState.IsValid)
            {
                naturalidade.DataCriacao = DateTime.Now;
                _context.Add(naturalidade);
                await _context.SaveChangesAsync();
                Naturalidade.NumeroDeNaturalidades++;
                return RedirectToAction(nameof(Index));
            }
            return View(naturalidade);
        }

        // GET: Naturalidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturalidade = await _context.Naturalidade.FindAsync(id);
            if (naturalidade == null)
            {
                return NotFound();
            }
            return View(naturalidade);
        }

        // POST: Naturalidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Descricao,DataCriacao")] Naturalidade naturalidade)
        {
            if (id != naturalidade.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(naturalidade);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NaturalidadeExists(naturalidade.id))
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
            return View(naturalidade);
        }

        // GET: Naturalidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var naturalidade = await _context.Naturalidade
                .FirstOrDefaultAsync(m => m.id == id);
            if (naturalidade == null)
            {
                return NotFound();
            }

            return View(naturalidade);
        }

        // POST: Naturalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var naturalidade = await _context.Naturalidade.FindAsync(id);
            var peixe = await _context.Peixe.FirstOrDefaultAsync(p => p.NaturalidadeId == id);

            if (peixe == null)
            {
                _context.Naturalidade.Remove(naturalidade);
                await _context.SaveChangesAsync();
                Naturalidade.NumeroDeNaturalidades--;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return Json(ResponseObject.ErrorResponse(message: "Um peixe é desta Naturalidade: " + naturalidade.Descricao));
            }

  
        }


        private bool NaturalidadeExists(int id)
        {
            return _context.Naturalidade.Any(e => e.id == id);
        }
    }
}
