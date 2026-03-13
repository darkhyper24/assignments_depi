using System;
using System.Globalization;

// ─────────────────────────────────────────────────────────────
//  ENUMERATIONS
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Restricts the gender field to Male or Female only.
/// </summary>
public enum Gender
{
    M,   // Male
    F    // Female
}

/// <summary>
/// Security privilege levels assigned to employees.
/// </summary>
public enum SecurityLevel
{
    Guest = 0,
    Developer = 1,
    Secretary = 2,
    DBA = 3
}

// ─────────────────────────────────────────────────────────────
//  HIRE DATE CLASS
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Represents a hiring date composed of Day, Month, and Year.
/// Validates all input to prevent runtime errors.
/// </summary>
public class HireDate
{
    // ── Backing fields ──────────────────────────────────────
    private int _day;
    private int _month;
    private int _year;

    // ── Properties ──────────────────────────────────────────

    public int Day
    {
        get => _day;
        set
        {
            if (value < 1 || value > 31)
                throw new ArgumentOutOfRangeException(nameof(Day), "Day must be between 1 and 31.");
            _day = value;
        }
    }

    public int Month
    {
        get => _month;
        set
        {
            if (value < 1 || value > 12)
                throw new ArgumentOutOfRangeException(nameof(Month), "Month must be between 1 and 12.");
            _month = value;
        }
    }

    public int Year
    {
        get => _year;
        set
        {
            if (value < 1900 || value > DateTime.Now.Year)
                throw new ArgumentOutOfRangeException(nameof(Year),
                    $"Year must be between 1900 and {DateTime.Now.Year}.");
            _year = value;
        }
    }

    // ── Constructors ─────────────────────────────────────────

    /// <summary>Default constructor — sets to January 1, 2000.</summary>
    public HireDate()
    {
        _day = 1;
        _month = 1;
        _year = 2000;
    }

    /// <summary>Parameterized constructor with full validation.</summary>
    public HireDate(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    // ── Methods ──────────────────────────────────────────────

    public override string ToString() =>
        $"{_day:D2}/{_month:D2}/{_year}";
}

// ─────────────────────────────────────────────────────────────
//  EMPLOYEE CLASS
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Represents an employee in the company with ID, name, security
/// level, salary, hire date, and gender.
/// </summary>
public class Employee
{
    // ── Backing fields ──────────────────────────────────────
    private int _id;
    private string _name;
    private SecurityLevel _securityLevel;
    private double _salary;
    private HireDate _hireDate;
    private Gender _gender;

    // ── Properties ──────────────────────────────────────────

    public int ID
    {
        get => _id;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(ID), "Employee ID must be a positive integer.");
            _id = value;
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Employee name cannot be null or empty.", nameof(Name));
            _name = value.Trim();
        }
    }

    public SecurityLevel SecurityLevel
    {
        get => _securityLevel;
        set
        {
            if (!Enum.IsDefined(typeof(SecurityLevel), value))
                throw new ArgumentException("Invalid security level.", nameof(SecurityLevel));
            _securityLevel = value;
        }
    }

    public double Salary
    {
        get => _salary;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(Salary), "Salary cannot be negative.");
            _salary = value;
        }
    }

    public HireDate HireDate
    {
        get => _hireDate;
        set => _hireDate = value ?? throw new ArgumentNullException(nameof(HireDate), "Hire date cannot be null.");
    }

    public Gender Gender
    {
        get => _gender;
        set
        {
            if (!Enum.IsDefined(typeof(Gender), value))
                throw new ArgumentException("Gender must be M (Male) or F (Female).", nameof(Gender));
            _gender = value;
        }
    }

    // ── Constructors ─────────────────────────────────────────

    /// <summary>
    /// Default constructor — creates a placeholder employee.
    /// </summary>
    public Employee()
    {
        _id = 1;
        _name = "Unknown";
        _securityLevel = SecurityLevel.Guest;
        _salary = 0.0;
        _hireDate = new HireDate();
        _gender = Gender.M;
    }

    /// <summary>
    /// Parameterized constructor — full employee initialization.
    /// </summary>
    public Employee(int id, string name, SecurityLevel securityLevel,
                    double salary, HireDate hireDate, Gender gender)
    {
        ID = id;
        Name = name;
        SecurityLevel = securityLevel;
        Salary = salary;
        HireDate = hireDate;
        Gender = gender;
    }

    /// <summary>
    /// Copy constructor — creates a new Employee from an existing one.
    /// </summary>
    public Employee(Employee other)
    {
        if (other == null) throw new ArgumentNullException(nameof(other));
        ID = other.ID;
        Name = other.Name;
        SecurityLevel = other.SecurityLevel;
        Salary = other.Salary;
        HireDate = new HireDate(other.HireDate.Day, other.HireDate.Month, other.HireDate.Year);
        Gender = other.Gender;
    }

    // ── Methods ──────────────────────────────────────────────

    /// <summary>
    /// Returns a description of the employee's security privileges.
    /// </summary>
    public string GetSecurityDescription() => SecurityLevel switch
    {
        SecurityLevel.Guest => "Read-only access — no system modifications allowed.",
        SecurityLevel.Developer => "Code repository & staging environment access.",
        SecurityLevel.Secretary => "Calendar, email, and document management access.",
        SecurityLevel.DBA => "Full database administration & system-level access.",
        _ => "Unknown privilege."
    };

    /// <summary>
    /// Returns the full title (Mr./Ms.) based on gender.
    /// </summary>
    public string GetTitle() => Gender == Gender.M ? "Mr." : "Ms.";

    /// <summary>
    /// Override ToString() — displays employee data including
    /// salary formatted as currency using String.Format.
    /// </summary>
    public override string ToString()
    {
        return String.Format(
            "┌─────────────────────────────────────────┐\n" +
            "  Employee Record\n" +
            "├─────────────────────────────────────────┤\n" +
            "  ID             : {0}\n" +
            "  Name           : {1} {2}\n" +
            "  Gender         : {3}\n" +
            "  Security Level : {4}\n" +
            "  Privileges     : {5}\n" +
            "  Salary         : {6:C}\n" +
            "  Hire Date      : {7}\n" +
            "└─────────────────────────────────────────┘",
            _id,
            GetTitle(), _name,
            _gender == Gender.M ? "Male" : "Female",
            _securityLevel,
            GetSecurityDescription(),
            _salary,
            _hireDate
        );
    }
}

