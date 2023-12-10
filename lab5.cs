using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args) 
        {
           if(args.Length > 0){
              if(args[0] == "-c" || args[0] == ""){
                blockConsole();
              } else if(args[0] == "-f"){ 
                blockFile(args[1]);
              } else {
                Console.WriteLine("Вы ввели недопустимый флаг.");
              }
           } 
        }
        public static void blockConsole(){
            Console.WriteLine("Введите предложение:");
            string str = Console.ReadLine();
            string[] words = changeString(str);
            Console.WriteLine("Выберите один из следующих пунктов а, b, c, d, e.");
            char symbol = Console.ReadLine()[0];
            blockWorkPoint(symbol, words);

        }
        public static void blockFile(string path){
            string str;
            try{
                str = File.ReadAllText(path);
            } catch (Exception ex){
                Console.WriteLine("При чтении файла по адресу \"" + path + "\" возникла ошибка.\n" + ex.Message);
                return;
            }
            string[] words = changeString(str);
            Console.WriteLine("Выберите один из следующих пунктов а, b, c, d, e.");
            char symbol = Console.ReadLine()[0];
            blockWorkPoint(symbol, words);
        }
        public static string[] changeString(string str){
            int dotIndex = str.IndexOf('.');
            string newStr = dotIndex != -1 ? str.Substring(0, dotIndex) : str;
            string[] words = str.Split(new char[] { ':', ' ', ',', '.', '!', '?', '-', '\\', '|', '/', '*', '-', '+'}, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
        public static void blockWorkPoint(char symbol, string[] words){
                switch(symbol){
                    case 'a':
                    blockA(words);
                    break;
                    case 'b':
                    blockB(words);
                    break;
                    case 'c':
                    blockC(words);
                    break;
                    case 'd':
                    blockD(words);
                    break;
                    case 'e':
                    blockE(words);
                    break;
                }
        }
        public static void blockA(string[] words)
        {
            Array.Sort(words);
            words = words.Where(word => word.Length > 3).ToArray();
            Console.WriteLine("Укажите три буквы, на которые должно оканчиваться слово:");
            string letters = Console.ReadLine();
            string found = Array.Find(words, word => word.Length >= 3 && word.EndsWith(letters, StringComparison.OrdinalIgnoreCase));
            if (found != null)
            {
                Console.WriteLine("Такое слово найдено " + found);
            }
            else
            {
                Console.WriteLine("Такого слова с последними тремя буквами " + letters + " не найдено.");
            }
        }  
        public static void blockB(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0)
                    {
                        char[] letters = words[i].ToCharArray();
                        letters[0] = char.ToUpper(letters[0]); 
                        letters[letters.Length - 1] = char.ToLower(letters[letters.Length - 1]); 
                        words[i] = new string(letters);
                    }
                }
                for (int i = 0; i < words.Length; i++)
                {
                    Console.WriteLine(words[i]);
                }
        }
        public static void blockC(string[] words)
        {
            Console.WriteLine("Введите слово, которое надо будет найти в предложении:");
            string searchWord = Console.ReadLine();
            int сount = 0;
            foreach (string word in words)
            {
                if (word.Equals(searchWord, StringComparison.OrdinalIgnoreCase))
                {
                    сount++;
                }
            }
            Console.WriteLine("В предложении найдено " + сount + " слов.");
        }   
        public static void blockD(string[] words)
        {
            Console.WriteLine("Введите слово, на которое будет заменено препоследнее слово в предложении:");
            string newWord = Console.ReadLine();
            if (words.Length >= 2)
            {
                words[words.Length - 2] = newWord;
            }
            else
            {
                Console.WriteLine("Длина строки не позволяет осуществить замену предпоследнего слова.");
            }
        } 
        public static void blockE(string[] words)
        {
            Console.WriteLine("Введите число от 1 до " + words.Length + ":");
            int position = Convert.ToInt32(Console.ReadLine());
            if (position >= 1 && position <= words.Length)
            {
                Console.WriteLine("Выбранное слово: " + words[position - 1].Substring(0, 1).ToUpper() + words[position - 1].Substring(1).ToLower());
            }
            else
            {
                Console.WriteLine("Вы ввели число, которое превышает количество слов в предложении.");
            }
        } 
    }
}