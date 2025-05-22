using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.NET_DB.Data;
using ASP.NET_DB.Models;

namespace ASP.NET_DB.Controllers;

public class PersonenController : Controller
{
    private readonly PersonenDbContext _context;

    public PersonenController(PersonenDbContext context)
    {
        _context = context;
        context.Database.EnsureCreated();
    }

    // GET: Personens
    public async Task<IActionResult> Index()
    {
        return View(await _context.Personen.ToListAsync());
    }

    // GET: Personens/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personen = await _context.Personen
            .FirstOrDefaultAsync(m => m.Pk == id);
        if (personen == null)
        {
            return NotFound();
        }

        return View(personen);
    }

    // GET: Personens/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Personens/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Pk,Vorname,Nachname,Alter,Adresse,Geschlecht,Email")] Personen personen)
    {
        if (ModelState.IsValid)
        {
            _context.Add(personen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(personen);
    }

    // GET: Personens/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personen = await _context.Personen.FindAsync(id);
        if (personen == null)
        {
            return NotFound();
        }
        return View(personen);
    }

    // POST: Personens/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Pk,Vorname,Nachname,Alter,Adresse,Geschlecht,Email")] Personen personen)
    {
        if (id != personen.Pk)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(personen);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonenExists(personen.Pk))
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
        return View(personen);
    }

    // GET: Personens/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var personen = await _context.Personen
            .FirstOrDefaultAsync(m => m.Pk == id);
        if (personen == null)
        {
            return NotFound();
        }

        return View(personen);
    }

    // POST: Personens/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var personen = await _context.Personen.FindAsync(id);
        if (personen != null)
        {
            _context.Personen.Remove(personen);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PersonenExists(int id)
    {
        return _context.Personen.Any(e => e.Pk == id);
    }
}
