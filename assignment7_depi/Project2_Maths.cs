// ═══════════════════════════════════════════════════════════
//  PROJECT 2 — Maths Class
// ═══════════════════════════════════════════════════════════
using System;

/// <summary>
/// All methods are static — no instance of Maths needed to call them.
/// </summary>
public static class Maths
{
    public static double Add(double a, double b)      => a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;

    /// <summary>Divide — returns NaN instead of throwing on divide-by-zero.</summary>
    public static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("  ⚠ Division by zero is undefined.");
            return double.NaN;
        }
        return a / b;
    }
}

class Project2
{
    static void Main()
    {
        Console.WriteLine("════════════════════════════════════");
        Console.WriteLine("         PROJECT 2 — Maths          ");
        Console.WriteLine("════════════════════════════════════\n");

        double a = 20, b = 4;

        // Called directly on the class — no `new Maths()` needed
        Console.WriteLine($"  a = {a},  b = {b}\n");
        Console.WriteLine($"  Add      ({a}, {b}) = {Maths.Add(a, b)}");
        Console.WriteLine($"  Subtract ({a}, {b}) = {Maths.Subtract(a, b)}");
        Console.WriteLine($"  Multiply ({a}, {b}) = {Maths.Multiply(a, b)}");
        Console.WriteLine($"  Divide   ({a}, {b}) = {Maths.Divide(a, b)}");

        // Edge case — divide by zero
        Console.WriteLine($"\n  Divide   ({a},  0) = {Maths.Divide(a, 0)}");
    }
}
