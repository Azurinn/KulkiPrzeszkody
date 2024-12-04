using System.Drawing;
using System.Numerics;

namespace KulkiZadanie4
{
    public abstract class ObiektGry
    {
        public Point Pozycja { get; set; }
        public Size Rozmiar { get; set; }
        public ObiektGry(int x, int y, int szerokosc, int wysokosc)
        {
            Pozycja = new Point(x, y);
            Rozmiar = new Size(szerokosc, wysokosc);
        }
    }
}
