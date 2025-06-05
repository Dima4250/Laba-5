using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laba_5
{
    public class TextProcessor
    {
        private Dictionary<string, string> errorDictionary;
        private readonly Regex phoneRegex = new Regex(@"\((\d{3})\)\s(\d{3})-(\d{2})-(\d{2})");

        public TextProcessor(Dictionary<string, string> errorDict)
        {
            errorDictionary = new Dictionary<string, string>(errorDict, StringComparer.OrdinalIgnoreCase);
        }

        public string CorrectSpellingErrors(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            string[] words = Regex.Split(text, @"(\W+)");
            for (int i = 0; i < words.Length; i++)
            {
                if (errorDictionary.TryGetValue(words[i], out string correctWord))
                {
                    words[i] = correctWord;
                }
            }
            return string.Concat(words);
        }

        public string ReformatPhoneNumbers(string text)
        {
            if (string.IsNullOrEmpty(text)) return text;

            return phoneRegex.Replace(text, match =>
            {
                string code = match.Groups[1].Value;
                string firstPart = match.Groups[2].Value;
                string secondPart = match.Groups[3].Value;
                string thirdPart = match.Groups[4].Value;
                return $"+380 {code} {firstPart} {secondPart} {thirdPart}";
            });
        }

        public string ProcessText(string text)
        {
            string correctedText = CorrectSpellingErrors(text);
            return ReformatPhoneNumbers(correctedText);
        }
    }
}
