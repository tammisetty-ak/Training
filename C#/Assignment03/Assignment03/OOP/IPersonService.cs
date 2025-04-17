namespace Assignment03.OOP;

public interface IPersonService
{
    int CalculateAge();

    double CalculateSalary();
    
    void addAddress(string address);
    
    List<string> GetAddresses();
}