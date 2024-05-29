using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

internal class StudentRepository : IStudentRepository
{
    private List<Student> _students;
    public StudentRepository()
    {
        #region Init
        _students = new()
            {
                new Student
                {
                    SchoolID = 1,
                    StudentName ="Moshe Levi"

                },
                new Student
                {
                    SchoolID = 1,
                    StudentName ="Avi Perez"
                },
                new Student
                {
                    SchoolID = 1,
                    StudentName ="Galit Mizrahi"
                },
                new Student
                {
                    SchoolID = 2,
                    StudentName ="Ronit Chen"
                },
                new Student
                {
                    SchoolID = 2,
                    StudentName ="Nivi Shemesh"
                },
            };
        #endregion
    }

    public IEnumerable<Student> GetStudentBySchoolID(int schoolID)
    {
        return _students.Where(p => p.SchoolID == schoolID);
    }
}

