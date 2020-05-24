using System;
using System.Collections.Generic;

namespace MontyHallSim
{
    class Program
    {
        static void Main(string[] args)
        {
            GameShow newGame = new GameShow();

            //newGame.PlayGameManual();
            newGame.TriggerAutoGame();


        }

    }
}
