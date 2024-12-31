using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5
{
    [Flags]
    enum Security_level
    {
        guest = 0b1000,
        Developer = 0b0100,
        secretary = 0b0010,
        DBA = 0b0001
    }

    enum Gender
    { 
        Male = 0,
        M  = 0,
        Female = 1,
        F = 1
    }

    internal class employees
    {
        //properties
        private int Id { get; set; }
        private string Name { get; set;}
        private Gender gender { get; set; }
        private Security_level security_Level { get; set; }
        private  double Salary { get; set; }

        private date Date1 = new date();

        //constructors
        public employees(int id, string name, Gender gender, Security_level security_Level, double salary, int day, int month, int year) : this(id, name, gender, security_Level)
        {
            this.Date1.Day = day;
            this.Date1.Month = month;
            this.Date1.Year = year;
            this.Salary = salary;
        }
        public employees(int id, string name, Gender gender, Security_level security_Level) : this(id, name, gender)
        {
            this.security_Level = security_Level;
        }
        public employees(int id, string name, Gender gender) : this(id, name)
        {
            this.gender = gender;
        }
        public employees(int id, string name) : this(id)
        {
            this.Name = name;
        }
        public employees(int id)
        {
            this.Id = id;
        }

        //function

        static public employees[] create_arr(int size)
        { 
            employees[] arr = new employees[size];
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"Enter EMP Id number {i + 1}");
                int id;
                while (!(int.TryParse(Console.ReadLine(), out id))) { Console.WriteLine("Enter valid ID"); }

                Console.WriteLine($"enter EMP name number {i + 1}");
                string name;
                while ((string.IsNullOrEmpty(name = Console.ReadLine()))) { Console.WriteLine("Enter valid name");}

                Console.WriteLine("Enter Gender M F m f male female");
                Gender gen;
                while (!(Enum.TryParse(Console.ReadLine(), true, out  gen))) { Console.WriteLine("pls enter valid Gender"); }

                Console.WriteLine("pls enter security level in this format (guest,developer,..)");
                string test4;
                while ((string.IsNullOrEmpty(test4 = Console.ReadLine())) || !(test4.Contains(','))) { Console.WriteLine("enter not empty data"); }
                string[] test5 = test4.Split(',');
                Security_level sl, sls = 0;
                int iterate = 0;
                foreach (string test in test5)
                {
                    while (!(Enum.TryParse(test.Trim(' ','(', ')'), true, out  sl)) && iterate > test.Length) { Console.WriteLine("not valid input");  }
                    sls |= sl;
                }

                Console.WriteLine("Enter salary");
                double salary;
                while (!(double.TryParse(Console.ReadLine(), out salary))) { Console.WriteLine("Enter valid data"); }

                Console.WriteLine("ENTER DATE note if any = 0 so u enter this data out of range\nday\nthen month\nthen year");
                int day, month, year;
                while (!(int.TryParse(Console.ReadLine(), out day)) & !(int.TryParse(Console.ReadLine(), out month)) & !(int.TryParse(Console.ReadLine(), out year))) { Console.WriteLine("enter valid value"); }
                arr[i] = new employees(id, name, gen, sls, salary, day, month, year);
            }
            return arr;
        }

        static public void print_arr(employees[] arr)
        {
            foreach (employees emp in arr)
            { 
                Console.WriteLine(emp);
            }
        }

        //static public void compare(ref employees[] arr)
        //{
        //    DateTime[] dateTimes = new DateTime[arr.Length];
        //    object[] array = new object[arr.Length];
        //    int i = 0, unboxing = 0;
        //    foreach (employees emp in arr)
        //    {
        //        array[i] = emp;   //مش عارف اوصل هنا خالص ازاي اعمل ترتيب
        //        i++;
        //    }
        //    array = array.OrderBy(Date1);
                
        //}
        public override string ToString()
        {
            return string.Format("ID {0}\nNAME: {1}\ngender: {2}\nSecurity_level: {3}\nsalary: {4}\ndate: {5}", Id, Name, gender, security_Level, Salary, Date1);
        }
    }

    class date
    {
        private int day;
        private int month;
        private int year;

        public int Year
        {
            get { return year; }
            set 
            { 
                if(value >= 2000 && value <= 9999)
                    year = value; 
            }
        }

        public int Month
        {
            get { return month; }
            set 
            { 
                if (value > 0 && value < 13)
                    month = value; 
            }
        }

        public int Day
        {
            get { return day; }
            set 
            { 
                if (value > 0 && value < 32)
                        day = value; 
            }
        }

        public override string ToString()
        {
            return $"{this.Day}/{this.Month}/{this.Year}";
        }
    }
}
