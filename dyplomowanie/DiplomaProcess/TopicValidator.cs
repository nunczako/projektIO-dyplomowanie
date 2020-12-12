using dyplomowanie.DiplomaProcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dyplomowanie.DiplomaProcess
{
    //klasa sprawdzajaca czy w temacie pracy znajduja sie zakazane slowa
    public class TopicValidator : IValidator
    {
        public bool IsTopicCorrect(string topic)
        {
            //definicja tablicy stringów zawierających słowa zakazane w temacie pracy
            string[] forbidden = { "przekleństwo", "pomidor", "kurczak" };
            //konwersja wyrazów do dużych liter aby zweryfikować temat niezależnie od formy w jakiej został podany wyraz
            forbidden = forbidden.Select(s => s.ToUpperInvariant()).ToArray();
            // rozdzielanie wszystkich wyrazow w temacie
            string[] wordArray = Regex.Split(topic, @"\W+");
            //konwersja wyrazów do dużych liter aby zweryfikować temat niezależnie od formy w jakiej został podany wyraz
            wordArray = wordArray.Select(s => s.ToUpperInvariant()).ToArray();

            // pętla sprawdzająca czy zakazany wyraz pojawia się w temacie
            foreach (string word in wordArray)
            {
                if (forbidden.Contains(word))
                {
                    // wyraz został znaleziony - temat nie może zostać ustawiony na podany
                    return false;
                }
            }
            // zakazane wyrazy nie zostały znalezione - temat jest ok
            return true;
        }

    }
}
