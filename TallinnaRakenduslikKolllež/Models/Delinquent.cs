using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolllež.Models
{
    public enum Violation
    {
        Kaklus,
        Narkootikumid,
        Suitsetamine,
        Hilinemine,
        Mustanahaline

    }

    public class Delinquent
    {
        [Key]
        public int DelinquentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Violation? CurrentViolation { get; set; }
        [Display(Name = "Kas on Õpetaja")]
        public bool? OnOpetaja { get; set; }
        [Display(Name = "Kirjeldus")]
        public string Description { get; set; }
        [Display(Name = "Olukord")]
        public string Olukord { get; set; }


    }
}