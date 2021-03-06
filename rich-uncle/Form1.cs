﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static rich_uncle.GlobalVariables;
namespace rich_uncle
{
    public partial class FormMain : Form
    {
        // ==================================== class private fields ========================================

        // for every player in the game
        Thread[] t; // players thread
        Player[] p;
        Thread turnThrd; // dice roll thread
        bool buy;
        System.Media.SoundPlayer diceSound = new System.Media.SoundPlayer("dice.wav");

        // ================================== class public functions ========================================
        public FormMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        public Point getHouseLocation(short number) // to get the location of the houses
        {
            switch (number)
            {
                case 1:
                    return label1.Location;
                case 2:
                    return label2.Location;
                case 3:
                    return label3.Location;
                case 4:
                    return label4.Location;
                case 5:
                    return label5.Location;
                case 6:
                    return label6.Location;
                case 7:
                    return label7.Location;
                case 8:
                    return label8.Location;
                case 9:
                    return label9.Location;
                case 10:
                    return label10.Location;
                case 11:
                    return label11.Location;
                case 12:
                    return label12.Location;
                case 13:
                    return label13.Location;
                case 14:
                    return label14.Location;
                case 15:
                    return label15.Location;
                case 16:
                    return label16.Location;
                case 17:
                    return label17.Location;
                case 18:
                    return label18.Location;
                case 19:
                    return label19.Location;
                case 20:
                    return label20.Location;
                case 21:
                    return label21.Location;
                case 22:
                    return label22.Location;
                case 23:
                    return label23.Location;
                case 24:
                    return label24.Location;
                case 25:
                    return label25.Location;
                case 26:
                    return label26.Location;
                case 27:
                    return label27.Location;
                case 28:
                    return label28.Location;
                case 29:
                    return label29.Location;
                case 30:
                    return label30.Location;
                case 31:
                    return label31.Location;
                case 32:
                    return label32.Location;
                case 33:
                    return label33.Location;
                case 34:
                    return label34.Location;
                case 35:
                    return label35.Location;
                case 36:
                    return label36.Location;
                case 37:
                    return label37.Location;
                case 38:
                    return label38.Location;
                case 39:
                    return label39.Location;
                case 40:
                    return label40.Location;
                default:
                    return new Point(0, 0);
            }
        }
        public bool GotInfo { get; set; }

