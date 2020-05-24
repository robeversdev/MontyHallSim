using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallSim
{
    class MontyDoor
    {
        private bool car;
        

        public bool isDoorOpen = false;
        public bool isDoorChosen = false;


        public bool IsCarBehindDoor()
        {
            return car;
        }

        public void setCarValue(bool prize)
        {
            this.car = prize;
        }

        public static List<MontyDoor> BuildDoors()
        {
            List<MontyDoor> threeDoors = new List<MontyDoor>();

            for (int i = 0; i < 3; i++)
            {
                threeDoors.Add(new MontyDoor());
            }

            threeDoors[0].setCarValue(true);

            threeDoors.Shuffle();
            return threeDoors;
        }

        /// <summary>
        /// Opens one of the Goat doors. Will not open the chosen door.
        /// </summary>
        /// <returns>Index of Opened Door</returns>
        public static int OpenGoatDoor(List<MontyDoor> gameDoors)
        {
            List<int> goatDoors = new List<int>();
            var random = new Random();

            int index = 0;
            foreach(MontyDoor door in gameDoors)
            {
                if(!door.isDoorChosen && !door.IsCarBehindDoor())
                {
                    goatDoors.Add(index);
                }

                index++;
            }
            int indexToOpen = random.Next(goatDoors.Count);
            gameDoors[goatDoors[indexToOpen]].OpenDoor();

            return goatDoors[indexToOpen];
        }

        public static int GetIndexOfRandomDoor(List<MontyDoor> gameDoors)
        {
            var random = new Random();
            return random.Next(gameDoors.Count);
        }

        public static MontyDoor GetUnopenedDoor(List<MontyDoor> gameDoors)
        {
            foreach(MontyDoor door in gameDoors)
            {
                if (!door.isDoorChosen && !door.isDoorOpen)
                {
                    return door;
                }
            }

            return null;
        }

        public static MontyDoor GetChosenDoor(List<MontyDoor> gameDoors)
        {
            foreach (MontyDoor door in gameDoors)
            {
                if (door.isDoorChosen)
                {
                    return door;
                }
            }

            return null;
        }

        public void OpenDoor()
        {
            this.isDoorOpen = true;
        }

        public void SetChoiceDoor(bool choice)
        {
            this.isDoorChosen = choice;
        }

    }

}
