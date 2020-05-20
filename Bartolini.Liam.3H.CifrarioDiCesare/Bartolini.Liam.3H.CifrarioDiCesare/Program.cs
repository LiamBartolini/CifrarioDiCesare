using System;

namespace Bartolini.Liam._3H.CifrarioDiCesare
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFrase;
            int key;
            Console.WriteLine("Cifrario di Cesare, Bartolini Liam");
            
            do
            {
                Console.WriteLine("Inserisci la stringa da cifrare: ");
                strFrase = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(strFrase))
                    Console.WriteLine("Inserire una frase!");

            } while (String.IsNullOrWhiteSpace(strFrase));

            do
            {
                Console.WriteLine("Inserisci la chiave di cifratura: ");
                string strChiave = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(strChiave))
                    Console.WriteLine("Inserire un numero!");


                int.TryParse(strChiave, out key);

            } while ((Decimal)key > 58 && (Decimal)key < 47);
            

            string cifrata = cifraMessaggio(strFrase, key);
            Console.WriteLine("La frase cifrata è: {0}", cifrata);

            Console.WriteLine("Se vuoi decifrare il messaggio scrivere 'si': ");
            string strConferma = Console.ReadLine();

            if (strConferma == "si")
            {
                string decifrata = decifraMessaggio(cifrata, key);
                Console.WriteLine("La frase decifrata è: {0}", decifrata);
            }
            else
                Console.WriteLine("Programma terminato");
        }

        static string cifraMessaggio(string frase, int key)
        {
            string alfabeto = "abcdefghijklmnopqrstuvwxyz";
            char[] a = alfabeto.ToCharArray();
            char[] p = frase.ToCharArray();
            int cont = 0;

            for(int i = 0; i < p.Length; i++)
            {
                p[i] = (char)((byte)p[i] + key);

                if((char)p[i] > 122)
                {
                    p[i] = a[cont];
                    cont++;
                }
            }

            return new string(p);
        }

        static string decifraMessaggio(string frase, int key)
        {
            char[] p = frase.ToCharArray();

            int j;
            string c = "";
            for(int i = 0; i < p.Length; i++)
            {
                j = (int)p[i] - key;

                if (j < 65)
                    j += 25;

                c += (char)j;
            }

            return c;
        }
    }
}