        // ================================== class private functions =======================================
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {

            if (!init())
                return;

            GlobalVariables glv = new GlobalVariables(this);


            initializeHouses();

            paintHouses(); // rondom colorization of 40 houses
            showNamesAndPrices();

            p = new Player[NumberOfPlayers];
            t = new Thread[NumberOfPlayers];

            // DON't mess with the order, we use this order in the game
            Color[] c = { Color.DodgerBlue, Color.Green, Color.Red, Color.Yellow };

            turnThrd = new Thread(new ThreadStart(chooseTurn));

            for (short i = 0; i < NumberOfPlayers; i++)
            {
                p[i] = new Player(this, c[i], i, turnThrd, 12, 12);
                t[i] = new Thread(new ThreadStart(p[i].startPlaying));
                t[i].Name = i.ToString();
            }
            for (int i = 0; i < NumberOfPlayers; i++)
                t[i].Start(); // players start playing

            turnThrd.Start(); // start rolling dices

            buttonStart.Enabled = false;
            buttonStart.Visible = false;

        }
        // following are the values initialized in getInfo Form, and we validate by 'gotInfo'
        private bool init() // get config's from user
        {
            getInfo gf = new getInfo(this);
            gf.ShowDialog();

            if (!GotInfo)
            {
                MessageBox.Show("Please enter correct input!", "Wrong info received",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (ushort i = 0; i < NumberOfPlayers; i++)
            {
                switch (i)
                {
                    case 0:
                        labelOwners0.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case 1:
                        labelOwners1.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case 2:
                        labelOwners2.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case 3:
                        labelOwners3.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    default:
                        break;
                }
            }


            return true;

        }
        private void initializeHouses()
        {

            for (ushort number = 1; number <= NumberOfHouses; number++)
            {
                switch (number)
                {
                    case 1:
                        housesInTheGame[number] = new House(label1, number);
                        break;
                    case 2:
                        housesInTheGame[number] = new House(label2, number);
                        break;
                    case 3:
                        housesInTheGame[number] = new House(label3, number);
                        break;
                    case 4:
                        housesInTheGame[number] = new House(label4, number);
                        break;
                    case 5:
                        housesInTheGame[number] = new House(label5, number);
                        break;
                    case 6:
                        housesInTheGame[number] = new House(label6, number);
                        break;
                    case 7:
                        housesInTheGame[number] = new House(label7, number);
                        break;
                    case 8:
                        housesInTheGame[number] = new House(label8, number);
                        break;
                    case 9:
                        housesInTheGame[number] = new House(label9, number);
                        break;
                    case 10:
                        housesInTheGame[number] = new House(label10, number);
                        break;
                    case 11:
                        housesInTheGame[number] = new House(label11, number);
                        break;
                    case 12:
                        housesInTheGame[number] = new House(label12, number);
                        break;
                    case 13:
                        housesInTheGame[number] = new House(label13, number);
                        break;
                    case 14:
                        housesInTheGame[number] = new House(label14, number);
                        break;
                    case 15:
                        housesInTheGame[number] = new House(label15, number);
                        break;
                    case 16:
                        housesInTheGame[number] = new House(label16, number);
                        break;
                    case 17:
                        housesInTheGame[number] = new House(label17, number);
                        break;
                    case 18:
                        housesInTheGame[number] = new House(label18, number);
                        break;
                    case 19:
                        housesInTheGame[number] = new House(label19, number);
                        break;
                    case 20:
                        housesInTheGame[number] = new House(label20, number);
                        break;
                    case 21:
                        housesInTheGame[number] = new House(label21, number);
                        break;
                    case 22:
                        housesInTheGame[number] = new House(label22, number);
                        break;
                    case 23:
                        housesInTheGame[number] = new House(label23, number);
                        break;
                    case 24:
                        housesInTheGame[number] = new House(label24, number);
                        break;
                    case 25:
                        housesInTheGame[number] = new House(label25, number);
                        break;
                    case 26:
                        housesInTheGame[number] = new House(label26, number);
                        break;
                    case 27:
                        housesInTheGame[number] = new House(label27, number);
                        break;
                    case 28:
                        housesInTheGame[number] = new House(label28, number);
                        break;
                    case 29:
                        housesInTheGame[number] = new House(label29, number);
                        break;
                    case 30:
                        housesInTheGame[number] = new House(label30, number);
                        break;
                    case 31:
                        housesInTheGame[number] = new House(label31, number);
                        break;
                    case 32:
                        housesInTheGame[number] = new House(label32, number);
                        break;
                    case 33:
                        housesInTheGame[number] = new House(label33, number);
                        break;
                    case 34:
                        housesInTheGame[number] = new House(label34, number);
                        break;
                    case 35:
                        housesInTheGame[number] = new House(label35, number);
                        break;
                    case 36:
                        housesInTheGame[number] = new House(label36, number);
                        break;
                    case 37:
                        housesInTheGame[number] = new House(label37, number);
                        break;
                    case 38:
                        housesInTheGame[number] = new House(label38, number);
                        break;
                    case 39:
                        housesInTheGame[number] = new House(label39, number);
                        break;
                    case 40:
                        housesInTheGame[number] = new House(label40, number);
                        break;
                    default:
                        break;
                }
            }
        }
        // main function of this class leis here as it rolls the dice and give turn to players
        private void chooseTurn()
        {
            string[] playersName = { "Blue", "Green", "Red", "Yellow" };

            short[] turns = { -1, -1, -1, -1 };
            bool[] stuck = { false, false, false, false };

            // first dice roll
            writeResultOfPlayers(playersName);
            showBankDeposit(BankDeposit);

            short countTurns = 0; // iterate to the number of players in turns
            short nextPosition = 0; // house to be occupied
            try // first roll of the dice
            {
                short maxDice = 0, firstToMove = -1; // to determine the first player
                short currentDice = 0;
                for (short i = 0; i < NumberOfPlayers; i++)
                {


                    currentDice = rollTheDice(p[i].MoveColor);
                    if (currentDice > maxDice)
                    {
                        maxDice = currentDice;
                        firstToMove = i;
                    }
                    p[i].NumberOfMovements = currentDice; // everyone's turn is determined here
                }

                turns[countTurns++] = firstToMove;

                colorizeDiceRoller(p[firstToMove].MoveColor, maxDice);

                nextPosition = (short)(p[turns[0]].CurrentHouse + p[turns[0]].NumberOfMovements);

                //t[firstToMove].Resume();
                //Thread.CurrentThread.Suspend();
                playerMoveLock[firstToMove].Release();
                chooseTurnLock.WaitOne();

                for (short i = 0; i < NumberOfPlayers; i++)
                    if (i != firstToMove)
                        turns[countTurns++] = i;


                buyCurrentHouse(turns[0], playersName[turns[0]],
                    nextPosition); // should we buy?


                currentDice = p[turns[0]].NumberOfMovements;

                if (currentDice == 6)
                    countTurns = 0;
                else
                    countTurns = 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } // just in case, if something goes wrong



            bool gameFinished = true;

            do
            {

                gameFinished = true;


                if (countTurns >= NumberOfPlayers)
                    countTurns = 0;

                writeResultOfPlayers(playersName);
                showBankDeposit(BankDeposit);



                try
                {

                    // check for game end
                    for (ushort i = 1; i <= NumberOfHouses; i++)
                        if (HouseOwner[i] == -1) // game still continues; houses are left to buy
                        {
                            gameFinished = false;
                            break;
                        }

                    short currentTurn = turns[countTurns];

                    if (stuck[currentTurn])
                    {
                        changeGroupBuyButtons(false, BackColor, Color.LightGray,
                            string.Format("Player {0} is Stuck!",
                            playersName[currentTurn]));

                        // dont stuck next round
                        stuck[currentTurn] = false;

                        // go to the next player
                        countTurns++;

                        continue;
                    }

                    // roll the dice
                    short currentDice = rollTheDice(p[currentTurn].MoveColor);

                    // bonus for a dice of 6
                    if (currentDice == 6)
                        countTurns--; // a player with dice 6, gets a reward

                    // let the player know it's dice number for movement in Player.cs
                    p[currentTurn].NumberOfMovements = currentDice;


                    // here's how magic happens in the GUI for dice roll; I love this part
                    colorizeDiceRoller(p[currentTurn].MoveColor, p[currentTurn].NumberOfMovements);



                    // to check the house rul, whether it is bought, a bonus house, etc.
                    nextPosition = (short)(p[currentTurn].CurrentHouse +
                        p[currentTurn].NumberOfMovements);



                    if (nextPosition > 40) // player finished a round
                    {
                        nextPosition %= 40;


                        // we cant have negative number in the bank
                        if (BankDeposit - FinishRoundBonus >= 0) // check for integrity of the bank
                        {
                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                string.Format("Player {0} passed one round and got {1} from bank!",
                                playersName[currentTurn], FinishRoundBonus));


                            BankDeposit -= FinishRoundBonus; // get from bank ...
                            p[currentTurn].PlayerDeposit += // ... get it to the player
                                (short)FinishRoundBonus;
                        }
                        else
                        {
                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                string.Format("Player {0} passed one round, but bank money can't become empty," +
                                " so no bonus!",
                                playersName[currentTurn]));
                        }
                    }


                    //t[currentTurn].Resume(); // let the player move for it's turn
                    //// wait for the player to finish moving, then roll the dice again
                    //Thread.CurrentThread.Suspend(); // dont move unless the player sit in it's house
                    playerMoveLock[currentTurn].Release();
                    chooseTurnLock.WaitOne();

                    // until deciding the destiny of the current house the player is on
                    bool stillMove = false;
                    do
                    {
                        switch (HouseOwner[nextPosition])
                        {
                            case -1: // the house is not bought
                                stillMove = false;
                                buyCurrentHouse(currentTurn, playersName[currentTurn], nextPosition);
                                break;



                            case -2: // bonus (-2)
                                stillMove = false;
                                short amount = 0;
                                switch (nextPosition)
                                {
                                    case 7:
                                        amount = 5000;
                                        break;
                                    case 40:
                                        amount = 3000;
                                        break;
                                    default:
                                        break;
                                }


                                if (BankDeposit - amount >= 0)
                                {
                                    changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                                string.Format("Player {0} won {1} as a bonus",
                                                playersName[currentTurn], amount));

                                    BankDeposit -= (ushort)amount;
                                    p[currentTurn].PlayerDeposit += amount;
                                }
                                else
                                {
                                    changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                        string.Format("Player {0} is in a bonus house, " +
                                        "but bank money can't become empty," +
                                        " so no bonus!",
                                        playersName[currentTurn]));
                                }
                                break;



                            case -3: // lose (-3)
                                stillMove = false;
                                amount = 0;
                                switch (nextPosition)
                                {
                                    case 16:
                                        amount = 1000;
                                        break;
                                    case 36:
                                        amount = 1500;
                                        break;
                                    default:
                                        break;
                                }


                                changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} lost {1} to the bank",
                                            playersName[currentTurn], amount));


