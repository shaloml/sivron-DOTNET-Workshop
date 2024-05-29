### תרגיל 3 – תרגול Configuration ב-Console Application

1. **צור פרויקט Console חדש ב-Visual Studio בשם `Exercise3`.**

2. **הוסף קובץ קונפיגורציה `appsettings.json` לפרויקט** עם התוכן הבא:
   ```json
   {
     "EmailService": {
       "Host": "mail.ewave.co.il",
       "Port": 443,
       "From": "noreply@ewave.co.il",
       "Username": "support",
       "Password": "1234"
     },
     "Features": {
       "HomePage": {
         "Title": "Hello World"
       }
     },
     "Layout": {
       "BackgroundColor": "Blue",
       "Color": "Red"
     }
   }
   ```

3. **צור מחלקה `EmailServiceSettings`** עם מאפיינים מתאימים בהתאם לנתונים בקובץ הקונפיגורציה `EmailService`.

4. **צור מחלקה `LayoutSettings`** עם מאפיינים מתאימים בהתאם לנתונים בקובץ הקונפיגורציה `Layout`.

5. **צור מחלקה `TestService`**:
   - צור פונקציה `Check` שמחזירה מחרוזת עם ערך הקונפיגורציה `Features:HomePage:Title` באופן ישיר באמצעות `GetValue`.
   - אתחל בבנאי את `LayoutSettings` באמצעות `Bind` והחזר את ערך `Color`.
   - הדפס את ה Title עם הצבע המתאים, רמז:ניתן להשתמש ב Enum `ConsoleColor` ב `LayoutSettings`

6. **הגדרה ב `Program`**:
   - אתחל את הקונפיגורציה לאובייקט `EmailServiceSettings`.
   - אתחל את `EmailServiceSettings` בבנאי של `TestService` באמצעות `IOptions`.
   - הדפס את ערך `Host` בפונקציה `Check`.

7. **השתמש ב-`IOptionsMonitor`**:
   - אתחל את `EmailServiceSettings` בבנאי של `TestService` באמצעות `IOptionsMonitor`.
   - החזר את ערך `Host` בפונקציה `Check`.
   - שנה את ערך `Host` בקובץ `appsettings.json` ל-`mail.google.com` ורענן את הדף, התוצאה על המסך צריכה להשתנות.


בהצלחה!