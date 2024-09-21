using AutoMapper;
using studentsForm.Application.Interfaces.Service;
using studentsForm.Application.Interfaces.UnitOfWork;
using studentsForm.Application.ViewModel;
using studentsForm.Core.Models;

namespace studentsForm.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<bool> AddStudent(AddStudentVM studentVM)
        {
            try
            {
                var newStudent = mapper.Map<Student>(studentVM);

                foreach (var subjectId in studentVM.SubjectIds)
                {
                    var subject = unitOfWork.GetRepository<Subject>().GetById(subjectId);
                    if (subject != null)
                    {
                        newStudent.StudentSubjects.Add(new StudentSubject
                        {
                            Student = newStudent,
                            Subject = subject
                        });
                    }
                }

                await unitOfWork.GetRepository<Student>().AddAsync(newStudent);
                await unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<List<SubjectVM>> GetAvailableSubjects()
        {
            var subjects = unitOfWork.GetRepository<Subject>().FindAll();
            return mapper.Map<List<SubjectVM>>(subjects);
        }

    }
}
