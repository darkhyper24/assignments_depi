// ═══════════════════════════════════════════════════════════
//  PROJECT 1 — Point3D
// ═══════════════════════════════════════════════════════════
using System;

public class Point3D : IComparable<Point3D>, ICloneable
{
    // ── Properties ──────────────────────────────────────────
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }

    // ── Constructors (chaining) ──────────────────────────────

    /// <summary>Default: origin (0, 0, 0)</summary>
    public Point3D() : this(0, 0, 0) { }

    /// <summary>2D point — Z defaults to 0</summary>
    public Point3D(double x, double y) : this(x, y, 0) { }

    /// <summary>Full 3D point — all other constructors chain here</summary>
    public Point3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // ── ToString ─────────────────────────────────────────────
    public override string ToString() =>
        $"Point Coordinates: ({X}, {Y}, {Z})";

    // ── Equality ─────────────────────────────────────────────
    // Overriding Equals + GetHashCode makes == work correctly.
    public override bool Equals(object obj)
    {
        if (obj is Point3D other)
            return X == other.X && Y == other.Y && Z == other.Z;
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(X, Y, Z);

    // Overload == and != operators so (P1 == P2) works as expected
    public static bool operator ==(Point3D a, Point3D b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Equals(b);
    }

    public static bool operator !=(Point3D a, Point3D b) => !(a == b);

    // ── IComparable — sort by X first, then Y, then Z ────────
    public int CompareTo(Point3D other)
    {
        if (other == null) return 1;
        int cmp = X.CompareTo(other.X);
        if (cmp != 0) return cmp;
        cmp = Y.CompareTo(other.Y);
        if (cmp != 0) return cmp;
        return Z.CompareTo(other.Z);
    }

    // ── ICloneable ───────────────────────────────────────────
    public object Clone() => new Point3D(X, Y, Z);
}

// ── Program ──────────────────────────────────────────────────
class Project1
{
    static void Main()
    {
        Console.WriteLine("════════════════════════════════════");
        Console.WriteLine("         PROJECT 1 — Point3D        ");
        Console.WriteLine("════════════════════════════════════\n");

        // ── 2. ToString demo ─────────────────────────────────
        Point3D P = new Point3D(10, 10, 10);
        Console.WriteLine($"ToString demo: {P}\n");

        // ── 3. Read P1 and P2 from user ──────────────────────
        Point3D P1 = ReadPoint("Enter P1");
        Point3D P2 = ReadPoint("Enter P2");

        // ── 4. Test == ───────────────────────────────────────
        Console.WriteLine($"\nP1: {P1}");
        Console.WriteLine($"P2: {P2}");
        Console.WriteLine(P1 == P2
            ? "\nP1 == P2 → TRUE  (points are equal)"
            : "\nP1 == P2 → FALSE (points are different)");

        // ── 5. Array of points, sorted by X then Y ───────────
        Point3D[] points =
        {
            new Point3D(5, 3, 1),
            new Point3D(2, 8, 4),
            new Point3D(5, 1, 9),
            new Point3D(1, 7, 2),
            new Point3D(2, 8, 0)
        };

        Console.WriteLine("\n--- Before Sort ---");
        foreach (var pt in points) Console.WriteLine($"  {pt}");

        Array.Sort(points);   // uses IComparable<Point3D>.CompareTo

        Console.WriteLine("\n--- After Sort (by X, then Y, then Z) ---");
        foreach (var pt in points) Console.WriteLine($"  {pt}");

        // ── 6. ICloneable demo ───────────────────────────────
        Point3D original = new Point3D(3, 6, 9);
        Point3D clone    = (Point3D)original.Clone();

        clone.X = 99;   // modifying clone must NOT affect original

        Console.WriteLine($"\nOriginal : {original}");
        Console.WriteLine($"Clone    : {clone}  (X changed to 99 — original intact)");
    }

    /// <summary>
    /// Reads a 3D point from the user.
    /// Uses TryParse to prevent any runtime crash on bad input.
    /// </summary>
    static Point3D ReadPoint(string label)
    {
        Console.WriteLine($"\n{label}:");
        return new Point3D(
            ReadDouble("  X: "),
            ReadDouble("  Y: "),
            ReadDouble("  Z: ")
        );
    }

    static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            // TryParse — never throws; returns false on bad input
            if (double.TryParse(input, out double result))
                return result;

            Console.WriteLine("  ✗ Invalid number. Please try again.");
        }
    }
}
