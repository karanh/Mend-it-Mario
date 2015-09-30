/* Purpose: To create a character that can be animated and moved around the screen
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
    //create abstract class for characters in the game ( mario, bowser,etc.)
    abstract class Character
    {
        //interger to hold width of characters
        public int Width;
        //...height of characters
        public int Height;
        //protected bollean value if their animation is cycled more than once 
        protected bool _oneCycleOnly;
        //protected image array to hold all the frames for each character
        protected Image[] _frames;
        //public image varible to hold the curent frame of each character as animation occurs
        public Image CurrentFrame;
        //protected current frame index version
        protected int _currentFrameIndex;

        //subprogram for current frame index
        public int CurrentFrameIndex
        {
            //allow the user to get the value of the current frame index
            get
            {
                return _currentFrameIndex;
            }
            //allow user to set the current frame
            protected set
            {        
                //if the value the user provides is less than the end frame index 
                if (value > (_endFrameIndex))
                {
                    //and if it only cycles once through the animation
                    if (_oneCycleOnly == true)
                    {
                        //current frame will equal the end frame 
                        _currentFrameIndex = _endFrameIndex;
                    }
                    //otherwise cycle the animation agian by going back to the beginning 
                    else
                    {
                        _currentFrameIndex = _startFrameIndex;
                    }
                }
                //if the vlaue is less than the last one, set it to the value provided by the user 
                else
                {
                   
                    _currentFrameIndex = value;
                }
                //frame from frame array
                CurrentFrame = _frames[_currentFrameIndex];
            }
        }
        //create x varible for the character
        public int X;
        //create y varible for the character
        public int Y;
        //create start frame index varible for the character 
        protected int _startFrameIndex;
        //also an end frame
        protected int _endFrameIndex;
        
        //subprogram for animation of character
        protected void Animate()
        {
            //run through frames of characters
            CurrentFrameIndex++;
        }

        //subprogram for drawing of characters
        public void Draw(Graphics grfx)
        {
            //run animation subprogram 
            Animate();
            //and draw each frame will its dimensions
            grfx.DrawImage(CurrentFrame, X, Y, Width, Height);
        }

        //subprogram for drawing of each character
        public void Draw(Graphics grfx, bool changeFrame)
        {
            //if frames can be changed 
            if (changeFrame == true)
            {
                //animate the frames
                Animate();
            }
            //draw by frames of each character
            grfx.DrawImage(CurrentFrame, X, Y, Width, Height);
        }
        
    }
}
