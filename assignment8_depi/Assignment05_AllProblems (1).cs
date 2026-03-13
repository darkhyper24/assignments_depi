using System;
using System.Collections;
using System.Collections.Generic;

// ═══════════════════════════════════════════════════════════════════════
//  PROBLEM 1 — Optimized Bubble Sort
// ═══════════════════════════════════════════════════════════════════════

/*  OPTIMIZATION EXPLAINED:
    ─────────────────────────────────────────────────────────────────────
    Standard Bubble Sort always runs n*(n-1)/2 comparisons even if the
    array becomes sorted early.

    Two optimizations applied:
    1. Early-exit flag (swapped): if a full pass makes zero swaps, the
       array is already sorted — stop immediately.
       → Best-case drops from O(n²) to O(n).

    2. Shrinking boundary (lastSwapIndex): after each pass, the largest
       unsorted element "bubbles" to its final position. We track the
       index of the LAST swap; everything beyond that index is already
       sorted and can be skipped in the next pass.
       → Reduces average comparisons significantly.
*/

public static class BubbleSortOptimized
{
    public static void Sort(int[] arr)
    {
        int n = arr.Length;
        int boundary = n - 1;   // only compare up to this index

        while (boundary > 0)
        {
            bool swapped = false;       // optimization 1: early-exit flag
            int  lastSwapIndex = 0;     // optimization 2: shrinking boundary

            for (int i = 0; i < boundary; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]); // swap
                    swapped       = true;
                    lastSwapIndex = i;   // record position of last swap
                }
            }

            if (!swapped) break;        // already sorted — no more passes needed
            boundary = lastSwapIndex;   // shrink the unsorted region
        }
    }

    public static void Demo()
    {
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("  PROBLEM 1 — Optimized Bubble Sort             ");
        Console.WriteLine("════════════════════════════════════════════════");

        int[] arr = { 64, 34, 25, 12, 22, 11, 90 };
        Console.Write("Before: ");
        Console.WriteLine(string.Join(", ", arr));

        Sort(arr);

        Console.Write("After : ");
        Console.WriteLine(string.Join(", ", arr));

        // Nearly-sorted array — demonstrates early-exit benefit
        int[] nearly = { 1, 2, 3, 5, 4 };
        Console.Write("\nNearly sorted before: ");
        Console.WriteLine(string.Join(", ", nearly));

        Sort(nearly);

        Console.Write("Nearly sorted after : ");
        Console.WriteLine(string.Join(", ", nearly));
        Console.WriteLine();
    }
}

// ═══════════════════════════════════════════════════════════════════════
//  PROBLEM 2 — Generic Range<T> Class
// ═══════════════════════════════════════════════════════════════════════

public class Range<T> where T : IComparable<T>
{
    public T Min { get; }
    public T Max { get; }

    /// <summary>Defines a range [min, max]. Min must not exceed Max.</summary>
    public Range(T min, T max)
    {
        if (min.CompareTo(max) > 0)
            throw new ArgumentException("Min cannot be greater than Max.");
        Min = min;
        Max = max;
    }

    /// <summary>Returns true if value falls within [Min, Max] inclusive.</summary>
    public bool IsInRange(T value) =>
        value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;

    /// <summary>
    /// Returns the length of the range.
    /// Uses dynamic to subtract generically — works for int, double, DateTime, etc.
    /// </summary>
    public dynamic Length() => (dynamic)Max - (dynamic)Min;

    public override string ToString() => $"Range[{Min} → {Max}]";

