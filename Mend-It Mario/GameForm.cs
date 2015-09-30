/* Purpose: To start the game process in which Mario must fix all the windows while trying
 *          to avoid bowser's fireballs and the birds.
 * Date of Completion: June 15, 2013
 * Teacher: Mr. Hsiung
 * Members: Junaid Ahmad, Karan Huynh, Donald Jung, Anish Chopra
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Mend_It_Mario
{
    public partial class GameForm : Form
    {
        //create a bowser for the game form        
        Bowser bowser;
        //create a mario (user character) for the game form   
        Mario mario;
        //create a building for the user to fix windows on for the game form   
        Building building;
        //create a fire ball array to hold all the generate fireballs for the game form   
        Fireball[] fireballs;
        //create a birds array to hold all the birds for the game form   
        Bird[] birds;
        //create a walls array to hold all the walls in the game form   
        Wall[] walls;
        //create a mushroom array to hold all the pwr up mushrooms for the game form   
        Mushroom[] mushrooms;
        //create a lives array to hold all the lives life has remaining for the game form   
        Life[] lives;
        //create a boollean game over varible to hold the status of the game for the game form   
        bool gameOver;
        //create a number of wall interger varible for the game form   
        int numWalls;
        //create a wall cordinate array to hold the codditates of the all the walls in the game form   
        int[,] wallCoords;
        //create a time interval varible for the game form  and set it to 0 
        int time = 0;
        //create a difficulty time varible in terms of frame rate for the game form   
        int difficultyTime;
        //create a bird speed interger varible to hold the speed of the birds for the game form   
        int birdSpeed;
        //create a interger varible for the number of birds for the game form   
        int numBirds;
        //create an integer variable for the number of mushrooms for the game form   
        int numMushrooms;
        //create a random number generater
        Random randomNumber = new Random();
        //create an interger to hold the number of displayed mushrooms on the game form
        int timeToDisplayMushrooms;
        //create an interger varible to hold the amount of time that has to pass before a mushroom is displayed
        //set it to 0 
        int timeBeforeDisplayingMushrooms = 0;
        //create a boolean varible to determine if the mushroom is displayed on the form
        bool displayMushrooms;
        //determines if bowser has been shot from the canon
        bool shotOnce;
        //determines if the game has been closed or not
        bool gameClosed = false;
        //counts every time the scene is re-drawn
        int drawTime = 0;
        //create an interger varible to hold the value of the current score the user has achieved in the game
        int currentScore;
        //using media properties use sound player to play background from
        //the theme song wave file found in the bin folder
        SoundPlayer backgroudMusic = new SoundPlayer("themeSong.wav");
        bool isGameRunning = false; // isGameRunning is true until the user chooses to exit or the game ends
        bool timeToUpdate = false;  // timeToUpdate is true when enough time has passed to update and redraw the screen
        double fps = 20;// fps is the number of frames that will be drawn per second, increase this number to have a smoother animation
        double lastTime;// lastTime holds the time that the last frame was drawn
        double gameTime;// gameTime holds the current time
        double timePassed;// timePassed holds the amount of time that has passed since the last frame was drawn
        double timePerFrame;// timePerFrame holds the amount of time that needs to pass before the next frame is drawn
        MenuForm frmMenu;//stores the menu form
        string levelToPlay;//stores the name of the level that will be played
        Image background = Properties.Resources.background;

        //Creates a new Game Form
        public GameForm(MenuForm menu, string levelToLoad)
        {
            InitializeComponent();
            //set the menu passed in as the menu form
            frmMenu = menu;
            //stores the name of the level that will be played
            levelToPlay = levelToLoad;
            this.DoubleBuffered = true;//This sets the form so it won't flicker when animating a lot of objects quickly
            //sets up necessary options for the form
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.ResizeRedraw |
                          ControlStyles.ContainerControl |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.SupportsTransparentBackColor
                          , true);
            UpdateStyles();
        }

        // Loads the game
        private void GameForm_Load(object sender, EventArgs e)
        {
            //start playing background music
            backgroudMusic.PlayLooping();
            //using streamreader sr read the current score text file found in the bin folder 
            //to find out the current score of the user 
            using (StreamReader sr = new StreamReader("currentScore.txt"))
            {
                //current score is read from the first line of the file
                currentScore = int.Parse(sr.ReadLine());
            }
            lblScore.Text = "Score: " + currentScore.ToString();
            //using stream reader sr read the difficulty file to determine how hard the level
            //will be for the user
            using (StreamReader sr = new StreamReader(levelToPlay))
            {
                //the 1st line is the difficulty time in terms of frame rate for the user
                difficultyTime = int.Parse(sr.ReadLine());
                //the 2nd line is the number of walls on the game form
                numWalls = int.Parse(sr.ReadLine());
                //the 3rd line is the number of mushroom displayed on the game form
                numMushrooms = int.Parse(sr.ReadLine());
                //the 4th line is the number of birds that will travel across the form at a given time
                numBirds = int.Parse(sr.ReadLine());
                //the 5th line is the speed of such birds as they travel across the game form
                birdSpeed = int.Parse(sr.ReadLine());
            }
            //create an array to the cordinates for the walls in the game 
            wallCoords = new int[2, numWalls];

            //create an index array for the setting of the of wall cordinates 
            for (int index = 0; index < numWalls; index++)
            {
                //set the cordinates for the walls for both x and y using the random number generator 
                wallCoords[0,index] = randomNumber.Next(0,4);
                wallCoords[1,index] = randomNumber.Next(0,6);
            }
            //create a new fireball array
            fireballs = new Fireball[0];
            //create a new mushroom array with the number of mushrooms as the max.
            mushrooms = new Mushroom[numMushrooms];

            
            timeToDisplayMushrooms = randomNumber.Next(100, 300); // random time for mushrooms to show up

            //Set the starting values needed for the Game loop timer functionality
            gameTime = System.Environment.TickCount;
            lastTime = gameTime;
            timePassed = 0;
            timePerFrame = 1000 / fps;

            //create a new boswer for the game form
            bowser = new Bowser();
            //create a new building for the game form
            building = new Building();

            //set the dimensions and position of the building for the game form
            building.X = DisplayRectangle.Width / 4;
            building.Y = 0;
            building.Height = DisplayRectangle.Height;
            building.Width = DisplayRectangle.Width / 2;
            
            //set the Y cord where mario will start
            int startY = building.Y + 120;

            //set the spacing for the users movements
            int spacingY = DisplayRectangle.Height / 7;

            //run a loop to set the windows for the building on the game form as rows
            for (int column = 0; column < building.Windows.GetLength(0); column++)
            {
                //run a loop to set the windows for the building on the game form as columns 
                for (int row = 0; row < building.Windows.GetLength(1); row++)
                {
                    //create new windows 
                    building.Windows[column, row] = new Window();
                    //set the windows in their x cords on the buildings
                    int startX = (int)(building.X + building.Windows[column, row].Width/2);
                    //set the width of the window
                    building.Windows[column, row].Width = building.Width / ((building.Windows.GetLength(0) - 1)*2);
                    //set the height of the window
                    building.Windows[column, row].Height = building.Width / ((building.Windows.GetLength(0) - 1) * 2);
                    //set the spacing b/w each window
                    int spacingX = (int)(building.Windows[column, row].Width * 1.5);
                    //set hortional spacing 
                    building.Windows[column, row].X = spacingX * column + startX;
                    //set vertical spacing 
                    building.Windows[column, row].Y = spacingY * row + startY;
                    //run break window subprogam for windows on the building 
                    building.Windows[column, row].BreakWindow();
                }
            }
            //create new mario for the game form
            mario = new Mario();
            //run update mario location subprogram for the game form
            UpdateMarioLocation();
            //bowser will start off 25 left of mario
            bowser.X = mario.X - 25;
            //20 vertically of building 
            bowser.Y = building.Y + 20;

            //created new birds array
            birds = new Bird[numBirds];

            //run loop for the addition of birds into game form
            for (int index = 0; index < birds.Length; index++)
            {
                //create new bird
                birds[index] = new Bird();
                //randomly start the birds movement on the one of the columns
                birds[index].Y = building.Windows[0, randomNumber.Next(0, 6)].Y;
                //randomly have the bird move across the game form
                birds[index].X = randomNumber.Next(-500, -birds[index].Width);
                //run fly subprogram from the birds class
                birds[index].Fly();
            }
            //create new wall array for game form to hold all arrays
            walls = new Wall[numWalls];

            //run loop to add walls to the game form
            for (int index = 0; index < walls.Length; index++)
            {
                //create new wall
                walls[index] = new Wall();
                //set the height of the walls  
                walls[index].Height = building.Windows[wallCoords[0, index], wallCoords[1, index]].Height;
                //set the x cord of the walls 
                walls[index].X = building.Windows[wallCoords[0, index], wallCoords[1, index]].X + building.Windows[wallCoords[0, index], wallCoords[1, index]].Width + walls[index].Width/4;
                //set the y cord of the walls 
                walls[index].Y = building.Windows[wallCoords[0, index], wallCoords[1, index]].Y;
                ///do not allow the mario (user controled) to cross the walls from left to right
                building.Windows[wallCoords[0, index], wallCoords[1, index]].MoveFromRight = false;
                building.Windows[wallCoords[0, index] + 1, wallCoords[1, index]].MoveFromLeft = false;
            }
            //shows that the game is running
            isGameRunning = true;
            //run play game subprogram
            PlayGame();
        }

        // Updates the game timer
        private void UpdateGameTimer()
        {
            //Get the current system time
            gameTime = System.Environment.TickCount;
            //Determing how much time has passed
            timePassed = gameTime - lastTime;

            //Has enough time passed for the next frame to be drawn
            if (timePassed >= timePerFrame)
            {
                //Set the system ready to draw the frame
                timeToUpdate = true;
                //Set the current time to the lastTime for the next time this code is checked
                lastTime = gameTime;
            }
        }
        
        // Performs all necessary tasks to play the game
        private void PlayGame()
        {
            //Continue looping until the game is signaled to be ended
            while (isGameRunning == true)
            {
                //Update the Game Loop timer
                UpdateGameTimer();

                //Only update the game if enough time has passed for one frame of animation
                if (timeToUpdate)
                {
                    //updates the scene
                    UpdateScene();
                    if (gameClosed == false)
                    {
                        this.Refresh(); //Forces the redraw immediately
                    }
                    //if the game is closed, then don't force the redraw
                    else
                    {
                        break;
                    }

                }
                //Tell Windows to keep doing all of its other actions so the program doesn't freeze.
                Application.DoEvents();
            }
            Application.DoEvents();
            //Exit the program
            //Application.Exit();
        }

        // Performs all tasks necessary for the game to be played (game logic)
        private void UpdateScene()
        {
            //increase the interval of the time before a mushroom is displayed by one 
            timeBeforeDisplayingMushrooms++;
            //if the time before mushroom is displayed in idenitcal to the time a mushroom should be displayed
            if (timeBeforeDisplayingMushrooms == timeToDisplayMushrooms)
            {
                //run an index for loop to add mushrooms to game form
                for (int index = 0; index < mushrooms.Length; index++)
                {
                    //create a new mushroom to game form
                    mushrooms[index] = new Mushroom();
                    //randomly add the mushroom by row and column 
                    mushrooms[index].X = building.Windows[randomNumber.Next(0, building.Windows.GetLength(0)), 0].X + building.Windows[randomNumber.Next(0, building.Windows.GetLength(0)), 0].Width / 2 - mushrooms[index].Width / 2;
                    mushrooms[index].Y = building.Windows[0, randomNumber.Next(0, building.Windows.GetLength(1))].Y + building.Windows[0, randomNumber.Next(0, building.Windows.GetLength(1))].Width / 2 - mushrooms[index].Width / 2;
                }
                //display the mushroom on the screen
                displayMushrooms = true;
            }
            //increase the time internal by 1
            time++;

            // if the time is equal to the diffuclty set by file and the game is not over 
            if (time == difficultyTime && gameOver == false)
            {
                //make bowser follow mario by closing the distance b/w them
                bowser.X = mario.X - 25;
                //set the time back to 0
                time = 0;
                //fire a fireball throws mario
                Fireball[] tempBricks = new Fireball[fireballs.Length];
                //copy the array
                Array.Copy(fireballs, tempBricks, fireballs.Length);
                //and create a new fireball
                fireballs = new Fireball[tempBricks.Length + 1];
                //do it agian 
                Array.Copy(tempBricks, fireballs, tempBricks.Length);
                fireballs[fireballs.Length - 1] = new Fireball();
                fireballs[fireballs.Length - 1].X = bowser.X;
                fireballs[fireballs.Length - 1].Y = bowser.Y;
                bowser.Smash();
                time = 0;
            }
            //run index for loop for the fireball 
            for (int index = 0; index < fireballs.Length; index++)
            {
                //move the fire ball down the building 
                fireballs[index].Y += 3;
                //after the fireball reaches the limtis of the display 
                if (fireballs[index].Y > DisplayRectangle.Height)
                {
                    //rin removefireball subprogram to remove the fireball from the game
                    RemoveFireball(ref fireballs, index);
                }

                //if the fireball collides with mario 
                if (Collision(fireballs[index], mario) == true)
                {
                    //remove the fireball from display
                    RemoveFireball(ref fireballs, index);
                    //and cause mario (user) to lose one of their lives
                    mario.LoseLife();
                }
            }

            //run for loop for bird movement 
            for (int index = 0; index < birds.Length; index++)
            {
                //move birds based on per decided speed for them
                birds[index].X += birdSpeed;
                //the given bird passes the width of th display 
                if (birds[index].X > DisplayRectangle.Width)
                {
                    //randomly add a new bird to the display 
                    birds[index].X = randomNumber.Next(-500, -birds[index].Width);
                    birds[index].Y = building.Windows[0, randomNumber.Next(0, 6)].Y;
                }

                //if the bird collides with mario
                if (Collision(birds[index], mario) == true)
                {
                    //run the bird impact subprogram for the bird
                    birds[index].Impact();
                    //make the bird jump after collision
                    birds[index].X += 200;
                    //with collision mario will lose one of his lives
                    mario.LoseLife();
                }
            }

            //run a index for loops for the mushroom pwr ups
            for (int index = 0; index < mushrooms.Length; index++)
            {
                //if mushroom is played on screen
                if (displayMushrooms == true)
                {
                    //and if mario has collided with the mushroom
                    if (Collision(mushrooms[index], mario) == true)
                    {
                        //run mario subprogram to gain a lif e
                        mario.GainLife();
                        //and run the subprogram to remove the given mushroom
                        RemoveMushroom(ref mushrooms, index);
                    }
                }
            }

            //create a new life array for users remaining lices
            lives = new Life[mario.Lives];
            //run a index for loop for the lives 
            for (int index = 0; index < lives.Length; index++)
            {
                //the lives will be assigned 
                lives[index] = new Life();
                
                //if the index 
                if (index == 0)
                {
                    lives[index].X = DisplayRectangle.Width - lives[index].Width;
                }
                else
                {
                    lives[index].X = lives[index - 1].X - lives[index].Width;
                }
            }
        }

        //Subprogram neccessary for the graphics
        protected override void OnPaint(PaintEventArgs e)
        {
            //This must be here, this draws all of the basic windows stuff, like the buttons, etc.
            base.OnPaint(e);
            //Draw the Scene
            DrawScene(e.Graphics);
        }
        
        //Draws the scene
        private void DrawScene(Graphics grfx)
        {
            //drawTime++;
            //Only draw if it is time to update
            if (timeToUpdate == true)
            {
                grfx.DrawImage(background, 0, 0, DisplayRectangle.Width, DisplayRectangle.Height);
                //increases the drawTime variable by 1
                drawTime++;
                //Reset update status so it will wait for the
                //next appropriate time to update
                timeToUpdate = false;
                
                //draw the building on to the form
                building.Draw(grfx);

                //run a for loop for the windows to draw them as rows 
                for (int column = 0; column < building.Windows.GetLength(0); column++)
                {
                    //run a for loop for the windows to draw them as columns 
                    for (int row = 0; row < building.Windows.GetLength(1); row++)
                    {
                        //draw in the windows on to the building 
                        building.Windows[column, row].Draw(grfx);
                    }
                }

                //mario is on the 6th frame of the animation or the 12th frame of animation
                if (mario.CurrentFrameIndex == 6 || mario.CurrentFrameIndex == 12)
                {
                    //set mario's width to 55 pixals
                    mario.Width = 55;
                    //set mario's height to 60 pixals
                    mario.Height = 60;
                }

                //if mario's frame of animation is the 13th one 
                else if (mario.CurrentFrameIndex == 13)
                {
                   //set marios width to 20 pixals 
                    mario.Width = 20;
                    //set mario's height to 20 pixals as well
                    mario.Height = 20;
                }
                //else wise for any other frame 
                else
                {
                    //set mario's width to 25 pixals
                    mario.Width = 25;
                    //set mario's height to 60 pixals
                    mario.Height = 60;
                }
                //draw mario on the screen
                mario.Draw(grfx);
                
                //if draw time is up to 5 
                if (drawTime == 5)
                {
                    //then bowser will be drawn 
                    bowser.Draw(grfx);

                    //run an index for loop for the drawing of the birds
                    for (int index = 0; index < birds.Length; index++)
                    {
                        //draw each index of the birds in its array
                        birds[index].Draw(grfx);
                    }
                    //set draw time back to 0
                    drawTime = 0;
                }

                //else 
                else
                {
                    //draw bowser without moving it to its next frame of animation
                    bowser.Draw(grfx, false);

                    //run a index for loop for all the birds 
                    for (int index = 0; index < birds.Length; index++)
                    {
                        //draws the bird without moving it to its next frame of animation
                        birds[index].Draw(grfx,false);
                    }
                }

                //run an index for loop for the fireballs 
                for (int index = 0; index < fireballs.Length; index++)
                {
                    //draws the fireball
                    fireballs[index].Draw(grfx);
                }

                //run a index for loop to draw the walls on to the game form
                for (int index = 0; index < walls.Length; index++)
                {
                    //draw each of the walls 
                    walls[index].Draw(grfx);
                }

                //if mushrooms can be displayed on the screen 
                if (displayMushrooms == true)
                {
                    //run a index for loops for the mushrooms 
                    for (int index = 0; index < mushrooms.Length; index++)
                    {
                        //draw mushroom of all index 
                        mushrooms[index].Draw(grfx);
                    }
                }

                //run a index for loop for the lives and draw them onto the form
                for (int index = 0; index < lives.Length; index++)
                {
                    //draw each index of the lives 
                    lives[index].Draw(grfx);
                }
            }

            //if mario has no more lives 
            if (mario.Lives == 0)
            {
                //the game is over 
                gameOver = true;
                //and mario will fall down the building 
                mario.Y += 20;
            }

            //if all the windows on the building have been fixed 
            if (CountNumFixedWindows(building.Windows) == building.Windows.Length)
            {
                //the game is over 
                gameOver = true;
                //and bowser has not been shot from the canon yet 
                if (shotOnce == false)
                {
                    //shoot bowser from the conon using the animation subprogram
                    bowser.ShootFromCanon();
                    //and set browser to has been shot 
                    shotOnce = true;
                }
                //if bowser is animated to fly 
                if (bowser.CurrentFrameIndex == 6)
                {
                    //launch him across the screen 
                    bowser.X -= 20;
                }
            }

            //if the game is over 
            if (gameOver == true)
            {
                //remove all the fireballs from the screen
                fireballs = new Fireball[0];
                //remove all the mushrooms from the screen
                mushrooms = new Mushroom[0];
                //remove all the birds from the screen
                birds = new Bird[0];
            }

            //If mario has fallen below the screen (aka he is dead)
            if (mario.Y > DisplayRectangle.Height)
            {
                //add the score to the highscore form (which will be determined if it is kept or not by the highschore form)
                HighScoreForm frmHighScore = new HighScoreForm(currentScore);
                //goes to the menu
                GoToMenu();                
            }

            //after bowser leaves the screen after being lanuched 
            if (bowser.X < 0)
            {
                //increase the diffculty of the frame rate 
                difficultyTime -= 5;
                //if the diffuclty time is already below 5 
                if (difficultyTime < 5)
                {
                    //set it 5 
                    difficultyTime = 5;
                }
                //increase the number of birds by one 
                numBirds++;
                //increase the speed of the birds
                birdSpeed += 5;
                
                //If the level that is being played is part of the main (infinite) game...
                if (levelToPlay == "infiniteGame.txt")
                {
                    //using streamwriter add the diffculity to its text file respectfully so it can be used 
                    //by the game to set the properties of the game 
                    using (StreamWriter sw = new StreamWriter(levelToPlay, false))
                    {
                        //write to the first line the difficulty of frame rate 
                        sw.WriteLine(difficultyTime.ToString());
                        //to the next line write the number of walls 
                        sw.WriteLine(numWalls.ToString());
                        //to the next line write the number of mushrooms 
                        sw.WriteLine(numMushrooms.ToString());
                        //to the next lne write the number of birds
                        sw.WriteLine(numBirds.ToString());
                        //to the next time write the speed of the birds
                        sw.WriteLine(birdSpeed.ToString());
                    }
                    //to save the current score as the gameform changes write it to the current text file 
                    //which is overwritable 
                    using (StreamWriter sw = new StreamWriter("currentScore.txt", false))
                    {
                        //write on the first line 
                        sw.WriteLine(currentScore.ToString());
                    }
                    //go to menu 
                    GoToMenu();
                    //create a new game form 
                    GameForm frmGame = new GameForm(frmMenu, levelToPlay);
                    //and show it has the next level
                    frmGame.Show();
                }
                //If the level being played is not part of the main(infinite) game
                else
                {
                    GoToMenu(); //go to the menu
                }
            }
        }

        //game form key controls with each press
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //if the user presses the up key
            if (e.KeyCode == Keys.Up)
            {
                //and mario isnt already at the top
                if (mario.WindowYPosition > 0)
                {
                    //move his position up a window
                    mario.WindowYPosition--;
                    //and update his location as one up
                    UpdateMarioLocation();                    
                }
            }

            //if the user presses the down key
            if (e.KeyCode == Keys.Down)
            {
                //and mario isnt already at the bottom of the building 
                if (mario.WindowYPosition < building.Windows.GetLength(1) - 1)
                {
                    //move his position down a window
                    mario.WindowYPosition++;
                    //and update his location as one down
                    UpdateMarioLocation();
                }
            }

            //if the user presses the left key
            if (e.KeyCode == Keys.Left)
            {
                //and mario isnt already to the left of the building 
                if (mario.WindowXPosition > 0 && building.Windows[mario.WindowXPosition-1, mario.WindowYPosition].MoveFromRight == true)
                {
                    //move mario to window to the left 
                    mario.WindowXPosition--;
                    //and update marios location to the one left 
                    UpdateMarioLocation();
                }
            }

            //if the user presses the right key
            if (e.KeyCode == Keys.Right)
            {
                //and mario isnt already already to most right of the building 
                if (mario.WindowXPosition < building.Windows.GetLength(0) - 1 && building.Windows[mario.WindowXPosition + 1, mario.WindowYPosition].MoveFromLeft == true)
                {
                    //move mario to the window to othe right 
                    mario.WindowXPosition++;
                    //update mario's location as one right 
                    UpdateMarioLocation();
                }
            }

            //if the user presses the spacebar on the keyboard 
            if (e.KeyCode == Keys.Space)
            {
                //add number of hits to the window of the building as means to fix it 
                building.Windows[mario.WindowXPosition, mario.WindowYPosition].NumHits++;
                //run the mario fixWindow subprogram as an animation
                mario.FixWindow();
                //if mario has taken three hits on the window at attempts to fix the window
                if (building.Windows[mario.WindowXPosition,mario.WindowYPosition].NumHits == 3)
                {
                    //run the windows fix animation subprogram 
                    building.Windows[mario.WindowXPosition, mario.WindowYPosition].FixWindow();
                    //add  one to the score 
                    currentScore++;
                    //update score label to show the score to the user
                    lblScore.Text = "Score: " + currentScore.ToString();
                }
                
            }

            //if the user presses the escape button 
            if (e.KeyCode == Keys.Escape)
            {
                //change the game running form to false 
                isGameRunning = false;
                //and run the go to menu subprogram to show menu form
                GoToMenu();
            }
        }

        //subprogram to update mario's location on the game form
        private void UpdateMarioLocation()
        {
            //updates mario's position to the window that he should be at
            mario.X = building.Windows[mario.WindowXPosition, mario.WindowYPosition].X + 25;
            mario.Y = building.Windows[mario.WindowXPosition, mario.WindowYPosition].Y + 10;
        }

        //subprogram to determine collisons between two characters
        private bool Collision(Character character1, Character character2)
        {
            //stores character1's top, bottom, left, and right
            int top1 = character1.Y;
            int bottom1 = character1.Y + character1.Height;
            int left1 = character1.X;
            int right1 = character1.X + character1.Width;
            //stores character2's top, bottom, left, and right
            int top2 = character2.Y;
            int bottom2 = character2.Y + character2.Height;
            int left2 = character2.X;
            int right2 = character2.X + character2.Width;

            //if the bottom of 1 is lower than the two of the 2 return false (collision has not occured)
            if (bottom1 < top2) return false;
            //if the top of 1 is higher than the bottom of two return false (collision has not occured)
            if (top1 > bottom2) return false;

            //same default setting as long as the two are not in the same range collision can not occur 
            if (right1 < left2) return false;
            if (left1 > right2) return false;

            //if none of the above if states are true than return true since collision has indeed occured 
            return true;
        }

        //subprogram to remove fireballs from the display screen and from the array of fireballs
        private void RemoveFireball(ref Fireball[] fireballs, int index)
        {
            //create a temporary array for the fireball array
            Fireball[] tempArray = new Fireball[fireballs.Length - 1];

            //run an index for loop to add to the temp fireball array 
            for (int indexToCopy = 0; indexToCopy < index; indexToCopy++)
            {
                //copies all the fireballs to the temp array that are before the fireball that is to be removed
                tempArray[indexToCopy] = fireballs[indexToCopy];
            }

            //run an index for loop to add to the temp fireball array
            for (int indexToCopy = index + 1; indexToCopy < fireballs.Length; indexToCopy++)
            {
                //copies all the fireballs to the temp array that are after the fireball that is to be removed
                tempArray[indexToCopy-1] = fireballs[indexToCopy];
            }

            //fireballs will be equal to the new fireballs array (the original length minus 1)
            fireballs = new Fireball[tempArray.Length];
            //copy the array as an means to remove the fireballs from the previous array 
            Array.Copy(tempArray, fireballs, tempArray.Length);
        }

        //subprogram to remove mushrooms from the screen 
        private void RemoveMushroom(ref Mushroom[] mushrooms, int index)
        {
            //create a temporary array for the mushroom array
            Mushroom[] tempArray = new Mushroom[mushrooms.Length - 1];

            //run an index for loop to add to the temp mushroom array 
            for (int indexToCopy = 0; indexToCopy < index; indexToCopy++)
            {
                //copies all the mushrooms to the temp array that are before the mushroom that is to be removed
                tempArray[indexToCopy] = mushrooms[indexToCopy];
            }

            //run an index for loop to add to the temp mushroom array
            for (int indexToCopy = index + 1; indexToCopy < mushrooms.Length; indexToCopy++)
            {
                //copies all the mushrooms to the temp array that are after the mushroom that is to be removed
                tempArray[indexToCopy - 1] = mushrooms[indexToCopy];
            }
            //mushrooms will be equal to the new mushrooms array (the original length minus 1)
            mushrooms = new Mushroom[tempArray.Length];
            //copy the array as an means to remove the mushrooms from the previous array 
            Array.Copy(tempArray, mushrooms, tempArray.Length);
        }

        //subprogtam to count the number of fixed wndows using the wndows array 
        private int CountNumFixedWindows(Window[,] windows)
        {
            //stores the number of windows that are fixed (initially set to zero to begin counting)
            int numFixedWindows = 0;
            //searches through the columns of the windows array and add 1 to the numFixedWindows variable
            //if the window that is being searched is fixed
            for (int column = 0; column < windows.GetLength(0); column++)
            {
                //searches through the rows of the windows array and add 1 to the numFixedWindows variable
                //if the window that is being searched is fixed
                for (int row = 0; row < windows.GetLength(1); row++)
                {
                    //if the current window being searched is fixed, add 1 to the numFixedWindows variable
                    if (windows[column, row].IsFixed == true)
                    {
                        numFixedWindows++;
                    }
                }
            }
            return numFixedWindows; //returns the number of fixed windows
        }

        //override subprogram to refresh the game 
        public override void Refresh()
        {
            //refresh the game form
            try
            {
                base.Refresh();
            }
            catch
            {
                
            }
        }

        //subprogram to handle escape from the game and go to menu
        public void GoToMenu()
        {
            //turn off the background music 
            backgroudMusic.Stop();
            //determine that the game has been closed 
            gameClosed = true;
            //and that the game is not longer running 
            isGameRunning = false;
            //show the menu window
            frmMenu.Show();
            //and hide the game window
            this.Hide();
        }
    }
}
