using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystemApp.Models
{
    public class Customer
    {
        private int customerID;
        private string name;
        private string emailAddress;
        private string phoneNumber;
        private string address;
        private int creditScore;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int CreditScore
        {
            get { return creditScore; }
            set { creditScore = value; }
        }

        // Default Constructor
        public Customer() { }

        // Parameterized Constructor
        public Customer(int customerID, string name, string emailAddress, string phoneNumber, string address, int creditScore)
        {
            this.customerID = customerID;
            this.name = name;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.creditScore = creditScore;
        }

        public override string ToString()
        {
            return $"CustomerID: {CustomerID}, Name: {Name}, Email: {EmailAddress}, Phone: {PhoneNumber}, Address: {Address}, CreditScore: {CreditScore}";
        }
    }
}
