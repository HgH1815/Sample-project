using System;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

class FinalProject
{
    public static void Main(string[] args)
    {
        string Username;
        string Password;
        string CorrectUsername = "Hasan";
        string CorrectPassword = "Ghorbani";

        do
        {
            Console.WriteLine(" Hello, Enter the Username & Password please...\n");
            Console.WriteLine("Username:");
            Username = Console.ReadLine();
            Console.WriteLine("Password:");
            Password = Console.ReadLine();
            if (Username != CorrectUsername || Password != CorrectPassword)// این شرط باعث میشود تا وقتی ما اطلاعات درست را وارد کردیم، دیگر پیغام خطا نشان داده نشود
            {
                Console.WriteLine("Wrong Information or Format, PLEASE try again\n");
            }

        }
        while (Username != CorrectUsername || Password != CorrectPassword);//این لوپ، حالات فرمت اشتباه را نیز پوشش میدهد(مثلا وارد کردن عدد به جای حرف و ...

        Console.WriteLine("Login Sucssesfull,\n");
        Console.WriteLine("WELCOME!...Hasan Ghorbani(:\n");
        string SectionNumber;//چرا اینجا شماره منو را رشته در نظر گرفتیم؟ چون اگر فرمت اشتباهی مثل حرف در بخش ورودی منو وارد شد، برنامه ارور کامپایل ندهد، پس مجبور شدیم اعداد هم رشته در نظر بگیریم تا مشکلی پیش نیاید 
        bool exit = false;
        while (!exit)//دقیقا مشابه رفتار نام کاربری و رمز عبور اشتباه، اینجا هم اگر عدد اشتباه یا فرمت اشتباه وارد شود، پیغام خطا نمایش داده میشه و مجدد پرسش منو انجام میشه
        {
            Console.WriteLine("Choose The Section... \n");
            Console.WriteLine("1) Caculator \n");
            Console.WriteLine("2) Library \n");
            Console.WriteLine("3) Exit! \n");

            SectionNumber = Console.ReadLine();


            switch (SectionNumber)//همه جا از دستور if استفاده شد، اینجا از دستور سوییچ کیس هم استفاده کردیم
            {
                case "1":
                    Caculator();
                    break;
                case "2":
                    Library();
                    break;
                case "3":
                    Console.WriteLine("Thanks For Using , Good Luck!...");
                    exit = true;//خروج از حلقه منو و پایان برنامه
                    break;
                default:
                    Console.WriteLine("Wrong Number Or Format, Please Try Again");//پیغام خطا برای وارد کردن هرچیز اشتباه،چه عدد اشتباه، و چه فرمت اشتباه(همه رو پوشش میده)
                    break;
            }

        }
    }
   
    public static void Caculator()//برای خوانایی و کلا همه چیز بهتر، ماشین حساب را در یک تابع جداگانه نوشتیم و برای استفاده از اون، در بخش منوی اصلی تابع رو فراخوانی کمیکنیم
    {
        Console.WriteLine("Welcome To The Caculator...\n");
        Console.WriteLine("To Return To The  MainMenu Enter 0, To Continue Enter Anything Except 0");
        string choise = Console.ReadLine();
        if (choise == "0") { return; }

        Console.WriteLine("Please Enter Two Numbers");
        double a = 0;
        bool ok = false;
        do
        {
            Console.Write("Number 1: ");
            string input = Console.ReadLine();

            try
            {
                a = Convert.ToDouble(input);
                ok = true; // اگر تبدیل موفق شد
            }
            catch
            {
                Console.WriteLine("Wrong Format! Please enter a valid number.\n");
                ok = false; // اگر خطا داد دوباره بپرس
            }

        }
        while (!ok);


        double b = 0;
        bool Ok = false;

        do
        {
            Console.Write("Number 2: ");
            string Input = Console.ReadLine();

            try//اینجا برای مطمئن شدن از ورودی صحیح(یعنی عدد نه چیزدیگه ای در ماشین حساب)، به جای حلقه های تکرار شونده از این دستور(ترای، کچ) استفاده کردیم
            {
                b = Convert.ToDouble(Input);
                Ok = true; // اگر تبدیل موفق شد
            }
            catch
            {
                Console.WriteLine("Wrong Format! Please enter a valid number.\n");
                Ok = false; // اگر خطا داد دوباره بپرس
            }

        }
        while (!Ok);

        string c;
        do//اینجا هم دقیقا مثل 3 حالت قبلی، برای فرمت اشتباه پیغام خطا و پرسش مجدد درنظر میگیریم
        {

            Console.WriteLine("Enter The Operator");
            Console.WriteLine("+" + " " + "-" + " " + "*" + " " + "/" + " " + ">=<");
            Console.Write("The Operator : ");
            c = Console.ReadLine();
            if (c != "+" && c != "-" && c != "*" && c != "/" && c != ">=<")
            {
                Console.WriteLine("Wrong Sign..., Please Choose The Rightone\n");
            }
        }
        while (c != "+" && c != "-" && c != "*" && c != "/" && c != ">=<");

        if (c == "-")
            Console.WriteLine("Result = " + (a - b));
        else if (c == "+")
            Console.WriteLine("Result = " + (a + b));
        else if (c == "*")
            Console.WriteLine("Result = " + (a * b));
        else if (c == "/")
            Console.WriteLine("Result = " + (a / b));
        else if (c == ">=<")
        {
            if (a > b) Console.WriteLine("Result = " + a + ">" + b);
            else if (a < b) Console.WriteLine("Result = " + a + "<" + b);
            else if (a == b) Console.WriteLine("Result = " + a + "==" + b);
        }//ما دیگه در اینجا نتیجه رو مستقیم حساب کردیم و در یه متغیر جدا به نام نتیجه نریختیم،هم حافظه کمتری اشغال میشه هم کدها شلوغ تر نمیشه 


    }

