using RavSoft.GoogleTranslator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate
{
    public class TranslatorWrapper
    {
        public string translateEnglishToBulgarian(string EnglishText)
        {
            Translator t = new Translator();
            string bulgarian = t.Translate(EnglishText, "English", "Bulgarian");
            return bulgarian;
        }

        public string translateBulgarianToEnglish(string BulgarianText)
        {
            Translator t = new Translator();
            string english = t.Translate(BulgarianText, "Bulgarian", "English");
            return english;
        }
    }
}
