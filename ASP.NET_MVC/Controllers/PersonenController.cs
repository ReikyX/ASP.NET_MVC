using ASP.NET_MVC.Models;
using ASP.NET_MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_MVC.Controllers;

public class PersonenController : Controller
{

    private readonly PersonenService _personenService;

    // GET: PersonenController
    public ActionResult Index()
    {
        return View(_personenService.GetAllPersons());
    }

    // GET: PersonenController/Details/5
    public ActionResult Details(int id)
    {
        var person = _personenService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View(person);
    }

    // GET: PersonenController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: PersonenController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(PersonenViewModel person)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _personenService.AddPerson(person);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(person);
            }
        }
        catch
        {
            return View(person);
        }
    }

    // GET: PersonenController/Edit/5
    public ActionResult Edit(int id)
    {
        var person = _personenService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View();
    }

    // POST: PersonenController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, PersonenViewModel editPerson)
    {
        try
        {
            var existingPerson = _personenService.GetPersonById(id);
            if(existingPerson == null)
            {
                return NotFound();
            }
            _personenService.UpdatePerson(editPerson);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(editPerson);
        }
    }

    // GET: PersonenController/Delete/5
    public ActionResult Delete(int id)
    {
        var person = _personenService.GetPersonById(id);
        if (person == null)
        {
            return NotFound();
        }
        return View(person);
    }

    // POST: PersonenController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            _personenService.DeletePerson(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
