using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    public class ErrorDictionaryManager
    {
        private Dictionary<string, string> errorDictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public void FillDictionaryManually()
        {
            Console.WriteLine("Заполнение словаря ошибочных слов (для завершения введите 'exit')");

            while (true)
            {
                Console.Write("Введите правильное слово: ");
                string correctWord = Console.ReadLine();

                if (correctWord.ToLower() == "exit") break;

                Console.WriteLine("Вводите ошибочные варианты (для завершения введите 'done'):");
                List<string> errors = new List<string>();

                while (true)
                {
                    Console.Write("Ошибочный вариант: ");
                    string error = Console.ReadLine();

                    if (error.ToLower() == "done") break;
                    if (error.ToLower() == "exit") return;

                    errors.Add(error);
                }

                foreach (var error in errors)
                {
                    if (!errorDictionary.ContainsKey(error))
                    {
                        errorDictionary.Add(error, correctWord);
                    }
                }
            }
        }

        public Dictionary<string, string> GetErrorDictionary()
        {
            return new Dictionary<string, string>(errorDictionary);
        }

        public void DisplayDictionary()
        {
            Console.WriteLine("\nТекущий словарь ошибочных слов:");
            foreach (var pair in errorDictionary)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