    public static void Demo()
    {
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("  PROBLEM 2 — Generic Range<T>                  ");
        Console.WriteLine("════════════════════════════════════════════════");

        // Integer range
        var intRange = new Range<int>(1, 100);
        Console.WriteLine($"{intRange}");
        Console.WriteLine($"  IsInRange(50)  → {intRange.IsInRange(50)}");
        Console.WriteLine($"  IsInRange(150) → {intRange.IsInRange(150)}");
        Console.WriteLine($"  Length()       → {intRange.Length()}");

        // Double range
        var dblRange = new Range<double>(0.5, 9.5);
        Console.WriteLine($"\n{dblRange}");
        Console.WriteLine($"  IsInRange(3.7) → {dblRange.IsInRange(3.7)}");
        Console.WriteLine($"  IsInRange(9.6) → {dblRange.IsInRange(9.6)}");
        Console.WriteLine($"  Length()       → {dblRange.Length()}");

        // Char range
        var charRange = new Range<char>('a', 'z');
        Console.WriteLine($"\n{charRange}");
        Console.WriteLine($"  IsInRange('m') → {charRange.IsInRange('m')}");
        Console.WriteLine($"  IsInRange('A') → {charRange.IsInRange('A')}");
        Console.WriteLine();
    }
}

// ═══════════════════════════════════════════════════════════════════════
//  PROBLEM 3 — Reverse ArrayList In-Place (no built-in Reverse)
// ═══════════════════════════════════════════════════════════════════════

public static class ArrayListUtils
{
    /// <summary>
    /// Reverses an ArrayList in-place using a two-pointer swap.
    /// Time: O(n)  |  Space: O(1) — no extra list created.
    /// </summary>
    public static void Reverse(ArrayList list)
    {
        int left  = 0;
        int right = list.Count - 1;

        while (left < right)
        {
            // swap elements at left and right pointers
            object temp    = list[left];
            list[left]     = list[right];
            list[right]    = temp;

            left++;
            right--;
        }
    }

    public static void Demo()
    {
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("  PROBLEM 3 — Reverse ArrayList In-Place        ");
        Console.WriteLine("════════════════════════════════════════════════");

        ArrayList list = new ArrayList { 10, 20, 30, 40, 50, 60 };
        Console.Write("Before: ");
        PrintArrayList(list);

        Reverse(list);

        Console.Write("After : ");
        PrintArrayList(list);

        // Edge case — single element
        ArrayList single = new ArrayList { 99 };
        Reverse(single);
        Console.Write("Single element reversed: ");
        PrintArrayList(single);

        // Edge case — empty list (must not crash)
        ArrayList empty = new ArrayList();
        Reverse(empty);
        Console.WriteLine("Empty list reversed: OK (no crash)");
        Console.WriteLine();
    }

    static void PrintArrayList(ArrayList list)
    {
        Console.WriteLine("[" + string.Join(", ", list.ToArray()) + "]");
    }
}

// ═══════════════════════════════════════════════════════════════════════
//  PROBLEM 4 — Filter Even Numbers from a List
// ═══════════════════════════════════════════════════════════════════════

public static class ListFilter
{
    /// <summary>Returns a new list containing only even numbers.</summary>
    public static List<int> GetEvens(List<int> numbers)
    {
        List<int> evens = new List<int>();
        foreach (int n in numbers)
            if (n % 2 == 0)
                evens.Add(n);
        return evens;
    }

    public static void Demo()
    {
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("  PROBLEM 4 — Filter Even Numbers               ");
        Console.WriteLine("════════════════════════════════════════════════");

        List<int> numbers = new List<int> { 1, 4, 7, 8, 13, 16, 22, 35, 40, 99 };
        Console.WriteLine($"Input : [{string.Join(", ", numbers)}]");

        List<int> evens = ListFilter.GetEvens(numbers);
        Console.WriteLine($"Evens : [{string.Join(", ", evens)}]");

        // Edge: all odd
        List<int> allOdd = new List<int> { 1, 3, 5, 7 };
        Console.WriteLine($"\nAll odd input : [{string.Join(", ", allOdd)}]");
        Console.WriteLine($"Evens         : [{string.Join(", ", GetEvens(allOdd))}]");
        Console.WriteLine();
    }
}

// ═══════════════════════════════════════════════════════════════════════
//  PROBLEM 5 — FixedSizeList<T>
// ═══════════════════════════════════════════════════════════════════════

public class FixedSizeList<T>
{
    private readonly T[]  _data;
    private int           _count;

    public int Capacity => _data.Length;
    public int Count    => _count;

    /// <summary>Creates a list with a fixed maximum capacity.</summary>
    public FixedSizeList(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentOutOfRangeException(nameof(capacity), "Capacity must be greater than zero.");
        _data  = new T[capacity];
        _count = 0;
    }

