namespace Wizualizacja
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            LiczbaPunktow = new Label();
            gracz = new PictureBox();
            pilka = new PictureBox();
            czasomierz = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)gracz).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pilka).BeginInit();
            SuspendLayout();
            // 
            // LiczbaPunktow
            // 
            LiczbaPunktow.AutoSize = true;
            LiczbaPunktow.Font = new Font("Calibri", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            LiczbaPunktow.ForeColor = Color.White;
            LiczbaPunktow.Location = new Point(12, 9);
            LiczbaPunktow.Name = "LiczbaPunktow";
            LiczbaPunktow.Size = new Size(84, 23);
            LiczbaPunktow.TabIndex = 0;
            LiczbaPunktow.Text = "Punkty: 0";
            // 
            // gracz
            // 
            gracz.BackColor = Color.White;
            gracz.Location = new Point(339, 432);
            gracz.Name = "gracz";
            gracz.Size = new Size(100, 32);
            gracz.TabIndex = 1;
            gracz.TabStop = false;
            // 
            // pilka
            // 
            pilka.BackColor = Color.Yellow;
            pilka.Location = new Point(383, 374);
            pilka.Name = "pilka";
            pilka.Size = new Size(20, 20);
            pilka.TabIndex = 1;
            pilka.TabStop = false;
            // 
            // czasomierz
            // 
            czasomierz.Interval = 16;
            czasomierz.Tick += eventyWykorzystujaceCzasomierz;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 476);
            Controls.Add(pilka);
            Controls.Add(gracz);
            Controls.Add(LiczbaPunktow);
            Name = "Form1";
            Text = "Kulki";
            KeyDown += przyciskWcisniety;
            KeyUp += przyciskOdcisniety;
            ((System.ComponentModel.ISupportInitialize)gracz).EndInit();
            ((System.ComponentModel.ISupportInitialize)pilka).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LiczbaPunktow;
        private PictureBox gracz;
        private PictureBox pilka;
        private System.Windows.Forms.Timer czasomierz;
    }
}
