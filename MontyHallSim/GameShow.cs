using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallSim
{
    class GameShow
    {
        List<MontyDoor> listOfDoorsInTheGame;
        bool doorChosen = false;
        bool swapChoiceMade = false;
        bool playAgainChoice = false;

        bool gameContinues = true;

        int numberOfGoatDoor;

        int totalWins = 0;
        int totalLosses = 0;


        private void SwapDoor()
        {
            int chosenDoorIndex = listOfDoorsInTheGame.IndexOf(MontyDoor.GetChosenDoor(listOfDoorsInTheGame));
            int unopenedDoorIndex = listOfDoorsInTheGame.IndexOf(MontyDoor.GetUnopenedDoor(listOfDoorsInTheGame));

            listOfDoorsInTheGame[chosenDoorIndex].SetChoiceDoor(false);
            listOfDoorsInTheGame[unopenedDoorIndex].SetChoiceDoor(true);

        }

        private string EndGame()
        {
            int chosenDoorIndex = listOfDoorsInTheGame.IndexOf(MontyDoor.GetChosenDoor(listOfDoorsInTheGame));

            if (listOfDoorsInTheGame[chosenDoorIndex].IsCarBehindDoor())
            {
                totalWins++;
                return "You've won a car!";
            }
            totalLosses++;
            return "Oh no! It was a Goat";
        }

        private void StartNewGame()
        {
            listOfDoorsInTheGame = MontyDoor.BuildDoors();
            doorChosen = false;
            swapChoiceMade = false;
            playAgainChoice = false;

        }

        public void PlayGameAuto(int numberOfGames, bool alwaysSwap)
        {
            for(int i = 0; i < numberOfGames; i++)
            {
                // set up new game
                StartNewGame();

                // select a random door
                listOfDoorsInTheGame[MontyDoor.GetIndexOfRandomDoor(listOfDoorsInTheGame)].SetChoiceDoor(true);
                doorChosen = true;

                // open a random goat door 
                MontyDoor.OpenGoatDoor(listOfDoorsInTheGame);

                // make the choice to swap or not
                if (alwaysSwap)
                    SwapDoor();

                // open the door and reveal the prize
                EndGame();
            }

            Console.WriteLine("Total wins: " + totalWins);
            Console.WriteLine("Total losses: " + totalLosses);
        }

        public void TriggerAutoGame()
        {
            Console.Clear();
            Console.WriteLine("Welcome to my Monty Hall Problem Simulator!");
            Console.WriteLine("How many iterations do you want?");
            
            int numberOfIterations = Convert.ToInt32(Console.ReadLine());
            bool alwaysSwapDoors = false;

            Console.Clear();
            Console.WriteLine("Okay! The game will run " + numberOfIterations + " times.");
            Console.WriteLine("Should doors be swapped? Y/N");

            while (!swapChoiceMade)
            {
                char swapKey = Console.ReadKey().KeyChar;

                if (swapKey == 'y')
                {
                    Console.Clear();
                    alwaysSwapDoors = true;
                    swapChoiceMade = true;
                }
                else if (swapKey == 'n')
                {
                    Console.Clear();
                    swapChoiceMade = true;

                }

            }

            Console.WriteLine("Okay! The game will run " + numberOfIterations + " times.");
            Console.WriteLine("The swap setting is set to " + alwaysSwapDoors);

            Console.WriteLine("Press any key to begin");

            Console.ReadKey();
            Console.Clear();

            PlayGameAuto(numberOfIterations, alwaysSwapDoors);

        }

        public void PlayGameManual()
        {
            while (gameContinues)
            {
                StartNewGame();

                Console.WriteLine("Welcome to the Game Show!");
                Console.WriteLine("Please select a door!");

                while (!doorChosen)
                {
                    char selection = Console.ReadKey().KeyChar;

                    switch (selection)
                    {
                        case '1':
                            {
                                Console.Clear();
                                Console.WriteLine("You chose Door 1!");
                                doorChosen = true;
                                listOfDoorsInTheGame[0].SetChoiceDoor(true);
                                break;
                            }
                        case '2':
                            {
                                Console.Clear();
                                Console.WriteLine("You chose Door 2!");
                                doorChosen = true;
                                listOfDoorsInTheGame[1].SetChoiceDoor(true);
                                break;
                            }
                        case '3':
                            {
                                Console.Clear();
                                Console.WriteLine("You chose Door 3!");
                                doorChosen = true;
                                listOfDoorsInTheGame[2].SetChoiceDoor(true);
                                break;
                            }



                    }
                }

                numberOfGoatDoor = MontyDoor.OpenGoatDoor(listOfDoorsInTheGame) + 1;
                Console.WriteLine("We revealed a goat behind Door " + numberOfGoatDoor);

                Console.WriteLine("Do you want to swap? Y/N");

                while (!swapChoiceMade)
                {
                    char swapKey = Console.ReadKey().KeyChar;

                    if (swapKey == 'y')
                    {
                        Console.Clear();
                        SwapDoor();
                        swapChoiceMade = true;
                    }
                    else if (swapKey == 'n')
                    {
                        Console.Clear();
                        swapChoiceMade = true;

                    }

                }

                // open door
                Console.WriteLine(EndGame());

                Console.WriteLine("Do you want to play again? Y/N");

                while(!playAgainChoice)
                {
                    char playAgainKey = Console.ReadKey().KeyChar;

                    if (playAgainKey == 'y')
                    {
                        Console.Clear();
                        playAgainChoice = true;
                    }
                    else if (playAgainKey == 'n')
                    {
                        Console.Clear();
                        playAgainChoice = true;
                        gameContinues = false;

                    }
                }

            }

            Console.WriteLine("Thank you for playing!");
            Console.WriteLine("Total wins: " + totalWins);
            Console.WriteLine("Total losses: " + totalLosses);


        }
    }
}
