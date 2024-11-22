using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApp.Models
{
    public class Loan
    {
        private int loanID;
        private Customer customer;
        private decimal principalAmount;
        private decimal interestRate;
        private int loanTerm;
        private string loanType;
        private string loanStatus;

        public int LoanID
        {
            get { return loanID; }
            set { loanID = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public decimal PrincipalAmount
        {
            get { return principalAmount; }
            set { principalAmount = value; }
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }

        public int LoanTerm
        {
            get { return loanTerm; }
            set { loanTerm = value; }
        }

        public string LoanType
        {
            get { return loanType; }
            set { loanType = value; }
        }

        public string LoanStatus
        {
            get { return loanStatus; }
            set { loanStatus = value; }
        }

        public int CustomerID { get; internal set; }

        // Virtual Method to Calculate Interest
        public virtual decimal CalculateInterest()
        {
            return (PrincipalAmount * InterestRate * LoanTerm) / 12;
        }

        // Virtual Method to Calculate EMI
        public virtual decimal CalculateEMI()
        {
            decimal rate = InterestRate / 12 / 100;
            int months = LoanTerm;
            return (PrincipalAmount * rate * (decimal)Math.Pow((double)(1 + rate), months)) / ((decimal)Math.Pow((double)(1 + rate), months) - 1);
        }
    }
}

