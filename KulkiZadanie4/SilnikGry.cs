using System;
using System.Collections.Generic;
using System.Drawing;

namespace KulkiZadanie4
{
    public class SilnikGry
    {
        public Pilka pilka;
        public Gracz gracz;
        public List<Blok> bloki;
        public int Punkty { get; set; }
        private Random random;
        public SilnikGry()
        {
            random = new Random();
            ZainicjalizujGre();
        }
        public void ZainicjalizujGre()
        {
            pilka = new Pilka(383, 374, 20, 20, 5, 5);
            gracz = new Gracz(339, 400, 100, 20, 20);
            bloki = new List<Blok>();

            int szerokoscBloku = 100;
            int wysokoscBloku = 32;
            int top = 50;
            int left = 100;
            int kolumny = 5;
            int wiersze = 3;

            for (int x = 0; x < wiersze; x++)
            {
                for (int y = 0; y < kolumny; y++)
                {
                    bloki.Add(new Blok(left + (y * (szerokoscBloku + 30)), top + (x * (wysokoscBloku + 20)), szerokoscBloku, wysokoscBloku));
                }
            }
            Punkty = 0;
        }
        public void zaktualizujGre(int szerokoscEkranu)
        {
            pilka.Uaktualnij();
            sprawdzKolizje(szerokoscEkranu);
        }
        private void sprawdzKolizje(int szerokoscEkranu)
        {
            if (pilka.Pozycja.X < 0 || pilka.Pozycja.X + pilka.Rozmiar.Width > szerokoscEkranu)
            {
                pilka.OdbijX();
            }
            if (pilka.Pozycja.Y < 0)
            {
                pilka.OdbijY();
            }
            if (pilka.Pozycja.Y + pilka.Rozmiar.Height >= gracz.Pozycja.Y &&
                pilka.Pozycja.X + pilka.Rozmiar.Width >= gracz.Pozycja.X &&
                pilka.Pozycja.X <= gracz.Pozycja.X + gracz.Rozmiar.Width)
            {
                pilka.PredkoscX = random.Next(5, 12) * (pilka.PredkoscX < 0 ? -1 : 1);
                pilka.OdbijY();
            }
            for (int i = bloki.Count - 1; i >= 0; i--)
            {
                Blok blok = bloki[i];
                var obrysBloku = new Rectangle(blok.Pozycja, blok.Rozmiar);
                var obrysPilki = new Rectangle(pilka.Pozycja, pilka.Rozmiar);
                if (obrysPilki.IntersectsWith(obrysBloku))
                {
                    bool uderzWGoreLubWDol = pilka.Pozycja.Y + pilka.Rozmiar.Height >= blok.Pozycja.Y &&
                                          pilka.Pozycja.Y <= blok.Pozycja.Y + blok.Rozmiar.Height;
                    bool uderzWLewoLubWPrawo = pilka.Pozycja.X + pilka.Rozmiar.Width >= blok.Pozycja.X &&
                                          pilka.Pozycja.X <= blok.Pozycja.X + blok.Rozmiar.Width;
                    if (uderzWGoreLubWDol)
                    {
                        pilka.OdbijY();
                    }
                    else if (uderzWLewoLubWPrawo)
                    {
                        pilka.OdbijX();
                    }
                    bloki.RemoveAt(i);
                    Punkty++;
                }
            }
        }
        public bool graWygrana()
        {
            return bloki.Count == 0;
        }
        public bool graPrzegrana()
        {
            return pilka.Pozycja.Y > 440;
        }
        public void usunBlok(int x, int y)
        {
            var blokDoUsuniecia = bloki.FirstOrDefault(b => b.Pozycja.X == x && b.Pozycja.Y == y);
            if (blokDoUsuniecia != null)
            {
                bloki.Remove(blokDoUsuniecia);
            }
        }
    }
}
