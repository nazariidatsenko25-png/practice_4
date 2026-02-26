namespace assignment4;


public class Course
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Teacher { get; private set; }
    
    public Course(int id, string name, string teacher)
    {
        Id = id;
        Name = name;
        Teacher = teacher;
    }

    public string GetInfo()
    {
        return $"Course ID: {Id}, Name: {Name}, Teacher: {Teacher}";
    }
}

public class Student
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    
    private List<Course> EnrolledCourses = new();

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public void AddCourse(Course course)
    {
        EnrolledCourses.Add(course);
    }

    public void ShowCourses()
    {
        Console.WriteLine($"ваші курси, {Name}:");
        forech(var course in EnrolledCourses)
        {
            Console.WriteLine(course.GetInfo());
        }
    }
    public string GetInfo()
    {
        return $"{Name} ID: {Id}, зарахований до таких курсів: {EnrolledCourses.Count} .";
    }
}

