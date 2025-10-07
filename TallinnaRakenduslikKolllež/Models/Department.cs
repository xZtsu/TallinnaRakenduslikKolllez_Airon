using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolllež.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public int? InstructorID { get; set; }
        public Instructor? Administrator { get; set; }
        public ICollection<Course>? Courses { get; set; }
        public byte? RowVersion { get; set; }

        /** 3 oma omadust**/
        public string? PhoneNumber { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
