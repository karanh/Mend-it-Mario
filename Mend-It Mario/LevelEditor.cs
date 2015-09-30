/* Purpose: To allow the user to adjust the difficulty of the game by saving the changes to a file
 * Date of Completion: June 15, 2013
 * Teacher: Mr. Hsiung
 * Members: Junaid Ahmad, Karan Huynh, Donald Jung, Anish Chopra*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Mend_It_Mario
{
    class LevelEditor
    {
        //Used to verify if the value is a number
        bool checkNumber;
        //Saves the number value 
        int number;
        //Holds all the edited values to adjust the difficulty of the level
        int[] levelEditValues = new int[5];
        //Holds all the error messages from invalid user inputs
        public string[] errorMessages = new string[5];
        //Base constructor for the level editor with all the default values of the form
        public LevelEditor()
        {
        }
        //Takes in the user's desired difficulty speed and saves it to an array that stores user's level adjustments
        public void Difficulty(string difficulty)
        {
            //Converts the value from a string to an int
            int value = ConvertToInt(difficulty);
            //Difficulty speed is too slow
            if (value > 80)
            {
                //Gives difficulty to a speed of 80
                value = 80;
                //User warning
                errorMessages[0] = "Value is too high. Value is automatically set to 80";
            }
            //Difficulty speed is too fast
            else if (value < 20)
            {
                //Gives difficulty to a speed of 20
                value = 20;
                //User warning
                errorMessages[1] = "Value is too low. Value is automatically set to 20";
            }
            //Saves the difficulty to an array that holds all adjusted values
            levelEditValues[0] = value;
        }
        //Takes in the user's desired number of walls and saves it to an array that stores user's level adjustments
        public void NumWalls(string numWalls)
        {
            //Converts the value from a string to an int
            int value = ConvertToInt(numWalls);
            //Saves the number of walls to an array that holds all adjusted values
            levelEditValues[1] = value;
        }
        //Takes in the user's desired number of mushrooms and saves it to an array that stores user's level adjustments
        public void NumMushrooms(string numMushrooms)
        {
            //Converts the value from a string to an int
            int value = ConvertToInt(numMushrooms);
            //Saves the number of mushrooms to an array that holds all adjusted values
            levelEditValues[2] = value;
        }
        //Takes in the user's desired number of birds and saves it to an array that stores user's level adjustments
        public void NumBirds(string numBirds)
        {
            //Converts the value from a string to an int
            int value = ConvertToInt(numBirds);
            //Saves the number of birds to an array that holds all adjusted values
            levelEditValues[3] = value;
        }
        //Takes in the user's desired bird speed and saves it to an array that stores user's level adjustments
        public void BirdSpeed(string birdSpeed)
        {
            int value = ConvertToInt(birdSpeed);
            //The birdspeed is too high
            if (value > 20)
            {
                //Sets the bird speed to 20
                value = 20;
                //User warning
                errorMessages[2] = "Value is too high. Value is automatically set to 20";
            }
            //The birdspeed is too low
            else if (value < 5)
            {
                //Sets the birdspeed to 5
                value = 5;
                //User warning
                errorMessages[3] = "Value is too low. Value is automatically set to 5";
            }
            //Saves the bird speed to an array that holds all adjusted values
            levelEditValues[4] = value;
            //Will write the adjustments to a file
            
        }
        
        //Converts input values from string to int
        private int ConvertToInt(string fileText)
        {
            //Checks if value is an integer
            checkNumber = int.TryParse(fileText, out number);
            if (checkNumber == true)
            {
                //Returns the input value as a string
                return number;
            }
            //Input value is not an integer
            else
            {
                //User warning
                errorMessages[4] = "ERROR! One or more of the following value(s) is/are either blank or invalid. Blank or invalid value(s) will automatically be saved to one or more of the following defaults:"+"\nDifficulty - 80"+"\nNumber of Walls - 0"+"\nNumber of Mushrooms - 0"+"\nNumber of Birds - 0"+"\nBird Speed - 5";
                //Gives default value of 0
                return 0;
            }
        }
        //Creates a text document with the adjustments for difficulty of a level
        public void WriteToFile(string fileName)
        {
            //Uses StreamWriter to create a txt document file called "LevelEditor"
            using (StreamWriter fileOutput = new StreamWriter(fileName))
            {
                //Loops through the array that stores the editted values to print to the file 
                for (int i = 0; i < levelEditValues.Length; i++)
                {
                    //Writes the values to each line
                    fileOutput.WriteLine(levelEditValues[i]);
                }
            }
        }
    }
}

