namespace studentsForm.Application.ViewModel
{
    public class AddStudentVM
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public List<int> SubjectIds { get; set; }
        public List<SubjectVM>? AvailableSubjects { get; set; }
    }


}
