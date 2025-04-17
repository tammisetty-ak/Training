namespace Assignment03.OOP;

public class Course
{
    public string CourseName { get; set; }
    
    private Dictionary<Student, char> _enrolledStudents = new Dictionary<Student, char>();

    public Course(string courseName)
    {
        CourseName = courseName;
    }
    
    public void EnrollStudent(Student student, char grade)
    {
        if (student == null)
            throw new ArgumentNullException(nameof(student));

        _enrolledStudents[student] = grade;
    }

    public List<Student> GetEnrolledStudents()
    {
        return new List<Student>(_enrolledStudents.Keys);
    }
}