    public static void Library()
    {
        List<string> books = new List<string>();  
        bool back = false;
        // آرایه‌ی کتاب‌های ثابت
    string[] defaultBooks = { "Animal Farm", "1984", "The Stranger" };

        while (!back)
        {
            Console.WriteLine("\n--- Library Menu ---");
            Console.WriteLine("1) Show Default Books (Array)");
            Console.WriteLine("2) Add a Book (List)");
            Console.WriteLine("3) Show All Books (List)");
            Console.WriteLine("4) Delete a Book (List)");
            Console.WriteLine("5) Search in Library (Array + List)");
            Console.WriteLine("6) Replace a Book (Array)");
            Console.WriteLine("7) Return to Main Menu");



            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\nDefault Books:");
                foreach (string b in defaultBooks)
                {
                    Console.WriteLine("- " + b);
                }

            }
            else if (choice == "2")
            {
                Console.Write("Enter Book Title: ");
                string title = Console.ReadLine();
                books.Add(title);
                Console.WriteLine("Book added successfully!\n");

            }
            else if (choice == "3")
            {
                Console.WriteLine("\nBooks in Library (List):");
                if (books.Count == 0)
                {
                    Console.WriteLine("No books yet!");
                }
                else
                {
                    foreach (string b in books)
                    {
                        Console.WriteLine("- " + b);
                    }
                }

            }
            else if (choice == "4")
            {
                Console.Write("Enter Book Title to Delete: ");
                string delTitle = Console.ReadLine();
                if (books.Contains(delTitle))//استفاده از تابع Contains در لیست، این تابع محتوی بودن یک چیز توی لیست رو بررسی میکنه، 
                {
                    books.Remove(delTitle);
                    Console.WriteLine("Book deleted successfully!\n");
                }
                else
                {
                    Console.WriteLine("Book not found in library!\n");
                }
            }
            else if (choice == "5")
            {
                Console.Write("Enter Book Title to Search: ");
                string search = Console.ReadLine();

                bool found = false;

                // جست‌وجو در آرایه
                foreach (string b in defaultBooks)
                {
                    if (b.ToLower() == search.ToLower())//این مکانسیم واسه چیه؟ واسه اینه که نام وارد شده و نام ثبت شده در لیست به حروف بزرگ و کوچیک حساس نباشن و اگه مثلا درلیست با حرف بزرگ بود و در کنسول حرف کوچک وارد شد بازهم پیدا کنه و مشکلی پیش نیاد
                    {
                        Console.WriteLine("Book found in default array!");
                        found = true;
                        break;
                    }
                }

                // جست‌وجو در لیست
                foreach (string b in books)
                {
                    if (b.ToLower() == search.ToLower())//اینم دقیقا به همون صورت بالا
                    {
                        Console.WriteLine("Book found in dynamic list!");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Book not found in library!");
                }

            }
            else if (choice == "6")
            {
                Console.Write("Enter Book Title to Replace (Array): ");// درآرایه نمیتوانیم ساختار حذف یااضافه جداگانه کتاب داشته باشیم، چونکه تعداد اعضای آرایه ثابته، بلافاصله بعد از حذف، باید اضافه داشته باشیم، از این جهت ساختار جایگزینی رو انتخاب کردیم

                string oldBook = Console.ReadLine();
                int index = Array.IndexOf(defaultBooks, oldBook);//استفاده از تابع indexOf از آرایه، به نام شماره یا ایندکس اون عضو از آرایه رو میده، 

                if (index >= 0)//اینجا شرط میرازیم تا مطمئن شیم اطلاعات وارد شده
                {
                    Console.Write("Enter New Book Title: ");
                    string newBook = Console.ReadLine();
                    defaultBooks[index] = newBook; // جایگزینی
                    Console.WriteLine("Book replaced successfully!\n");
                }
                else
                {
                    Console.WriteLine("Book not found in default array!\n");
                }

            }
            else if (choice == "7")
            {
                back = true; // خروج از کتابخونه

            }
            else
            {
                Console.WriteLine("Wrong Number Or Format, Please Try Again\n");
            }
        }
    
    }
   

}