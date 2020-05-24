using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Class holding helper methods from Stack Overflow. Code not written by me.
/// </summary>
namespace MontyHallSim
{
    static class MyExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
