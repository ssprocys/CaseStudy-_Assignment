using System;

namespace LoanManagementSystemApp.Exceptions
{
    public class InvalidLoanException : Exception
    {
        public InvalidLoanException() { }

        public InvalidLoanException(string message) : base(message) { }

        public InvalidLoanException(string message, Exception inner) : base(message, inner) { }
    }
}
