using System.Text;
using System.IO;
using System.Text.Json;

//задание 1
// namespace File_System
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Random random = new Random();
//             List<int> numbers = new List<int>();
//             List<int> prosteNumbers = new List<int>();
//             List<int> fibonacciNumbers = new List<int>();
//             for (int i = 0; i < 100; i++)
//             {
//                 numbers.Add(random.Next(1, 101));
//             }
//             foreach (int number in numbers)
//             {
//                 if (IsProste(number))
//                 {
//                     prosteNumbers.Add(number);
//                 }
//             }
//             foreach (int number in numbers)
//             {
//                 if (IsFibonacci(number))
//                 {
//                     fibonacciNumbers.Add(number);
//                 }
//             }
//             File.WriteAllLines("prosti_chicla.txt",prosteNumbers.Select((n=>n.ToString())));
//             File.WriteAllLines("fibonacci_chicla.txt",fibonacciNumbers.Select((n=>n.ToString())));
//             Console.WriteLine("Всего чисел: "+numbers.Count);
//             Console.WriteLine("Простых: "+ prosteNumbers.Count);
//             Console.WriteLine("Fibonacci: "+ fibonacciNumbers.Count);
//             static bool IsProste(int number)
//             {
//                 if (number <= 1)
//                     return false;
//                 for (int i = 2; i < Math.Sqrt(number); i++)
//                 {
//                     if (number % i == 0)
//                         return false;
//                 }
//
//                 return true;
//             }
//             static bool IsFibonacci(int number)
//             {
//                 int a = 0, b = 1;
//                 while (a < number)
//                 {
//                     int temp = a;
//                     a = b;
//                     b = temp + b;
//                 }
//                 return a == number;
//             }
//         }
//     }
// }



//задание 2
// internal class Program
// {
//     static void Main(string[] args)
//     {
//         try
//         {
//             Console.WriteLine("Введите путь к файлу: ");
//             string filename = Console.ReadLine();
//             Console.WriteLine("Введите слово для поиска: ");
//             string poisk = Console.ReadLine();
//             Console.WriteLine("Введите слово для замены: ");
//             string zamena= Console.ReadLine();
//             string filecontent = File.ReadAllText(filename);
//             int count = Podshet(filecontent, poisk);
//             string zamenaslov = filecontent.Replace(poisk, zamena);
//             File.WriteAllText(filename,zamenaslov);
//             Console.WriteLine($"Количество замененных слов: {count}");
//
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.Message);
//         }
//
//         static int Podshet(string text, string word)
//         {
//             int count = 0;
//             int index = text.IndexOf(word, StringComparison.OrdinalIgnoreCase);
//             while (index!=-1)
//             {
//                 count++;
//                 index = text.IndexOf(word, index + word.Length, StringComparison.OrdinalIgnoreCase);
//             }
//             return count;
//         }
//         
//     }
//}


//задание 3
// namespace File_System
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             try
//             {
//                 Console.WriteLine("Введите путь к файлу: ");
//                 string filename = Console.ReadLine();
//                 Console.WriteLine("Введите путь к файлу cо словами для модерации: ");
//                 string moderationfilename = Console.ReadLine();
//                 string text = File.ReadAllText(filename);
//                 string[] moderationwords = File.ReadAllLines(moderationfilename);
//                 foreach (string word in moderationwords)
//                 {
//                     text = text.Replace(word, new string('*', word.Length), StringComparison.OrdinalIgnoreCase);
//                 }
//
//                 string moderationfilepath = Path.Combine(Path.GetDirectoryName(filename),$"moderated_{Path.GetFileName(filename)}");
//                 File.WriteAllText(moderationfilepath,text);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"Ошибка: {ex.Message}");
//             }
//         }
//     }
// }
//



