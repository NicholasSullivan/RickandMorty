using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Media;

/*
 * Nicholas Sullivan 821661666
 * Irakli Gordadze 821008299
 * Nika Tbileli 821008286
 * 
 * COMPE 361 Final Project
 * December 13, 2018
 * 
 * Trivia Maze Game
 * 
 */

namespace COMPE_361_Final_Project
{
    public partial class Form1 : Form
    {
        // Room #, Left, Top, Right, Bottom
        Room room1 = new Room(1, 2, 4, 0, 0);
        Room room2 = new Room(2, 0, 3, 1, 0);
        Room room3 = new Room(3, 0, 5, 4, 2);
        Room room4 = new Room(4, 3, 0, 0, 1);
        Room room5 = new Room(5, 0, 0, 0, 3);

        // initialize all windows forms controls and variables
        int currentRoomNumber = 0;
        Random rnd = new Random();
        List<Room> roomList = new List<Room>();
        PictureBox gifPictureBox = new PictureBox();
        PictureBox rickPictureBox = new PictureBox();
        PictureBox titlePictureBox = new PictureBox();
        PictureBox startPictureBox = new PictureBox();
        PictureBox loadPictureBox = new PictureBox();
        PictureBox exitPictureBox = new PictureBox();
        PictureBox menuIconPictureBox = new PictureBox();
        PictureBox transparencyPictureBox = new PictureBox();
        PictureBox rickTalkingPictureBox = new PictureBox();
        PictureBox bossTalkingPictureBox = new PictureBox();
        SoundPlayer portalGunSound = new SoundPlayer(Properties.Resources.Portal_Gun);
        SoundPlayer ohGeez = new SoundPlayer(Properties.Resources.Oh__geez);
        SoundPlayer themeSong = new SoundPlayer(Properties.Resources.Rick___Morty_Theme);
        SoundPlayer growl = new SoundPlayer(Properties.Resources.growl);
        SoundPlayer growl2 = new SoundPlayer(Properties.Resources.growl2);
        SoundPlayer muder = new SoundPlayer(Properties.Resources.murder);
        SoundPlayer shady = new SoundPlayer(Properties.Resources.shady);
        PictureBox rickPortal = new PictureBox();
        PictureBox leftDoorPictureBox = new PictureBox();
        PictureBox rightDoorPictureBox = new PictureBox();
        PictureBox topDoorPictureBox = new PictureBox();
        PictureBox bottomDoorPictureBox = new PictureBox();
        PictureBox mapPictureBox = new PictureBox();
        PictureBox inventoryPictureBox = new PictureBox();
        PictureBox bossPictureBox = new PictureBox();
        PictureBox summerPictureBox = new PictureBox();
        PictureBox endGamePictureBox = new PictureBox();
        PictureBox piece1PictureBox = new PictureBox();
        PictureBox piece2PictureBox = new PictureBox();
        PictureBox piece3PictureBox = new PictureBox();
        PictureBox piece4PictureBox = new PictureBox();
        PictureBox doorKeyPictureBox = new PictureBox();
        Label instructionsLabel = new Label();
        Label questionLabel = new Label();
        RadioButton answer1RadioButton = new RadioButton();
        RadioButton answer2RadioButton = new RadioButton();
        RadioButton answer3RadioButton = new RadioButton();
        Button closeInstructionsButton = new Button();
        Button submitAnswerButton = new Button();
        List<Label> mazeLabelList = new List<Label>();

        // vars
        bool isPlaying = false;
        bool isMaze = false;
        bool mapIsOpen = false;
        bool inventoryIsOpen = false;
        int rickTalking = 0;
        int bossTalking = 1;
        int nextRoom = 0;
        string lastPressed = "";
        bool hasPiece1 = false;
        bool hasPiece2 = false;
        bool hasPiece3 = false;
        bool hasPiece4 = false;
        int piecesCounter = 0;
        string doorEntered = "";
        bool isCorrect = false;
        int questionIterator = 0;

        // To read from SQLite Database
        List<Table> tables = new List<Table>();
        List<int> listNumbers = new List<int>();
        List<int> doorStatusList = new List<int>();

        public Form1()
        {
            InitializeComponent();
            KeyDown += new KeyEventHandler(Form1_KeyDown);
        }

