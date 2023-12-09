using System;
using System.IO;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args) 
        {
           if(args.Length > 0){
              if(args[0] == "-c" || args[0] == ""){
                block1();
              } else if(args[0] == "-f"){ 
                block2(args[1]);
              } else {
                Console.WriteLine("Вы ввели недопустимый флаг.");
              }
           } 
        }
        public static void block1(){
            Console.WriteLine("Ввод символов с клавиатуры осуществляется через пробел:");
            string input = Console.ReadLine();
            string [] symbols = input.Split(' ');
            int summa = 0;
            int count = 0;
            foreach(string symbol in symbols){
                if(int.TryParse(symbol, out _)){
                    continue;
                }
                if(symbol.Length > 0){
                    char ch = symbol[0];
                    if(!char.IsDigit(ch)){
                        summa += (int)ch;
                        count++;
                    }
                }
            }
            double average = summa / count;
            Console.WriteLine("Среднее арифметическое символов в соответствии с таблицей ASCII кодов равно " + average);
        }

        public static void block2(string path){
            try{
                if(File.Exists(path)){
                    string data = File.ReadAllText(path);
                    int summa = 0;
                    int count = 0;
                   foreach (char c in data)
                    {
                        summa += (int)c; 
                        count++;
                    }
                    double average = summa / count;
                Console.WriteLine("Среднее арифметическое символов в соответствии с таблицей ASCII кодов равно " + average);

                } else{
                    Console.WriteLine("В данной дериктории указанного файла нету! Проверьте путь и название файла!");
                }
            } catch (Exception excep) {
                Console.WriteLine("При открытии/чтении файла " + excep.Message + " возникла ошибка");
            }
        }
    }
}