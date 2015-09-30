/* Purpose: To create a menu that allows the user to go to different forms
 * Date of Completion: June 15, 2013
 * Teacher: Mr. Hsiung
 * Members: Junaid Ahmad, Karan Huynh, Donald Jung, Anish Chopra
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Mend_It_Mario
{
    public partial class MenuForm : Form
    {
        //menu form constructor
        public MenuForm()
        {
            InitializeComponent();
        }

        //when the start game button on the menu is clicked and the game form is loaded...
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            //set diffculty of time via framerate as an interval of 80
            int difficultyTime = 80;
            //set the number of birds as 1
            int numBirds = 1;
            //set the bird speed in terms of framerate as an interval of 5
            int birdSpeed = 5;
            //set the number of pwr up mushrooms to 2
            int numMushrooms = 2;
            //set the number of obstucle walls to stop mario to 2
            int numWalls = 2;
            //create array to hold the corriates of the obstcule walls
            int[,] wallCoords = new int[2, 2];
            //add the wall cordinates  to the array
            wallCoords[0, 0] = 2;
            wallCoords[1, 0] = 3;
            wallCoords[0, 1] = 1;
            wallCoords[1, 1] = 4;

            //using the streamwriter properties from the IO to write onto the difficulty 
            //text file and allow for overwriting 
            using (StreamWriter sw = new StreamWriter("infiniteGame.txt", false))
            {
                //print to the 1st line. the diffculty in terms of time
                sw.WriteLine(difficultyTime.ToString());
                //print to the 2nd line the number of walls on the gameform
                sw.WriteLine(numWalls.ToString());                
                //print to the 3rd line the number of mushrooms
                sw.WriteLine(numMushrooms.ToString());
                //print to the 4th line the number of bird on the gameform
                sw.WriteLine(numBirds.ToString());
                //print to the 5th line the speed of the birds
                sw.WriteLine(birdSpeed.ToString());
            }

            //resets the score
            ResetScore();

            //hide the menu form before loading the game form
            this.Hide();
            //create a game form
            GameForm frmGame = new GameForm(this, "infiniteGame.txt");
            //show the game form to the user
            frmGame.Show();
            
        }

        //when highscore button is clicked do the following 
        private void btnHighscores_Click(object sender, EventArgs e)
        {
            //hide the menu form 
            this.Hide();
            //create a new highscore form
            HighScoreForm frmHighScore = new HighScoreForm();
            //show highsore form
            frmHighScore.Show();
        }
        //When level editor is clicked
        private void btnLevelEditor_Click(object sender, EventArgs e)
        {
            //hide the menu form
            this.Hide();
            //create a level editor form
            LevelEditorForm frmLevelEditor = new LevelEditorForm();
            //shows the level editor form
            frmLevelEditor.Show();
        }
        //when load level is clicked
        private void btnLoadLevel_Click(object sender, EventArgs e)
        {
            string levelToLoad = txtLevelToLoad.Text + ".txt"; //stores the inputted file name
            //if the inputted file exists, load the game using that file
            if (File.Exists(levelToLoad))
            {
                //hide the menu form 
                this.Hide();
                //create a new game form form using the inputted file
                GameForm frmGame = new GameForm(this, levelToLoad);
                //show game form
                frmGame.Show();
                //resets the score
                ResetScore();
            }
            else
            {
                MessageBox.Show("This file does not exist.");
            }
        }

        //Resets the current score back to zero
        private void ResetScore()
        {
            //using the streamwriter properties from the IO to write onto the currentScore 
            //text file and allow for overwriting 
            using (StreamWriter sw2 = new StreamWriter("currentScore.txt", false))
            {
                //set the current score written as the first line as 0 
                sw2.WriteLine("0");
            }
        }
    }
}
