namespace Assignment03.OOP;

public interface ICourseService
{
    void EnrollStudent(Student student,  char grade);
    
    List<Student> GetStudents();
}