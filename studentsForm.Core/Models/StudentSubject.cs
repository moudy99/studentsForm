namespace studentsForm.Core.Models
{
    public class StudentSubject
    {

        public string StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
