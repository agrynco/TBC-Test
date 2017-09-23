using System;

namespace TBC_Test.DAL.Abstract.Exceptions
{
    public class DalException : Exception
    {
        public DalException()
        {
        }

        public DalException(string message) : base(message)
        {
        }

        public DalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}