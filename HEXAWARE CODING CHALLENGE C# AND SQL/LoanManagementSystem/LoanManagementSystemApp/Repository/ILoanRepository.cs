
using LoanManagementSystemApp.Models;
using System.Collections.Generic;

namespace LoanManagementSystemApp.Repository
{
    public interface ILoanRepository
    {
        int ApplyLoan(Loan loan);  // Apply for a loan (with confirmation)
        decimal CalculateInterest(decimal principalAmount, decimal interestRate, int loanTerm);  // Calculate Interest with parameters
        decimal CalculateInterest(int loanId);  // Calculate Interest with loan ID
        int LoanStatus(int loanId, int creditScore);  // Update loan status based on credit score
        decimal CalculateEMI(decimal principalAmount, decimal interestRate, int loanTerm);  // Calculate EMI with parameters
        decimal CalculateEMI(int loanId);  // Calculate EMI with loan ID
        void LoanRepayment(int loanId, decimal amount);  // Handle loan repayment
        List<Loan> GetAllLoans();  // Get all loans
        Loan GetLoanById(int loanId);  // Get loan by ID
        int AddLoan(Loan loan);  // Add new loan to database
        int UpdateLoanStatus(int loanId, string status);  // Update loan status
        int DeleteLoan(int loanId);  // Delete loan from database
    }
}
