using System;


namespace SalesWebMVC.Services.Exceptions
{
    public class IntegreityException : ApplicationException
    {

        public IntegreityException(string message) : base(message) 
        { 
        }
    }
}
