using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioScrapping.Exceptions
{
    public class CouldNotScrapWathcesLinksFromBasePageException : Exception
    {
        public CouldNotScrapWathcesLinksFromBasePageException()
        {
        }
        public CouldNotScrapWathcesLinksFromBasePageException(string message)
        : base(String.Format("Could not find links element from base page in order to collect message: {0}", message))
        {
        }

        public CouldNotScrapWathcesLinksFromBasePageException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
