using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day2 : AbstractDay
    {    
        private Regex _regex;

        public Day2() : base(2)
        {
            _regex = new Regex(@"(?<min>\d+)-(?<max>\d+)\s(?<car>.):\s(?<password>.+)");
        }

        public override string Part1()
        {    
            var ok = 0;
            foreach(var s in Data)
            {
                var m = _regex.Matches(s)[0];
                var count = m.Groups["password"].Value.Count(f => f == Convert.ToChar(m.Groups["car"].Value));

                if(count >= Convert.ToInt32(m.Groups["min"].Value) && count <= Convert.ToInt32(m.Groups["max"].Value))
                    ok++;
            }

            return ok.ToString();
        }

        public override string Part2()
        {
            var ok = 0;
            foreach(var s in Data)
            {
                var m = _regex.Matches(s)[0];

                var c1 = m.Groups["password"].Value[Convert.ToInt32(m.Groups["min"].Value) - 1];
                var c2 = m.Groups["password"].Value[Convert.ToInt32(m.Groups["max"].Value) - 1];

                if(c1 == Convert.ToChar(m.Groups["car"].Value) ^ c2 == Convert.ToChar(m.Groups["car"].Value))
                    ok++;
            }

            return ok.ToString();
        }
    }
}