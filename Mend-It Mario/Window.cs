/* Purpose: To create a window that Mario must fix
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
    //create window class which will inhert from the character class for its properties 
    class Window : Character
    {
        //public int varible to hold the number of Hits
        public int NumHits;
        //public bollean 'MoveFromLeft' varible to hold true/false value to limit the movements of the user character
        public bool MoveFromLeft;
        //public bollean 'MoveFromRight' varible to hold true/false value to limit the movements of the user character
        public bool MoveFromRight;
        //public boolean that determines if the window is fixed or not
        public bool IsFixed;

        //constructor for the Window class to hold default values
        public Window()
        {
            //frames array to hold frame images for windows with a max of two frames
            _frames = new Image[2];
            //frist index of the array is assigned as the fixed window image 
            _frames[0] = Properties.Resources.fixed_window;
            //second index of the array is assigned as the broken window image
            _frames[1] = Properties.Resources.broken_window;
            //current frame which is displayed to the user on the form is equal to the frame index of the current index
            CurrentFrame = _frames[_currentFrameIndex];

            //assign the height and width of the window frames
            Height = 80;
            Width = 80;

            //set the movements of the user character ( mario) to true everywhere so that the character can move everywhere
            MoveFromLeft = true;
            MoveFromRight = true;
        }

        //subprogram to hold the properties of a window when it is broken 
        public void BreakWindow()
        {
            //the starting frame of a broken window is the second index of the window array
            _startFrameIndex = 1;
            //the end frame index of the broken window is still the same index 
            _endFrameIndex = 1;
            //the the broken window only cycles once thus it is true
            _oneCycleOnly = true;
        }

        //subprogram to hold the properties of the window when it is fixed by the user 
        public void FixWindow()
        {
            //the starting index of the fixed window is the image in the first index of the window array
            _startFrameIndex = 0;
            //the ending index of the fixed window is the same ( the image is constant)
            _endFrameIndex = 0;
            //the the fixed window only cycles once thus it is true
            _oneCycleOnly = true;
            //shows that the window is fixed
            IsFixed = true;
        }
    }
}
