using System.Drawing;
using System.Numerics;

namespace KulkiZadanie4
{
    public class Pilka : ObiektGry
    {
        public int PredkoscX { get; set; }
        public int PredkoscY { get; set; }
        public Pilka(int x, int y, int szerokosc, int wysokosc, int predkoscX, int predkoscY)
            : base(x, y, szerokosc, wysokosc)
        {
            PredkoscX = predkoscX;
            PredkoscY = predkoscY;
        }
        public void OdbijX()
        {
            PredkoscX = -PredkoscX;
        }
        public void OdbijY()
        {
            PredkoscY = -PredkoscY;
        }
        public void Uaktualnij()
        {
            Pozycja = new Point(Pozycja.X + PredkoscX, Pozycja.Y + PredkoscY);
        }
    }
}
