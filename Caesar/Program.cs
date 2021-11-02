using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Caesar
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alfabet = "AĄBCĆDEĘFGHIJKLŁMNOPQRSTUVWXYZaąbcćdefghijklłmńoópqrsśtuwxyz1234567890".ToCharArray();
            Console.WriteLine("Wybierz opcje");
            Szyfruj(alfabet);
            Deszyfruj(alfabet);
            Porownaj();
        }

        private static void Szyfruj(char[] alfabet)
        {
            Console.WriteLine("Podaj Słowo");
            string napis = Console.ReadLine().Replace(" ", string.Empty);
            Console.WriteLine("Podaj Klucz");
            int klucz = Convert.ToInt32(Console.ReadLine());

            char[] słowoEncrypted = new char[napis.Length];

            for (int i = 0; i < napis.Length; i++)
            {
                int a = Array.IndexOf(alfabet, napis[i]) + klucz;
                if (a < alfabet.Length)
                {
                    słowoEncrypted[i] = alfabet[a];
                }
                else
                {
                    słowoEncrypted[i] = alfabet[a - alfabet.Length];
                }

            }
            foreach (var item in słowoEncrypted)
            {
                Console.Write(item);
            }
            Console.WriteLine(" ");


        }
        private static void Deszyfruj(char[] alfabet)
        {
            Console.WriteLine("Podaj Słowo");
            string napis = Console.ReadLine().Replace(" ", string.Empty);

            //Zapis
            string szyfry = @"szyfry.txt";
            StreamWriter sw;
            if (!File.Exists(szyfry))
            {
                sw=File.CreateText(szyfry);
            }
            else
            {
                sw = new StreamWriter(szyfry,false);
            }

            char[] słowoEncrypted = new char[napis.Length];
            for (int j = 1; j < alfabet.Length; j++)
            {
                for (int i = 0; i < napis.Length; i++)
                {
                    int a = Array.IndexOf(alfabet, napis[i]) + j;
                    if (a < alfabet.Length)
                    {
                        słowoEncrypted[i] = alfabet[a];
                    }
                    else
                    {
                        słowoEncrypted[i] = alfabet[a - alfabet.Length];
                    }
                    
                }
                sw.WriteLine(słowoEncrypted);
                
            }
            sw.Close();


        }
        private static void Porownaj()
        {
            string path = @"szyfry.txt";
            string slownik = @"słowa.txt";
            List <string> szyfry = new List <string>();
            List<char> szyfryy = new List<char>();
            StreamReader sr = File.OpenText(path);
            string s;
            
            if (File.Exists(path))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    szyfry.Add(s);
                }
            }
            else
            {
                Console.WriteLine("Błąd");
            }
            sr = File.OpenText(slownik);

            if (File.Exists(slownik))
            {
                while ((s = sr.ReadLine()) != null)
                {
                    
                    if (szyfry.Any(x=>szyfry.Contains(s)))
                    {
                        Console.WriteLine(s+" ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Błąd");
            }

        }

    }
}
