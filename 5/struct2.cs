using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _5
{
    internal struct Person
    {
        private string Name { get; set; }
		private int Age { get; set; }

		public Person(string name, int age) 
		{
			Name = name;
			Age = age;
		}

		static public Person[] Create(int size)
		{
			Person[] result = new Person[size];
			for (int i = 0; i < size; i++)
			{
				Console.WriteLine($"Enter name of person number {1 + i}");
				string test;
                while (string.IsNullOrEmpty(test = Console.ReadLine())) { Console.WriteLine("PLS ENTER NAME AGAIN");}
				result[i].Name = test;
                Console.WriteLine($"Enter age of person number {1 + i}");
				int age;
				while (!(int.TryParse(Console.ReadLine(), out age)) || age < 18) { Console.WriteLine("PLS ENTER age AGAIN"); }
				result[i].Age = age;
            }
			return result;
        }
        static public string check(Person[] arr)
		{
			Person person = arr[0];
			for (int i = 0; i < arr.Length; i++)
			{
				if(arr[i].Age >= person.Age)
						person.Age = arr[i].Age;
						person.Name = arr[i].Name;
            }
            return $"old person name is {person.Name} and his age is {person.Age}";
		}

	}
}
 