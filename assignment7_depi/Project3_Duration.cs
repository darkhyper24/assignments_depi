// ═══════════════════════════════════════════════════════════
//  PROJECT 3 — Duration Class
// ═══════════════════════════════════════════════════════════
using System;

public class Duration
{
    // ── Backing fields ──────────────────────────────────────
    private int _hours;
    private int _minutes;
    private int _seconds;

    // ── Properties ──────────────────────────────────────────
    public int Hours
    {
        get => _hours;
        set => _hours = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(Hours), "Hours cannot be negative.");
    }

    public int Minutes
    {
        get => _minutes;
        set => _minutes = (value >= 0 && value < 60) ? value : throw new ArgumentOutOfRangeException(nameof(Minutes), "Minutes must be 0–59.");
    }

    public int Seconds
    {
        get => _seconds;
        set => _seconds = (value >= 0 && value < 60) ? value : throw new ArgumentOutOfRangeException(nameof(Seconds), "Seconds must be 0–59.");
    }

    // ── Constructors ─────────────────────────────────────────

    /// <summary>Default: 0h 0m 0s</summary>
    public Duration() : this(0, 0, 0) { }

    /// <summary>From individual hours, minutes, seconds.</summary>
    public Duration(int hours, int minutes, int seconds)
    {
        Hours   = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    /// <summary>
    /// From total seconds — auto-converts to h/m/s.
    /// e.g. 3600 → 1h 0m 0s | 7800 → 2h 10m 0s | 666 → 0h 11m 6s
    /// </summary>
    public Duration(int totalSeconds)
    {
        if (totalSeconds < 0)
            throw new ArgumentOutOfRangeException(nameof(totalSeconds), "Total seconds cannot be negative.");

        Hours   = totalSeconds / 3600;
        Minutes = (totalSeconds % 3600) / 60;
        Seconds = totalSeconds % 60;
    }

    // ── Helper: total seconds ─────────────────────────────────
    public int TotalSeconds => Hours * 3600 + Minutes * 60 + Seconds;

    // ── Override System.Object members ──────────────────────

    /// <summary>
    /// Shows Hours only when > 0, matching the required output format.
    /// </summary>
    public override string ToString()
    {
        if (Hours > 0)
            return $"Hours: {Hours}, Minutes: {Minutes}, Seconds: {Seconds}";
        else
            return $"Minutes: {Minutes}, Seconds: {Seconds}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Duration other)
            return TotalSeconds == other.TotalSeconds;
        return false;
    }

    public override int GetHashCode() => TotalSeconds.GetHashCode();

    // ═══════════════════════════════════════════════════════
    //  OPERATOR OVERLOADING
    // ═══════════════════════════════════════════════════════

    // ── D3 = D1 + D2 ─────────────────────────────────────────
    public static Duration operator +(Duration a, Duration b) =>
        new Duration(a.TotalSeconds + b.TotalSeconds);

    // ── D3 = D1 + 7800  (Duration + int seconds) ─────────────
    public static Duration operator +(Duration a, int seconds) =>
        new Duration(a.TotalSeconds + seconds);

    // ── D3 = 666 + D3   (int seconds + Duration) ─────────────
    public static Duration operator +(int seconds, Duration b) =>
        new Duration(seconds + b.TotalSeconds);

    // ── D3 = D1 - D2 ─────────────────────────────────────────
    public static Duration operator -(Duration a, Duration b)
    {
        int result = a.TotalSeconds - b.TotalSeconds;
        return new Duration(result < 0 ? 0 : result); // clamp at 0
    }

    // ── D3 = ++D1  (prefix) — increases by ONE minute ────────
    public static Duration operator ++(Duration d) =>
        new Duration(d.TotalSeconds + 60);

    // ── D3 = --D2  (prefix) — decreases by ONE minute ────────
    public static Duration operator --(Duration d)
    {
        int result = d.TotalSeconds - 60;
        return new Duration(result < 0 ? 0 : result); // clamp at 0
    }

    // ── if (D1 > D2) ─────────────────────────────────────────
    public static bool operator >(Duration a, Duration b) =>
        a.TotalSeconds > b.TotalSeconds;

    // ── if (D1 <= D2) ────────────────────────────────────────
    public static bool operator <=(Duration a, Duration b) =>
        a.TotalSeconds <= b.TotalSeconds;

    // Required companions when overloading > and <=
    public static bool operator <(Duration a, Duration b)  => a.TotalSeconds < b.TotalSeconds;
    public static bool operator >=(Duration a, Duration b) => a.TotalSeconds >= b.TotalSeconds;

    // ── if (D1)  — true when duration is greater than zero ───
    public static bool operator true(Duration d)  => d.TotalSeconds > 0;
    public static bool operator false(Duration d) => d.TotalSeconds == 0;

    // ── (DateTime) D1 — explicit cast to DateTime ────────────
    // Adds the duration to DateTime.Today, producing a usable DateTime.
    public static explicit operator DateTime(Duration d) =>
        DateTime.Today.Add(TimeSpan.FromSeconds(d.TotalSeconds));
}

