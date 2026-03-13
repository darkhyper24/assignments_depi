//problem 1
Console.Write("Enter a number: ");
string input = Console.ReadLine();
Console.WriteLine("You entered: " + input);

// problem 2
string str = "123abc";
try
{
    int num = int.Parse(str);
    Console.WriteLine(num);
}
catch (FormatException)
{
    Console.WriteLine("FormatException: The string contains non-numeric characters.");
}


// problem 3
float a = 1.5f;
float b = 2.3f;
float result = a + b;
Console.WriteLine("Result: " + result);

// problem 4
string text = "Hello, World!";
string sub = text.Substring(7, 5); // Extracts "World"
Console.WriteLine(sub);

// problem 5
int x = 10;
int y = x;
y = 20;
Console.WriteLine("x: " + x); // x remains 10
Console.WriteLine("y: " + y); // y is 20

//problem 6
Console.Write("Enter a number: ");
//string? input = Console.ReadLine();
if (input == null)
{
    Console.WriteLine("No input provided.");
}
else
{
    Console.WriteLine("You entered: " + input);
}

Person p1 = new Person { Name = "Alice" };
Person p2 = p1;
p2.Name = "Bob";
Console.WriteLine("p1.Name: " + p1.Name); // "Bob"
Console.WriteLine("p2.Name: " + p2.Name); // "Bob"



// problem 7
string str1 = "Hello";
string str2 = "World";
string combined = str1 + " " + str2;
Console.WriteLine(combined);
