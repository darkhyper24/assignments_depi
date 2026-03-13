using System;

// ============================================
// Answer Class
// ============================================
class Answer
{
    public int AnswerId { get; set; }
    public string AnswerText { get; set; }

    public Answer(int id, string text)
    {
        AnswerId = id;
        AnswerText = text;
    }

    public override string ToString()
    {
        return $"{AnswerId}. {AnswerText}";
    }
}

// ============================================
// Base Question Class
// ============================================
abstract class Question : ICloneable, IComparable<Question>
{
    public string Header { get; set; }
    public string Body { get; set; }
    public int Mark { get; set; }

    public Answer[] AnswerList;
    public Answer RightAnswer;

    public Question(string header, string body, int mark)
    {
        Header = header;
        Body = body;
        Mark = mark;
    }

    public abstract void ShowQuestion();

    public object Clone()
    {
        return this.MemberwiseClone();
    }

    public int CompareTo(Question other)
    {
        return this.Mark.CompareTo(other.Mark);
    }

    public override string ToString()
    {
        return $"{Header}\n{Body}\nMark: {Mark}";
    }
}

// ============================================
// True / False Question
// ============================================
class TrueFalseQuestion : Question
{
    public TrueFalseQuestion(string header, string body, int mark)
        : base(header, body, mark)
    {
        AnswerList = new Answer[2]
        {
            new Answer(1,"True"),
            new Answer(2,"False")
        };
    }

    public override void ShowQuestion()
    {
        Console.WriteLine(this);
        foreach (var ans in AnswerList)
            Console.WriteLine(ans);
    }
}

// ============================================
// MCQ Question
// ============================================
class MCQQuestion : Question
{
    public MCQQuestion(string header, string body, int mark, Answer[] answers)
        : base(header, body, mark)
    {
        AnswerList = answers;
    }

    public override void ShowQuestion()
    {
        Console.WriteLine(this);

        foreach (var ans in AnswerList)
            Console.WriteLine(ans);
    }
}

// ============================================
// Base Exam Class
// ============================================
abstract class Exam
{
    public int Time { get; set; }
    public int NumberOfQuestions { get; set; }

    public Question[] Questions;

    public Exam(int time, int num)
    {
        Time = time;
        NumberOfQuestions = num;
        Questions = new Question[num];
    }

    public abstract void ShowExam();
}

// ============================================
// Final Exam
// ============================================
class FinalExam : Exam
{
    public FinalExam(int time, int num) : base(time, num) { }

    public override void ShowExam()
    {
        int totalGrade = 0;

        foreach (var q in Questions)
        {
            q.ShowQuestion();

            Console.Write("Your Answer: ");
            int userAnswer = int.Parse(Console.ReadLine());

            if (q.RightAnswer.AnswerId == userAnswer)
                totalGrade += q.Mark;
        }

        Console.WriteLine("Your Grade = " + totalGrade);
    }
}

// ============================================
// Practical Exam
// ============================================
class PracticalExam : Exam
{
    public PracticalExam(int time, int num) : base(time, num) { }

    public override void ShowExam()
    {
        foreach (var q in Questions)
        {
            q.ShowQuestion();

            Console.Write("Your Answer: ");
            int userAnswer = int.Parse(Console.ReadLine());

            Console.WriteLine("Correct Answer: " + q.RightAnswer.AnswerText);
        }
    }
}

// ============================================
// Subject Class
// ============================================
class Subject
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }

    public Exam SubjectExam;

    public Subject(int id, string name)
    {
        SubjectId = id;
        SubjectName = name;
    }

    public void CreateExam(Exam exam)
    {
        SubjectExam = exam;
    }
}

// ============================================
// Main Program
// ============================================
class Program
{
    static void Main()
    {
        Subject subject = new Subject(1, "Programming");

        // Create answers
        Answer[] mcqAnswers = new Answer[]
        {
            new Answer(1,"C#"),
            new Answer(2,"Java"),
            new Answer(3,"Python"),
            new Answer(4,"C++")
        };

        // Create questions
        MCQQuestion q1 = new MCQQuestion(
            "Q1",
            "Which language is used for .NET?",
            5,
            mcqAnswers
        );

        q1.RightAnswer = mcqAnswers[0];

        TrueFalseQuestion q2 = new TrueFalseQuestion(
            "Q2",
            ".NET is developed by Microsoft",
            5
        );

        q2.RightAnswer = q2.AnswerList[0];

        // Create Final Exam
        FinalExam exam = new FinalExam(60, 2);

        exam.Questions[0] = q1;
        exam.Questions[1] = q2;

        subject.CreateExam(exam);

        // Start Exam
        subject.SubjectExam.ShowExam();
    }
}