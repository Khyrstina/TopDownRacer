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

            if (carLeft) { player.Left -= carSpeed; } 
            //move car left if car left is true
            if (carRight) { player.Left += carSpeed; }
            // move the car right if the car right is true

            //end of car moving

            //bounce the car off the boundaries of the panel
            if (player.Left < 1)
            {
                carLeft = false; //stop the car from going off screen
            }
            else if (player.Left + player.Width > 380)
            {
                carRight = false;
            }
            //end of the boundaries

            //move the AI cars down
            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;

            //respawn the AIs and change their images
            if (AI1.Top > panel1.Height)
            {
                changeAI1();// change AI car images once they have left the scene
                AI1.Left = rnd.Next(2, 160); //random numbers where they appear on the left
                AI1.Top = rnd.Next(100, 200) * -1; // random numbers where they appear on top
            }
            if (AI2.Top > panel1.Height)
            {
                changeAI2(); //change the AI car images once they leave the scene
                AI2.Left = rnd.Next(185, 327);
                AI2.Top = rnd.Next(100, 200) * -1;
            }
            // end of respawning the AIs and images changin
        

            //checking multiple conditions for hit test player and AI
            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver(); 
            }
            // end of hit testing the player

            //speed up the traffic & checking for conditions
            
            if (Score > 100 && Score < 500)
            {
                trafficSpeed = 6;
                roadSpeed = 7;
            }
            
            if (Score > 500 && Score < 1000)
            {
                trafficSpeed = 7;
                roadSpeed = 8;
            }

            else if (Score > 1200)
            {
                trafficSpeed = 9;
                roadSpeed = 10;
            }
            //end of traffic speeding up
        }

        private void moveCar(object sender, KeyEventArgs e)
        {
            //if the player pressed the left key & the player is inside the panel
            //then car left boolean = true
            if (e.KeyCode == Keys.Left && player.Left >0)
            {
                carLeft = true;
            }
            //same but with car right boolean = true
            if (e.KeyCode == Keys.Right && player.Left + player.Width < panel1.Width)
                    {
                carRight = true;
            }
        }

        private void stopCar(object sender, KeyEventArgs e)
        {
            // if the left key is up then car left is false
            if (e.KeyCode == Keys.Left)
            {
                carLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                carRight = false;
            }
        }
        private void changeAI1()
        {
            int num = rnd.Next(1, 8); 
            // local variable generates a number between 1-8
            //we will use that to show any image based on that number
            //switch statement will check which number and display images as requested
            switch (num)
            {

                case 1:
                    AI1.Image = Properties.Resources.carGreen;
                    break;

                case 2:
                    AI1.Image = Properties.Resources.carGrey;
                    break;

                case 3:
                    AI1.Image = Properties.Resources.carOrange;
                    break;

                case 4:
                    AI1.Image = Properties.Resources.carPink;
                    break;

                case 5:
                    AI1.Image = Properties.Resources.CarRed;
                    break;

                case 6:
                    AI1.Image = Properties.Resources.TruckBlue;
                    break;

                case 7:
                    AI1.Image = Properties.Resources.TruckWhite;
                    break;

                case 8:
                    AI1.Image = Properties.Resources.ambulance;
                    break;
                default:
                    break;
            }
        }

        private void changeAI2()
        {
            int num = rnd.Next(1, 8);
            // local variable generates a number between 1-8
            //we will use that to show any image based on that number
            //switch statement will check which number and display images as requested
            switch (num)
            {

                case 1:
                    AI2.Image = Properties.Resources.carGreen;
                    break;

                case 2:
                    AI2.Image = Properties.Resources.carGrey;
                    break;

                case 3:
                    AI2.Image = Properties.Resources.carOrange;
                    break;

                case 4:
                    AI2.Image = Properties.Resources.carPink;
                    break;

                case 5:
                    AI2.Image = Properties.Resources.CarRed;
                    break;

                case 6:
                    AI2.Image = Properties.Resources.TruckBlue;
                    break;

                case 7:
                    AI2.Image = Properties.Resources.TruckWhite;
                    break;

                case 8:
                    AI2.Image = Properties.Resources.ambulance;
                    break;
                default:
                    break;
            }
        }
        private void gameOver()
        {
            trophy.Visible = true;

            gameTimer.Stop();

            button1.Enabled = true;

            //showing the explosion on top of the car
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(- 8, 5);

            explosion.BackColor = Color.Transparent;
            explosion.BringToFront(); // puts this over the car not under

            //final score trophy
            if (Score < 1000)
            {
                trophy.Image = Properties.Resources.bronze;
            }

            if (Score > 2000)
            {
                trophy.Image = Properties.Resources.silver;
            }

            if (Score > 3500)
            {
                trophy.Image = Properties.Resources.gold;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
