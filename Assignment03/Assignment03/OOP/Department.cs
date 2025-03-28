namespace Assignment03.OOP;

public class Department
{
    public string DepartmentName { get; set; }
    
    public Instructor Head { get; set; }
    
    public double Budget { get; set; }
    
    public DateTime BudgetStartDate { get; set; }
    
    public DateTime BudgetEndDate { get; set; }
    
    private List<Course> _courses = new List<Course>();

    public Department(string departmentName, double budget, DateTime budgetStartDate, DateTime budgetEndDate)
    {
        DepartmentName = departmentName;
        Budget = budget;
        BudgetStartDate = budgetStartDate;
        BudgetEndDate = budgetEndDate;
    }

    public void SetHead(Instructor instructor)
    {
        Head = instructor;
        instructor.SetDepartment(this);
    }

    public void AddCourse(Course course)
    {
        if (course != null && !_courses.Contains(course))
        {
            _courses.Add(course);
        }
    }

    public List<Course> GetCourses()
    {
        return new List<Course>(_courses);
    }
    
}