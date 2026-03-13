//problem 1
using System.Linq;

int num = int.Parse(Console.ReadLine());

if (num % 3 == 0 && num % 4 == 0)
    Console.WriteLine("Yes");
else
    Console.WriteLine("No");

//problem 2
int num2 = int.Parse(Console.ReadLine());

if (num2 < 0)
    Console.WriteLine("Negative");
else
    Console.WriteLine("Positive");

//problem 3
int a = int.Parse(Console.ReadLine());
int b = int.Parse(Console.ReadLine());
int c = int.Parse(Console.ReadLine());

int max = Math.Max(a, Math.Max(b, c));
int min = Math.Min(a, Math.Min(b, c));

Console.WriteLine("Max element = " + max);
Console.WriteLine("Min element = " + min);

//problem 4
int num3 = int.Parse(Console.ReadLine());

if (num3 % 2 == 0)
    Console.WriteLine("Even");
else
    Console.WriteLine("Odd");

//problem 5
char ch = char.ToLower(Console.ReadKey().KeyChar);

if ("aeiou".Contains(ch))
    Console.WriteLine("\nVowel");
else
    Console.WriteLine("\nConsonant");

//problem 6
int n = int.Parse(Console.ReadLine());

for (int i = 1; i <= n; i++)
{
    Console.Write(i + " ");
}

//problem 7
int n7 = int.Parse(Console.ReadLine());

for (int i = 1; i <= 12; i++)
{
    Console.Write((n7 * i) + " ");
}

//problem 8
int n1 = int.Parse(Console.ReadLine());

for (int i = 2; i <= n1; i += 2)
{
    Console.Write(i + " ");
}

//problem 9
int baseNum = int.Parse(Console.ReadLine());
int power = int.Parse(Console.ReadLine());

int result = 1;

for (int i = 0; i < power; i++)
{
    result *= baseNum;
}

Console.WriteLine(result);

//problem 10
int total = 0;

for (int i = 0; i < 5; i++)
{
    total += int.Parse(Console.ReadLine());
}

double avg = total / 5.0;

Console.WriteLine("Total marks = " + total);
Console.WriteLine("Average Marks = " + avg);
Console.WriteLine("Percentage = " + avg);

//problem 11
int month = int.Parse(Console.ReadLine());

int days = DateTime.DaysInMonth(2024, month);

Console.WriteLine("Days in Month: " + days);

//problem 12
double a1 = double.Parse(Console.ReadLine());
double b1 = double.Parse(Console.ReadLine());
char op = Console.ReadKey().KeyChar;

switch (op)
{
    case '+': Console.WriteLine(a1 + b1); break;
    case '-': Console.WriteLine(a1 - b1); break;
    case '*': Console.WriteLine(a1 * b1); break;
    case '/': Console.WriteLine(a1 / b1); break;
}

//problem 13
string text = Console.ReadLine();

char[] arr = text.ToCharArray();
Array.Reverse(arr);

Console.WriteLine(new string(arr));

//problem 14
int num5 = int.Parse(Console.ReadLine());
int reversed = 0;

while (num5 > 0)
{
    reversed = reversed * 10 + num5 % 10;
    num5 /= 10;
}

Console.WriteLine(reversed);

//problem 15
int start = int.Parse(Console.ReadLine());
int end = int.Parse(Console.ReadLine());

for (int i = start; i <= end; i++)
{
    bool prime = true;

    if (i < 2) prime = false;

    for (int j = 2; j <= Math.Sqrt(i); j++)
    {
        if (i % j == 0)
        {
            prime = false;
            break;
        }
    }

    if (prime)
        Console.Write(i + " ");
}

//problem 16
int num7 = int.Parse(Console.ReadLine());

string binary = "";

while (num7 > 0)
{
    binary = (num7 % 2) + binary;
    num7 /= 2;
}

Console.WriteLine(binary);

//problem 17
double x1 = double.Parse(Console.ReadLine());
double y1 = double.Parse(Console.ReadLine());
double x2 = double.Parse(Console.ReadLine());
double y2 = double.Parse(Console.ReadLine());
double x3 = double.Parse(Console.ReadLine());
double y3 = double.Parse(Console.ReadLine());

if ((y2 - y1) * (x3 - x1) == (y3 - y1) * (x2 - x1))
    Console.WriteLine("Points lie on a straight line");
else
    Console.WriteLine("Not on a straight line");

//problem 18
double time = double.Parse(Console.ReadLine());

if (time >= 2 && time <= 3)
    Console.WriteLine("Highly Efficient");
else if (time > 3 && time <= 4)
    Console.WriteLine("Increase speed");
else if (time > 4 && time <= 5)
    Console.WriteLine("Training needed");
else if (time > 5)
    Console.WriteLine("Leave the company");

//problem 19
int mido = int.Parse(Console.ReadLine());

for (int i = 0; i < mido; i++)
{
    for (int j = 0; j < mido; j++)
    {
        if (i == j)
            Console.Write("1 ");
        else
            Console.Write("0 ");
    }
    Console.WriteLine();
}

//problem 20
int[] arr3 = { 1, 2, 3, 4, 5 };

int sum = arr3.Sum();

Console.WriteLine(sum);

//problem 21
int[] a8 = { 1, 3, 5 };
int[] b8 = { 2, 4, 6 };

int[] merged = a8.Concat(b8).OrderBy(x => x).ToArray();

foreach (var x in merged)
    Console.Write(x + " ");
