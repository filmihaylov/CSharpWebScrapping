using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceExchange.Exceptions
{
    public class UnableToGetExchangeRateException : Exception
    {
        public UnableToGetExchangeRateException()
        {
        }
        public UnableToGetExchangeRateException(string message)
        : base(String.Format("Unable to Get Exchange Rate : {0}", message))
        {
        }

        public UnableToGetExchangeRateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
