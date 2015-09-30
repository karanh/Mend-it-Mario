/* Purpose: To create a fireball that is thrown by bowser at Mario
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
    //create fireball class which will inhert from the character class
    class Fireball : Character
    {
        //constructor for fireballs to hold all its default values 
        public Fireball()
        {
            //only one image for the frames of of the fireballs 
            _frames = new Image[1];
            _frames[0] = Properties.Resources.fireball_pic;
            //set the dimensions of fireballs image
            Width = 40;
            Height = 40;
        }
    }
}
