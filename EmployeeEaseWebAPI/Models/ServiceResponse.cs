namespace EmployeeEaseWebAPI.Models
{
    public class ServiceResponse<T>
    {
        public T? Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
