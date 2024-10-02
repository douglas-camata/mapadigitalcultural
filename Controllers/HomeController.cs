using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.Models;
using App.Context;

namespace Pagina.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string? id)
    {
        if (id != null) 
        {
            Regiao regiao = _context.Regioes.FirstOrDefault(m => m.Nome == id);
            return View(regiao);
        }
        
        return View();
        
    }

    public IActionResult BuscarRegiao(string? id)
    {
        Regiao regiao = _context.Regioes.FirstOrDefault(m => m.Nome == id);
        return RedirectToAction("Index",  new {regiao});
    }


    public IActionResult Privacy()
    {
        return View();
    }

}
