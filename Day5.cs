using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day5 : AbstractDay
    {
        public Day5() : base(5)
        { }

        public override string Part1()
        {
            return  GetAllIds().Max().ToString();
        }

        public override string Part2()
        {
            var ids = GetAllIds();
            for(var i = ids.Min(); i < ids.Max(); i++)
            {
                if(!ids.Contains(i) && ids.Contains(i - 1) && ids.Contains(i + 1))
                    return i.ToString();
            }

            return null;
        }

        private List<int> GetAllIds()
        {
            var list = new List<int>();
            foreach(var data in Data)
            {
                var bf = data.Substring(0, 7);
                var lr = data.Substring(7, 3);

                var row = FindRow(bf, 0, 127);
                var col = FindCol(lr, 0, 7);

                list.Add(row * 8 + col);
            }

            return list;
        }

        private int FindRow(string input, int inf, int sup)
        {
            var count = sup - inf + 1;

            if(input.Length == 1) {
                if(input == "F")
                    return inf;
                else 
                    return sup;
            }

            foreach(var c in input)
            {
                if(c == 'F')
                {
                    return FindRow(input.Substring(1), inf, sup - count / 2);
                }
                else 
                {
                    return FindRow(input.Substring(1), inf + count / 2, sup);
                }
            }

            return 0;
        }

        private int FindCol(string input, int inf, int sup)
        {
            var count = sup - inf + 1;

            if(input.Length == 1) {
                if(input == "L")
                    return inf;
                else 
                    return sup;
            }

            foreach(var c in input)
            {
                if(c == 'L')
                {
                    return FindCol(input.Substring(1), inf, sup - count / 2);
                }
                else 
                {
                    return FindCol(input.Substring(1), inf + count / 2, sup);
                }
            }

            return 0;
        }
    }
}