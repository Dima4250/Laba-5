using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_5
{
    public class FileProcessingManager
    {
        private readonly TextFileManager fileManager;
        private readonly TextProcessor textProcessor;

        public FileProcessingManager(TextProcessor processor, TextFileManager manager)
        {
            textProcessor = processor;
            fileManager = manager;
        }

        public void ProcessFile(string directoryPath, string fileName)
        {
            try
            {
                string content = fileManager.OpenTextFile(directoryPath, fileName);
                if (content == null) return;

                string processedContent = textProcessor.ProcessText(content);
                fileManager.SaveTextFile(directoryPath, fileName, processedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке файла: {ex.Message}");
            }
        }
    }
}
