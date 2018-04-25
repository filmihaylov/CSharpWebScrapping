using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioScrapping.Exceptions
{
    public class InvalidWatchPageUrlException : Exception
    {
        public InvalidWatchPageUrlException()
        {
        }
        public InvalidWatchPageUrlException(string message)
        : base(String.Format("Invalid Watch Page Url message : {0}", message))
        {
        }

        public InvalidWatchPageUrlException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
