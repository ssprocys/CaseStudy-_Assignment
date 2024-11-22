using LoanManagementSystemApp.Exceptions;
using LoanManagementSystemApp.Models;
using LoanManagementSystemApp.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;




namespace LoanManagementSystemApp.Repository
{
    public class LoanRepository : ILoanRepository
    {
        private readonly string _connectionString;
        private SqlCommand _cmd;

        public LoanRepository()
        {
            _connectionString = DbConnUtil.GetConnectionString(); // Get the connection string from utility
            _cmd = new SqlCommand();
        }

        // 1. Apply Loan (with user confirmation)
        public int ApplyLoan(Loan loan)
        {
            try
            {
                // Ask for user confirmation
                Console.WriteLine("Do you want to apply for this loan? (Yes/No): ");
                string userResponse = Console.ReadLine();

                if (userResponse.Equals("Yes", StringComparison.OrdinalIgnoreCase))
                {
                    loan.LoanStatus = "Pending";  // Set loan status to "Pending"
                    return AddLoan(loan);  // Call AddLoan to insert into the database
                }
                else
                {
                    Console.WriteLine("Loan application rejected.");
                    return 0; // Loan not added
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error occurred while applying for loan", ex);
            }
        }

        // 2. Calculate Interest (overloaded)
        public decimal CalculateInterest(decimal principalAmount, decimal interestRate, int loanTerm)
        {
            try
            {
                return (principalAmount * interestRate * loanTerm) / 12;
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while calculating interest", ex);
            }
        }

        public decimal CalculateInterest(int loanId)
        {
            try
            {
                Loan loan = GetLoanById(loanId);
                if (loan == null)
                {
                    throw new InvalidLoanException("Loan not found");
                }
                return (loan.PrincipalAmount * loan.InterestRate * loan.LoanTerm) / 12;
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while calculating interest for the loan", ex);
            }
        }

        // 3. Loan Status (based on credit score)
        public int LoanStatus(int loanId, int creditScore)
        {
            try
            {
                string status = creditScore > 650 ? "Approved" : "Rejected";
                return UpdateLoanStatus(loanId, status);  // Update the loan status in the database
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while updating loan status", ex);
            }
        }

        // 4. Calculate EMI (overloaded)
        public decimal CalculateEMI(decimal principalAmount, decimal interestRate, int loanTerm)
        {
            try
            {
                decimal monthlyRate = interestRate / 12 / 100;  // Convert annual interest rate to monthly
                int months = loanTerm;
                return (principalAmount * monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), months)) /
                       ((decimal)Math.Pow((double)(1 + monthlyRate), months) - 1);
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while calculating EMI", ex);
            }
        }

