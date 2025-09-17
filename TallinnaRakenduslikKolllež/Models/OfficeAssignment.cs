using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace TallinnaRakenduslikKolllež.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        [StringLength(50)]
        [Display(Name = "Kabinet")]
        public string Location { get; set; }

        /**/
    }
}
