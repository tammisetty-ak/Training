namespace Assignment03.OOP;

public class Person : IPersonService
{
    private string _name;
    
    public string Name { get => _name; set => _name = value; }
    
    private DateTime _dateOfBirth;
    
    private double _salary;


    public double Salary
    {
        get { return _salary; }
        set { _salary = value; }
    }
    
    private List<string> _addresses = new List<string>();

    public Person(string name, DateTime dateOfBirth, double salary)
    {
        _name = name;
        _dateOfBirth = dateOfBirth;
        _salary = salary;
    }

    public int CalculateAge()
    {
        DateTime today = DateTime.Today;
        int age = today.Year - _dateOfBirth.Year;
        if (_dateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }

    public virtual double CalculateSalary()
    {
        return _salary;
    }

    public void addAddress(string address)
    {
        throw new NotImplementedException();
    }

    public void AddAddress(string address)
    {
        if(!string.IsNullOrEmpty(address))
            _addresses.Add(_name);
    }

    public List<string> GetAddresses()
    {
        return new List<string> (_addresses);
    }

}