        public decimal CalculateEMI(int loanId)
        {
            try
            {
                Loan loan = GetLoanById(loanId);
                if (loan == null)
                {
                    throw new InvalidLoanException("Loan not found");
                }

                decimal monthlyRate = loan.InterestRate / 12 / 100;
                int months = loan.LoanTerm;
                return (loan.PrincipalAmount * monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), months)) /
                       ((decimal)Math.Pow((double)(1 + monthlyRate), months) - 1);
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while calculating EMI for the loan", ex);
            }
        }

        // 5. Loan Repayment
        public void LoanRepayment(int loanId, decimal amount)
        {
            try
            {
                Loan loan = GetLoanById(loanId);
                if (loan == null)
                {
                    throw new InvalidLoanException("Loan not found");
                }

                decimal emiAmount = CalculateEMI(loanId);  // Get EMI amount for this loan
                if (amount < emiAmount)
                {
                    Console.WriteLine("Repayment amount is less than EMI. Payment rejected.");
                }
                else
                {
                    int numberOfEMIs = (int)(amount / emiAmount);  // Calculate number of EMIs that can be paid
                    Console.WriteLine($"You can pay {numberOfEMIs} EMIs with this amount.");
                    // Update the loan balance or other business logic here
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while processing loan repayment", ex);
            }
        }

        // Get All Loans from the database
        public List<Loan> GetAllLoans()
        {
            List<Loan> loans = new List<Loan>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    _cmd.CommandText = "SELECT * FROM Loan";
                    _cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    SqlDataReader reader = _cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Loan loan = new Loan
                        {
                            LoanID = (int)reader["LoanID"],
                            CustomerID = (int)reader["CustomerID"],
                            PrincipalAmount = (decimal)reader["PrincipalAmount"],
                            InterestRate = (decimal)reader["InterestRate"],
                            LoanTerm = (int)reader["LoanTerm"],
                            LoanType = (string)reader["LoanType"],
                            LoanStatus = (string)reader["LoanStatus"]
                        };

                        loans.Add(loan);
                    }

                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while fetching all loans", ex);
            }

            return loans;
        }

        // Get a Loan by ID from the database
        public Loan GetLoanById(int loanId)
        {
            Loan loan = null;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    _cmd.CommandText = "SELECT * FROM Loan WHERE LoanID = @LoanID";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@LoanID", loanId);

                    _cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    SqlDataReader reader = _cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        loan = new Loan
                        {
                            LoanID = (int)reader["LoanID"],
                            CustomerID = (int)reader["CustomerID"],
                            PrincipalAmount = (decimal)reader["PrincipalAmount"],
                            InterestRate = (decimal)reader["InterestRate"],
                            LoanTerm = (int)reader["LoanTerm"],
                            LoanType = (string)reader["LoanType"],
                            LoanStatus = (string)reader["LoanStatus"]
                        };
                    }

                    sqlConnection.Close();
                }

                if (loan == null)
                {
                    throw new InvalidLoanException("Loan not found");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while fetching loan by ID", ex);
            }

            return loan;
        }

        // Add a Loan to the database
        public int AddLoan(Loan loan)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    _cmd.CommandText = "INSERT INTO Loan (CustomerID, PrincipalAmount, InterestRate, LoanTerm, LoanType, LoanStatus) " +
                                       "VALUES (@CustomerID, @PrincipalAmount, @InterestRate, @LoanTerm, @LoanType, @LoanStatus)";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@CustomerID", loan.CustomerID);
                    _cmd.Parameters.AddWithValue("@PrincipalAmount", loan.PrincipalAmount);
                    _cmd.Parameters.AddWithValue("@InterestRate", loan.InterestRate);
                    _cmd.Parameters.AddWithValue("@LoanTerm", loan.LoanTerm);
                    _cmd.Parameters.AddWithValue("@LoanType", loan.LoanType);
                    _cmd.Parameters.AddWithValue("@LoanStatus", loan.LoanStatus);

                    _cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    return _cmd.ExecuteNonQuery();  // Execute the insert query
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while adding loan to the database", ex);
            }
        }

        // Update the status of a loan (e.g., Approved/Rejected based on credit score)
        public int UpdateLoanStatus(int loanId, string status)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    _cmd.CommandText = "UPDATE Loan SET LoanStatus = @LoanStatus WHERE LoanID = @LoanID";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@LoanID", loanId);
                    _cmd.Parameters.AddWithValue("@LoanStatus", status);

                    _cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    return _cmd.ExecuteNonQuery(); // Execute the update query
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while updating loan status", ex);
            }
        }

        // Delete a loan from the database
        public int DeleteLoan(int loanId)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
                {
                    _cmd.CommandText = "DELETE FROM Loan WHERE LoanID = @LoanID";
                    _cmd.Parameters.Clear();
                    _cmd.Parameters.AddWithValue("@LoanID", loanId);

                    _cmd.Connection = sqlConnection;
                    sqlConnection.Open();

                    return _cmd.ExecuteNonQuery();  // Execute the delete query
                }
            }
            catch (Exception ex)
            {
                throw new InvalidLoanException("Error while deleting loan", ex);
            }
        }
    }
}