    /// <summary>
    /// Adds an element. Throws InvalidOperationException if the list is full.
    /// </summary>
    public void Add(T item)
    {
        if (_count == Capacity)
            throw new InvalidOperationException(
                $"List is full. Maximum capacity of {Capacity} has been reached.");
        _data[_count++] = item;
    }

    /// <summary>
    /// Gets an element by index. Throws ArgumentOutOfRangeException for invalid indices.
    /// </summary>
    public T Get(int index)
    {
        if (index < 0 || index >= _count)
            throw new ArgumentOutOfRangeException(nameof(index),
                $"Index {index} is out of range. Valid range: 0 to {_count - 1}.");
        return _data[index];
    }

    public override string ToString()
    {
        var items = new T[_count];
        Array.Copy(_data, items, _count);
        return $"FixedSizeList(capacity={Capacity}, count={_count}): [{string.Join(", ", items)}]";
    }

    public static void Demo()
    {
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("  PROBLEM 5 — FixedSizeList<T>                  ");
        Console.WriteLine("════════════════════════════════════════════════");

        FixedSizeList<string> list = new FixedSizeList<string>(3);

        list.Add("Alice");
        list.Add("Bob");
        list.Add("Carol");
        Console.WriteLine(list);

        // ── Try to exceed capacity ────────────────────────────
        Console.WriteLine("\nTrying to add a 4th element to a capacity-3 list...");
        try
        {
            list.Add("Dave");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"  [CAUGHT] {ex.Message}");
        }

        // ── Valid access ──────────────────────────────────────
        Console.WriteLine($"\nGet(1) → {list.Get(1)}");

        // ── Invalid index ─────────────────────────────────────
        Console.WriteLine("\nTrying Get(10) on a 3-element list...");
        try
        {
            list.Get(10);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"  [CAUGHT] {ex.Message}");
        }
        Console.WriteLine();
    }
}

// ═══════════════════════════════════════════════════════════════════════
//  PROBLEM 6 — First Non-Repeated Character
// ═══════════════════════════════════════════════════════════════════════

public static class StringUtils
{
    /// <summary>
    /// Returns the index of the first non-repeated character.
    /// Returns -1 if every character appears more than once.
    ///
    /// Strategy (two-pass using Dictionary):
    ///   Pass 1 — count frequency of every character.
    ///   Pass 2 — find the first character whose count == 1.
    /// Time: O(n)  |  Space: O(k) where k = unique characters.
    /// </summary>
    public static int FirstNonRepeated(string s)
    {
        if (string.IsNullOrEmpty(s)) return -1;

        // Pass 1: build frequency map
        Dictionary<char, int> freq = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        // Pass 2: return index of first character with frequency 1
        for (int i = 0; i < s.Length; i++)
            if (freq[s[i]] == 1)
                return i;

        return -1;
    }

    public static void Demo()
    {
        Console.WriteLine("════════════════════════════════════════════════");
        Console.WriteLine("  PROBLEM 6 — First Non-Repeated Character      ");
        Console.WriteLine("════════════════════════════════════════════════");

        Test("leetcode");      // 'l' at index 0
        Test("loveleetcode"); // 'v' at index 2
        Test("aabb");          // all repeated → -1
        Test("aabbc");         // 'c' at index 4
        Test("z");             // single char → index 0
        Test("");              // empty → -1
        Console.WriteLine();
    }

    static void Test(string s)
    {
        int idx = FirstNonRepeated(s);
        if (idx == -1)
            Console.WriteLine($"  \"{s}\" → No non-repeated character (-1)");
        else
            Console.WriteLine($"  \"{s}\" → '{s[idx]}' at index {idx}");
    }
}

// ═══════════════════════════════════════════════════════════════════════
//  ENTRY POINT
// ═══════════════════════════════════════════════════════════════════════

class Runner
{
    static void Main()
    {
        BubbleSortOptimized.Demo();
        Range<int>.Demo();
        ArrayListUtils.Demo();
        ListFilter.Demo();
        FixedSizeList<string>.Demo();
        StringUtils.Demo();
    }
}
