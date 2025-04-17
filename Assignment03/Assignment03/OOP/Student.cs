namespace Assignment03.OOP;

public class Student :  Person, IStudentService
{
    private Dictionary<Course, char> _courseGrades = new Dictionary<Course, char>();

    public Student(string name, DateTime dateOfBirth, double salary = 0) : base(name, dateOfBirth, salary)
    {
        
    }

    public void EnrollCourse(Course course, char grade)
    {
        if (course == null)
        {
            throw new ArgumentNullException("course");
        }
        
        _courseGrades[course] = grade;
        course.EnrollStudent(this, grade);
    }
    
    public double CalculateGPA()
    {
        if (_courseGrades.Count == 0)
            return 0.0;

        double totalPoints = 0;
        foreach (var grade in _courseGrades.Values)
        {
            totalPoints += GradeToPoint(grade);
        }
        return totalPoints / _courseGrades.Count;
    }
    
    private int GradeToPoint(char grade)
    {
        switch (Char.ToUpper(grade))
        {
            case 'A': return 4;
            case 'B': return 3;
            case 'C': return 2;
            case 'D': return 1;
            case 'F': return 0;
            default: return 0;
        }
    }
    
    public override double CalculateSalary()
    {
        return Salary;
    }
}