using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day1 : AbstractDay
    {        
        public Day1() : base(1)
        { }

        public override string Part1()
        {            
            foreach(var i in IntData)
            {
                foreach(var j in IntData)
                {
                    if(i + j == 2020)
                        return (i * j).ToString();
                }
            }
            return null;
        }

        public override string Part2()
        {
            foreach(var i in IntData)
            {
                foreach(var j in IntData)
                {
                    foreach(var k in IntData)
                    {
                        if(i + j + k == 2020)
                            return (i * j * k).ToString();
                    }
                }
            }
            return null;
        }
    }
}