# Examination System Design

## Overview

This document explains the object-oriented design of the Examination
System implemented in C#.\
The system supports two exam types (**Final** and **Practical**) and
multiple question types.

------------------------------------------------------------------------

## Main Concepts

### 1. Answer

Represents a possible answer to a question.

**Attributes** - AnswerId - AnswerText

------------------------------------------------------------------------

### 2. Question (Abstract Base Class)

Represents a general question.

**Attributes** - Header - Body - Mark - AnswerList\[\] - RightAnswer

**Derived Classes** - TrueFalseQuestion - MCQQuestion

------------------------------------------------------------------------

### 3. Exam (Abstract Base Class)

Represents a general exam.

**Attributes** - Time - NumberOfQuestions - Questions\[\]

**Derived Classes** - FinalExam - PracticalExam

**Behavior** - ShowExam()

Implementation differs for each exam type.

------------------------------------------------------------------------

### 4. Subject

Represents a subject that contains an exam.

**Attributes** - SubjectId - SubjectName - Exam

**Behavior** - CreateExam()

------------------------------------------------------------------------

## Special Behaviors

### Practical Exam

-   Displays the correct answer after finishing each question.

### Final Exam

-   Displays the final grade after completing the exam.

------------------------------------------------------------------------

## Interfaces Used

### ICloneable

Allows cloning of Question objects.

### IComparable

Allows comparison between questions based on marks.

------------------------------------------------------------------------

## UML Class Diagram

The following diagram presents the main classes, inheritance hierarchy,
interfaces, and relationships in a clean markdown-friendly format.

```text
+---------------------------+
|          Subject          |
+---------------------------+
| + SubjectId : int         |
| + SubjectName : string    |
| + SubjectExam : Exam      |
+---------------------------+
| + CreateExam()            |
+---------------------------+
              |
              | contains 1
              v
+---------------------------+
|      <<abstract>>         |
|            Exam           |
+---------------------------+
| + Time : int              |
| + NumberOfQuestions : int |
| + Questions : Question[]  |
+---------------------------+
| + ShowExam()              |
+---------------------------+
        ^                           ^
        |                           |
        | inherits                  | inherits
        |                           |
+-------------------+     +-------------------+
|     FinalExam     |     |   PracticalExam   |
+-------------------+     +-------------------+
| + ShowExam()      |     | + ShowExam()      |
+-------------------+     +-------------------+


+---------------------------+
|      <<abstract>>         |
|          Question         |
+---------------------------+
| + Header : string         |
| + Body : string           |
| + Mark : int              |
| + AnswerList : Answer[]   |
| + RightAnswer : Answer    |
+---------------------------+
| + ShowQuestion()          |
+---------------------------+
        ^                           ^
        |                           |
        | inherits                  | inherits
        |                           |
+-------------------+     +-------------------+
| TrueFalseQuestion |     |    MCQQuestion    |
+-------------------+     +-------------------+
| + ShowQuestion()  |     | + ShowQuestion()  |
+-------------------+     +-------------------+

Question implements ICloneable
Question implements IComparable

+---------------------------+      +---------------------------+
|       ICloneable          |      |       IComparable         |
+---------------------------+      +---------------------------+
| + Clone()                 |      | + CompareTo(obj)          |
+---------------------------+      +---------------------------+

+---------------------------+
|          Answer           |
+---------------------------+
| + AnswerId : int          |
| + AnswerText : string     |
+---------------------------+

Relationships:
- Exam contains 1..* Question
- Question has 2..* Answer choices
- Question has 1 correct Answer
```

### Diagram Notes

- `Question` and `Exam` are abstract base classes.
- `TrueFalseQuestion` and `MCQQuestion` inherit from `Question`.
- `FinalExam` and `PracticalExam` inherit from `Exam`.
- `Question` implements `ICloneable` and `IComparable`.
- `PracticalExam` shows the correct answer after each question.
- `FinalExam` shows the final grade after the exam ends.
