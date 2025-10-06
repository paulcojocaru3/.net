// See https://aka.ms/new-console-template for more information


public record Student(int Id, string Name, int Age, List<Course> Courses);
public record Course(string Title, int Credits);

public class Instructor
{
    public string Name { get; init; }
    public string Department { get; init; }
    public string Email { get; init; }

    public Instructor(string Name, string Department, string Email)
    {
        this.Name = Name;
        this.Department = Department;
        this.Email = Email;
    }
}


public class Program
{
    public static void Main()
    {
        var courses = new List<Course>();
        courses.Add(new Course("T1", 5));
        courses.Add(new Course("T1", 3));
        Student p1 = new Student(1, "Paul", 12, courses);
        var newCourses = new List<Course>(p1.Courses);
        newCourses.Add(new Course("T2", 5));
        Student p2 = p1 with { Courses = newCourses };

        var i1 = new Instructor("Ion", "Motocicleta", "ionmotocicleta@gmail.com");
        Console.WriteLine($"{i1.Name} {i1.Department} {i1.Email}");
        Func1(p2);
        var cursFiltrat = courses.Where(c => c.Credits > 3).ToList();
        foreach (var c in cursFiltrat)
        {
            Console.WriteLine($"{c.Title} -> {c.Credits} credite");
        }

    }

    public static void Func1(Object ob)
    {
        switch (ob)
        {
            case Student s when s.Courses is not null:
                Console.WriteLine($"Student: {s.Name}, Cursuri: {s.Courses.Count}");
                break;
            case Course c:
                Console.WriteLine($"Course: {c.Title}, {c.Credits}");
                break;
            case null:
                Console.WriteLine("NULL");
                break;
            default:
                Console.WriteLine("necunoscut");
                break;
                
        }
    }
}
