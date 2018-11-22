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
            Scherm scherm;
            scherm = new Scherm();
            Application.Run(new Scherm());
        }

    }
    //Form class
    //liefst hier nog toevoegen dat de knoppen in eerste instantie automatisch centreren ongeacht schermformaat (anders laten zoals het is - berekend op een 1920x1080px scherm)
    class Scherm : Form
    {
        //Declaraties
        public DateTime Starttijd; DateTime Reactietijd;
        public Button reactie; Button start;
        public Random rnd;
        public Point startplek; Point reactieplek1; Point reactieplek2; Point muisplek;
        public int r3;

        //Form method
        public Scherm()
        {
            this.Text = "Fitts' Law";
            this.BackColor = Color.CadetBlue;
            this.WindowState = FormWindowState.Maximized;

            //Random Number Generator
            rnd = new Random();
            int r1 = rnd.Next(1870);
            Thread.Sleep(9);
            int r2 = rnd.Next(1030);
            Thread.Sleep(3);
            r3 = rnd.Next(30, 500);

            //Locaties
            startplek = new Point(300,100);
            reactieplek1 = new Point(r1, r2);

            //'Start' knop
            start = new Button
            {
                Text = "Click here",
                Font = new Font("Comic Sans MS", 20),
                Location = startplek,
                BackColor = Color.BlueViolet,
                Size = new Size(100, 100),
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
            start.Click += start_klik;
            reactie.Click += reactie_klik;

        }
        //Event Handlers   
        void start_klik(object sender, EventArgs e)
        {
            start.Visible = !start.Visible;
            reactie.Visible = !reactie.Visible;

            Starttijd = DateTime.Now;

            muisplek = MousePosition;
        }

        void reactie_klik(object sender, EventArgs e)
        {
            start.Visible = !start.Visible;
            reactie.Visible = !reactie.Visible;

            int r4 = rnd.Next(80, 500);
            reactie.Size = new Size(r4, r4);
            Thread.Sleep(5);
            int r5 = rnd.Next(1870);
            Thread.Sleep(11);
            int r6 = rnd.Next(1030);
            reactieplek2 = new Point(r5, r6);
            reactie.Location = reactieplek2;

            double dx = reactieplek2.X - muisplek.X;
            double dy = reactieplek2.Y - muisplek.Y;
            double dpx = Math.Sqrt((dx * dx) + (dy * dy));
            Console.WriteLine("D: " + dpx);
 
            Console.WriteLine("W: " + r3);
            Console.WriteLine("ID: " + Math.Log((2*dpx / r3), 2.0));
            Console.WriteLine("T: ");

            Reactietijd = DateTime.Now;
            TimeSpan elapsedSpan = (Reactietijd - Starttijd);
            Console.WriteLine("time: " + elapsedSpan);
        }
    }
}
