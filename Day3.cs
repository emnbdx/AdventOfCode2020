using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day3 : AbstractDay
    {
        public Day3() : base(3)
        {}

        public override string Part1()
        {
            var tree = Move(3, 1);
            return tree.ToString();
        }

        public override string Part2()
        {
            var tree = Move(1, 1);
            tree *= Move(3, 1);
            tree *= Move(5, 1);
            tree *= Move(7, 1);
            tree *= Move(1, 2);

            return tree.ToString();
        }

        private int Move(int right, int down)
        {
            var currentX = 0;
            var tree = 0;

            for(var i = down; i < Data.Count(); i+=down) {
                currentX += right;
                if(Data[i][currentX % Data[i].Length] == '#')
                    tree++;
            }
            Console.WriteLine(tree.ToString());

            return tree;
        }
    }
}