                                p[currentTurn].PlayerDeposit -= (short)amount; // get from player ...
                                BankDeposit += (ushort)amount; // ... and give it to the bank
                                break;




                            case -4: // move forward (-4) ...
                            case -5: // ... or backward (-5)
                                stillMove = true;
                                amount = 0;
                                switch (nextPosition)
                                { // number of spaces to go backward
                                    case 9:
                                        amount = -4;
                                        break;
                                    case 20:
                                        amount = 5;
                                        break;
                                    case 39:
                                        amount = -3;
                                        break;
                                    default:
                                        break;
                                }

                                p[currentTurn].NumberOfMovements = amount;

                                // for the next house the player is going to be on
                                nextPosition = (short)(p[currentTurn].CurrentHouse +
                                                p[currentTurn].NumberOfMovements);

                                //t[currentTurn].Resume(); // let the player move for it's turn
                                //// wait for the player to finish moving, then roll the dice again
                                //Thread.CurrentThread.Suspend();
                                playerMoveLock[currentTurn].Release();
                                chooseTurnLock.WaitOne();


                                break;
                            case -6: // luck houses (-6)

                                amount = 0;
                                switch (nextPosition)
                                {
                                    case 14: // even number, go forward or stuck next round otherwise

                                        changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} roll the dice. " +
                                            "If even, go forward, stuck next round otherwise.",
                                            playersName[currentTurn]));

                                        currentDice = rollTheDice(p[currentTurn].MoveColor);

                                        if (currentDice % 2 == 0) // even
                                        {
                                            stillMove = true;
                                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} roll the dice " +
                                            "for number of houses.",
                                            playersName[currentTurn]));

                                            currentDice = rollTheDice(p[currentTurn].MoveColor);

                                            p[currentTurn].NumberOfMovements = currentDice;

                                            nextPosition = (short)(p[currentTurn].CurrentHouse +
                                                p[currentTurn].NumberOfMovements);

                                            //t[currentTurn].Resume(); // let the player move for it's turn
                                            //// wait for the player to finish moving, then roll the dice again
                                            //Thread.CurrentThread.Suspend();
                                            playerMoveLock[currentTurn].Release();
                                            chooseTurnLock.WaitOne();

                                        }
                                        else // otherwise; stuck
                                        {
                                            stillMove = false;
                                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                                string.Format("Player {0} is stuck for the next round.",
                                                playersName[currentTurn]));


                                            stuck[currentTurn] = true;
                                        }


                                        break;
                                    case 21: // even number, win money or go backward otherwise

                                        changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} roll the dice. " +
                                            "If even, win money, go backward otherwise.",
                                            playersName[currentTurn]));


                                        currentDice = rollTheDice(p[currentTurn].MoveColor);

                                        if (currentDice % 2 == 0) // even
                                        {
                                            stillMove = false;
                                            if (BankDeposit - 1500 >= 0)
                                            {
                                                changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                                string.Format("Player {0} won 1500 points",
                                                playersName[currentTurn]));

                                                BankDeposit -= 1500;
                                                p[currentTurn].PlayerDeposit += 1500;
                                            }
                                            else
                                            {
                                                changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                                    string.Format("Player {0} should get a bonus," +
                                                    "but bank money can't become empty, so no bonus!"));
                                            }

                                        }
                                        else // otherwise; go backward
                                        {
                                            stillMove = true;
                                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} roll the dice " +
                                            "for number of houses.",
                                            playersName[currentTurn]));

                                            currentDice = rollTheDice(p[currentTurn].MoveColor);

                                            p[currentTurn].NumberOfMovements = (short)(-currentDice);

                                            nextPosition = (short)(p[currentTurn].CurrentHouse +
                                                p[currentTurn].NumberOfMovements);

                                            //t[currentTurn].Resume(); // let the player move for it's turn
                                            //// wait for the player to finish moving, then roll the dice again
                                            //Thread.CurrentThread.Suspend();
                                            playerMoveLock[currentTurn].Release();
                                            chooseTurnLock.WaitOne();
                                        }

                                        break;
                                    case 32: // even number, stuck next round or lose money otherwise

                                        stillMove = false;

                                        changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} roll the dice. " +
                                            "If even, win money, go backward otherwise.",
                                            playersName[currentTurn]));

                                        currentDice = rollTheDice(p[currentTurn].MoveColor);

                                        if (currentDice % 2 == 0) // even
                                        {
                                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                                string.Format("Player {0} is stuck for the next round.",
                                                playersName[currentTurn]));


                                            stuck[currentTurn] = true;
                                        }
                                        else
                                        {
                                            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                                            string.Format("Player {0} lost 1000 points to bank",
                                            playersName[currentTurn]));

                                            p[currentTurn].PlayerDeposit -= 1000;
                                            BankDeposit += 1000;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            default: // it is bought, not by itself definitely
                                stillMove = false;
                                rentHouse(currentTurn, playersName[currentTurn], nextPosition,
                                        playersName[HouseOwner[nextPosition]], HouseOwner[nextPosition]);
                                break;


                        }
                    } while (stillMove);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace, ex.Message + ex.Source,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } // just in case, if something goes wrong




                countTurns++;
            } while (!gameFinished); // condition is for test ONLY


            ushort maxPoint = 0;
            int gameWinner = determineWinner(ref maxPoint);


            MessageBox.Show(string.Format("Player {0} won the game with {1} points!"

                , playersName[maxPoint], gameWinner)
                    , "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);


            buttonExit_Click(null, null); // exit the program

        }
        private int determineWinner(ref ushort maxPoint)
        {
            int[] playerPoints = new int[NumberOfPlayers]; // calculate each player's points
            for (ushort i = 0; i < NumberOfPlayers; i++)
            {
                playerPoints[i] = p[i].PlayerDeposit;
                string tmp = null;
                switch (i)
                {
                    case 0:
                        tmp = labelOwners0.Text;
                        break;
                    case 1:
                        tmp = labelOwners1.Text;
                        break;
                    case 2:
                        tmp = labelOwners2.Text;
                        break;
                    case 3:
                        tmp = labelOwners3.Text;
                        break;
                    default:
                        break;
                }

                foreach (var item in tmp.Split('\n'))
                {
                    try
                    {
                        int tmp1 = Convert.ToInt32(item);
                        playerPoints[i] += BuyHouse[tmp1];
                    }
                    catch (Exception ex)
                    {
                        
                    }

                }
            }
            int maxNum = playerPoints[maxPoint];
            for (ushort i = 1; i < NumberOfPlayers; i++)
                if (playerPoints[i] > maxNum)
                {
                    maxPoint = i;
                    maxNum = playerPoints[i];
                }
            return maxNum;
        }
        private void buyCurrentHouse(short playerIndex, string playerName, short houseToBeBougth)
        {

            ushort cost = BuyHouse[houseToBeBougth];

            changeGroupBuyButtons(true, Color.Goldenrod, Color.LightGray,
                string.Format("Player {0} buy house {1} for {2}?",
                playerName, houseToBeBougth, BuyHouse[houseToBeBougth]));


            waitDecideBuyLock.WaitOne();
            if (buy)
            {
                p[playerIndex].PlayerDeposit -= (short)cost;
                BankDeposit += cost;

                showHouseOwner(playerIndex, houseToBeBougth);

                HouseOwner[houseToBeBougth] = playerIndex;

                if (HouseColors[houseToBeBougth] == Color.DodgerBlue)
                    p[playerIndex].OwnedBlueHouses += RentHouse[houseToBeBougth];

                else if (HouseColors[houseToBeBougth] == Color.Green)
                    p[playerIndex].OwnedGreenHouses += RentHouse[houseToBeBougth];

                else if (HouseColors[houseToBeBougth] == Color.Red)
                    p[playerIndex].OwnedRedHouses += RentHouse[houseToBeBougth];

                else if (HouseColors[houseToBeBougth] == Color.Yellow)
                    p[playerIndex].OwnedYellowHouses += RentHouse[houseToBeBougth];


            }

            changeGroupBuyButtons(false, BackColor,
                BackColor, string.Format("Buy?"));

        }
        private void showHouseOwner(short player, short house)
        {
            switch (player)
            {
                case 0:
                    labelOwners0.Text += house.ToString() + "\n";
                    break;
                case 1:
                    labelOwners1.Text += house.ToString() + "\n";
                    break;
                case 2:
                    labelOwners2.Text += house.ToString() + "\n";
                    break;
                case 3:
                    labelOwners3.Text += house.ToString() + "\n";
                    break;
                default:
                    break;
            }

        }
        private void changeGroupBuyButtons(bool enableButtons, Color buttonColor,
            Color groupBoxColor = new Color(), string message = null)
        {
            if (groupBoxColor != new Color())
                groupBoxBuy.BackColor = groupBoxColor;

            buttonYesBuy.Enabled = enableButtons;
            buttonNoBuy.Enabled = enableButtons;

            buttonYesBuy.BackColor = buttonColor;
            buttonNoBuy.BackColor = buttonColor;
            if (message != null)
                labelShow5.Text = message;
        }
        private void rentHouse(short playerIndex, string playerName,
            short houseToBeBougth, string ownerName, short ownerNumber)
        {

            // dont rent from self
            if (playerIndex == ownerNumber)
                return;

            

            ushort cost = 0;

            if (HouseColors[houseToBeBougth] == Color.DodgerBlue)
                cost = p[ownerNumber].OwnedBlueHouses;
            else if (HouseColors[houseToBeBougth] == Color.Green)
                cost = p[ownerNumber].OwnedGreenHouses;
            else if (HouseColors[houseToBeBougth] == Color.Red)
                cost = p[ownerNumber].OwnedRedHouses;
            else if (HouseColors[houseToBeBougth] == Color.Yellow)
                cost = p[ownerNumber].OwnedYellowHouses;


            changeGroupBuyButtons(false, BackColor, Color.LightGray,
                            string.Format("Player {0} rented house {1} from {2} for {3}",
                            playerName, houseToBeBougth, ownerName, cost));

            p[playerIndex].PlayerDeposit -= (short)cost;
            p[ownerNumber].PlayerDeposit += (short)RentHouse[houseToBeBougth];



            changeGroupBuyButtons(false, BackColor);

        }
        private void showBankDeposit(uint bank)
        {
            labelBank.Text = bank.ToString();
        }
        // print the game result for user
        private void writeResultOfPlayers(string[] names)
        {
            int[] points = new int[NumberOfPlayers];

            for (short i = 0; i < NumberOfPlayers; i++)
            {
                switch (i)
                {
                    case 0:
                        labelOwners0.BackColor = Color.DodgerBlue;
                        break;
                    case 1:
                        labelOwners1.BackColor = Color.Green;
                        break;
                    case 2:
                        labelOwners2.BackColor = Color.Red;
                        break;
                    case 3:
                        labelOwners3.BackColor = Color.Yellow;
                        break;
                    default:
                        break;
                }
            }
            for (short i = 0; i < NumberOfPlayers; i++)
                points[i] = p[i].PlayerDeposit;
            labelPlayers.Text = string.Format(
                "{0}: {1}\n" +
                "{2}: {3}\n",
                names[0], points[0],
                names[1], points[1]);
            if (NumberOfPlayers > 2)
            {
                labelPlayers.Text += string.Format(
                "{0}: {1}\n",
                names[2], points[2]);
                if (NumberOfPlayers > 3)
                    labelPlayers.Text += string.Format(
                        "{0}: {1}\n",
                        names[3], points[3]);
            }
        }
        // colorize the 40 houses
        private void paintHouses()
        {
            for (int number = 1; number <= NumberOfHouses; number++)
            {
                switch (number)
                {
                    case 1:
                        label1.BackColor = HouseColors[number];
                        break;
                    case 2:
                        label2.BackColor = HouseColors[number];
                        break;
                    case 3:
                        label3.BackColor = HouseColors[number];
                        break;
                    case 4:
                        label4.BackColor = HouseColors[number];
                        break;
                    case 5:
                        label5.BackColor = HouseColors[number];
                        break;
                    case 6:
                        label6.BackColor = HouseColors[number];
                        break;
                    case 7:
                        label7.BackColor = HouseColors[number];
                        break;
                    case 8:
                        label8.BackColor = HouseColors[number];
                        break;
                    case 9:
                        label9.BackColor = HouseColors[number];
                        break;
                    case 10:
                        label10.BackColor = HouseColors[number];
                        break;
                    case 11:
                        label11.BackColor = HouseColors[number];
                        break;
                    case 12:
                        label12.BackColor = HouseColors[number];
                        break;
                    case 13:
                        label13.BackColor = HouseColors[number];
                        break;
                    case 14:
                        label14.BackColor = HouseColors[number];
                        break;
                    case 15:
                        label15.BackColor = HouseColors[number];
                        break;
                    case 16:
                        label16.BackColor = HouseColors[number];
                        break;
                    case 17:
                        label17.BackColor = HouseColors[number];
                        break;
                    case 18:
                        label18.BackColor = HouseColors[number];
                        break;
                    case 19:
                        label19.BackColor = HouseColors[number];
                        break;
                    case 20:
                        label20.BackColor = HouseColors[number];
                        break;
                    case 21:
                        label21.BackColor = HouseColors[number];
                        break;
                    case 22:
                        label22.BackColor = HouseColors[number];
                        break;
                    case 23:
                        label23.BackColor = HouseColors[number];
                        break;
                    case 24:
                        label24.BackColor = HouseColors[number];
                        break;
                    case 25:
                        label25.BackColor = HouseColors[number];
                        break;
                    case 26:
                        label26.BackColor = HouseColors[number];
                        break;
                    case 27:
                        label27.BackColor = HouseColors[number];
                        break;
                    case 28:
                        label28.BackColor = HouseColors[number];
                        break;
                    case 29:
                        label29.BackColor = HouseColors[number];
                        break;
                    case 30:
                        label30.BackColor = HouseColors[number];
                        break;
                    case 31:
                        label31.BackColor = HouseColors[number];
                        break;
                    case 32:
                        label32.BackColor = HouseColors[number];
                        break;
                    case 33:
                        label33.BackColor = HouseColors[number];
                        break;
                    case 34:
                        label34.BackColor = HouseColors[number];
                        break;
                    case 35:
                        label35.BackColor = HouseColors[number];
                        break;
                    case 36:
                        label36.BackColor = HouseColors[number];
                        break;
                    case 37:
                        label37.BackColor = HouseColors[number];
                        break;
                    case 38:
                        label38.BackColor = HouseColors[number];
                        break;
                    case 39:
                        label39.BackColor = HouseColors[number];
                        break;
                    case 40:
                        label40.BackColor = HouseColors[number];
                        break;
                    default:
                        break;
                }
            }
        }
        private void colorizeDiceRoller(Color back, short numberOfDice)
        {
            /* now I am proud ofthis function and all functionalizing 
             * in my program cause it made my life a lot easier */
            labelShow2.BackColor = back;
            //labelDice.Text = numberOfDice.ToString();
            switch (numberOfDice)
            {
                case 1:
                    pictureBoxDice.Image = Image.FromFile("dice1.png");
                    break;
                case 2:
                    pictureBoxDice.Image = Image.FromFile("dice2.png");
                    break;
                case 3:
                    pictureBoxDice.Image = Image.FromFile("dice3.png");
                    break;
                case 4:
                    pictureBoxDice.Image = Image.FromFile("dice4.png");
                    break;
                case 5:
                    pictureBoxDice.Image = Image.FromFile("dice5.png");
                    break;
                case 6:
                    pictureBoxDice.Image = Image.FromFile("dice6.png");
                    break;
                default:
                    break;
            }
        }
        private short rollTheDice(Color back)
        {
            changeButtonDice(true, Color.SaddleBrown);
            rollDiceLock.WaitOne();

            short result = 0;


            Random generateRandom = new Random(DateTime.Now.Second);
            diceSound.Play(); // dice sound


            for (int i = 0; i < 77; i++)
            {
                result = (short)generateRandom.Next(1, 7);
                colorizeDiceRoller(back, result);
                Thread.Sleep(8);
            }
            return result;
        }
        private void changeButtonDice(bool enable, Color color)
        {
            buttonRollTheDice.BackColor = color;
            buttonRollTheDice.Enabled = enable;
        }
        private void buttonRollTheDice_Click(object sender, EventArgs e)
        {
            try
            {
                changeButtonDice(false, BackColor);
                rollDiceLock.Release();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void buttonYesBuy_Click(object sender, EventArgs e)
        {
            buy = true;
            waitDecideBuyLock.Release();
        }
        private void buttonNoBuy_Click(object sender, EventArgs e)
        {
            buy = false;
            waitDecideBuyLock.Release();
        }
        private void showNamesAndPrices()
        {
            for (int number = 1; number <= NumberOfHouses; number++)
            {
                switch (number)
                {
                    case 1:
                        label1.Text =
                            string.Format("1. Furniture\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 2:
                        label2.Text =
                            string.Format("2. Depart.\n") +
                        string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 3:
                        label3.Text =
                            string.Format("3. Fish\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 4:
                        label4.Text =
                            string.Format("4. Grocery\n") +
                        string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 5:
                        label5.Text =
                            string.Format("5. Shoe\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 6:
                        label6.Text =
                            string.Format("6. Dairy\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 7:
                        label7.Text =
                            string.Format("7. Bonus\n");
                        break;
                    case 8:
                        label8.Text =
                            string.Format("8. Barber\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 9:
                        label9.Text =
                            string.Format("9. Move back 4 houses!\n");
                        break;
                    case 10:
                        label10.Text =
                            string.Format("10. Florist\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 11:
                        label11.Text =
                            string.Format("11. Phone\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 12:
                        label12.Text =
                            string.Format("12. Airline\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 13:
                        label13.Text =
                            string.Format("13. Taxi\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 14:
                        label14.Text =
                            string.Format("14. Test luck!\n");
                        break;
                    case 15:
                        label15.Text =
                            string.Format("15. Railroad\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 16:
                        label16.Text =
                            string.Format("16. Ooops!\n");
                        break;
                    case 17:
                        label17.Text =
                            string.Format("17. Busline!\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 18:
                        label18.Text =
                            string.Format("18. Circus\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 19:
                        label19.Text =
                            string.Format("19. Book\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 20:
                        label20.Text =
                            string.Format("20. Move forward 5 houses!\n");
                        break;
                    case 21:
                        label21.Text =
                            string.Format("21. Test luck!\n");
                        break;
                    case 22:
                        label22.Text =
                            string.Format("22. Baseball\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 23:
                        label23.Text =
                            string.Format("23. Journal\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 24:
                        label24.Text =
                            string.Format("24. Steel\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 25:
                        label25.Text =
                            string.Format("25. Tire\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 26:
                        label26.Text =
                            string.Format("26. Electric\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 27:
                        label27.Text =
                            string.Format("27. TV\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 28:
                        label28.Text =
                            string.Format("28. Diamond\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 29:
                        label29.Text =
                            string.Format("29. Watch\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 30:
                        label30.Text =
                            string.Format("30. Oil\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 31:
                        label31.Text =
                            string.Format("31. Farm\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 32:
                        label32.Text =
                            string.Format("32. Test luck!\n");
                        break;
                    case 33:
                        label33.Text =
                            string.Format("33. Orange\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 34:
                        label34.Text =
                            string.Format("34. Planting\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 35:
                        label35.Text =
                            string.Format("35. Journal\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 36:
                        label36.Text =
                            string.Format("36. Ooops!\n");
                        break;
                    case 37:
                        label37.Text =
                            string.Format("37. Radio\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 38:
                        label38.Text =
                            string.Format("38. Car\n") +
                            string.Format("Buy: {0}\nRent: {1}",
                            BuyHouse[number], RentHouse[number]);
                        break;
                    case 39:
                        label39.Text =
                            string.Format("39. Move back 3 houses!\n");
                        break;
                    case 40:
                        label40.Text =
                            string.Format("40. Bonus\n");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
