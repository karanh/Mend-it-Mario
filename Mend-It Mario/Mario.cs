/* Purpose: To create a mario character that, in the game, fixes windows while avoiding fireballs and birds.
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
    //mario class will inhert from the character class
    class Mario : Character
    {
        //create private lives varible
        private int _lives;

        //subprogram to hold the properites of lives 
        public int Lives
        {
            //allow the user to get the value of lives 
            get
            {
                return _lives;
            }
            //allow the user to set the value of lives 
            private set
            {
                //if the value is below 0
                if (value < 0)
                {
                    //set it as 0
                    _lives = 0;
                }
                //otherwise set it to the value the user provides
                else
                {
                    _lives = value;
                }
            }
        }

        //create public interger varible for hortionizal window position
        public int WindowXPosition;
        //create public interger varible for vertical window position
        public int WindowYPosition;

        //constructor for mario class to hold default values 
        public Mario()
        {
            //mario has 3 lives as default
            _lives = 3;
            //the width of mario is  50 pixals
            Width = 50;
            //the height of mario is 60 pixals
            Height = 60;
            //mario will have 13 images in his animations 
            _frames = new Image[14];

            //********** IMAGES FOR MARIO ANIMATION **************************
            _frames[0] = Properties.Resources.Mario_Fix_1;
            _frames[1] = Properties.Resources.Mario_Fix_2;
            _frames[2] = Properties.Resources.Mario_Fix_3;
            _frames[3] = Properties.Resources.Mario_Fix_4;
            _frames[4] = Properties.Resources.Mario_Fix_5;
            _frames[5] = Properties.Resources.Mario_Fix_6;
            _frames[6] = Properties.Resources.Mario_Straight;
            _frames[7] = Properties.Resources.Mario_Falling_1;
            _frames[8] = Properties.Resources.Mario_Falling_2;
            _frames[9] = Properties.Resources.Mario_Falling_3;
            _frames[10] = Properties.Resources.Mario_Falling_4;
            _frames[11] = Properties.Resources.Mario_Falling_5;
            _frames[12] = Properties.Resources.Mario_Straight;
            _frames[13] = Properties.Resources.Dead_Mario;

            //run subprogram for mario standing still ( one image)
            StandStill();
            //current frame is based on the index it is on
            CurrentFrame = _frames[_currentFrameIndex];
            //position on the window
            WindowXPosition = 2;
            WindowYPosition = 5;
        }

        //subprogram for when he is standing still 
        public void StandStill()
        {
            //call frame index 6 (image of him standing still)
            _currentFrameIndex = 6;
            _startFrameIndex = 6;
            _endFrameIndex = 6;
            _oneCycleOnly = true;
        }

        //subprogram to fix window
        public void FixWindow()
        {
            //animation to display fixing of window
            CurrentFrameIndex = 0;
            _startFrameIndex = 0;
            _endFrameIndex = 6;
            _oneCycleOnly = true;
        }

        //subprogram for losing life 
        public void LoseLife()
        {
            //subtract one from mario lives
            Lives--;

            //if mario has no more lives
            if (Lives == 0)
            {
                //do animation for death 
                CurrentFrameIndex = 13;
                _startFrameIndex = 13;
                _endFrameIndex = 13;
                _oneCycleOnly = true;
            }
            //if he is still alive animate stand still animation
            else
            {
                CurrentFrameIndex = 7;
                _startFrameIndex = 7;
                _endFrameIndex = 12;
                _oneCycleOnly = true;
            }
        }

        //subprogram for gaining life 
        public void GainLife()
        {
            //add one to the number of lives
            Lives++;
        }
    }
}
