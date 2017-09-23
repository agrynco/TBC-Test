using System;

namespace TBC_Test.Dependency
{
    public class DependencyInjectionException : Exception
    {
        public DependencyInjectionException(string message) : base(message)
        {
        }
    }
}