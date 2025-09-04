﻿using System.ComponentModel.DataAnnotations;

namespace TallinnaRakenduslikKolllež.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
        public string? Address { get; set; }
        public string? GroupName { get; set; }
        public string? Email { get; set; }
    }
}
