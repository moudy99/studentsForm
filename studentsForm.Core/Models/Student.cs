using Microsoft.AspNetCore.Identity;

namespace studentsForm.Core.Models
{
    public class Student : IdentityUser
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();

    }
}
