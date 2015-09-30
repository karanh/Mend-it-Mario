/* Purpose: To create a bowser character that throws fireballs at Mario during the game
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
    //create bowser class which will inhert from the character class for its properties 
    class Bowser : Character
    {
        //Contructor to hold the default values of bowser
        public Bowser()
        {
            //assign images to each index of the array to hold the grames for Bowser
            _frames = new Image[7];
            _frames[0] = Properties.Resources.bowser_half_down;
            _frames[1] = Properties.Resources.bowser_full_down;
            _frames[2] = Properties.Resources.bowser_front;
            _frames[3] = Properties.Resources.empty_canon;
            _frames[4] = Properties.Resources.bowser_in_canon_up;
            _frames[5] = Properties.Resources.bowser_in_canon_crying;
            _frames[6] = Properties.Resources.bowser_flying_out_of_canon;
            //sets the width and height of the animation for Bowser
            Width = 70;
            Height = 70;
            //Makes bowser stay still when he releases firebombs
            StandStill();
            //Sets the frame image of bowser to his moving position
            CurrentFrame = _frames[_currentFrameIndex];
        }
        //Sets the properties to make bowser stand still
        public void StandStill()
        {
            //Bowser's animation stays the same
            _currentFrameIndex = 2;
            _startFrameIndex = 2;
            _endFrameIndex = 2;
           //Stops repitition of bowser's animaion
            _oneCycleOnly = true;
        }
        //Sets the properties to make bowser shoot fireballs
        public void Smash() // change subprogram name
        {
            //Bowser's animation stays the same
            CurrentFrameIndex = 0;
            _startFrameIndex = 0;
            _endFrameIndex = 2;
            //Stops repitition of bowser's animaion
            _oneCycleOnly = true;
        }
        //Sets the properties to make bowser shoot from a cannon
        public void ShootFromCanon()
        {
            //Bowser is standing 
            CurrentFrameIndex = 4;
            //Bowser is inside cannon
            _startFrameIndex = 3;
            //Bowser is horizonal
            _endFrameIndex = 6;
            //Sets the width and height animation for bowser
            Width = 70;
            Height = 70;
            //Stops him from cycling through the animations more than once
            _oneCycleOnly = true;
        }
    }
}
