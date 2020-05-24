﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

/// <summary>
/// Treadsafe Randomizer code borrowed from https://stackoverflow.com/questions/273313/randomize-a-listt
/// </summary>
namespace MontyHallSim
{
    public static class ThreadSafeRandom
    {
        [ThreadStatic] private static Random Local;

        public static Random ThisThreadsRandom
        {
            get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
        }
    }

}
