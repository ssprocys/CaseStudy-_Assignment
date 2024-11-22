using LoanManagementSystemApp.Exceptions;
using LoanManagementSystemApp.Models;
using LoanManagementSystemApp.Repository;
using System;
using System.Collections.Generic;

namespace LoanManagementSystemApp
{
    public class LoanManagement
    {
        private static LoanRepository loanRepository = new LoanRepository();

        // Show the main menu and handle user input
        public static void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("*****************************");
                Console.WriteLine("Welcome to the Loan Management System");
                Console.WriteLine("1. Apply Loan");
                Console.WriteLine("2. Calculate Interest");
                Console.WriteLine("3. Calculate EMI");
                Console.WriteLine("4. Loan Status (Based on Credit Score)");
                Console.WriteLine("5. Loan Repayment");
                Console.WriteLine("6. View All Loans");
                Console.WriteLine("7. Exit");
                Console.WriteLine("*****************************");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ApplyLoan();
                        break;
                    case "2":
                        CalculateInterest();
                        break;
                    case "3":
                        CalculateEMI();
                        break;
                    case "4":
                        LoanStatus();
                        break;
                    case "5":
                        LoanRepayment();
                        break;
                    case "6":
                        ViewAllLoans();
                        break;
                    case "7":
                        exit = true;
                        Console.WriteLine("Exiting the system...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("Press any key to go back to the main menu...");
                    Console.ReadKey();
                }
            }
        }

        // Apply a new loan
        private static void ApplyLoan()
        {
            try
            {
                Loan loan = new Loan();
                Console.Write("Enter Customer ID: ");
                loan.CustomerID = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Principal Amount: ");
                loan.PrincipalAmount = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Interest Rate (annual percentage): ");
                loan.InterestRate = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter Loan Term (in months): ");
                loan.LoanTerm = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Loan Type: ");
                loan.LoanType = Console.ReadLine();

                int result = loanRepository.ApplyLoan(loan);
                if (result > 0)
                {
                    Console.WriteLine("Loan application submitted successfully!");
                }
                else
                {
                    Console.WriteLine("Loan application was rejected.");
                }
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // Calculate loan interest
        private static void CalculateInterest()
        {
            try
            {
                Console.Write("Enter Loan ID to calculate interest: ");
                int loanId = Convert.ToInt32(Console.ReadLine());
                decimal interest = loanRepository.CalculateInterest(loanId);
                Console.WriteLine($"The interest for the loan is: {interest}");
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // Calculate EMI for a loan
        private static void CalculateEMI()
        {
            try
            {
                Console.Write("Enter Loan ID to calculate EMI: ");
                int loanId = Convert.ToInt32(Console.ReadLine());
                decimal emi = loanRepository.CalculateEMI(loanId);
                Console.WriteLine($"The EMI for the loan is: {emi}");
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // Update loan status based on credit score
        private static void LoanStatus()
        {
            try
            {
                Console.Write("Enter Loan ID: ");
                int loanId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Credit Score: ");
                int creditScore = Convert.ToInt32(Console.ReadLine());

                int result = loanRepository.LoanStatus(loanId, creditScore);
                if (result > 0)
                {
                    Console.WriteLine("Loan status updated successfully.");
                }
                else
                {
                    Console.WriteLine("Error updating loan status.");
                }
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // Repay the loan
        private static void LoanRepayment()
        {
            try
            {
                Console.Write("Enter Loan ID to repay: ");
                int loanId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter repayment amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                loanRepository.LoanRepayment(loanId, amount);
                Console.WriteLine("Loan repayment processed.");
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }

        // View all loans
        private static void ViewAllLoans()
        {
            try
            {
                List<Loan> loans = loanRepository.GetAllLoans();
                if (loans.Count > 0)
                {
                    Console.WriteLine("Listing all loans:");
                    foreach (var loan in loans)
                    {
                        Console.WriteLine($"Loan ID: {loan.LoanID}, Customer ID: {loan.CustomerID}, Status: {loan.LoanStatus}");
                    }
                }
                else
                {
                    Console.WriteLine("No loans found.");
                }
            }
            catch (InvalidLoanException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}
