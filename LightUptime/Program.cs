using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//[2018-01-15] Challenge #347 [Easy] How long has the light been on?
//https://www.reddit.com/r/dailyprogrammer/comments/7qn07r/20180115_challenge_347_easy_how_long_has_the/

namespace LightUptime
{
    class Program
    {
        static void Main(string[] args)
        {
            var input1 = new int[] { 2, 4, 3, 6, 1, 3, 6, 8 };
            var input2 = new int[] { 6, 8, 5, 8, 8, 9, 5, 7, 4, 7 };
            Console.WriteLine(GetLightUptime(input1));
            Console.WriteLine(GetLightUptime(input2));
            Console.Read();
        }

        private static int GetLightUptime(int[] input)
        {
            var inputEnumerator = input.GetEnumerator();
            var result = new BitArray(24);
            while (inputEnumerator.MoveNext())
            {
                var enter = (int)inputEnumerator.Current;
                inputEnumerator.MoveNext();
                var exit = (int)inputEnumerator.Current;
                result.Or(CreateBitArray(enter, exit));
            }
            return result.OfType<bool>().Count(b => b == true);
        }

        private static BitArray CreateBitArray(int enter, int leave)
        {
            var array = new BitArray(24);
            for (int i = enter; i < leave; i++)
            {
                array.Set(i, true);
            }
            return array;
        }
    }
}
