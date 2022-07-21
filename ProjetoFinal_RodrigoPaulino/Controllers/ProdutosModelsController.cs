using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_RodrigoPaulino.Data;
using ProjetoFinal_RodrigoPaulino.Models;

namespace ProjetoFinal_RodrigoPaulino.Controllers
{
    public class ProdutosModelsController : Controller
    {
        private readonly BancoContext _context;

        public ProdutosModelsController(BancoContext context)
        {
            _context = context;
        }

        // GET: ProdutosModels
        public async Task<IActionResult> Index()
        {
            var bancoContext = _context.Produtos.Include(p => p.Lojas);
            return View(await bancoContext.ToListAsync());
        }

        // GET: ProdutosModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtosModel = await _context.Produtos
                .Include(p => p.Lojas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            return View(produtosModel);
        }

        // GET: ProdutosModels/Create
        public IActionResult Create()
        {
            ViewData["IdLoja"] = new SelectList(_context.Lojas, "Id", "Nome");
            return View();
        }

        // POST: ProdutosModels/Create
        /// <summary>
        /// Quinto passo será criar as actions das paginas de cadastro, ediçao  e deleção 
        /// e a criação das views de cada action
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdLoja,NomeProduto,Tamanho,Cor,Valor")] ProdutosModel produtosModel)
        {
            produtosModel.NomeProduto = produtosModel.NomeProduto.ToUpper();
            _context.Add(produtosModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["IdLoja"] = new SelectList(_context.Lojas, "Id", "Localizacao", produtosModel.IdLoja);
            
        }

        // GET: ProdutosModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtosModel = await _context.Produtos.FindAsync(id);
            if (produtosModel == null)
            {
                return NotFound();
            }
            ViewData["IdLoja"] = new SelectList(_context.Lojas, "Id", "Localizacao", produtosModel.IdLoja);
            return View(produtosModel);
        }

        // POST: ProdutosModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdLoja,NomeProduto,Tamanho,Cor,Valor")] ProdutosModel produtosModel)
        {
            if (id != produtosModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtosModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutosModelExists(produtosModel.Id))
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
            ViewData["IdLoja"] = new SelectList(_context.Lojas, "Id", "Localizacao", produtosModel.IdLoja);
            return View(produtosModel);
        }

        // GET: ProdutosModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Produtos == null)
            {
                return NotFound();
            }

            var produtosModel = await _context.Produtos
                .Include(p => p.Lojas)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produtosModel == null)
            {
                return NotFound();
            }

            return View(produtosModel);
        }

        // POST: ProdutosModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Produtos == null)
            {
                return Problem("Entity set 'BancoContext.Produtos'  is null.");
            }
            var produtosModel = await _context.Produtos.FindAsync(id);
            if (produtosModel != null)
            {
                _context.Produtos.Remove(produtosModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutosModelExists(int id)
        {
          return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        public async Task<IActionResult> ExibirLista()
        {
            List<ProdutosModel> produtos = await _context.Produtos.ToListAsync();
            return View ("Edit", produtos);
        }
    }
}
