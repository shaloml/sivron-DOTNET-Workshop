using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class SchoolService
    {
        private readonly IStudentRepository _studentRepository;

        public SchoolService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetStudentBySchoolID(int schoolID)
        {
            return _studentRepository.GetStudentBySchoolID(schoolID).OrderBy(s => s.StudentName);

        }

        public IEnumerable<Student> GetWithPriceBySchoolID(int schoolID)
        {
            var list = _studentRepository.GetStudentBySchoolID(schoolID).OrderBy(s => s.StudentName);

            return CalcPrice(list);
        }

        private IEnumerable<Student> CalcPrice(IEnumerable<Student> students)
        {
            foreach (var student in students)
            {
                student.Price = student.SchoolID * 3;

                yield return student;
            }
        }
    }
}
