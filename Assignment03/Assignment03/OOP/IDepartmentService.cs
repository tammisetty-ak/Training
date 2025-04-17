namespace Assignment03.OOP;

public interface IDepartmentService
{
    void AssignHead(Instructor instructor);
    
    void AddCourse(Course course);
    
    List<Course> GetCourses();
}