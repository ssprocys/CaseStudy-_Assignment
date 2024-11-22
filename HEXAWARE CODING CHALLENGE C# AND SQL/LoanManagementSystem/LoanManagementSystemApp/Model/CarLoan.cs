using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApp.Models
{
    public class CarLoan : Loan
    {
        private string carModel;
        private decimal carValue;

        public string CarModel
        {
            get { return carModel; }
            set { carModel = value; }
        }

        public decimal CarValue
        {
            get { return carValue; }
            set { carValue = value; }
        }

        // Constructor for Car Loan
        public CarLoan(int loanID, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus, string carModel, decimal carValue)
        {
            LoanID = loanID;
            Customer = customer;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            LoanType = loanType;
            LoanStatus = loanStatus;
            CarModel = carModel;
            CarValue = carValue;
        }
    }
}

