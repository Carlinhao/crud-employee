using System;
using System.Globalization;

namespace employers.application.Exceptions.RegraNegocio
{
    public class RegranegocioException : Exception
    {
        public RegranegocioException() : base() { }

        public RegranegocioException(string message) : base(message) { }

        public RegranegocioException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
