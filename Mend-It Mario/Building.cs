/* Purpose: To create a building that contains all the windows that Mario must fix
 * Date of Completion: June 15, 2013
 * Teacher: Mr. Hsiung
 * Members: Junaid Ahmad, Karan Huynh, Donald Jung, Anish Chopra
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mend_It_Mario
{   
    //building class will inhert from the character class 
    class Building : Character
    {
        //create a public window array to hold all the windows on the building
        public Window[,] Windows;

        //constructor for the building class to hold all default values 
        public Building()
        {
            //frames for building will only have one image to pass in cycle
            _frames = new Image[1];
            //image is located in the resourse folder
            _frames[0] = Properties.Resources.building;
            CurrentFrame = _frames[_currentFrameIndex];
            //create new windows in the array with 5x6S
            Windows = new Window[5, 6];
        }
    }
}
