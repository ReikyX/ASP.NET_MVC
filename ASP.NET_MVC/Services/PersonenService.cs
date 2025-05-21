using ASP.NET_MVC.Models;

namespace ASP.NET_MVC.Services;

public class PersonenService
{
    private readonly List<PersonenViewModel> _personen = new List<PersonenViewModel>();

    public List<PersonenViewModel> GetAllPersons()
    {
        return _personen;
    }

    public PersonenViewModel GetPersonById(int id)
    {
        return _personen.FirstOrDefault(p => p.Pk == id);
    }

    public void AddPerson(PersonenViewModel person)
    {
        person.Pk = _personen.Any() ? _personen.Max(p => p.Pk) + 1 : 1;
        _personen.Add(person);
    }

    public void UpdatePerson(PersonenViewModel person)
    {
        var existingPerson = GetPersonById(person.Pk);
        if (existingPerson != null)
        {
            existingPerson.Vorname = person.Vorname;
            existingPerson.Nachname = person.Nachname;
            existingPerson.Alter = person.Alter;
            existingPerson.Adresse = person.Adresse;
            existingPerson.Geschlecht = person.Geschlecht;
            existingPerson.Email = person.Email;
        }
    }

    public void DeletePerson(int pk)
    {
        var person = _personen.FirstOrDefault(p => p.Pk == pk);
        if (person != null)
        {
            _personen.Remove(person);
        }
    }
}
