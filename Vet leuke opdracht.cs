using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hallo
{
    class Help
    {
        static void Main()
        {
            Scherm scherm; //kennelijk moest dit dus hier staan???
            scherm = new Scherm();
            Application.Run(new Scherm());
        }
    }
}

//Form
class Scherm : Form
{
    public Scherm()
    {
        this.Text = "Fitts' Law";
        this.BackColor = Color.CadetBlue;
        this.WindowState = FormWindowState.Maximized;
       
//Locaties
        Point startplek; Point beginplek;
        startplek = new Point(200, 200); beginplek = new Point(400, 200);

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

//'Begin' knop
        Button begin;
        begin = new Button
        {
            Text = "Click here",
            Font= new Font("Comic Sans MS", 20),
            Location = beginplek,
            BackColor = Color.HotPink,
            Size = new Size(100, 100),
        };
        
        this.Controls.Add(start);
        this.Controls.Add(begin);
    }
}