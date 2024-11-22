using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApp.Models
{
    public class HomeLoan : Loan
    {
        private string propertyAddress;
        private decimal propertyValue;

        public string PropertyAddress
        {
            get { return propertyAddress; }
            set { propertyAddress = value; }
        }

        public decimal PropertyValue
        {
            get { return propertyValue; }
            set { propertyValue = value; }
        }

        // Constructor for Home Loan
        public HomeLoan(int loanID, Customer customer, decimal principalAmount, decimal interestRate, int loanTerm, string loanType, string loanStatus, string propertyAddress, decimal propertyValue)
        {
            LoanID = loanID;
            Customer = customer;
            PrincipalAmount = principalAmount;
            InterestRate = interestRate;
            LoanTerm = loanTerm;
            LoanType = loanType;
            LoanStatus = loanStatus;
            PropertyAddress = propertyAddress;
            PropertyValue = propertyValue;
        }
    }
}
