using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace Hallo
{
    class Help


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
        public DateTime Starttijd;
        public DateTime Reactietijd;

        //Random Number Generator
        public void RNG()
        {
            Random rnd = new Random();
            int r1 = rnd.Next(1870);
            Thread.Sleep(9);
            int r2 = rnd.Next(1030);
            Thread.Sleep(3);
            int r3 = rnd.Next(30, 500);
            Thread.Sleep(17);
            int r4 = rnd.Next(30, 500);
        }
        //Form method
        public Scherm()
        {
            this.Text = "Fitts' Law";
            this.BackColor = Color.CadetBlue;
            this.WindowState = FormWindowState.Maximized;

            //Locaties
            Point startplek; Point reactieplek;
            startplek = new Point(910, 490); reactieplek = new Point(400, 200);

            //'Start' knop
            Button start;
            start = new Button
            {
                Text = "Click here",
                Font = new Font("Comic Sans MS", 20),
                Location = startplek,
                BackColor = Color.BlueViolet,
                Size = new Size(100, 100),
            };

            //'Reactie' knop
            Button reactie;
            reactie = new Button
            {
                Text = "Click here",
                Font = new Font("Comic Sans MS", 20),
                Location = reactieplek,
                BackColor = Color.HotPink,
                Size = new Size(100, 100),
                Visible = false,
            };

            this.Controls.Add(start);
            this.Controls.Add(reactie);
            start.Click += start_klik;
            reactie.Click += reactie_klik;




            //daadwerkelijke functionaliteit van de knoppen          
            void start_klik(object sender, EventArgs e)
            {
                start.Visible = false;
                reactie.Visible = true;
                DateTime Starttijd = DateTime.Now;


            }

            void reactie_klik(object sender, EventArgs e)
            {
                start.Visible = true;
                reactie.Visible = false;
                reactie.Size = new Size(200, 200);
                DateTime Reactietijd = DateTime.Now;
                long elapsedTicks = Reactietijd.Ticks - Starttijd.Ticks;
                TimeSpan elapsedSpan = new TimeSpan(elapsedTicks);
                Console.WriteLine(elapsedSpan);
            }
        }

    }

}