using Microsoft.AspNetCore.Mvc;
using StudentData.DAL;
using StudentData.Models;
using StudentData.Models.DBEntities;

namespace StudentData.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDBContext _context;

        public StudentController(StudentDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var students = _context.Students.ToList();

            List<StudentViewModel> studentList = new List<StudentViewModel>();

            if (students != null)
            {
                foreach (var student in students)
                {
                    var StudentViewModel = new StudentViewModel()
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth,
                        Email = student.Email,
                        Stream = student.Stream
                    };
                    studentList.Add(StudentViewModel);
                }
                return View(studentList);
            }
            return View(studentList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel studentData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        FirstName = studentData.FirstName,
                        LastName = studentData.LastName,
                        DateOfBirth = studentData.DateOfBirth,
                        Email = studentData.Email,
                        Stream = studentData.Stream
                    };

                    _context.Students.Add(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student Added Successfully...";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is not valid";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == Id);

                if (student != null)
                {
                    var studentView = new StudentViewModel()
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth,
                        Email = student.Email,
                        Stream = student.Stream,
                    };

                    return View(studentView);
                }
                else
                {
                    TempData["errorMessage"] = $"Student details not available with the Id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(StudentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = new Student()
                    {
                        Id = model.Id,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        DateOfBirth = model.DateOfBirth,
                        Email = model.Email,
                        Stream = model.Stream,
                    };
                    _context.Students.Update(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student details updated successfully!!!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Model data is invaild.";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == Id);

                if (student != null)
                {
                    var studentView = new StudentViewModel()
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        DateOfBirth = student.DateOfBirth,
                        Email = student.Email,
                        Stream = student.Stream,
                    };

                    return View(studentView);
                }
                else
                {
                    TempData["errorMessage"] = $"Student details not available with the Id: {Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Delete(StudentViewModel model)
        {
            try
            {
                var student = _context.Students.SingleOrDefault(x => x.Id == model.Id);

                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Student deleted successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"Student details not available with the Id: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }

        }
    }
}
