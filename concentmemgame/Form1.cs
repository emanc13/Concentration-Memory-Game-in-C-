using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace concentmemgame
{
    public partial class Form1 : Form
    {
        //Create an instance of random
        Random random = new Random();


        List<string> icons = new List<string>()
        {
            "T", "T", "Q", "Q", "a", "a", "w", "w",
            "x", "x", "E", "E", "m", "m", "U", "U"
        };

        //Click history
        Label firstClicked, secondClicked;
        public Form1()
        {
            InitializeComponent();
            AssignIcons(); // call icons to assign to squares
        }

        
        private void label_Click(object sender, EventArgs e)
        {
            
            if (firstClicked != null && secondClicked != null)
                return;

            
            Label clickedLabel = sender as Label;

            if (clickedLabel == null)
                return;

            
            if (clickedLabel.ForeColor == Color.Black)
                return;

            
            if (firstClicked == null)
            {
                firstClicked = clickedLabel;
                firstClicked.ForeColor = Color.Black;
                return;
            }

            secondClicked = clickedLabel;
            secondClicked.ForeColor = Color.Black;

            CheckForWinner();
            //winner! function(icons dont fade)
            
            if (firstClicked.Text == secondClicked.Text)
            {
                firstClicked = null;
                secondClicked = null;
            }
            else
                
                timer1.Start();            
        }

        private void CheckForWinner()
        {
            Label label; 
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                label = tableLayoutPanel1.Controls[i] as Label;

                if (label != null && label.ForeColor == label.BackColor)
                    return;
                
            }

            MessageBox.Show("Winner! Icons matched!");
            Close(); 
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            
            firstClicked = null;
            secondClicked = null;
        }

        
        private void AssignIcons()
        {
            Label label;
            int randomNumber;

            
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                if (tableLayoutPanel1.Controls[i] is Label)
                    label = (Label)tableLayoutPanel1.Controls[i];
                else
                    continue;

                
                randomNumber = random.Next(0, icons.Count);// choose anything from 0 to any icon in list
                label.Text = icons[randomNumber];

                
                icons.RemoveAt(randomNumber);
            }
        }
    }
}
