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