// ─────────────────────────────────────────────────────────────
//  PROGRAM — ENTRY POINT
// ─────────────────────────────────────────────────────────────

class Program
{
    static void Main(string[] args)
    {
        // Set culture so currency formats correctly (e.g., $1,234.56)
        CultureInfo.CurrentCulture = new CultureInfo("en-US");

        // ── Create Employee Array of size 3 ──────────────────
        Employee[] EmpArr = new Employee[3];

        // Employee 1 — DBA
        EmpArr[0] = new Employee(
            id: 101,
            name: "Alice Johnson",
            securityLevel: SecurityLevel.DBA,
            salary: 95000.00,
            hireDate: new HireDate(15, 3, 2018),
            gender: Gender.F
        );

        // Employee 2 — Guest
        EmpArr[1] = new Employee(
            id: 102,
            name: "Bob Martinez",
            securityLevel: SecurityLevel.Guest,
            salary: 42000.00,
            hireDate: new HireDate(1, 7, 2023),
            gender: Gender.M
        );

        // Employee 3 — Security Officer (DBA level = full permissions)
        EmpArr[2] = new Employee(
            id: 103,
            name: "Carol Smith",
            securityLevel: SecurityLevel.DBA,   // Full permissions
            salary: 88500.50,
            hireDate: new HireDate(20, 11, 2015),
            gender: Gender.F
        );

        // ── Display all employees ─────────────────────────────
        Console.WriteLine("===========================================");
        Console.WriteLine("       COMPANY EMPLOYEE DIRECTORY         ");
        Console.WriteLine("===========================================\n");

        foreach (Employee emp in EmpArr)
        {
            Console.WriteLine(emp.ToString());
            Console.WriteLine();
        }

        // ── Demonstrate salary in currency format separately ──
        Console.WriteLine("===========================================");
        Console.WriteLine("         SALARY SUMMARY (Currency)        ");
        Console.WriteLine("===========================================");

        foreach (Employee emp in EmpArr)
        {
            Console.WriteLine(String.Format(
                "  {0,-20} [{1,-10}]  Salary: {2,12:C}",
                emp.Name,
                emp.SecurityLevel,
                emp.Salary
            ));
        }

        Console.WriteLine("===========================================\n");

        // ── Demonstrate validation (safe error handling) ──────
        Console.WriteLine("Testing input validation...\n");

        TryCreateBadEmployee("Invalid salary (-500)", () =>
            new Employee(200, "Test User", SecurityLevel.Guest, -500, new HireDate(), Gender.M));

        TryCreateBadEmployee("Invalid month (13)", () =>
            new Employee(201, "Test User", SecurityLevel.Guest, 1000, new HireDate(1, 13, 2020), Gender.M));

        TryCreateBadEmployee("Empty name", () =>
            new Employee(202, "  ", SecurityLevel.Guest, 1000, new HireDate(), Gender.M));

        TryCreateBadEmployee("Invalid ID (0)", () =>
            new Employee(0, "Test User", SecurityLevel.Guest, 1000, new HireDate(), Gender.M));

        Console.WriteLine("\nAll validation checks passed. No runtime errors.\n");
    }

    /// <summary>
    /// Safely attempts to create an employee; catches and displays
    /// validation errors without crashing the program.
    /// </summary>
    static void TryCreateBadEmployee(string testLabel, Func<Employee> factory)
    {
        try
        {
            Employee e = factory();
            Console.WriteLine($"  [PASS — unexpected] {testLabel}: Created without error.");
        }
        catch (ArgumentOutOfRangeException ex)   // must come BEFORE ArgumentException
        {
            Console.WriteLine($"  [CAUGHT] {testLabel}");
            Console.WriteLine($"           → {ex.Message}\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"  [CAUGHT] {testLabel}");
            Console.WriteLine($"           → {ex.Message}\n");
        }
    }
}