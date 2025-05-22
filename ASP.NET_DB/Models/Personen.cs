using System.ComponentModel.DataAnnotations;

namespace ASP.NET_DB.Models;

public class Personen
{
    [Key]
    public int Pk { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie einen Vornamen an.")]
    [StringLength(50, ErrorMessage = "Der Vorname darf maximal 50 Zeichen lang sein.")]
    public string Vorname { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie einen Nachnamen an.")]
    [StringLength(50, ErrorMessage = "Der Nachname darf maximal 50 Zeichen lang sein.")]
    public string Nachname { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine Alter an.")]
    [Range(0, 120, ErrorMessage = "Das Alter muss zwischen 0 und 120 Jahren liegen.")]
    public int Alter { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine Adresse an.")]
    [StringLength(100, ErrorMessage = "Die Adresse darf maximal 100 Zeichen lang sein.")]
    public string Adresse { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie das Geschlecht an.")]
    public string Geschlecht { get; set; }

    [Required(ErrorMessage = "Bitte geben Sie eine E-Mail-Adresse an.")]
    [EmailAddress(ErrorMessage = "Bitte geben Sie eine gültige E-Mail-Adresse an.")]
    [StringLength(100, ErrorMessage = "Die E-Mail-Adresse darf maximal 100 Zeichen lang sein.")]
    public string Email { get; set; }


}
