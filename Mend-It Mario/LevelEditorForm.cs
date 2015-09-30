/* Purpose: To allow the user to adjust the difficulty of the game by saving the changes to a file
 * Date of Completion: June 15, 2013
 * Teacher: Mr. Hsiung
 * Members: Junaid Ahmad, Karan Huynh, Donald Jung, Anish Chopra*/
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
    public partial class LevelEditorForm : Form
    {
        //Creates an edit to adjust the level to the user's requirements
        LevelEditor edits = new LevelEditor();
        public LevelEditorForm()
        {
            InitializeComponent();
        }
        //Tells user details to difficulty assignments
        private void txtDifficulty_TextChanged_1(object sender, EventArgs e)
        {
            //User warning
            lblDisplayMessage.Text = "Please enter a value between 20 - 80" + "\n" + "\n20 is the most difficult" + "\n80 is the easiest";
        }
        //Runs when the save button is clicked
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //Stores the desired difficulty
            edits.Difficulty(txtDifficulty.Text);
            //Stors the desired number of walls
            edits.NumWalls(txtNumWalls.Text);
            //Stores the desired number of mushrooms
            edits.NumMushrooms(txtNumMushrooms.Text);
            //Stores the desired number of birds
            edits.NumBirds(txtNumBirds.Text);
            //Stores the desired bird speed
            edits.BirdSpeed(txtBirdSpeed.Text);
            
            //Loops through all possible errors in input
            for (int i = 0; i < edits.errorMessages.Length; i++)
            {
                //Displays errors with inputs to user
                lblDisplayMessage.Text = edits.errorMessages[i];

            }
            //stores the inputted file name
            string fileName = txtFileName.Text + ".txt";
            //if the file exists, then prompt the user to input a new file name
            if (File.Exists(fileName))
            {
                //prompt the user to input a new file name
                MessageBox.Show("File already exists. Please enter a new name.");
                //exits the subprogram
                return;
            }
            edits.WriteToFile(fileName);
            btnReturn.Visible = true;
        }
        //Blanks out messages to user
        private void txtNumWalls_TextChanged_1(object sender, EventArgs e)
        {
            //clears the message label
            lblDisplayMessage.Text = "";
        }
        //Blanks out messages to user
        private void txtNumMushrooms_TextChanged_1(object sender, EventArgs e)
        {
            //clears the message label
            lblDisplayMessage.Text = "";
        }
        //Blanks out messages to user
        private void txtNumBirds_TextChanged_1(object sender, EventArgs e)
        {
            //clears the message label
            lblDisplayMessage.Text = "";
        }
        //Tells user details to birdspeed assignments
        private void txtBirdSpeed_TextChanged_1(object sender, EventArgs e)
        {
            //User Warning
            lblDisplayMessage.Text = "Please enter a value between 5 - 20" + "\n" + "\n5 is the slowest" + "\n20 is the fastest";
        }
        //Returns user to main user menu
        private void btnReturn_Click_1(object sender, EventArgs e)
        {
            //creates a new menu form
            MenuForm frmMenu = new MenuForm();
            //show the menu window
            frmMenu.Show();
            //hides current level editor window
            this.Hide();
            //hide the menu form 
       
        }
    }
}
