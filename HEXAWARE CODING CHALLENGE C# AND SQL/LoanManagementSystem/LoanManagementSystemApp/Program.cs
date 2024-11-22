using LoanManagementSystemApp;

namespace LoanManagementSystemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Start the loan management system
                LoanManagement.ShowMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
