using studentsForm.Application.ViewModel;

namespace studentsForm.Application.Interfaces.Service
{
    public interface IStudentService
    {
        Task<bool> AddStudent(AddStudentVM student);
        Task<List<SubjectVM>> GetAvailableSubjects();
    }
}