        // Method to check key input and move character and check for collisions
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(isPlaying || e.KeyCode == Keys.M || e.KeyCode == Keys.I || e.KeyCode == Keys.S)
            {
                int x = spritePictureBox.Location.X;
                int y = spritePictureBox.Location.Y;
                if (e.KeyCode == Keys.Right && ((this.ClientSize.Width - spritePictureBox.Location.X) > spritePictureBox.Width + 8))
                {
                    if(isMaze && currentRoomNumber != 5)
                    {
                        if ((!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[0].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[1].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[2].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[3].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[4].Bounds)))
                        {
                            x += 8;
                            spritePictureBox.Image = Properties.Resources.mortynew;
                            //toolStripStatusLabel1.Text = "Right";
                            lastPressed = "Right";
                        }
                        else if (lastPressed != "Right")
                        {
                            x += 8;
                            spritePictureBox.Image = Properties.Resources.mortynew;
                            //toolStripStatusLabel1.Text = "Right";
                            lastPressed = "Right";
                        }
                    }
                }
                else if (e.KeyCode == Keys.Left && ((this.ClientSize.Width - spritePictureBox.Location.X) < this.ClientSize.Width - 8))
                {
                    if (isMaze && currentRoomNumber != 5)
                    {
                        if ((!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[0].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[1].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[2].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[3].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[4].Bounds)))
                        {
                            x -= 8;
                            spritePictureBox.Image = Properties.Resources.mortynewleft;
                            //toolStripStatusLabel1.Text = "Left";
                            lastPressed = "Left";
                        }
                        else if (lastPressed != "Left")
                        {
                            x -= 8;
                            spritePictureBox.Image = Properties.Resources.mortynewleft;
                            //toolStripStatusLabel1.Text = "Left";
                            lastPressed = "Left";
                        }
                    }
                }
                else if (e.KeyCode == Keys.Up && ((this.ClientSize.Height - spritePictureBox.Location.Y) < this.ClientSize.Height - 30))
                {
                    if (isMaze)
                    {
                        if (currentRoomNumber == 5)
                        {
                            y -= 8;
                            spritePictureBox.Image = Properties.Resources.backmorty;
                            //toolStripStatusLabel1.Text = "Up";
                            lastPressed = "Up";
                        }
                        else if ((!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[0].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[1].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[2].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[3].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[4].Bounds)))
                        {
                            y -= 8;
                            spritePictureBox.Image = Properties.Resources.backmorty;
                            //toolStripStatusLabel1.Text = "Up";
                            lastPressed = "Up";
                        }
                        else if (lastPressed != "Up")
                        {
                            y -= 8;
                            spritePictureBox.Image = Properties.Resources.backmorty;
                            //toolStripStatusLabel1.Text = "Up";
                            lastPressed = "Up";
                        }
                    }
                    else
                    {
                        y -= 8;
                        spritePictureBox.Image = Properties.Resources.backmorty;
                        //toolStripStatusLabel1.Text = "Up";
                        lastPressed = "Up";
                    }
                }
                else if (e.KeyCode == Keys.Down && ((this.ClientSize.Height - spritePictureBox.Location.Y) > spritePictureBox.Height + 30))
                {
                    if (isMaze)
                    {
                        if (currentRoomNumber == 5)
                        {

                        }
                        else if ((!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[0].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[1].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[2].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[3].Bounds)) && (!spritePictureBox.Bounds.IntersectsWith(mazeLabelList[4].Bounds)))
                        {
                            y += 8;
                            spritePictureBox.Image = Properties.Resources.mortnewfontr;
                            //toolStripStatusLabel1.Text = "Down";
                            lastPressed = "Down";
                        }
                        else if (lastPressed != "Down")
                        {
                            y += 8;
                            spritePictureBox.Image = Properties.Resources.mortnewfontr;
                            //toolStripStatusLabel1.Text = "Down";
                            lastPressed = "Right";
                        }
                    }
                    else
                    {
                        y += 8;
                        spritePictureBox.Image = Properties.Resources.mortnewfontr;
                        //toolStripStatusLabel1.Text = "Down";
                        lastPressed = "Right";
                    }
                }
                else if (e.KeyCode == Keys.M && isMaze && currentRoomNumber != 5)
                {
                    toolStripStatusLabel1.Text = "Map";
                    OpenMap();
                }
                else if (e.KeyCode == Keys.I && isMaze && currentRoomNumber != 5)
                {
                    //toolStripStatusLabel1.Text = "Inventory";
                    //OpenInventory();
                }
                else if (e.KeyCode == Keys.S && isMaze && currentRoomNumber != 5)
                {
                    if (mazeLabelList[0].BackColor != Color.Red)
                    {
                        toolStripStatusLabel1.Text = "Show Hidden Walls";
                        foreach (Control wall in mazeLabelList)
                        {
                            wall.BackColor = Color.Red;
                        }
                    }
                    else
                    {
                        toolStripStatusLabel1.Text = "Hide Hidden Walls";
                        foreach (Control wall in mazeLabelList)
                        {
                            wall.BackColor = Color.Transparent;
                        }
                    }
                }
                spritePictureBox.Location = new Point(x, y);
                if (spritePictureBox.Bounds.IntersectsWith(rickPictureBox.Bounds) && rickPictureBox.Enabled)
                {
                    TouchRick();
                    isPlaying = false;
                }
                if (spritePictureBox.Bounds.IntersectsWith(bossPictureBox.Bounds) && bossTalking == 1)
                {
                    TouchBoss();
                    isPlaying = false;
                }
                if (spritePictureBox.Bounds.IntersectsWith(piece1PictureBox.Bounds))
                {
                    if (!hasPiece1)
                    {
                        shady.Play();
                        hasPiece1 = true;
                        piecesCounter++;
                        piece1PictureBox.Visible = false;
                        inventoryLabel.Text = $"Pieces: {piecesCounter}/4";
                    }
                }
                if (spritePictureBox.Bounds.IntersectsWith(piece2PictureBox.Bounds))
                {
                    if (!hasPiece2)
                    {
                        shady.Play();
                        hasPiece2 = true;
                        piecesCounter++;
                        piece2PictureBox.Visible = false;
                        inventoryLabel.Text = $"Pieces: {piecesCounter}/4";
                    }
                }
                if (spritePictureBox.Bounds.IntersectsWith(piece3PictureBox.Bounds))
                {
                    if(!hasPiece3)
                    {
                        shady.Play();
                        hasPiece3 = true;
                        piecesCounter++;
                        piece3PictureBox.Visible = false;
                        inventoryLabel.Text = $"Pieces: {piecesCounter}/4";
                    }
                }
                if (spritePictureBox.Bounds.IntersectsWith(piece4PictureBox.Bounds))
                {
                    if (!hasPiece4)
                    {
                        shady.Play();
                        hasPiece4 = true;
                        piecesCounter++;
                        piece4PictureBox.Visible = false;
                        inventoryLabel.Text = $"Pieces: {piecesCounter}/4";
                    }
                }
                if (spritePictureBox.Bounds.IntersectsWith(leftDoorPictureBox.Bounds) && currentRoomNumber != 5)
                {
                    doorEntered = "left";
                    nextRoom = roomList[currentRoomNumber - 1].LeftDoor - 1;
                    doorChecker();
                }
                else if (spritePictureBox.Bounds.IntersectsWith(rightDoorPictureBox.Bounds) && currentRoomNumber != 5)
                {
                    doorEntered = "right";
                    nextRoom = roomList[currentRoomNumber - 1].RightDoor - 1;
                    doorChecker();
                }
                else if (spritePictureBox.Bounds.IntersectsWith(topDoorPictureBox.Bounds) && currentRoomNumber != 5)
                {
                    if (currentRoomNumber == 3)
                    {
                        if (piecesCounter == 4)
                        {
                            doorEntered = "top";
                            nextRoom = roomList[currentRoomNumber - 1].TopDoor - 1;
                            doorChecker();
                        }
                        else
                            toolStripStatusLabel1.Text = "You have not collected all of the pieces yet!";
                    }
                    else
                    {
                        doorEntered = "top";
                        nextRoom = roomList[currentRoomNumber - 1].TopDoor - 1;
                        doorChecker();
                    } 
                }
                else if (spritePictureBox.Bounds.IntersectsWith(bottomDoorPictureBox.Bounds) && currentRoomNumber != 5)
                {
                    if (isMaze)
                    {
                        doorEntered = "bottom";
                        nextRoom = roomList[currentRoomNumber - 1].BottomDoor - 1;
                        doorChecker();
                    }
                }
            }
        }

        // checks the state of the doors in the current room to see which are locked, which are unlocked, and which havent been tried.
        private void doorChecker()
        {
            switch (currentRoomNumber)
            {
                case 1:
                    if (doorEntered == "left")
                    {
                        if (doorStatusList[0] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[0] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - (leftDoorPictureBox.Width) * 2), (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "right")
                    {
                        if (doorStatusList[2] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[2] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((rightDoorPictureBox.Width) * 2, (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "top")
                    {
                        if (doorStatusList[1] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[1] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - topDoorPictureBox.Width) / 2 + 20, (this.ClientSize.Height - bottomDoorPictureBox.Height * 3));
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "bottom")
                    {
                        if (doorStatusList[3] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[3] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - bottomDoorPictureBox.Width) / 2 + 20, topDoorPictureBox.Height * 2);
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }

                    break;
                case 2:
                    if (doorEntered == "left")
                    {
                        if (doorStatusList[4] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[4] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - (leftDoorPictureBox.Width) * 2), (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "right")
                    {
                        if (doorStatusList[0] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[0] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((rightDoorPictureBox.Width) * 2, (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "top")
                    {
                        if (doorStatusList[5] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[5] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - topDoorPictureBox.Width) / 2 + 20, (this.ClientSize.Height - bottomDoorPictureBox.Height * 3));
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "bottom")
                    {
                        if (doorStatusList[6] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[6] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - bottomDoorPictureBox.Width) / 2 + 20, topDoorPictureBox.Height * 2);
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    break;
                case 3:
                    if (doorEntered == "left")
                    {
                        if (doorStatusList[7] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[7] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - (leftDoorPictureBox.Width) * 2), (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "right")
                    {
                        if (doorStatusList[9] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[9] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((rightDoorPictureBox.Width) * 2, (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "top")
                    {
                        if (doorStatusList[8] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[8] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - topDoorPictureBox.Width) / 2 + 20, (this.ClientSize.Height - bottomDoorPictureBox.Height * 3));
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "bottom")
                    {
                        if (doorStatusList[5] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[5] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - bottomDoorPictureBox.Width) / 2 + 20, topDoorPictureBox.Height * 2);
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    break;
                case 4:
                    if (doorEntered == "left")
                    {
                        if (doorStatusList[9] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[9] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - (leftDoorPictureBox.Width) * 2), (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "right")
                    {
                        if (doorStatusList[11] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[11] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((rightDoorPictureBox.Width) * 2, (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "top")
                    {
                        if (doorStatusList[10] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[10] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - topDoorPictureBox.Width) / 2 + 20, (this.ClientSize.Height - bottomDoorPictureBox.Height * 3));
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    if (doorEntered == "bottom")
                    {
                        if (doorStatusList[1] == 0)
                        {
                            askQuestion();
                        }
                        else if (doorStatusList[1] == 1)
                        {
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - bottomDoorPictureBox.Width) / 2 + 20, topDoorPictureBox.Height * 2);
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                        }
                        else
                            toolStripStatusLabel1.Text = "Door is Locked!";
                    }
                    break;
            }
        }

        // Load SQLite Database data
        private void LoadQuestionList()
        {
            tables = SQLgate.LoadTable();
        }

        // Populate Form with random question from SQLite Database
        private void WireUpQuestionList()
        {
            int answerPosition = rnd.Next(0, 3);
            questionLabel.Text = tables[listNumbers[questionIterator]].Question1;
            switch (answerPosition)
            {
                case 0:
                    answer1RadioButton.Text = tables[listNumbers[questionIterator]].Answer1;
                    answer2RadioButton.Text = tables[listNumbers[questionIterator]].Answer2;
                    answer3RadioButton.Text = tables[listNumbers[questionIterator]].Answer3;
                    break;
                case 1:
                    answer1RadioButton.Text = tables[listNumbers[questionIterator]].Answer2;
                    answer2RadioButton.Text = tables[listNumbers[questionIterator]].Answer1;
                    answer3RadioButton.Text = tables[listNumbers[questionIterator]].Answer3;
                    break;
                case 2:
                    answer1RadioButton.Text = tables[listNumbers[questionIterator]].Answer1;
                    answer2RadioButton.Text = tables[listNumbers[questionIterator]].Answer3;
                    answer3RadioButton.Text = tables[listNumbers[questionIterator]].Answer2;
                    break;
            }
        }

        // Opens the map from anywhere in the game based on key input from above input checking.
        private void OpenMap()
        {
            if (isMaze)
            {
                if (!mapIsOpen)
                {
                    this.Controls.Add(mapPictureBox);
                    isPlaying = false;
                    mapIsOpen = true;
                    leftDoorPictureBox.Visible = false;
                    rightDoorPictureBox.Visible = false;
                    topDoorPictureBox.Visible = false;
                    bottomDoorPictureBox.Visible = false;
                    currentRoomLabel.Visible = false;
                    inventoryLabel.Visible = false;
                    spritePictureBox.Visible = false;
                    foreach (Control wall in mazeLabelList)
                    {
                        wall.Visible = false;
                    }
                    switch (currentRoomNumber)
                    {
                        case 1:
                            if (!hasPiece1)
                                piece1PictureBox.Visible = false;
                            break;
                        case 2:
                            if (!hasPiece2)
                                piece2PictureBox.Visible = false;
                            break;
                        case 3:
                            if (!hasPiece3)
                                piece3PictureBox.Visible = false;
                            break;
                        case 4:
                            if (!hasPiece4)
                                piece4PictureBox.Visible = false;
                            break;
                    }
                            mapPictureBox.Visible = true;
                }
                else
                {
                    this.Controls.Remove(mapPictureBox);
                    isPlaying = true;
                    leftDoorPictureBox.Visible = true;
                    rightDoorPictureBox.Visible = true;
                    topDoorPictureBox.Visible = true;
                    bottomDoorPictureBox.Visible = true;
                    currentRoomLabel.Visible = true;
                    inventoryLabel.Visible = true;
                    spritePictureBox.Visible = true;
                    foreach (Control wall in mazeLabelList)
                    {
                        wall.Visible = true;
                    }
                    switch(currentRoomNumber)
                    {
                        case 1:
                            if (!hasPiece1)
                                piece1PictureBox.Visible = true;
                            break;
                        case 2:
                            if (!hasPiece2)
                                piece2PictureBox.Visible = true;
                            break;
                        case 3:
                            if (!hasPiece3)
                                piece3PictureBox.Visible = true;
                            break;
                        case 4:
                            if (!hasPiece4)
                                piece4PictureBox.Visible = true;
                            break;
                    }
                    mapPictureBox.Visible = false;
                    mapIsOpen = false;
                }
            }
        }

        // Moves from one room to the next and populates the form accordingly with doors.
        public void UpdateRoom (Room currentRoom)
        {
            if (currentRoom == room5)
            {
                //currentRoomLabel.Text = "Room: " + currentRoom.RoomNumber.ToString();
                currentRoomLabel.Visible = false;
                inventoryLabel.Visible = false;
                toolStripStatusLabel1.Text = "Talk to Morty Jr.";
                spritePictureBox.Image = Properties.Resources.backmorty;
                currentRoomNumber = currentRoom.RoomNumber;
                this.Controls.Remove(leftDoorPictureBox);
                this.Controls.Remove(topDoorPictureBox);
                this.Controls.Remove(rightDoorPictureBox);
                this.Controls.Remove(bottomDoorPictureBox);
                spritePictureBox.Location = new Point((this.ClientSize.Width - spritePictureBox.Width) / 2, this.ClientSize.Height - (spritePictureBox.Height + spritePictureBox.Height/2));
                foreach (Control wall in mazeLabelList)
                {
                    wall.Visible = false;
                }
                piece3PictureBox.Visible = false;
                BackColor = Color.Red;
                this.Controls.Add(bossPictureBox);
                bossPictureBox.Width = 100;
                bossPictureBox.Height = 150;
                bossPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                bossPictureBox.Image = Properties.Resources.boss1;
                bossPictureBox.Location = new Point((this.ClientSize.Width - bossPictureBox.Width) / 2, (this.ClientSize.Height - bossPictureBox.Height) / 5);
            }
            else
            {
                currentRoomLabel.Text = "Room: " + currentRoom.RoomNumber.ToString();
                currentRoomNumber = currentRoom.RoomNumber;
                switch (currentRoomNumber)
                {
                    case 1:
                        BackColor = Color.LightGreen;
                        if (!hasPiece1)
                        {
                            this.Controls.Add(piece1PictureBox);
                            this.Controls.Remove(piece2PictureBox);
                            this.Controls.Remove(piece3PictureBox);
                            this.Controls.Remove(piece4PictureBox);
                            piece1PictureBox.Image = Properties.Resources.boxp;
                            piece1PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            piece1PictureBox.Width = 45;
                            piece1PictureBox.Height = 45;
                            piece1PictureBox.Location = new Point(75, this.ClientSize.Height - 125);
                        }
                        break;
                    case 2:
                        BackColor = Color.Yellow;
                        if (!hasPiece2)
                        {
                            this.Controls.Add(piece2PictureBox);
                            this.Controls.Remove(piece1PictureBox);
                            this.Controls.Remove(piece3PictureBox);
                            this.Controls.Remove(piece4PictureBox);
                            piece2PictureBox.Image = Properties.Resources.boxp;
                            piece2PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            piece2PictureBox.Width = 45;
                            piece2PictureBox.Height = 45;
                            piece2PictureBox.Location = new Point(75, 125);
                        }
                        break;
                    case 3:
                        BackColor = Color.Orange;
                        if (!hasPiece3)
                        {
                            this.Controls.Add(piece3PictureBox);
                            this.Controls.Remove(piece1PictureBox);
                            this.Controls.Remove(piece2PictureBox);
                            this.Controls.Remove(piece4PictureBox);
                            piece3PictureBox.Image = Properties.Resources.boxp;
                            piece3PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            piece3PictureBox.Width = 45;
                            piece3PictureBox.Height = 45;
                            piece3PictureBox.Location = new Point(this.ClientSize.Width - 75, 125);
                        }
                        break;
                    case 4:
                        BackColor = Color.MediumPurple;
                        if (!hasPiece4)
                        {
                            this.Controls.Add(piece4PictureBox);
                            this.Controls.Remove(piece1PictureBox);
                            this.Controls.Remove(piece2PictureBox);
                            this.Controls.Remove(piece3PictureBox);
                            piece4PictureBox.Image = Properties.Resources.boxp;
                            piece4PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            piece4PictureBox.Width = 45;
                            piece4PictureBox.Height = 45;
                            piece4PictureBox.Location = new Point(this.ClientSize.Width - 75, this.ClientSize.Height - 120);
                        }
                        break;
                }
                for (int i = 0; i < mazeLabelList.Count(); i++)
                {
                    this.Controls.Add(mazeLabelList[i]);
                    int labelHeight = rnd.Next(1, 45);
                    int labelWidth = 10;
                    int labelX = rnd.Next(this.ClientSize.Width - (this.ClientSize.Width / 4) * 3, this.ClientSize.Width - this.ClientSize.Width / 4);
                    int labelY = rnd.Next(this.ClientSize.Height - (this.ClientSize.Height / 3) * 2, this.ClientSize.Height - this.ClientSize.Height / 3);
                    while (!(labelX < spritePictureBox.Location.X || labelX > spritePictureBox.Location.X + spritePictureBox.Width) || (labelY < spritePictureBox.Location.Y || labelY > spritePictureBox.Location.Y + spritePictureBox.Height))
                    {
                        labelHeight = rnd.Next(1, 100);
                        labelWidth = rnd.Next(1, 20);
                        labelX = rnd.Next(this.ClientSize.Width - (this.ClientSize.Width / 4) * 3, this.ClientSize.Width - this.ClientSize.Width / 4);
                        labelY = rnd.Next(this.ClientSize.Height - (this.ClientSize.Height / 3) * 2, this.ClientSize.Height - this.ClientSize.Height / 3);
                    }
                    mazeLabelList[i].Height = labelHeight;
                    mazeLabelList[i].Width = labelWidth;
                    mazeLabelList[i].Location = new Point(labelX, labelY);
                }
            }
            doorUpdater();
        }

        // Form Load
        private void Form1_Load(object sender, EventArgs e)
        {
            StartMenu();
            this.KeyPreview = true;
            LoadQuestionList();
            int number;
            for (int i = 0; i < 20; i++)
            {
                do
                {
                    number = rnd.Next(0, 20);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }
        }

        // n/a
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        // this is load, not about
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Coming Soon!";
        }

        // Menu item Exit button
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // save not restart
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Coming Soon!";
        }

        // n/a
        private void topPictureBox_Click(object sender, EventArgs e)
        {

        }

        // the main menu when the game first starts
        private void StartMenu()
        {
            this.BackColor = Color.Black;
            themeSong.Play();

            Bitmap b = new Bitmap(new Bitmap(Properties.Resources.portalgun), 100, 100);
            this.Cursor = new Cursor(b.GetHicon());

            this.Controls.Add(titlePictureBox);
            titlePictureBox.Image = Properties.Resources.title;
            titlePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            titlePictureBox.Width = 500;
            titlePictureBox.Height = 125;
            titlePictureBox.Location = new Point(((this.ClientSize.Width - titlePictureBox.Width) / 2), 50);
            titlePictureBox.Click += this.PictureClick;

            this.Controls.Add(startPictureBox);
            startPictureBox.Image = Properties.Resources.start;
            startPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            startPictureBox.Location = new Point(titlePictureBox.Location.X, 320);
            startPictureBox.Width = 100;
            startPictureBox.Height = 50;
            startPictureBox.Click += this.PictureClick;

            this.Controls.Add(loadPictureBox);
            loadPictureBox.Image = Properties.Resources.load;
            loadPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            loadPictureBox.Location = new Point((this.ClientSize.Width - loadPictureBox.Width) / 2, 320);
            loadPictureBox.Width = 100;
            loadPictureBox.Height = 50;
            loadPictureBox.Click += this.PictureClick;

            this.Controls.Add(exitPictureBox);
            exitPictureBox.Image = Properties.Resources.exit;
            exitPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            exitPictureBox.Location = new Point((this.ClientSize.Width + (titlePictureBox.Width/2)) / 2, 320);
            exitPictureBox.Width = 100;
            exitPictureBox.Height = 50;
            exitPictureBox.Click += this.PictureClick;

            this.Controls.Add(menuIconPictureBox);
            menuIconPictureBox.Image = Properties.Resources.menu_icon;
            menuIconPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            menuIconPictureBox.Location = new Point((this.ClientSize.Width - menuIconPictureBox.Width) / 2, 175);
            menuIconPictureBox.Width = 130;
            menuIconPictureBox.Height = 120;
            menuIconPictureBox.Click += this.PictureClick;
            
            isPlaying = false;
            spritePictureBox.Visible = false;
            currentRoomLabel.Visible = false;
            inventoryLabel.Visible = false;
            toolStripMenuItem1.Visible = false;
            helpToolStripMenuItem.Visible = false;
            toolStripStatusLabel1.Visible = false;

        }

        // The first room entered after the main menu
        private void EntryRoom()
        {
            isPlaying = false;
            toolStripStatusLabel1.Text = "Talk to Rick";
            this.Controls.Add(bottomDoorPictureBox);
            bottomDoorPictureBox.Image = Properties.Resources.portl;
            bottomDoorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            bottomDoorPictureBox.Location = new Point((this.ClientSize.Width - bottomDoorPictureBox.Width) / 2 + 15, (this.ClientSize.Height - bottomDoorPictureBox.Height) - (toolStripStatusLabel1.Height) * 2 - bottomDoorPictureBox.Height - 20);
            bottomDoorPictureBox.Width = 70;
            bottomDoorPictureBox.Height = 70;
            bottomDoorPictureBox.Visible = true;
            //bottomPictureBox.Enabled = false;
            entryRoomPortalTimer.Start();
            Bitmap b = new Bitmap(new Bitmap(Properties.Resources.portalgun), 50, 50);
            this.Cursor = new Cursor(b.GetHicon());
            this.Controls.Remove(gifPictureBox);
            this.Controls.Remove(titlePictureBox);
            this.Controls.Remove(startPictureBox);
            this.Controls.Remove(loadPictureBox);
            this.Controls.Remove(exitPictureBox);
            this.Controls.Remove(menuIconPictureBox);
            this.Controls.Add(rickPictureBox);
            rickPictureBox.Image = Properties.Resources.rickNew;
            rickPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            rickPictureBox.Height = 110;
            rickPictureBox.Width = 50;
            spritePictureBox.Image = Properties.Resources.backmorty;
            rickPictureBox.Location = new Point((this.ClientSize.Width - rickPictureBox.Width) / 2, ((this.ClientSize.Height - rickPictureBox.Height) / 2) - ((this.ClientSize.Height - rickPictureBox.Height) / 4));
            spritePictureBox.Location = new Point((this.ClientSize.Width - spritePictureBox.Width) / 2, ((this.ClientSize.Height - spritePictureBox.Height) / 2) + ((this.ClientSize.Height - spritePictureBox.Height) / 6));
            BackColor = Color.LightBlue;
            spritePictureBox.Visible = true;
            toolStripMenuItem1.Visible = true;
            helpToolStripMenuItem.Visible = true;
            toolStripStatusLabel1.Visible = true;
        }

        // To talk to Rick when you collide with him
        private void TouchRick()
        {
            SoundPlayer goodJobMorty = new SoundPlayer(Properties.Resources.Good_Job_Morty);
            goodJobMorty.Play();
            isPlaying = false;
            toolStripStatusLabel1.Text = "Click the speech bubble to continue";
            this.Controls.Add(rickTalkingPictureBox);
            rickTalkingPictureBox.Image = Properties.Resources.RickTalk_1;
            rickTalkingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            rickTalkingPictureBox.Width = 500;
            rickTalkingPictureBox.Height = 150;
            rickTalkingPictureBox.Location = new Point(((this.ClientSize.Width - rickTalkingPictureBox.Width) / 2), this.ClientSize.Height - (rickTalkingPictureBox.Height) - 30);
            rickTalkingPictureBox.Click += this.PictureClick;

        }

        // To talk to the final boss when you collide with him
        private void TouchBoss()
        {
            growl.Play();
            isPlaying = false;
            toolStripStatusLabel1.Text = "Click the speech bubble to continue";
            this.Controls.Add(bossTalkingPictureBox);
            bossTalkingPictureBox.Image = Properties.Resources.boss_talk_1;
            bossTalkingPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            bossTalkingPictureBox.Width = 500;
            bossTalkingPictureBox.Height = 150;
            bossTalkingPictureBox.Location = new Point(((this.ClientSize.Width - bossTalkingPictureBox.Width) / 2), this.ClientSize.Height - (bossTalkingPictureBox.Height) - 30);
            bossTalkingPictureBox.Click += this.PictureClick;

        }

        // Starts the maze and enters the first room
        private void StartMaze()
        {
            isMaze = true;
            inventoryLabel.Text = $"Pieces: {piecesCounter}/4";
            portalRotateStart.Start();
            for (int i = 0; i <= 11; i++)
            {
                doorStatusList.Add(0);
            }
            bottomDoorPictureBox.Visible = true;
            topDoorPictureBox.Visible = true;
            toolStripStatusLabel1.Text = "Collect all of the pieces of the Portal Gun to save the world!";

            this.Controls.Add(leftDoorPictureBox);
            leftDoorPictureBox.Image = Properties.Resources.portl;
            leftDoorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            leftDoorPictureBox.Width = 70;
            leftDoorPictureBox.Height = 70;
            leftDoorPictureBox.Location = new Point((30), (this.ClientSize.Height - leftDoorPictureBox.Height) / 2);

            this.Controls.Add(rightDoorPictureBox);
            rightDoorPictureBox.Image = Properties.Resources.portl;
            rightDoorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            rightDoorPictureBox.Width = 70;
            rightDoorPictureBox.Height = 70;
            rightDoorPictureBox.Location = new Point((this.ClientSize.Width - rightDoorPictureBox.Width) - 30, (this.ClientSize.Height - rightDoorPictureBox.Height) / 2);

            topDoorPictureBox.Location = new Point((this.ClientSize.Width - topDoorPictureBox.Width) / 2, toolStripMenuItem1.Height + 30);

            mapPictureBox.Image = Properties.Resources.map;
            mapPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            mapPictureBox.Width = 400;
            mapPictureBox.Height = 400;
            mapPictureBox.Location = new Point(((this.ClientSize.Width - mapPictureBox.Width) / 2), (this.ClientSize.Height - mapPictureBox.Height) / 2);
            mapPictureBox.Click += this.PictureClick;

            inventoryPictureBox.Image = Properties.Resources.zelda_cooking_menu;
            inventoryPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            inventoryPictureBox.Width = 400;
            inventoryPictureBox.Height = 400;
            inventoryPictureBox.Location = new Point(((this.ClientSize.Width - inventoryPictureBox.Width) / 2), (this.ClientSize.Height - inventoryPictureBox.Height) / 2);
            inventoryPictureBox.Click += this.PictureClick;

            for (int i = 0; i < 5; i++)
            {
                mazeLabelList.Add(new Label());
            }

            mapPictureBox.Visible = false;
            inventoryPictureBox.Visible = false;

            isPlaying = true;
            this.Controls.Remove(rickPictureBox);
            rickPictureBox.Enabled = false;
            this.Controls.Remove(rickTalkingPictureBox);
            BackColor = Color.LightGreen;
            spritePictureBox.Visible = true;
            currentRoomLabel.Visible = true;
            inventoryLabel.Visible = true;
            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            roomList.Add(room4);
            roomList.Add(room5);
            currentRoomNumber = room1.RoomNumber;
            UpdateRoom(room1);
        }

        // Button click handler for closing instructions and submitting an answer to a question
        private void ButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            if (clickedButton == closeInstructionsButton)
            {
                isPlaying = true;
                foreach (Control control in this.Controls)
                {
                    if (control.Bounds.IntersectsWith(instructionsLabel.Bounds) && ((control != closeInstructionsButton) && (control != instructionsLabel) && (control != questionLabel) && (control != answer1RadioButton) && (control != answer2RadioButton) && (control != answer3RadioButton)))
                    {
                        control.Visible = true;
                        if (!isMaze)
                        {
                            bottomDoorPictureBox.Visible = false;
                        }
                    }
                    if (hasPiece1)
                    {
                        piece1PictureBox.Visible = false;
                    }
                    if (hasPiece2)
                    {
                        piece2PictureBox.Visible = false;
                    }
                    if (hasPiece3)
                    {
                        piece3PictureBox.Visible = false;
                    }
                    if (hasPiece4)
                    {
                        piece4PictureBox.Visible = false;
                    }
                    if ((control == closeInstructionsButton) || (control == instructionsLabel))
                    {
                        control.Visible = false;
                    }
                }
                if (isMaze)
                {
                    currentRoomLabel.Visible = true;
                    inventoryLabel.Visible = true;
                }
                this.Controls.Remove(instructionsLabel);
                this.Controls.Remove(closeInstructionsButton);
                this.Focus();
            }
            else if (clickedButton == submitAnswerButton)
            {
                // compare checked radio button to answer 2 (correct answer)
                if (answer1RadioButton.Checked)
                {
                    if (answer1RadioButton.Text == tables[listNumbers[questionIterator]].Answer2)
                    {
                        isCorrect = true;
                    }
                }
                else if (answer2RadioButton.Checked)
                {
                    if (answer2RadioButton.Text == tables[listNumbers[questionIterator]].Answer2)
                    {
                        isCorrect = true;
                    }
                }
                else if (answer3RadioButton.Checked)
                {
                    if (answer3RadioButton.Text == tables[listNumbers[questionIterator]].Answer2)
                    {
                        isCorrect = true;
                    }
                }
                
                isPlaying = true;
                leftDoorPictureBox.Visible = true;
                rightDoorPictureBox.Visible = true;
                topDoorPictureBox.Visible = true;
                bottomDoorPictureBox.Visible = true;
                currentRoomLabel.Visible = true;
                spritePictureBox.Visible = true;
                inventoryLabel.Visible = true;
                switch (currentRoomNumber)
                {
                    case 1:
                        if (!hasPiece1)
                        piece1PictureBox.Visible = true;
                        break;
                    case 2:
                        if (!hasPiece2)
                            piece2PictureBox.Visible = true;
                        break;
                    case 3:
                        if (!hasPiece3)
                            piece3PictureBox.Visible = true;
                        break;
                    case 4:
                        if (!hasPiece4)
                            piece4PictureBox.Visible = true;
                        break;
                }
                foreach (Control wall in mazeLabelList)
                {
                    wall.Visible = true;
                }
                questionLabel.Visible = false;
                submitAnswerButton.Visible = false;
                answer1RadioButton.Visible = false;
                answer2RadioButton.Visible = false;
                answer3RadioButton.Visible = false;

                if (isCorrect)
                {
                    if (isMaze)
                        currentRoomLabel.Visible = true;
                    this.Focus();
                    switch (currentRoomNumber)
                    {
                        case 1:
                            if (doorEntered == "left")
                                doorStatusList[0] = 1;
                            else if (doorEntered == "right")
                                doorStatusList[2] = 1;
                            else if (doorEntered == "top")
                                doorStatusList[1] = 1;
                            else if (doorEntered == "bottom")
                                doorStatusList[3] = 1;
                            break;
                        case 2:
                            if (doorEntered == "left")
                                doorStatusList[4] = 1;
                            else if (doorEntered == "right")
                                doorStatusList[0] = 1;
                            else if (doorEntered == "top")
                                doorStatusList[5] = 1;
                            else if (doorEntered == "bottom")
                                doorStatusList[6] = 1;
                            break;
                        case 3:
                            if (doorEntered == "left")
                                doorStatusList[7] = 1;
                            else if (doorEntered == "right")
                                doorStatusList[9] = 1;
                            else if (doorEntered == "top")
                                doorStatusList[8] = 1;
                            else if (doorEntered == "bottom")
                                doorStatusList[5] = 1;
                            break;
                        case 4:
                            if (doorEntered == "left")
                                doorStatusList[9] = 1;
                            else if (doorEntered == "right")
                                doorStatusList[11] = 1;
                            else if (doorEntered == "top")
                                doorStatusList[10] = 1;
                            else if (doorEntered == "bottom")
                                doorStatusList[1] = 1;
                            break;
                    }
                    switch (doorEntered)
                    {
                        case "left":
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - (leftDoorPictureBox.Width) * 2), (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                            break;
                        case "right":
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((rightDoorPictureBox.Width) * 2, (this.ClientSize.Height - spritePictureBox.Height) / 2);
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                            break;
                        case "top":
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - topDoorPictureBox.Width) / 2 + 20, (this.ClientSize.Height - bottomDoorPictureBox.Height * 3));
                            toolStripStatusLabel1.Text = ("Correct Answer, Door Unlocked.");
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                            break;
                        case "bottom":
                            if (nextRoom < 0)
                                nextRoom = rnd.Next(1, 4);
                            spritePictureBox.Location = new Point((this.ClientSize.Width - bottomDoorPictureBox.Width) / 2 + 20, topDoorPictureBox.Height * 2);
                            portalGunSound.Play();
                            UpdateRoom(roomList[nextRoom]);
                            break;
                    }
                }
                else if (!isCorrect) // if ans not correct
                {
                    toolStripStatusLabel1.Text = "Wrong Answer. Door is now Locked!";
                    switch (currentRoomNumber)
                    {
                        case 1:
                            if (doorEntered == "left")
                                doorStatusList[0] = 2;
                            else if (doorEntered == "right")
                                doorStatusList[2] = 2;
                            else if (doorEntered == "top")
                                doorStatusList[1] = 2;
                            else if (doorEntered == "bottom")
                                doorStatusList[3] = 2;
                            break;
                        case 2:
                            if (doorEntered == "left")
                                doorStatusList[4] = 2;
                            else if (doorEntered == "right")
                                doorStatusList[0] = 2;
                            else if (doorEntered == "top")
                                doorStatusList[5] = 2;
                            else if (doorEntered == "bottom")
                                doorStatusList[6] = 2;
                            break;
                        case 3:
                            if (doorEntered == "left")
                                doorStatusList[7] = 2;
                            else if (doorEntered == "right")
                                doorStatusList[9] = 2;
                            else if (doorEntered == "top")
                                doorStatusList[8] = 2;
                            else if (doorEntered == "bottom")
                                doorStatusList[5] = 2;
                            break;
                        case 4:
                            if (doorEntered == "left")
                                doorStatusList[9] = 2;
                            else if (doorEntered == "right")
                                doorStatusList[11] = 2;
                            else if (doorEntered == "top")
                                doorStatusList[10] = 2;
                            else if (doorEntered == "bottom")
                                doorStatusList[1] = 2;
                            break;
                    }
                    ohGeez.Play();
                    doorUpdater();
                }
                iterationTimer.Start();
                isCorrect = false;
            }
        }

        // updates the doors images to reflect their status as untouched, open, or locked
        private void doorUpdater()
        {
            leftDoorPictureBox.Image = Properties.Resources.portl;
            topDoorPictureBox.Image = Properties.Resources.portl;
            rightDoorPictureBox.Image = Properties.Resources.portl;
            bottomDoorPictureBox.Image = Properties.Resources.portl;
            if (piecesCounter != 4)
            doorStatusList[8] = 0;
            switch (currentRoomNumber)
            {
                case 1:
                    if (doorStatusList[0] == 1)
                        leftDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[0] == 2)
                        leftDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[1] == 1)
                        topDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[1] == 2)
                        topDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[2] == 1)
                        rightDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[2] == 2)
                        rightDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[3] == 1)
                        bottomDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[3] == 2)
                        bottomDoorPictureBox.Image = Properties.Resources.redportal;
                    break;
                case 2:
                    if (doorStatusList[4] == 1)
                        leftDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[4] == 2)
                        leftDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[5] == 1)
                        topDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[5] == 2)
                        topDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[0] == 1)
                        rightDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[0] == 2)
                        rightDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[6] == 1)
                        bottomDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[6] == 2)
                        bottomDoorPictureBox.Image = Properties.Resources.redportal;
                    break;
                case 3:
                    if (doorStatusList[7] == 1)
                        leftDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[7] == 2)
                        leftDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[8] == 1)
                        topDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[8] == 2)
                        endGameTImer.Start();
                    if (doorStatusList[9] == 1)
                        rightDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[9] == 2)
                        rightDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[5] == 1)
                        bottomDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[5] == 2)
                        bottomDoorPictureBox.Image = Properties.Resources.redportal;
                    break;
                case 4:
                    if (doorStatusList[9] == 1)
                        leftDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[9] == 2)
                        leftDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[10] == 1)
                        topDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[10] == 2)
                        topDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[11] == 1)
                        rightDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[11] == 2)
                        rightDoorPictureBox.Image = Properties.Resources.redportal;
                    if (doorStatusList[1] == 1)
                        bottomDoorPictureBox.Image = Properties.Resources.blueportal;
                    else if (doorStatusList[1] == 2)
                        bottomDoorPictureBox.Image = Properties.Resources.redportal;
                    break;
            }

            // if locked in a room
            switch (currentRoomNumber)
            {
                case 1:
                    if (doorStatusList[0] == 2 && doorStatusList[1] == 2 && doorStatusList[2] == 2 && doorStatusList[3] == 2)
                        endGameTImer.Start();
                    break;
                case 2:
                    if (doorStatusList[4] == 2 && doorStatusList[5] == 2 && doorStatusList[0] == 2 && doorStatusList[6] == 2)
                        endGameTImer.Start();
                    break;
                case 3:
                    if (doorStatusList[7] == 2 && doorStatusList[8] == 2 && doorStatusList[9] == 2 && doorStatusList[5] == 2)
                        endGameTImer.Start();
                    break;
                case 4:
                    if (doorStatusList[9] == 2 && doorStatusList[10] == 2 && doorStatusList[11] == 2 && doorStatusList[1] == 2)
                        endGameTImer.Start();
                    break;
            }

            if (!hasPiece1 && doorStatusList[0] == 2 && doorStatusList[1] == 2 && doorStatusList[2] == 2 && doorStatusList[3] == 2)
                endGameTImer.Start();
            if (!hasPiece2 && doorStatusList[4] == 2 && doorStatusList[5] == 2 && doorStatusList[0] == 2 && doorStatusList[6] == 2)
                endGameTImer.Start();
            if (!hasPiece3 && doorStatusList[7] == 2 && doorStatusList[8] == 2 && doorStatusList[9] == 2 && doorStatusList[5] == 2)
                endGameTImer.Start();
            if (!hasPiece4 && doorStatusList[9] == 2 && doorStatusList[10] == 2 && doorStatusList[11] == 2 && doorStatusList[1] == 2)
                endGameTImer.Start();

        }

        // click handler for picture box clicks to talk with characters and interact with main menu items
        private void PictureClick(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;

            if (clickedPictureBox == startPictureBox)
            {
                portalGunSound.Play();
                EntryRoom();
            }
            else if (clickedPictureBox == loadPictureBox)
            {
                portalGunSound.Play();
                MessageBox.Show("Coming Soon!");
            }
            else if (clickedPictureBox == exitPictureBox)
            {
                Application.Exit();
            }
            else if (clickedPictureBox == menuIconPictureBox)
            {

                ohGeez.Play();
            }
            else if (clickedPictureBox == rickTalkingPictureBox)
            {
                SoundPlayer burp = new SoundPlayer(Properties.Resources.burp);
                if (rickTalking < 4)
                    burp.Play();
                switch (rickTalking)
                {
                    case 0:
                        rickTalkingPictureBox.Image = Properties.Resources.RickTalk_2;
                        break;
                    case 1:
                        rickTalkingPictureBox.Image = Properties.Resources.RickTalk_3;
                        break;
                    case 2:
                        rickTalkingPictureBox.Image = Properties.Resources.RickTalk_4;
                        rickPictureBox.Location = new Point((this.ClientSize.Width - rickPictureBox.Width) / 2, rickPictureBox.Location.Y - 10);
                        break;
                    case 3:
                        rickTalkingPictureBox.Image = Properties.Resources.RickTalk_5;
                        rickPictureBox.Location = new Point((this.ClientSize.Width - rickPictureBox.Width) / 2, rickPictureBox.Location.Y - 10);
                        rickPictureBox.Image = Properties.Resources.rickfinger;
                        this.Controls.Add(topDoorPictureBox);
                        topDoorPictureBox.Image = Properties.Resources.portl;
                        topDoorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        topDoorPictureBox.Width = 70;
                        topDoorPictureBox.Height = 70;
                        topDoorPictureBox.Location = new Point(((this.ClientSize.Width - topDoorPictureBox.Width) / 2) + 60, toolStripMenuItem1.Height + 55);
                        portalRotateStart.Start();
                        break;
                    case 4:
                        rickPictureBox.Visible = false;
                        portalGunSound.Play();
                        break;
                    case 5:
                        topDoorPictureBox.Visible = false;
                        ohGeez.Play();
                        rickTalkingPictureBox.Image = Properties.Resources.RickTalk_6;
                        break;
                    case 6:
                        portalGunSound.Play();
                        StartMaze();
                        break;
                }
                rickTalking++;
            }
            else if (clickedPictureBox == bossTalkingPictureBox)
            {
                SoundPlayer burp = new SoundPlayer(Properties.Resources.burp);
                if (bossTalking < 4)
                    growl2.Play();
                switch (bossTalking)
                {
                    case 0:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_1;
                        break;
                    case 1:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_2;
                        break;
                    case 2:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_3;
                        break;
                    case 3:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_4;
                        this.Controls.Add(topDoorPictureBox);
                        topDoorPictureBox.Image = Properties.Resources.portl;
                        topDoorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        topDoorPictureBox.Width = 70;
                        topDoorPictureBox.Height = 70;
                        topDoorPictureBox.Location = new Point(((this.ClientSize.Width - topDoorPictureBox.Width) / 2) + 100, toolStripMenuItem1.Height + 55);
                        break;
                    case 4:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_5;
                        portalGunSound.Play();
                        this.Controls.Add(summerPictureBox);
                        summerPictureBox.Image = Properties.Resources.summer1;
                        summerPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        summerPictureBox.Width = 25;
                        summerPictureBox.Height = 100;
                        summerPictureBox.Location = new Point(((this.ClientSize.Width - topDoorPictureBox.Width) / 2) + 125, toolStripMenuItem1.Height + topDoorPictureBox.Height * 2);
                        break;
                    case 5:
                        // add new mad morty sound
                        ohGeez.Play(); 
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_6;
                        break;
                    case 6:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_7;
                        break;
                    case 7:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_8;
                        break;
                    case 8:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_9;
                        break;
                    case 9:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_10;
                        break;
                    case 10:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_4;
                        // open portal
                        this.Controls.Add(leftDoorPictureBox);
                        leftDoorPictureBox.Image = Properties.Resources.portl;
                        leftDoorPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        leftDoorPictureBox.Width = 70;
                        leftDoorPictureBox.Height = 70;
                        leftDoorPictureBox.Location = new Point(((this.ClientSize.Width - leftDoorPictureBox.Width) / 4), spritePictureBox.Location.Y);
                        break;
                    case 11:
                        bossTalkingPictureBox.Image = Properties.Resources.boss_talk_5;
                        // walk towards portal
                        spritePictureBox.Location = new Point((spritePictureBox.Location.X - (spritePictureBox.Location.X - leftDoorPictureBox.Location.X) / 2), spritePictureBox.Location.Y);
                        break;
                    case 12:
                        // leave through portal
                        portalGunSound.Play();
                        spritePictureBox.Visible = false;
                        break;
                    case 13:
                        bossTalkingPictureBox.Visible = false;
                        // summer cry
                        summerPictureBox.Image = Properties.Resources.summercrying;
                        muder.Play();
                        summerPictureBox.Width *= 2;
                        leftDoorPictureBox.Visible = false;
                        endGameTImer.Start();
                        break;

                }
                bossTalking++;
            }
        }

        // Open instructions from menu strip
        private void instructionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string resource_data = Properties.Resources.instructions;
            string[] words = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            currentRoomLabel.Visible = false;
            inventoryLabel.Visible = false;
            foreach (string lines in words)
            {
                isPlaying = false;
                this.Controls.Add(instructionsLabel);
                instructionsLabel.AutoSize = false;
                instructionsLabel.Font = new Font("Arial", 10, FontStyle.Bold);
                instructionsLabel.Width = this.ClientSize.Width-20;
                instructionsLabel.Height = this.ClientSize.Height/2;
                instructionsLabel.Location = new Point(((this.ClientSize.Width - instructionsLabel.Width) / 2), (this.ClientSize.Height - instructionsLabel.Height) / 2);
                instructionsLabel.Text = lines;
                this.Controls.Add(closeInstructionsButton);
                closeInstructionsButton.Click += this.ButtonClick;
                closeInstructionsButton.Text = "Got it!";
                closeInstructionsButton.BackColor = Color.LightGreen;
                closeInstructionsButton.Height = 50;
                closeInstructionsButton.Width = 100;
                closeInstructionsButton.Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 100);
                foreach (Control control in this.Controls)
                {
                    if ((control.Bounds.IntersectsWith(instructionsLabel.Bounds) && (control != instructionsLabel)))
                    {
                        control.Visible = false;
                    }
                    else if (control == closeInstructionsButton || control == instructionsLabel)
                    {
                        control.Visible = true;
                    }
                }
                
            }
        }

        // Open the question and asnwer
        private void askQuestion()
        {
            
            isPlaying = false;
                this.Controls.Add(questionLabel);
                questionLabel.AutoSize = false;
            questionLabel.Font = new Font("Rick_and_Morty", 24, FontStyle.Regular);
            questionLabel.Width = this.ClientSize.Width - 20;
            questionLabel.Height = this.ClientSize.Height / 20;
            questionLabel.Location = new Point(((this.ClientSize.Width - questionLabel.Width) / 2), questionLabel.Height + 15);
            questionLabel.Text = "Question Goes Here:";
            questionLabel.Visible = true;
                this.Controls.Add(submitAnswerButton);
            submitAnswerButton.Click += this.ButtonClick;
            submitAnswerButton.Text = "Submit Answer";
            submitAnswerButton.BackColor = Color.LightGreen;
            submitAnswerButton.Height = 50;
            submitAnswerButton.Width = 100;
            submitAnswerButton.Location = new Point(this.ClientSize.Width - 200, this.ClientSize.Height - 100);
            submitAnswerButton.Visible = true;
            leftDoorPictureBox.Visible = false;
            rightDoorPictureBox.Visible = false;
            topDoorPictureBox.Visible = false;
            bottomDoorPictureBox.Visible = false;
            currentRoomLabel.Visible = false;
            inventoryLabel.Visible = false;
            spritePictureBox.Visible = false;
            inventoryLabel.Visible = false;
            foreach (Control wall in mazeLabelList)
            {
                wall.Visible = false;
            }
            switch (currentRoomNumber)
            {
                case 1:
                    if (!hasPiece1)
                        piece1PictureBox.Visible = false;
                    break;
                case 2:
                    if (!hasPiece2)
                        piece2PictureBox.Visible = false;
                    break;
                case 3:
                    if (!hasPiece3)
                        piece3PictureBox.Visible = false;
                    break;
                case 4:
                    if (!hasPiece4)
                        piece4PictureBox.Visible = false;
                    break;
            }
            this.Controls.Add(answer1RadioButton);
            answer1RadioButton.Font = new Font("Rick_and_Morty", 24, FontStyle.Regular);
            answer1RadioButton.Location = new Point(10, 5 * questionLabel.Height);
            answer1RadioButton.AutoSize = true;
            answer1RadioButton.Text = "Answer 1 Goes Here";
            answer1RadioButton.Visible = true;
            this.Controls.Add(answer2RadioButton);
            answer2RadioButton.Font = new Font("Rick_and_Morty", 24, FontStyle.Regular);
            answer2RadioButton.Location = new Point(10, 10 * questionLabel.Height);
            answer2RadioButton.AutoSize = true;
            answer2RadioButton.Text = "Answer 2 Goes Here";
            answer2RadioButton.Visible = true;
            this.Controls.Add(answer3RadioButton);
            answer3RadioButton.Font = new Font("Rick_and_Morty", 24, FontStyle.Regular);
            answer3RadioButton.Location = new Point(10, 15 * questionLabel.Height);
            answer3RadioButton.AutoSize = true;
            answer3RadioButton.Text = "Answer 3 Goes Here";
            answer3RadioButton.Visible = true;
            WireUpQuestionList();
        }

        // actual about
        private void aboutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "A trivia maze game by Nick Sullivan, Irakli Gordadze, and Nika Tbileli.";
            aboutTimer.Start();
        }

        // timer to control morty's entry portal
        private void entryRoomPortalTimer_Tick(object sender, EventArgs e)
        {
            bottomDoorPictureBox.Visible = false;
            isPlaying = true;
            entryRoomPortalTimer.Stop();
        }

        // timer that hides the about info and shows the objective
        private void aboutTimer_Tick(object sender, EventArgs e)
        {
            if (isMaze)
            {
                toolStripStatusLabel1.Text = "Collect all of the pieces of the Portal Gun to save the world!";
            }
            else
                toolStripStatusLabel1.Text = "Talk to Rick";
        }

        // timer that constantly spins the portals
        private void portalRotateStart_Tick(object sender, EventArgs e)
        {
            if (isMaze)
            {
                Image img1 = leftDoorPictureBox.Image;
                img1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                leftDoorPictureBox.Image = img1;
                Image img2 = rightDoorPictureBox.Image;
                img2.RotateFlip(RotateFlipType.Rotate90FlipNone);
                rightDoorPictureBox.Image = img2;
            }
            Image img3 = bottomDoorPictureBox.Image;
            img3.RotateFlip(RotateFlipType.Rotate90FlipNone);
            bottomDoorPictureBox.Image = img3;
            Image img4 = topDoorPictureBox.Image;
            img4.RotateFlip(RotateFlipType.Rotate90FlipNone);
            topDoorPictureBox.Image = img4;
            portalRotateStart.Start();
        }

        // timer to end the game
        private void endGameTImer_Tick(object sender, EventArgs e)
        {
            foreach(Control control in Controls)
            {
                control.Visible = false;
            }
            this.Controls.Add(endGamePictureBox);
            this.BackColor = Color.Black;
            endGamePictureBox.Image = Properties.Resources.gameOver;
            themeSong.Play();
            endGamePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            endGamePictureBox.Width = 350;
            endGamePictureBox.Height = 150;
            endGamePictureBox.Location = new Point((this.ClientSize.Width - endGamePictureBox.Width) / 2, (this.ClientSize.Height - endGamePictureBox.Height) / 2);
            endGameTImer.Enabled = false;
        }

        // To update the questions after the sprite is away from the portal to avoid extra collisions.
        private void iterationTimer_Tick(object sender, EventArgs e)
        {
            questionIterator++;
            iterationTimer.Enabled = false;
            //toolStripStatusLabel1.Text = questionIterator.ToString();
        }

        // cheating mechanism to bring you to end of the game.
        private void cheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isMaze)
            {
                UpdateRoom(room5);
                for (int i = 0; i < doorStatusList.Count; i++)
                    doorStatusList[i] = 0;
                piecesCounter = 4;
                piece1PictureBox.Visible = false;
                piece2PictureBox.Visible = false;
                piece3PictureBox.Visible = false;
                piece4PictureBox.Visible = false;
                toolStripStatusLabel1.Text = "Brought to the last room and all pieces found.";
            }
            else
                toolStripStatusLabel1.Text = "Please Talk to Rick before Cheating!";


        }
    }
}
