using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendas = await _context.Venda.ToListAsync();

            // Pré-carregar os clientes e produtos em um dicionário para facilitar o acesso na view
            var clientes = await _context.Cliente.ToDictionaryAsync(c => c.IdCliente, c => c.NmCliente);
            
            var produtos = await _context.Produto.ToDictionaryAsync(p => p.IdProduto, p => p.DscProduto);

            ViewBag.Clientes = clientes;
            ViewBag.Produtos = produtos;

            return View(vendas);
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }
            
            // Pré-carregar os clientes e produtos em um dicionário para facilitar o acesso na view
            var clientes = await _context.Cliente.ToDictionaryAsync(c => c.IdCliente, c => c.NmCliente);

            var produtos = await _context.Produto.ToDictionaryAsync(p => p.IdProduto, p => p.DscProduto);

            ViewBag.Clientes = clientes;
            ViewBag.Produtos = produtos;

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Cliente, "IdCliente", "NmCliente", "");
            ViewBag.Produtos = new SelectList(_context.Produto, "IdProduto", "DscProduto", "");
            return View();
        }

        // POST: Vendas/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVenda,IdCliente,IdProduto,QtdVenda,VlrUnitarioVenda,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(venda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }            
            ViewBag.Clientes = new SelectList(_context.Cliente, "IdCliente", "NmCliente", venda.IdCliente);
            ViewBag.Produtos = new SelectList(_context.Produto, "IdProduto", "DscProduto", venda.IdProduto);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }
            
            ViewBag.Clientes = new SelectList(_context.Cliente, "IdCliente", "NmCliente", venda.IdCliente);
            ViewBag.Produtos = new SelectList(_context.Produto, "IdProduto", "DscProduto", venda.IdProduto);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVenda,IdCliente,IdProduto,QtdVenda,VlrUnitarioVenda,DthVenda,VlrTotalVenda")] Venda venda)
        {
            if (id != venda.IdVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.IdVenda))
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
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var venda = await _context.Venda
                .FirstOrDefaultAsync(m => m.IdVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Venda.FindAsync(id);
            if (venda != null)
            {
                _context.Venda.Remove(venda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Venda.Any(e => e.IdVenda == id);
        }

        [HttpGet]
        public IActionResult ObterValorUnitario(int productId)
        {
            var produto = _context.Produto.FirstOrDefault(p => p.IdProduto == productId);
            if (produto != null)
            {
                return Json(new { valorUnitario = produto.VlrUnitario });
            }
            else
            {
                return Json(new { valorUnitario = 0 }); // ou outro valor padrão caso não encontre o produto
            }
        }
    }
}
