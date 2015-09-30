/* Purpose: To create a bird that flies across the building during the game
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
    //create bird class which will inhert from the character class for its properties 
    class Bird : Character
    {
        //constructor the bird class
        public Bird()
        {
            //there are three images for the bird frames to create the animation 
            //therefore create an array to hold the image for the bird animation 
            _frames = new Image[3];

            //assign images to each index of the array to hold the frames for the bird
            _frames[0] = Properties.Resources.green_bird_2;
            _frames[1] = Properties.Resources.green_bird_final;
            _frames[2] = Properties.Resources.green_bird_1;

            //the current frame being displayed will be represented by the index that is form is on
            CurrentFrame = _frames[_currentFrameIndex];

            //set the width and height of the animation for the bird
            Width = 70;
            Height = 50;

            //call fly subprogram to run the path of the bird across the world
            Fly();
        }

        //subprogram to hold the properties of the bird animation so he can fly across the screen
        public void Fly()
        {
            //the varible of the current index of the animation is changed and starts off at the frame which
            //is the second index in the array
            _currentFrameIndex = 2;
            //the animation starts at second index
            _startFrameIndex = 2;
            //the animation ends also ends at the end index
            _endFrameIndex = 2;
            //the cycle of the animation will only go through it once
            _oneCycleOnly = true;
        }

        //subprogram to hold the properties of the bird animation when a collision occurs
        public void Impact()
        {
            //the varible of the current index of the animation is changed  and starts off at the first index
            _currentFrameIndex = 0;
            //the starting frame of the animation is equal to the first index in the array
            _startFrameIndex = 0;
            //the ending frame of the animation is equal to the 2 index of the array 
            _endFrameIndex = 2;
            //the cycle of the animation will only go through it once
            _oneCycleOnly = true;
        }
    }
}
