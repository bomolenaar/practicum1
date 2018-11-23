using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Practicum1
{
    class Run
    {
        static void Main()
        {
             Application.Run(new Scherm());
        }

    }
    //Form class
    class Scherm : Form
    {
        //Declaraties
        public DateTime Starttijd; DateTime Reactietijd;
        public Button reactie; Button start;
        public Random rnd;
        public Point reactieplek1; Point reactieplek2; Point muisplek;
        public Graphics g;
        public double dpi, dx, dy, dpx, d;
        public int r1, r2, r3;
        public int sb, sh, knopformaat; 

        //Form method
        public Scherm()
        {
            this.Text = "Fitts' Law";
            this.BackColor = Color.CadetBlue;
            this.WindowState = FormWindowState.Maximized;

            //Schermformaat
            sb = Screen.GetWorkingArea(this).Width;
            sh = Screen.GetWorkingArea(this).Height;
            knopformaat = sh / 10;

            //D
            g = this.CreateGraphics();
            dpi = g.DpiX;
           
            //Random Number Generator
            rnd = new Random();
            r3 = rnd.Next(80, 400);
            Thread.Sleep(3);
            r1 = rnd.Next((0), (sb - r3));
            Thread.Sleep(9);
            r2 = rnd.Next((0), (sh - r3));

            //Locaties
            reactieplek1 = new Point(r1, r2);

            //'Start' knop
            start = new Button
            {
                Text = "Click here",
                Font = new Font("Comic Sans MS", 20),
                Left = (sb - knopformaat) / 2,
                Top = (sh- knopformaat) / 2,
                BackColor = Color.BlueViolet,
                Size = new Size(knopformaat, knopformaat),
                Visible = true,
            };


            //'Reactie' knop
            reactie = new Button
            {
                Text = "Click here",
                Font = new Font("Comic Sans MS", 20),
                Location = reactieplek1,
                BackColor = Color.HotPink,
                Size = new Size(r3, r3),
                Visible = false,
            };

            this.Controls.Add(start);
            this.Controls.Add(reactie);
            start.Click +=Start_klik;
            reactie.Click += Reactie_klik;

        }
        //Event Handlers
       void Start_klik(object sender, EventArgs e)
        {
            start.Visible = !start.Visible;
            reactie.Visible = !reactie.Visible;

            Starttijd = DateTime.Now;

            muisplek = MousePosition;
        }

        void Reactie_klik(object sender, EventArgs e)
        {
            start.Visible = !start.Visible;
            reactie.Visible = !reactie.Visible;

            r3 = rnd.Next(80, 400);
            Thread.Sleep(3);
            r1 = rnd.Next((0), (sb - r3));
            Thread.Sleep(9);
            r2 = rnd.Next((0), (sh - r3));
            reactie.Size = new Size(r3, r3);
            reactieplek2 = new Point(r1, r2);
            reactie.Location = reactieplek2;

            dx = reactieplek2.X - muisplek.X;
            dy = reactieplek2.Y - muisplek.Y;
            dpx = Math.Sqrt((dx * dx) + (dy * dy));
            d = (dpx / dpi) * 2.54;

            Reactietijd = DateTime.Now;
            TimeSpan elapsedSpan = (Reactietijd - Starttijd);

            Console.WriteLine(  d + "\t" +
                                r3 + "\t" +
                                Math.Log((1 + d / r3), 2.0) + "\t" +
                                elapsedSpan);
        }
    }
}