//задание 4
// namespace File_System
// {
//     [Serializable]
//     public class Text
//     {
//         public string Text2 { get; set; }
//
//         public Text(string text)
//         {
//             Text2 = text;
//         }
//     }
//
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Введите путь к файлу:");
//             string filePath = Console.ReadLine();
//             string newFilePath = ReverseFileContent(filePath);
//             Console.WriteLine($"Новый файл с перевернутым текстом: {newFilePath}");
//         }
//         static string ReverseFileContent(string filePath)
//         {
//             Text textfile = SerializeFile(filePath);
//             ReverseText(textfile);
//             string newFilePath = Path.Combine(Path.GetDirectoryName(filePath), "perevernuti_" + Path.GetFileName(filePath));
//             SaveContentToFile(newFilePath, textfile);
//             return newFilePath;
//         }
//         static Text SerializeFile(string filePath)
//         {
//             string text = File.ReadAllText(filePath);
//             Text textfile = new Text(text);
//             string jsonFile = JsonSerializer.Serialize(textfile);
//             File.WriteAllText("serialized_text.json", jsonFile);
//             return textfile;
//         }
//         static void ReverseText(Text textfile)
//         {
//             char[] reversedArray = textfile.Text2.ToCharArray();
//             Array.Reverse(reversedArray);
//             textfile.Text2 = new string(reversedArray);
//         }
//         static void SaveContentToFile(string filePath, Text textfile)
//         {
//             File.WriteAllText(filePath, textfile.Text2);
//         }
//     }
// }


//задание 5
// namespace File_System
// {
//     [Serializable]
//     public class Text
//     {
//         public string Text2 { get; set; }
//         public Text(string text)
//         {
//             Text2 = text;
//         }
//     }
//
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Console.WriteLine("Введите путь к файлу:");
//             string filePath = Console.ReadLine();
//             AnalyzeFile(filePath);
//         }
//
//         static void AnalyzeFile(string filePath)
//         {
//             Text textfile = Serialize(filePath);
//             List<int> numbers = ParseNumbers(textfile);
//             Dictionary<string, List<int>> analysis = AnalyzeNumbers(numbers);
//             Save(analysis);
//             Console.WriteLine($"Положительных чисел: {analysis["positives"].Count}");
//             Console.WriteLine($"Отрицательных чисел: {analysis["negatives"].Count}");
//             Console.WriteLine($"Двузначных чисел: {analysis["twoDigits"].Count}");
//             Console.WriteLine($"Пятизначных чисел: {analysis["fiveDigits"].Count}");
//         }
//
//         static Text Serialize(string filePath)
//         {
//             string text = File.ReadAllText(filePath);
//             Text textfile = new Text(text);
//             string jsonFile = JsonSerializer.Serialize(textfile);
//             File.WriteAllText("serialized_numbers.json", jsonFile);
//             return textfile;
//         }
//
//         static List<int> ParseNumbers(Text textfile)
//         {
//             string[] numberStrings = textfile.Text2.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
//             List<int> numbers = new List<int>();
//             foreach (string numberString in numberStrings)
//             {
//                 if (int.TryParse(numberString, out int number))
//                 {
//                     numbers.Add(number);
//                 }
//             }
//             return numbers;
//         }
//         static Dictionary<string, List<int>> AnalyzeNumbers(List<int> numbers)
//         {
//             Dictionary<string, List<int>> analysis = new Dictionary<string, List<int>>
//             {
//                 { "positives", new List<int>() },
//                 { "negatives", new List<int>() },
//                 { "twoDigits", new List<int>() },
//                 { "fiveDigits", new List<int>() }
//             };
//
//             foreach (int number in numbers)
//             {
//                 if (number > 0)
//                 {
//                     analysis["positives"].Add(number);
//                 }
//                 if (number < 0)
//                 {
//                     analysis["negatives"].Add(number);
//                 }
//                 if (Math.Abs(number) >= 10 && Math.Abs(number) < 100)
//                 {
//                     analysis["twoDigits"].Add(number);
//                 }
//                 if (Math.Abs(number) >= 10000 && Math.Abs(number) < 100000)
//                 {
//                     analysis["fiveDigits"].Add(number);
//                 }
//             }
//             return analysis;
//         }
//
//         static void Save(Dictionary<string, List<int>> analysis)
//         {
//             File.WriteAllLines("positives.txt", analysis["positives"].ConvertAll(n => n.ToString()));
//             File.WriteAllLines("negatives.txt", analysis["negatives"].ConvertAll(n => n.ToString()));
//             File.WriteAllLines("two_digits.txt", analysis["twoDigits"].ConvertAll(n => n.ToString()));
//             File.WriteAllLines("five_digits.txt", analysis["fiveDigits"].ConvertAll(n => n.ToString()));
//         }
//     }
// }