using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dajkstra_2022_3_9_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Koliko cvorova?");
            int n = Convert.ToInt32(Console.ReadLine());
            Graf_M novi = new Graf_M(n);
            novi.popuni();
            int[] resenje = novi.Dajkstra(0);
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(novi.Cvor[i] + ": " + resenje[i]);
            }
        }
    }
    class Graf_M
    {
        public int Broj_cvorova;
        public int[,] Matr;
        public string[] Cvor;

        public Graf_M(int n)
        {
            Broj_cvorova = n;
            Cvor = new string[n];
            Matr = new int[n, n];
        }
        public void popuni()
        {
            Broj_cvorova = 7;
            Cvor = new string[] { "A", "B", "C", "D", "E", "F", "G" };
            Matr = new int[,] {
            { 6, 5, 0, 0, 0, 0, 0 },
            { 6, 0, 0, 3, 1, 0, 0 } ,
            { 5, 0, 0, 0, 4, 0, 0 },
            { 0,3,0,0,1,2,0 },
            { 0,1,4,1,0,5,0 },
            { 0,0,0,2,5,0,8 },
            { 0,0,0,0,0,0,8 }
            };
        }
        public void Unesi()
        {
            for (int i = 0; i < Broj_cvorova; i++)
            {
                Console.WriteLine("Naziv " + (i + 1) + " cvora= ");
                Cvor[i] = Console.ReadLine();
            }
            for (int i = 0; i < Broj_cvorova; i++)
            {
                for (int j = 0; j < Broj_cvorova; j++)
                {
                    if (i != j)
                    {
                        Console.WriteLine(Cvor[i] + " - " + Cvor[j] + " = ");
                        Matr[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
                }
            }
        }
        public int[] Dajkstra(int pocetak)
        {
            bool[] posecen = new bool[Broj_cvorova];
            int[] duzina = new int[Broj_cvorova];
            for (int i = 0; i < Broj_cvorova; i++)
            {
                duzina[i] = 999;
                posecen[i] = false;
            }
            duzina[pocetak] = 0;
            bool gotovo = false;
            while (!gotovo)
            {
                for (int i = 0; i < Broj_cvorova; i++)
                {
                    if (i == pocetak) continue;
                    if (Matr[pocetak, i] != 0)
                    {
                        if (duzina[pocetak] + Matr[pocetak, i] < duzina[i])
                            duzina[i] = duzina[pocetak] + Matr[pocetak, i];
                    }
                }
                int br = 0;
                int koliko = 0;
                for (; br < Broj_cvorova; br++)
                {
                    if (posecen[br] == false) break;
                    else koliko++;
                }
                if (koliko == Broj_cvorova)
                {
                    gotovo = true;
                    break;
                }
                int min = duzina[br];
                int pos = br;
                for (int i = 0; i < Broj_cvorova; i++)
                {
                    if (posecen[i] == false)
                    {
                        if (duzina[i] < min)
                        {
                            min = duzina[i];
                            pos = i;
                        }
                    }
                }
                posecen[pocetak] = true;
                pocetak = pos;
            }
            return duzina;
        }
    }
}

