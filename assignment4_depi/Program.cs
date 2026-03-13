// =====================================================
// 1) Difference between passing Value Type parameters
//    by value and by reference
// =====================================================

/*
Value Types in C# include: int, double, float, bool, char, struct.

Passing by Value:
When a value type parameter is passed by value, a copy of the variable
is sent to the function. Any changes made inside the function do not
affect the original variable.

Passing by Reference:
When passed by reference using the keyword (ref), the function receives
the actual variable. Any changes made inside the function affect the
original variable.
*/

using System;

class ValueTypeExample
{
    static void ChangeValue(int x)
    {
        x = 50; // changes only the copy
    }

    static void ChangeValueRef(ref int x)
    {
        x = 50; // changes the original variable
    }

    static void Main()
    {
        int num = 10;

        ChangeValue(num);
        Console.WriteLine("After pass by value: " + num); // 10

        ChangeValueRef(ref num);
        Console.WriteLine("After pass by reference: " + num); // 50
    }
}



// =====================================================
// 2) Difference between passing Reference Type parameters
//    by value and by reference
// =====================================================

/*
Reference Types include: arrays, classes, objects, string.

Passing by Value:
A copy of the reference is passed to the function. Both the original
and the copy refer to the same object in memory, so the function can
modify the object's contents.

Passing by Reference:
When using (ref), the reference itself can be replaced with another
object, which will also change the original reference outside the
function.
*/

class ReferenceTypeExample
{
    static void ModifyArray(int[] arr)
    {
        arr[0] = 100; // modifies the same array object
    }

    static void ReplaceArray(ref int[] arr)
    {
        arr = new int[] { 9, 9, 9 }; // replaces the array reference
    }
}



// =====================================================
// 3) Function that accepts 4 parameters and returns
//    result of summation and subtraction
// =====================================================

class MathOperations
{
    static int Calculate(int a, int b, int c, int d)
    {
        // (a + b) - (c + d)
        return (a + b) - (c + d);
    }
}



// =====================================================
// 4) Function to calculate sum of digits
// =====================================================

class SumDigitsExample
{
    static int SumDigits(int num)
    {
        int sum = 0;

        while (num > 0)
        {
            sum += num % 10;
            num /= 10;
        }

        return sum;
    }
}



// =====================================================
// 5) Function IsPrime
// =====================================================

class PrimeExample
{
    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;

        for (int i = 2; i <= num / 2; i++)
        {
            if (num % i == 0)
                return false;
        }

        return true;
    }
}



// =====================================================
// 6) Function MinMaxArray using reference parameters
// =====================================================

class MinMaxExample
{
    static void MinMaxArray(int[] arr, ref int min, ref int max)
    {
        min = arr[0];
        max = arr[0];

        foreach (int num in arr)
        {
            if (num < min)
                min = num;

            if (num > max)
                max = num;
        }
    }
}



// =====================================================
// 7) Iterative factorial function (non-recursive)
// =====================================================

class FactorialExample
{
    static int Factorial(int n)
    {
        int result = 1;

        for (int i = 1; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }
}



// =====================================================
// 8) Function ChangeChar
// =====================================================

class ChangeCharacterExample
{
    static string ChangeChar(string text, int position, char newChar)
    {
        char[] chars = text.ToCharArray();
        chars[position] = newChar;

        return new string(chars);
    }
}