// ── Program ──────────────────────────────────────────────────
class Project3
{
    static void Main()
    {
        Console.WriteLine("════════════════════════════════════");
        Console.WriteLine("        PROJECT 3 — Duration        ");
        Console.WriteLine("════════════════════════════════════\n");

        // ── Constructor demos ─────────────────────────────────
        Console.WriteLine("--- Constructor Output ---");
        Duration D1 = new Duration(1, 10, 15);
        Console.WriteLine($"new Duration(1,10,15)  → {D1}");  // Hours: 1, Minutes: 10, Seconds: 15

        Duration fromSec1 = new Duration(3600);
        Console.WriteLine($"new Duration(3600)     → {fromSec1}");  // Hours: 1, Minutes: 0, Seconds: 0

        Duration D2 = new Duration(7800);
        Console.WriteLine($"new Duration(7800)     → {D2}");   // Hours: 2, Minutes: 10, Seconds: 0

        Duration D3 = new Duration(666);
        Console.WriteLine($"new Duration(666)      → {D3}");   // Minutes: 11, Seconds: 6

        // ── Operator overloads ────────────────────────────────
        Console.WriteLine("\n--- Operator Overloading ---");

        // D3 = D1 + D2
        D3 = D1 + D2;
        Console.WriteLine($"D3 = D1 + D2           → {D3}");

        // D3 = D1 + 7800
        D3 = D1 + 7800;
        Console.WriteLine($"D3 = D1 + 7800         → {D3}");

        // D3 = 666 + D3
        D3 = 666 + D3;
        Console.WriteLine($"D3 = 666 + D3          → {D3}");

        // D3 = ++D1  (increase D1 by one minute)
        D3 = ++D1;
        Console.WriteLine($"D3 = ++D1              → D3={D3}  | D1={D1}");

        // D3 = --D2  (decrease D2 by one minute)
        D3 = --D2;
        Console.WriteLine($"D3 = --D2              → D3={D3}  | D2={D2}");

        // D1 = D1 - D2
        D1 = D1 - D2;
        Console.WriteLine($"D1 = D1 - D2           → {D1}");

        // Comparison operators
        Console.WriteLine("\n--- Comparison Operators ---");
        D1 = new Duration(1, 10, 15);
        D2 = new Duration(7800);
        Console.WriteLine($"D1 = {D1}");
        Console.WriteLine($"D2 = {D2}");
        Console.WriteLine($"D1 > D2                → {D1 > D2}");
        Console.WriteLine($"D1 <= D2               → {D1 <= D2}");

        // bool operator — if (D1)
        Console.WriteLine("\n--- bool Operator: if(D1) ---");
        if (D1)
            Console.WriteLine($"D1 is truthy → Duration is greater than zero ({D1})");

        Duration empty = new Duration(0, 0, 0);
        if (!empty)
            Console.WriteLine($"empty is falsy → Duration is zero ({empty})");

        // Explicit cast to DateTime
        Console.WriteLine("\n--- Explicit Cast to DateTime ---");
        DateTime dt = (DateTime)D1;
        Console.WriteLine($"(DateTime) D1          → {dt:yyyy-MM-dd HH:mm:ss}");

        // ── Equals / GetHashCode ──────────────────────────────
        Console.WriteLine("\n--- Equals / GetHashCode ---");
        Duration A = new Duration(3600);
        Duration B = new Duration(1, 0, 0);   // same as 3600 seconds
        Console.WriteLine($"A = {A}");
        Console.WriteLine($"B = {B}");
        Console.WriteLine($"A.Equals(B)            → {A.Equals(B)}");
        Console.WriteLine($"A.GetHashCode()        → {A.GetHashCode()}");
        Console.WriteLine($"B.GetHashCode()        → {B.GetHashCode()} (must match)");
    }
}
