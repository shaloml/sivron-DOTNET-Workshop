namespace ConsoleApp1
{
    internal interface IStudentRepository
    {
        IEnumerable<Student> GetStudentBySchoolID(int schoolID);
    }
}