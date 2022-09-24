using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TopDownRacer
{
   
    public partial class Form1 : Form
    {
        //global variables
        int carSpeed = 5;
    int roadSpeed = 5;
    bool carLeft;
        bool carRight;
        int trafficSpeed = 5; // how fast traffic will travel down screen
        int Score = 0;
    Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            Reset();
        }
        private void Reset()
        {
            trophy.Visible = false; // hide the trophy until we are ready

            button1.Enabled = false; //disable the button when game is running

            explosion.Visible = false; //hide explosion until we are ready for it

            trafficSpeed = 5; // set the traffic back to default

            roadSpeed = 5; // set the road speed back to default

            Score = 0; // reset score to zero

            player.Left = 161; // reset player left
            player.Top = 286; // reset player at top

            carLeft = false; // reset the moving left to false

            carRight = false; // reset moving right to false

            //move the AI to default position off screen
            AI1.Left = 66;
            AI1.Top = -120;

            AI2.Left = 294;
            AI2.Top = -185;

            //reset the roads back to their default
            roadTrack2.Left = -3;
            roadTrack2.Top = -222;
            roadTrack1.Left = -2;
            roadTrack1.Top = -638;

            // start the timer
            gameTimer.Start();


        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Score++; //increase score as we move

            distance.Text = "" + Score; // show the score on the distance label

            roadTrack1.Top += roadSpeed; // move the track 1 down with the +=
            roadTrack2.Top += roadSpeed;

            //if the track has gone past -630 then we set it back to default
            //seamless animation
            if (roadTrack1.Top > 630)
            {
                roadTrack1.Top = -630;
            }
            if (roadTrack2.Top > 630)
            {
                roadTrack2.Top = -630;
            }
           // end of track animation

        }
    }
}
