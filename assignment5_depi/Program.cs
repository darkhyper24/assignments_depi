// ===============================================
// Enum WeekDays representing the days of the week
// ===============================================

using System;

enum WeekDays
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

class Program
{
    static void Main()
    {
        // Loop through all enum values and print them
        foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
        {
            Console.WriteLine(day);
        }
    }
}


// ===============================================
// Struct Person with Name and Age
// ===============================================


//struct Person
//{
//    public string Name;
//   public int Age;
//}

//class Program
//{
//    static void Main()
//    {
//        // Create array of 3 persons
//        Person[] persons = new Person[3];

//        persons[0].Name = "Ali";
//        persons[0].Age = 25;

//        persons[1].Name = "Sara";
//        persons[1].Age = 30;

//        persons[2].Name = "Omar";
//        persons[2].Age = 20;

// Display data
//        foreach (Person p in persons)
//        {
//            Console.WriteLine("Name: " + p.Name + " Age: " + p.Age);
//        }
//    }
//}


// ===============================================
// Enum Season
// ===============================================
/*
using System;

enum Season
{
    Spring,
    Summer,
    Autumn,
    Winter
}

class Program
{
    static void Main()
    {
        Console.Write("Enter Season: ");
        string input = Console.ReadLine();

        Season season;

        if (Enum.TryParse(input, true, out season))
        {
            switch (season)
            {
                case Season.Spring:
                    Console.WriteLine("March to May");
                    break;

                case Season.Summer:
                    Console.WriteLine("June to August");
                    break;

                case Season.Autumn:
                    Console.WriteLine("September to November");
                    break;

                case Season.Winter:
                    Console.WriteLine("December to February");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid Season");
        }
    }
}
*/



/*
// ===============================================
// Permissions Enum using Flags
// ===============================================

using System;

[Flags]
enum Permissions
{
    Read = 1,
    Write = 2,
    Delete = 4,
    Execute = 8
}

class Program
{
    static void Main()
    {
        Permissions userPermission = Permissions.Read | Permissions.Write;

        // Add Permission
        userPermission |= Permissions.Execute;

        // Remove Permission
        userPermission &= ~Permissions.Write;

        // Check Permission
        if ((userPermission & Permissions.Read) == Permissions.Read)
        {
            Console.WriteLine("Read permission exists");
        }

        Console.WriteLine(userPermission);
    }
}
*/

/*
// ===============================================
// Enum Colors
// ===============================================

using System;

enum Colors
{
    Red,
    Green,
    Blue
}

class Program
{
    static void Main()
    {
        Console.Write("Enter a color: ");
        string input = Console.ReadLine();

        Colors color;

        if (Enum.TryParse(input, true, out color))
        {
            Console.WriteLine("It is a primary color");
        }
        else
        {
            Console.WriteLine("It is NOT a primary color");
        }
    }
}
*/

/*
// ===============================================
// Struct Point for 2D coordinates
// ===============================================

using System;

struct Point
{
    public double X;
    public double Y;
}

class Program
{
    static void Main()
    {
        Point p1, p2;

        Console.WriteLine("Enter first point:");
        Console.Write("X: ");
        p1.X = double.Parse(Console.ReadLine());
        Console.Write("Y: ");
        p1.Y = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter second point:");
        Console.Write("X: ");
        p2.X = double.Parse(Console.ReadLine());
        Console.Write("Y: ");
        p2.Y = double.Parse(Console.ReadLine());

        double distance = Math.Sqrt(
            Math.Pow(p2.X - p1.X, 2) +
            Math.Pow(p2.Y - p1.Y, 2)
        );

        Console.WriteLine("Distance = " + distance);
    }
}
*/


/*
// ===============================================
// Struct Person and find oldest person
// ===============================================

using System;

struct Person
{
    public string Name;
    public int Age;
}

class Program
{
    static void Main()
    {
        Person[] persons = new Person[3];

        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter Name: ");
            persons[i].Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            persons[i].Age = int.Parse(Console.ReadLine());
        }

        Person oldest = persons[0];

        foreach (Person p in persons)
        {
            if (p.Age > oldest.Age)
            {
                oldest = p;
            }
        }

        Console.WriteLine("Oldest Person: " + oldest.Name + " Age: " + oldest.Age);
    }
}
*/