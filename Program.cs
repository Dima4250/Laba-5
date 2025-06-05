using Laba_5;
using System.Text;


class Program
{
    static void Main(string[] args)
    {
        // Инициализация менеджеров
        var errorDictManager = new ErrorDictionaryManager();
        var fileManager = new TextFileManager();

        // 1. Заполнение словаря ошибок
        errorDictManager.FillDictionaryManually();
        errorDictManager.DisplayDictionary();

        // Создаем процессор с текущим словарем
        var textProcessor = new TextProcessor(errorDictManager.GetErrorDictionary());
        var processingManager = new FileProcessingManager(textProcessor, fileManager);

        // 2. Работа с файлами
        Console.WriteLine("\nРабота с текстовыми файлами");
        Console.Write("Введите директорию для работы с файлами: ");
        string directoryPath = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1 - Создать новый файл");
            Console.WriteLine("2 - Открыть и обработать существующий файл");
            Console.WriteLine("3 - Просмотр содержимого файла");
            Console.WriteLine("4 - Выход");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewFile(directoryPath, fileManager);
                    break;
                case "2":
                    ProcessExistingFile(directoryPath, processingManager);
                    break;
                case "3":
                    ViewFileContent(directoryPath, fileManager);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void CreateNewFile(string directoryPath, TextFileManager fileManager)
    {
        Console.Write("Введите имя файла (с расширенем .txt): ");
        string fileName = Console.ReadLine();

        Console.WriteLine("Введите текст (для завершения введите 'END' на новой строке):");
        StringBuilder content = new StringBuilder();
        string line;

        while ((line = Console.ReadLine()) != "END")
        {
            content.AppendLine(line);
        }

        string filePath = fileManager.CreateTextFile(directoryPath, fileName, content.ToString());
        if (filePath != null)
        {
            Console.WriteLine($"Файл успешно создан: {filePath}");
        }
    }

    static void ProcessExistingFile(string directoryPath, FileProcessingManager processingManager)
    {
        Console.Write("Введите имя файла для обработки: ");
        string fileName = Console.ReadLine();

        processingManager.ProcessFile(directoryPath, fileName);
    }

    static void ViewFileContent(string directoryPath, TextFileManager fileManager)
    {
        Console.Write("Введите имя файла для просмотра: ");
        string fileName = Console.ReadLine();

        fileManager.DisplayFileContent(directoryPath, fileName);
    }
}
