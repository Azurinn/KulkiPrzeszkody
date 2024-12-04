using KulkiZadanie4;

namespace Wizualizacja
{
    public partial class Form1 : Form
    {
        private SilnikGry silnikGry;
        private bool idzWLewo;
        private bool idzWPrawo;
        private bool graSkonczona;
        private List<PictureBox> blokiPictureBox = new List<PictureBox>();
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            silnikGry = new SilnikGry();
            ZainicjalizujBloki();
            czasomierz.Start();
        }

        private void eventyWykorzystujaceCzasomierz(object sender, EventArgs e)
        {
            if (!graSkonczona)
            {
                if (idzWLewo)
                {
                    silnikGry.gracz.IdzWLewo();
                }
                if (idzWPrawo)
                {
                    silnikGry.gracz.IdzWPrawo(this.ClientSize.Width);
                }

                silnikGry.zaktualizujGre(this.ClientSize.Width);
                uaktualnijWizualizacje();

                if (silnikGry.graPrzegrana())
                {
                    koniecGry("Przegrales!! Wcisnij enter by zagrac ponownie.");
                }
                else if (silnikGry.graWygrana())
                {
                    koniecGry("Wygrales!! Wcisnij enter by zagrac ponownie.");
                }
            }
        }

        private void ZainicjalizujBloki()
        {
            foreach (Blok bloki in silnikGry.bloki)
            {
                PictureBox pb = new PictureBox
                {
                    BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
                    Tag = "bloki",
                    Width = bloki.Rozmiar.Width,
                    Height = bloki.Rozmiar.Height,
                    Left = bloki.Pozycja.X,
                    Top = bloki.Pozycja.Y
                };

                blokiPictureBox.Add(pb);
                this.Controls.Add(pb);
            }
        }

        private void uaktualnijWizualizacje()
        {
            uaktualnijPozycjeGraczaIPilki();
            usunZniszczoneBloki();
            uaktualnijLicznikPunktow();
        }

        private void uaktualnijPozycjeGraczaIPilki()
        {
            pilka.Left = silnikGry.pilka.Pozycja.X;
            pilka.Top = silnikGry.pilka.Pozycja.Y;
            gracz.Left = silnikGry.gracz.Pozycja.X;
        }

        private void usunZniszczoneBloki()
        {
            var blokiDoUsuniecia = blokiPictureBox
                .Where(pb => !silnikGry.bloki.Any(b => b.Pozycja.X == pb.Left && b.Pozycja.Y == pb.Top))
                .ToList();

            foreach (PictureBox pb in blokiDoUsuniecia)
            {
                blokiPictureBox.Remove(pb);
                this.Controls.Remove(pb);
                pb.Dispose();
            }
        }
        private void uaktualnijLicznikPunktow()
        {
            LiczbaPunktow.Text = "Punkty: " + silnikGry.Punkty;
        }
        private void koniecGry(string wiadomosc)
        {
            graSkonczona = true;
            czasomierz.Stop();
            LiczbaPunktow.Text = "Punkty: " + silnikGry.Punkty + " " + wiadomosc;
        }
        private void przyciskWcisniety(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                idzWLewo = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                idzWPrawo = true;
            }
        }
        private void przyciskOdcisniety(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                idzWLewo = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                idzWPrawo = false;
            }
            if (e.KeyCode == Keys.Enter && graSkonczona)
            {
                graSkonczona = false;
                silnikGry.ZainicjalizujGre();
                ZresetujBloki();
                czasomierz.Start();
            }
        }
        private void ZresetujBloki()
        {
            foreach (PictureBox pb in blokiPictureBox)
            {
                this.Controls.Remove(pb);
                pb.Dispose();
            }
            blokiPictureBox.Clear();
            ZainicjalizujBloki();
        }
    }
}
