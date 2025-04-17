namespace Assignment03.OOP;

public class Instructor : Person, IInstructorService, IDepartmentService
{
    public DateTime JoinDate {get; set;}
    public Department Department {get; set;}

    public Instructor(string name, DateTime dateOfBirth, double salary, DateTime joinDate) : base(name, dateOfBirth,
        salary)
    {
        JoinDate = joinDate;
    }

    public int GetYearsOfExperience()
    {
        DateTime today = DateTime.Today;
        int years = today.Year - JoinDate.Year;
        if (JoinDate.Date > today.AddYears(-years)) years--;
        return years;
    }
    
    public override double CalculateSalary()
    {
        int experience = GetYearsOfExperience();
        // Bonus: 1% per year of experience.
        double bonus = Salary * experience / 100;
        return Salary + bonus;
    }
    
    public void AssignHead(Instructor instructor)
    {
        Department?.SetHead(instructor);
    }
    
    public void AddCourse(Course course)
    {
        Department?.AddCourse(course);
    }

    public List<Course> GetCourses()
    {
        return Department?.GetCourses() ?? new List<Course>();
    }

    public void SetDepartment(Department department)
    {
        Department = department;
    }
    
    
    

    
    
    
}