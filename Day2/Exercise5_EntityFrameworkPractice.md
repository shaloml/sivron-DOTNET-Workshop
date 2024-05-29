### תרגיל 5: שימוש ב-Entity Framework Core

#### מטרה:
בתרגיל זה תתרגל את השימוש ב-Entity Framework Core ליצירת מסד נתונים, הוספת נתונים ושליפת נתונים ב-Console Application.

#### שלבים לביצוע:

1. **צור פרויקט Console חדש בשם `EFCoreExercise`.**

2. **התקן את חבילת `Microsoft.EntityFrameworkCore.Sqlite`**:
   - נווט אל חלון ה-Package Manager Console והרץ את הפקודה:
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore.Sqlite
     ```

3. **התקן את חבילת `Microsoft.EntityFrameworkCore.Design`**:
   - הרץ את הפקודה:
     ```sh
     dotnet add package Microsoft.EntityFrameworkCore.Design
     ```

4. **צור מחלקת מודל בשם `Student`**:
   - צור תיקייה בשם `Models` בפרויקט והוסף את המחלקה הבאה:
     ```csharp
     namespace EFCoreExercise.Models
     {
         public class Student
         {
             public int Id { get; set; }
             public string Name { get; set; }
             public DateTime EnrollmentDate { get; set; }
         }
     }
     ```

5. **צור מחלקת DbContext בשם `SchoolContext`**:
   - צור תיקייה בשם `Data` בפרויקט והוסף את המחלקה הבאה:
     ```csharp
     using Microsoft.EntityFrameworkCore;
     using EFCoreExercise.Models;

     namespace EFCoreExercise.Data
     {
         public class SchoolContext : DbContext
         {
             public SchoolContext(DbContextOptions<SchoolContext> options)
                 : base(options)
             {
             }

             public DbSet<Student> Students { get; set; }
         }
     }
     ```

6. **הגדר את DbContext ב-Program.cs**:
   - הוסף את קוד ההגדרות ל-DbContext בקובץ `Program.cs`.

7. **צור והפעל את ה-Migrations**:
   - פתח את חלון ה-Package Manager Console והרץ את הפקודות הבאות:
     ```sh
     Add-Migration InitialCreate
     Update-Database
     ```

8. **הוסף נתונים והצג אותם**:
   - הוסף קוד להוספת נתונים לטבלת `Students` ושליפת הנתונים והצגתם בקונסול.
