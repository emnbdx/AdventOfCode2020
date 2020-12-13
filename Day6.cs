using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day6 : AbstractDay
    {
        public Day6() : base(6)
        { }

        public override string Part1()
        {
            var answers = new List<string>();
            var answer = "";
            foreach(var line in Data)
            {
                if(string.IsNullOrEmpty(line)) {
                    answers.Add(answer);
                    answer = "";
                } else {
                    answer += line;
                }
            }
            
            answers.Add(answer);

            return answers.Sum(a => a.Distinct().Count()).ToString();
        }

        public override string Part2()
        {
            var commonAnswers = new List<string>();
            string answer = null;
            foreach(string line in Data)
            {
                if(string.IsNullOrEmpty(line)) {
                    commonAnswers.Add(answer);
                    answer = null;
                } else {
                    var tmp = "";
                    if(answer == null) {
                        answer = line;
                    } else {
                        foreach(var c in answer.ToList()) {
                            if(line.Contains(c))
                                tmp += c;
                        }

                        answer = tmp;
                    }
                }
            }
            
            commonAnswers.Add(answer);

            return commonAnswers.Sum(a => a.Distinct().Count()).ToString();
        }
    }
}