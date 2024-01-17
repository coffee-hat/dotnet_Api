namespace EmployeeManagement.Exception;

public class ApiException : System.Exception
{
    public ApiException(string message) : base (message)
    {
    }
    
    public ApiException(int errorCode, string message) : base (message)
    {
    }
}