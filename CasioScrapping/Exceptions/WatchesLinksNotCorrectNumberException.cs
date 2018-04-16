using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasioShopBgScrapping.Exceptions
{
    public class WatchesLinksNotCorrectNumberException : Exception
    {
        public WatchesLinksNotCorrectNumberException()
        {
        }
        public WatchesLinksNotCorrectNumberException(string message)
        : base(String.Format("Invalid Links Collected, Current Links Number: {0}", message))
        {
        }

        public WatchesLinksNotCorrectNumberException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
