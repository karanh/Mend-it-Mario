/* Purpose: To create a mushroom that Mario can collect to get an extra life
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
    //the mario class inherts from the character class
    class Mushroom : Character
    {
        //constructor for mushroom class to hold all its default values 
        public Mushroom()
        {
            //mushroom will have two images in its animation frames
            _frames = new Image[2];

            //the 2 images for mushroom animation are in the resourses 
            _frames[0] = Properties.Resources.red_mushroom;
            _frames[1] = Properties.Resources.green_mushroom;

            //set the dimensions for the mushrooms as 40 by 40
            Width = 40;
            Height = 40;

            //frames transitions b/w start and last frames
            _currentFrameIndex = 0;
            _startFrameIndex = 0;
            _endFrameIndex = 1;
            CurrentFrame = _frames[_currentFrameIndex];
        }

        
    }
}
