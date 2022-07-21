using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal_RodrigoPaulino.Data;
using ProjetoFinal_RodrigoPaulino.Models;
using ProjetoFinal_RodrigoPaulino.Repositorio;

namespace ProjetoFinal_RodrigoPaulino.Controllers
{

   /// <summary>
   /// controller para 
   /// </summary>
    public class LojasModelsController : Controller
    {

        /// <summary>
        /// variavel somente para leitura 
        /// </summary>
        private readonly BancoContext _context;

        /// <summary>
        /// para gravar precisamos injetar o BancoContext aqui 
        /// criamos tambem uma variavel privada para usarmos nessa classe
        /// fazendo a injeção de dependencia
        /// </summary>
        public LojasModelsController(BancoContext context)
        {
            _context = context;
        }

        // GET: LojasModels
        public async Task<IActionResult> Index()
        {
            return _context.Lojas != null ?
                        View(await _context.Lojas.ToListAsync()) :
                        Problem("Erro ao efetuar o cadastro, tente novamente mais tarde");
            //Entity set 'BancoContext.Lojas' is null.
        }

        // GET: LojasModels/Details/5
        /// <summary>
        /// método que exibe os detalhes da loja
        /// pegando o id como parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(int? id)
        {
            //condição onde se a id ou o banco forem nulos
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }
            //retornamos uma busca pelo primeiro
            //ou unico registro do banco passando uma
            //expressao lambda

            var lojasModel = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lojasModel == null)
            {
                return NotFound();
            }

            return View(lojasModel);
        }

        // GET: LojasModels/Create
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// método que apaga de fato do banco de dados
        /// usando o id como parametro de entrada
        /// </summary>      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Localizacao,Seguimento,Telefone")] LojasModel lojasModel)
        {
            lojasModel.Nome = lojasModel.Nome.ToUpper();
            _context.Add(lojasModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

        // GET: LojasModels/Edit/5
        /// <summary>
        /// método para iditar uma loja no banco
        /// pegando o id como parametro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            //Se uma entidade com os valores de chave primária existentes existir no contexto,
            //ela será retornada imediatamente sem fazer uma solicitação para o repositório.
            var lojasModel = await _context.Lojas.FindAsync(id);
            if (lojasModel == null)
            {
                return NotFound();
            }
            return View(lojasModel);
        }

       /// <summary>
       /// método de edicao de uma loja para o banco de dados
       /// </summary>
       /// <param name="id"></param>
       /// <param name="lojasModel"></param>
       /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Localizacao,Seguimento,Telefone")] LojasModel lojasModel)
        {
            if (id != lojasModel.Id)
            {
                return NotFound();
            }
            //criando condição : se o valor da modelstate diferente de  valida o if ira passar os comandos de cadastro

            if (!ModelState.IsValid)
            {
                //o programa tenta fazer o update no banco e salvar as mudanças
                try
                {
                    
                    _context.Update(lojasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LojasModelExists(lojasModel.Id))
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
            return View(lojasModel);
        }



        // GET: LojasModels/Delete/5

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lojas == null)
            {
                return NotFound();
            }

            var lojasModel = await _context.Lojas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lojasModel == null)
            {
                return NotFound();
            }

            return View(lojasModel);
        }

        // POST: LojasModels/Delete/5
        /// <summary>
        /// método para confirmação de deleção
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lojas == null)
            {
                return Problem("Erro ao apagar as informações, tente novamente mais tarde");
            }
            var lojasModel = await _context.Lojas.FindAsync(id);
            if (lojasModel != null)
            {
                _context.Lojas.Remove(lojasModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LojasModelExists(int id)
        {
          return (_context.Lojas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
