using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Context;
using App.Models;

namespace Pagina.Controllers
{
    public class RegiaoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly string _caminhoPasta;

        public RegiaoController(AppDbContext context, IWebHostEnvironment pastaSite)
        {
            _context = context;
            _caminhoPasta = pastaSite.WebRootPath;
        }

        // GET: Regiao
        public async Task<IActionResult> Index()
        {
              return _context.Regioes != null ? 
                          View(await _context.Regioes.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Regioes'  is null.");
        }

        // GET: Regiao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Regioes == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.IdRegiao == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // GET: Regiao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regiao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Regiao regiao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regiao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regiao);
        }

        // GET: Regiao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Regioes == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao == null)
            {
                return NotFound();
            }
            return View(regiao);
        }

        // POST: Regiao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Regiao regiao, IFormFile fotoDanca, IFormFile fotoCulinaria, IFormFile fotoMusica, IFormFile fotoFestas, IFormFile fotoFolclore, IFormFile fotoArtesanato, IFormFile fotoVestimenta, IFormFile fotoLiteratura, IFormFile fotoTurismo)
        {
            if (id != regiao.IdRegiao)
            {
                return NotFound();
            }

            if (fotoDanca != null){
                string img = SalvarFoto(fotoDanca);
                regiao.ImagemDanca = img;
            }
            if (fotoCulinaria != null){
                string img = SalvarFoto(fotoCulinaria);
                regiao.ImagemCulinaria = img;
            }
            if (fotoMusica != null){
                string img = SalvarFoto(fotoMusica);
                regiao.ImagemMusica = img;
            }
            if (fotoFestas != null){
                string img = SalvarFoto(fotoFestas);
                regiao.ImagemFestas = img;
            }
            if (fotoFolclore != null){
                string img = SalvarFoto(fotoFolclore);
                regiao.ImagemFolclore = img;
            }
            if (fotoArtesanato != null){
                string img = SalvarFoto(fotoArtesanato);
                regiao.ImagemArtesanato = img;
            }
            if (fotoVestimenta != null){
                string img = SalvarFoto(fotoVestimenta);
                regiao.ImagemVestimenta = img;
            }
            if (fotoLiteratura != null){
                string img = SalvarFoto(fotoLiteratura);
                regiao.ImagemLiteratura = img;
            }
            if (fotoTurismo != null){
                string img = SalvarFoto(fotoTurismo);
                regiao.ImagemTurismo = img;
            }

            if (true)
            {
                try
                {
                    _context.Update(regiao);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegiaoExists(regiao.IdRegiao))
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
            return View(regiao);
        }

        public string SalvarFoto(IFormFile imagemSelecionada)
        {
            var nome = Guid.NewGuid().ToString() + imagemSelecionada.FileName;
            //var nome = imagemSelecionada.FileName;

            var caminhoPastaFotos = _caminhoPasta + "\\img";
            if (!Directory.Exists(caminhoPastaFotos))
            {
                Directory.CreateDirectory(caminhoPastaFotos);
            }

            using (var stream = System.IO.File.Create(caminhoPastaFotos + "\\" + nome))
            {
                imagemSelecionada.CopyTo(stream);
            }

            return nome;
        }

        // GET: Regiao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Regioes == null)
            {
                return NotFound();
            }

            var regiao = await _context.Regioes
                .FirstOrDefaultAsync(m => m.IdRegiao == id);
            if (regiao == null)
            {
                return NotFound();
            }

            return View(regiao);
        }

        // POST: Regiao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Regioes == null)
            {
                return Problem("Entity set 'AppDbContext.Regioes'  is null.");
            }
            var regiao = await _context.Regioes.FindAsync(id);
            if (regiao != null)
            {
                _context.Regioes.Remove(regiao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegiaoExists(int id)
        {
          return (_context.Regioes?.Any(e => e.IdRegiao == id)).GetValueOrDefault();
        }
    }
}
