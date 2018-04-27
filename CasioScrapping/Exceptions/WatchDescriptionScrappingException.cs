using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioScrapping.Exceptions
{
    public class WatchDescriptionScrappingException : Exception
    {
        public WatchDescriptionScrappingException()
        {
        }
        public WatchDescriptionScrappingException(string message)
        : base(String.Format("Scrapped Watch Description Erorr: {0}", message))
        {
        }

        public WatchDescriptionScrappingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
