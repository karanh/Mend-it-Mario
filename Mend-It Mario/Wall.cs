/* Purpose: To create a wall that prevents Mario from going to a certain window from a certain direction
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
    //create wall class which will inhert from the character class for its properties 
    class Wall : Character
    {
        
        //constructor for the wall class to hold all its default values
        public Wall()
        {
            
            //the frames array for the wall will only hold one image ( the wall itself)
            _frames = new Image[1];
            //the one index is equal to the image of the wall from the resourses
            _frames[0] = Properties.Resources.obstacle_wall;
            //the width of the wall is assigned as 20 
            Width = 20;
        }
    }
}
