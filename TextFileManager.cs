using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    public class TextFileManager
    {
        public string CreateTextFile(string directoryPath, string fileName, string content)
        {
            try
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, fileName);
                File.WriteAllText(filePath, content, Encoding.UTF8);
                return filePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
                return null;
            }
        }

        public string OpenTextFile(string directoryPath, string fileName)
        {
            try
            {
                string filePath = Path.Combine(directoryPath, fileName);
                if (File.Exists(filePath))
                {
                    return File.ReadAllText(filePath, Encoding.UTF8);
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
                return null;
            }
        }

        public void DisplayFileContent(string directoryPath, string fileName)
        {
            try
            {
                string filePath = Path.Combine(directoryPath, fileName);
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"\nСодержимое файла {fileName}:");
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(File.ReadAllText(filePath));
                    Console.WriteLine("----------------------------------------");
                }
                else
                {
                    Console.WriteLine("Файл не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при отображении файла: {ex.Message}");
            }
        }

        public void SaveTextFile(string directoryPath, string fileName, string content)
        {
            try
            {
                string filePath = Path.Combine(directoryPath, fileName);
                File.WriteAllText(filePath, content, Encoding.UTF8);
                Console.WriteLine("Файл успешно сохранен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}
