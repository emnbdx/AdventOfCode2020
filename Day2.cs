using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day2 : AbstractDay
    {        
        public Day2() : base(2)
        { }

        public override string Part1()
        {    
            var pattern = @"(?<min>\d+)-(?<max>\d+)\s(?<car>.):\s(?<password>.+)";
            var rg = new Regex(pattern);

            var ok = 0;
            foreach(var s in StringData)
            {
                var m = rg.Matches(s)[0];
                var count = m.Groups["password"].Value.Count(f => f == Convert.ToChar(m.Groups["car"].Value));

                if(count >= Convert.ToInt32(m.Groups["min"].Value) && count <= Convert.ToInt32(m.Groups["max"].Value))
                    ok++;
            }

            return ok.ToString();
        }

        public override string Part2()
        {
            var pattern = @"(?<min>\d+)-(?<max>\d+)\s(?<car>.):\s(?<password>.+)";
            var rg = new Regex(pattern);

            var ok = 0;
            foreach(var s in StringData)
            {
                var m = rg.Matches(s)[0];

                var c1 = m.Groups["password"].Value[Convert.ToInt32(m.Groups["min"].Value) - 1];
                var c2 = m.Groups["password"].Value[Convert.ToInt32(m.Groups["max"].Value) - 1];

                if(c1 == Convert.ToChar(m.Groups["car"].Value) ^ c2 == Convert.ToChar(m.Groups["car"].Value))
                    ok++;
            }

            return ok.ToString();
        }
    }
}