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
        return $"айди курса: {Id}, назва: {Name}, Вчитель: {Teacher}";
    }
}

public class Student
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    
    private List<Course> enrolledCourses = new();

    public Student(int id, string name)
    {
        Id = id;
        Name = name;
    }
    
    public void AddCourse(Course course)
    {
        enrolledCourses.Add(course);
    }

    public void ShowCourses()
    {
        Console.WriteLine($"ваші курси, {Name}:");
        foreach (var course in enrolledCourses)
        {
            Console.WriteLine(course.GetInfo());
        }
    }
    public string GetInfo()
    {
        return $"{Name} ID: {Id}, зарахований до таких курсів: {enrolledCourses.Count} .";
    }
}

public class University
{
    private List<Course> courses = new();
    private Dictionary<int, Student> students = new();
    private Queue<Student> registrationQueue = new();
    private Stack<string> changeHistory = new();
    public void AddCourse(Course course)
    {
        courses.Add(course);
        changeHistory.Push($"ось курс було додано: {course.Name}");
    }

    public void RegStudent(Student student)
    {
        students[student.Id] = student;
        changeHistory.Push($"студент зареєстрований: {student.Name}");
    }
    
    public void AddToQueue(Student student)
    {
        registrationQueue.Enqueue(student);
        changeHistory.Push($"студент {student.Name} доданий до черги на реєстрацію");
    }

    public void FromQueue(Course course)
    {
        if (registrationQueue.TryDequeue(out var student))
        {
            student.AddCourse(course);
            changeHistory.Push($"Студент {student.Name} зареєстрований на {course.Name} з черги");
        }
    }
    public void EnrollStudentInTheCourse(Student student, Course course)
    {
        student.AddCourse(course);
        changeHistory.Push($"студент {student.Name} зареєстрований на курс {course.Name}");
    }
    
    public void ShowEveryCourse()
    {
        Console.WriteLine("всі курси університету:");
        foreach (var course in courses)
        {
            Console.WriteLine(course.GetInfo());
        }
    }

    public void ShowEveryStudent()
    {
        Console.WriteLine("всі студенти університету:");
        foreach (var student in students.Values)
        {
            Console.WriteLine(student.GetInfo());
        }
    }
    public void ShowHistory()
    {
        Console.WriteLine("історія змін:");
        foreach (var change in changeHistory)
        {
            Console.WriteLine(change);
        }
    }
    public Course GetCourse(int index)
    {
        return courses[index];
    }
}

var university = new University();
university.AddCourse(new Course(1, "Математика", "Професор Іван"));
university.AddCourse(new Course(2, "Фізика", "ткаченко"));
university.AddCourse(new Course(3, "Інформатика", "Вчитель Хоменко"));

var student1 = new Student(1, "Олександр");
var student2 = new Student(2, "Марія");
var student3 = new Student(3, "Іван");

university.RegStudent(student1);
university.RegStudent(student2);
university.RegStudent(student3);
university.ShowEveryStudent();

university.EnrollStudentInTheCourse(student1, university.GetCourse(0));
university.ShowStudentCourses(student1.Id);

university.AddToQueue(student2);
university.AddToQueue(student3);

university.FromQueue(university.GetCourse(1));
university.FromQueue(university.GetCourse(2));

university.ShowHistory();
