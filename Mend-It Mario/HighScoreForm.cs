/* Purpose: To save and display the top 10 highscores of the main (infinite) game
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
    public partial class HighScoreForm : Form
    {        
        //double array to hold all the highscores taken from the saved file
        private double[] highscores = new double[10];
        //private string varible to hold the name of the highscore text file that all highscore data is saved in
        private string highscoreFile = "highscores.txt";

        //overload constructor for highscore form to hold all overload changes with a parameter of score interger from the gameform 
        public HighScoreForm(int score)
        {
            InitializeComponent();

            //get all the highscores by calling the properties of the ReadHighScoreFile subprogram
            highscores = ReadHighScoreFile();
            //only add the highscore if its less than the current score of the user 
            if (highscores[9] < score)
            {
                //add the user's score to the array of highscores 
                highscores[9] = score;
            }

            //call subprogram to set up the details of the form
            SetUpForm();

        }

        //base constructor for the highscore form with all the default values of the form
        public HighScoreForm()
        {
            InitializeComponent();
            //highscores array will be filled out by the subprogram "ReadHighScoreFile"
            highscores = ReadHighScoreFile();
            //setupform subprogram is called 
            SetUpForm();
        }

        //subprogram for displaying the highscores to the user in a list box
        private void DisplayHighScores(double[] highscores)
        {
            lstHighscores.Items.Clear();
            //run through an index loop to print out the top 10 scores to the user 
            for (int index = 0; index < 10; index++)
            {
                //add each index of the highscores to the highscore list box as an item
                lstHighscores.Items.Add(Convert.ToString(highscores[index]));
            }
        }

        //subprogram to write the sorted highscores to the highscores text file
        private void WriteHighScoreFile(double[] highscores)
        {
            //using the streamwriter item from the IO library gain access to the text file with highscores on computer
            using (StreamWriter writer = new StreamWriter(highscoreFile))
            {
                //loop through index to print out the scores in the array into a text file to save them 
                for (int index = 0; index < highscores.Length ; index++)
                {
                    //print each score on each line
                    writer.WriteLine(highscores[index]);
                }
            }
        }
        
        //subprogram to sort the highscores from highest to lowest
        private void SelectionSort(double[] highscores)
        {
            /* Count through all the indexes so that we sort all of them.
             * We don't need to sort the last index because they will 
             * already be sorted.  That is why we "- 1" */
            for (int indexOfNextPositionToSort = 0; indexOfNextPositionToSort < highscores.Length - 1; indexOfNextPositionToSort++)
            {

                // This stores the index of what we think is the smallest element
                // at the current point
                int indexOfLargestElement = indexOfNextPositionToSort;

                /* Count through all the indexes so we can compare if they are
                 * smaller than our current "smallest" */
                for (int indexOfElementToCompare = indexOfLargestElement + 1; indexOfElementToCompare < highscores.Length; indexOfElementToCompare++)
                {
                    /* If we have found something bigger */
                    if (highscores[indexOfElementToCompare] > highscores[indexOfLargestElement])
                    {
                        indexOfLargestElement = indexOfElementToCompare;
                    }
                }

                /* When the counting loop exits, we know that 
                 * indexOfSmallestElement will be correct.  We should
                 * swap the smallest element into the front of the array*/

                // Temporarily store the smallest element so we don't lose it
                double temp = highscores[indexOfLargestElement];
                // Move the first element where the smallest used to be
                highscores[indexOfLargestElement] = highscores[indexOfNextPositionToSort];
                // Move the smallest element into the front of the array
                highscores[indexOfNextPositionToSort] = temp;

            }
        }

        //subprogram to read the highscores from the text file on the computer that has stored them
        private double[] ReadHighScoreFile()
        {
            //using streamreader from the IO library read the file for all the saved highscores
            using (StreamReader reader = new StreamReader(highscoreFile))
            {
                //loop through indexes and fill the array for the highscores so that they may be analysised 
                for (int index = 0; index < highscores.Length; index++)
                {
                    //read each line as the scores are seperated by line in the file
                    highscores[index] = Convert.ToDouble(reader.ReadLine());
                }                
            }

            //return the highscores array to the main subprogram
            return highscores;
        }

        //when the highscore form is loaded...
        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            //make the highscore list box visable
            lstHighscores.Visible = true;
            //turn display highscore subprogram to show the users the highscore
            //highscores array is passed into the subprogram
            DisplayHighScores(highscores);   
        }

        //subprogram to set up the details of the form
        private void SetUpForm()
        {
            //run selection sort subprogram to sort through the highscores
            SelectionSort(highscores);

            //run WriteHighScoreFile subprogram to write the highscores to the highscores saved file
            WriteHighScoreFile(highscores);

            //display the highscores to the user by calling the properties of the subprogram 
            DisplayHighScores(highscores);
        }

        private void btnReturnToMenu_Click(object sender, EventArgs e)
        {
            MenuForm frmMenu = new MenuForm();
            //show the menu window
            frmMenu.Show();
            //and hide the game window
            this.Hide();
        }
    }
}
