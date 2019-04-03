using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


class Tron
{
    static int sol = 0;
    static int sag = 1;
    static int yukari = 2;
    static int asagi = 3;


    static int birinciOyuncuSkor = 0;
    static int birinciOyuncuYon = sag;
    static int birinciOyuncuSutun = 0;
    static int birinciOyuncuSira = 0;


    static int ikinciOyuncuSkor = 0;
    static int ikinciOyuncuYon = sol;
    static int ikinciOyuncuSutun = 40;
    static int ikinciOyuncuSira = 5;


    static bool[,] kullanildiMi;


    static void Main(string[] args)
    {
        OyunAlani();
        EkraniBaslat();

        kullanildiMi = new bool[Console.WindowWidth, Console.WindowHeight];


        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                ChangePlayerDirection(key);
            }


            OyunculariHareketEttir();


            bool birinciOyuncuKaybederse = Kaybettir(birinciOyuncuSira, birinciOyuncuSutun);
            bool ikinciOyuncuKaybederse = Kaybettir(ikinciOyuncuSira, ikinciOyuncuSutun);


            if (birinciOyuncuKaybederse && ikinciOyuncuKaybederse)
            {
                birinciOyuncuSkor++;
                ikinciOyuncuSkor++;
                Console.WriteLine();
                Console.WriteLine("Oyun Bitti");
                Console.WriteLine("Eşit Oyun!");
                Console.WriteLine("Şuan ki skor: {0} - {1}", birinciOyuncuSkor, ikinciOyuncuSkor);
                OyunuYenile();
            }
            if (birinciOyuncuKaybederse)
            {
                ikinciOyuncuSkor++;
                Console.WriteLine();
                Console.WriteLine("Oyun Bitti");
                Console.WriteLine("2. Oyuncu kazandı!");
                Console.WriteLine("Şuan ki Skor: {0} - {1}", birinciOyuncuSkor, ikinciOyuncuSkor);
                OyunuYenile();
            }
            if (ikinciOyuncuKaybederse)
            {
                birinciOyuncuSkor++;
                Console.WriteLine();
                Console.WriteLine("Oyun Bitti");
                Console.WriteLine("1. Oyuncu kazandı!");
                Console.WriteLine("Şuan ki Skor: {0} - {1}", birinciOyuncuSkor, ikinciOyuncuSkor);
                OyunuYenile();
            }


            kullanildiMi[birinciOyuncuSutun, birinciOyuncuSira] = true;
            kullanildiMi[ikinciOyuncuSutun, ikinciOyuncuSira] = true;


            WriteOnPosition(birinciOyuncuSutun, birinciOyuncuSira, '*', ConsoleColor.Yellow);
            WriteOnPosition(ikinciOyuncuSutun, ikinciOyuncuSira, '*', ConsoleColor.Cyan);


            Thread.Sleep(100);
        }
    }


    static void EkraniBaslat()
    {
        string bas = "Basit bir tron oyunu";
        Console.Title = "Tron by Berk";
        Console.CursorLeft = Console.BufferWidth / 2 - bas.Length / 2;
        Console.WriteLine(bas);


        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Oyuncu 1'in kontrolleri:\n");
        Console.WriteLine("W - Yukarı");
        Console.WriteLine("A - Sol");
        Console.WriteLine("S - Aşağı");
        Console.WriteLine("D - Sağ");

        string longestString = "Oyuncu 2'nin kontrolleri:";
        int cursorLeft = Console.BufferWidth - longestString.Length;

        Console.CursorTop = 1;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.CursorLeft = cursorLeft;
        Console.WriteLine("Player 2's kontrolleri:");
        Console.CursorLeft = cursorLeft;
        Console.WriteLine("Üst Ok - Üst");
        Console.CursorLeft = cursorLeft;
        Console.WriteLine("Sol Ok - Sol");
        Console.CursorLeft = cursorLeft;
        Console.WriteLine("Aşağı Ok - Aşağı");
        Console.CursorLeft = cursorLeft;
        Console.WriteLine("Yukarı Ok - Sağ");

        Console.ReadKey();
        Console.Clear();
    }
    static void OyunuYenile()
    {
        kullanildiMi = new bool[Console.WindowWidth, Console.WindowHeight];
        OyunAlani();
        birinciOyuncuYon = sag;
        ikinciOyuncuYon = sol;
        Console.WriteLine("Oyuna tekrar başlamak için bir tuşa bas.");
        Console.ReadKey();
        Console.Clear();
        OyunculariHareketEttir();
    }


    static bool Kaybettir(int row, int col)
    {
        if (row < 0)
        {
            return true;
        }
        if (col < 0)
        {
            return true;
        }
        if (row >= Console.WindowHeight)
        {
            return true;
        }
        if (col >= Console.WindowWidth)
        {
            return true;
        }


        if (kullanildiMi[col, row])
        {
            return true;
        }


        return false;
    }


    static void OyunAlani()
    {
        Console.WindowHeight = 30;
        Console.BufferHeight = 30;


        Console.WindowWidth = 100;
        Console.BufferWidth = 100;


        /*
         * 
         * ->>>>            <<<<-
         * 
         */
        birinciOyuncuSutun = 0;
        birinciOyuncuSira = Console.WindowHeight / 2;


        ikinciOyuncuSutun = Console.WindowWidth - 1;
        ikinciOyuncuSira = Console.WindowHeight / 2;
    }


    static void OyunculariHareketEttir()
    {
        if (birinciOyuncuYon == sag)
        {
            birinciOyuncuSutun++;
        }
        if (birinciOyuncuYon == sol)
        {
            birinciOyuncuSutun--;
        }
        if (birinciOyuncuYon == yukari)
        {
            birinciOyuncuSira--;
        }
        if (birinciOyuncuYon == asagi)
        {
            birinciOyuncuSira++;
        }


        if (ikinciOyuncuYon == sag)
        {
            ikinciOyuncuSutun++;
        }
        if (ikinciOyuncuYon == sol)
        {
            ikinciOyuncuSutun--;
        }
        if (ikinciOyuncuYon == yukari)
        {
            ikinciOyuncuSira--;
        }
        if (ikinciOyuncuYon == asagi)
        {
            ikinciOyuncuSira++;
        }
    }


    static void WriteOnPosition(int x, int y, char ch, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.SetCursorPosition(x, y);
        Console.Write(ch);
    }


    static void ChangePlayerDirection(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.W && birinciOyuncuYon != asagi)
        {
            birinciOyuncuYon = yukari;
        }
        if (key.Key == ConsoleKey.A && birinciOyuncuYon != sag)
        {
            birinciOyuncuYon = sol;
        }
        if (key.Key == ConsoleKey.D && birinciOyuncuYon != sol)
        {
            birinciOyuncuYon = sag;
        }
        if (key.Key == ConsoleKey.S && birinciOyuncuYon != yukari)
        {
            birinciOyuncuYon = asagi;
        }


        if (key.Key == ConsoleKey.UpArrow && ikinciOyuncuYon != asagi)
        {
            ikinciOyuncuYon = yukari;
        }
        if (key.Key == ConsoleKey.LeftArrow && ikinciOyuncuYon != sag)
        {
            ikinciOyuncuYon = sol;
        }
        if (key.Key == ConsoleKey.RightArrow && ikinciOyuncuYon != sol)
        {
            ikinciOyuncuYon = sag;
        }
        if (key.Key == ConsoleKey.DownArrow && ikinciOyuncuYon != yukari)
        {
            ikinciOyuncuYon = asagi;
        }
    }
}
