using ConsoleApp1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;


#region IOC
var services = new ServiceCollection();

services.AddTransient<IStudentRepository, StudentRepository>();
services.AddTransient<SchoolService>();


var serviceProvider = services.BuildServiceProvider(true);

var schoolService = serviceProvider.GetRequiredService<SchoolService>();

var students = schoolService.GetWithPriceBySchoolID(1);

foreach (var student in students)
{
	Console.WriteLine($"SchoolID:{student.SchoolID},StudentName: {student.StudentName} ");
}
#endregion

//StudentRepository studentRepository = new StudentRepository();
//SchoolService schoolService1 = new SchoolService(studentRepository);

//var students2 = schoolService1.GetStudentBySchoolID(1);

//foreach (var student in students2)
//{
//    Console.WriteLine($"SchoolID:{student.SchoolID},StudentName: {student.StudentName} ");
//}
