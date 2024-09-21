using Microsoft.AspNetCore.Mvc;
using studentsForm.Application.Interfaces.Service;
using studentsForm.Application.ViewModel;

namespace studentsForm.Presentation.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            var viewModel = new AddStudentVM
            {
                AvailableSubjects = await studentService.GetAvailableSubjects()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentVM student)
        {
            student.AvailableSubjects = await studentService.GetAvailableSubjects();

            if (ModelState.IsValid)
            {
                bool isAdded = await studentService.AddStudent(student);
                if (isAdded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }

            return BadRequest("Invalid model state.");
        }

    }
}
