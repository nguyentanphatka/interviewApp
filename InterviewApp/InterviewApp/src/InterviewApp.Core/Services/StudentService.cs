using InterviewApp.Core.Interfaces;
using InterviewApp.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterviewApp.Core.Data.Entities;
using InterviewApp.Core.Handler.Student.Command.AddStudents;
using InterviewApp.Core.Specifications;

namespace InterviewApp.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _studentRepository;

        public StudentService(IRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            var students = await _studentRepository.ListAsync(new GetAllStudentSpec());
            return students;
        }

        public async Task<IEnumerable<Student>> GetStudentSorted()
        {
            var students = await _studentRepository.ListAsync(new GetAllStudentSpec());
            if (students.Count < 30)
                return students;
            var studentArr = students.OrderByDescending(s => s.DOB).ToArray();
            var rand = new Random();
            int num = rand.Next(0, studentArr.Length - 30);

            var result = new List<Student>();
            result.AddRange(studentArr[10..20]);
            result.AddRange(studentArr[30..(30+num)]);
            result.AddRange(studentArr[..10]);
            result.AddRange(studentArr[(30+num)..]);
            result.AddRange(studentArr[20..30]);
            
            return result;
        }
        
        public async Task<bool> AddStudents(List<InsertStudentsModel> students)
        {
            try
            {

                foreach (var model in students)
                {
                    var student = new Student()
                    {
                        FullName = model.FullName,
                        DOB = model.DOB
                    };
                    await _studentRepository.AddAsync(student);
                }
                await _studentRepository.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                //TODO log
                return false;
            }
        }

        public async Task<bool> DeleteStudents()
        {
           var students =  await _studentRepository.ListAsync(new GetAllStudentSpec());
            await _studentRepository.DeleteRangeAsync(students);
            return true;
        }
    }
}
