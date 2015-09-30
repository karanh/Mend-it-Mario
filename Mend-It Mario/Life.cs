/* Purpose: To create a life image to show the number of lives that Mario has
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
    //the life class will inhert from the character class
    class Life : Character
    {
        //constructor the life class to hold all the default values 
        public Life()
        {
            //there is only one frame will only one image for the frame 
            _frames = new Image[1];
            //image is required from the resourses file
            _frames[0] = Properties.Resources.Mario_Straight;
            //current frame will always be the same image 
            CurrentFrame = _frames[_currentFrameIndex];
            //width of the life image is 20 pixels
            Width = 40;
            //height of the life image is 20 pixels
            Height = 40;
        }
    }
}
