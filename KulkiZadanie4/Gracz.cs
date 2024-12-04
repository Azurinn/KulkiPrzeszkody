using System.Drawing;

namespace KulkiZadanie4
{
    public class Gracz : ObiektGry
    {
        public int Predkosc { get; set; }
        public Gracz(int x, int y, int szerokosc, int wysokosc, int predkosc)
            : base(x, y, szerokosc, wysokosc)
        {
            Predkosc = predkosc;
        }
        public void IdzWLewo()
        {
            if (Pozycja.X > 0)
                Pozycja = new Point(Pozycja.X - Predkosc, Pozycja.Y);
        }
        public void IdzWPrawo(int szerokoscEkranu)
        {
            if (Pozycja.X + Rozmiar.Width < szerokoscEkranu)
                Pozycja = new Point(Pozycja.X + Predkosc, Pozycja.Y);
        }
    }
}