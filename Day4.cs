using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class Day4 : AbstractDay
    {
        private List<Passport> _passports;

        public Day4() : base(4)
        {
            _passports = new List<Passport>();

            var tmp = "";
            foreach(var line in Data)
            {
                if(string.IsNullOrEmpty(line)) {
                    _passports.Add(new Passport(tmp));
                    tmp = "";
                } else {
                    tmp += " " + line;
                }
            }
            
            _passports.Add(new Passport(tmp));
        }

        public override string Part1()
        {
            return _passports.Count(p => p.IsValid()).ToString();
        }

        public override string Part2()
        {
            return _passports.Count(p => p.IsValidStrong()).ToString();
        }

        private class Passport
        {
            public Passport(string line)
            {
                var data = line.Split(' ');
                BirthYear = data.FirstOrDefault(s => s.StartsWith("byr"))?.Replace("byr:", "");
                IssueYear = data.FirstOrDefault(s => s.StartsWith("iyr"))?.Replace("iyr:", "");
                ExpirationYear = data.FirstOrDefault(s => s.StartsWith("eyr"))?.Replace("eyr:", "");
                Height = data.FirstOrDefault(s => s.StartsWith("hgt"))?.Replace("hgt:", "");
                HairColor = data.FirstOrDefault(s => s.StartsWith("hcl"))?.Replace("hcl:", "");
                EyeColor = data.FirstOrDefault(s => s.StartsWith("ecl"))?.Replace("ecl:", "");
                PassportId = data.FirstOrDefault(s => s.StartsWith("pid"))?.Replace("pid:", "");
                CountryId = data.FirstOrDefault(s => s.StartsWith("cid"))?.Replace("cid:", "");
            }

            public string BirthYear { get; set; }
            public string IssueYear { get; set; }
            public string ExpirationYear { get; set; }
            public string Height { get; set; }
            public string HairColor { get; set; }
            public string EyeColor { get; set; }
            public string PassportId { get; set; }
            public string CountryId { get; set; }

            public bool IsValid()
            {
                return BirthYear != null &&
                    IssueYear != null &&
                    ExpirationYear != null &&
                    Height != null &&
                    HairColor != null &&
                    EyeColor != null &&
                    PassportId != null;
            }

            public bool IsValidStrong()
            {
                var eyesColor = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                var rgHairColor = new Regex(@"^#[0-9a-f]{6}$");
                var rgPassportId = new Regex(@"^\d{9}$");

                return BirthYear != null && Int32.TryParse(BirthYear, out var b) && b >= 1920 && b <= 2002 &&
                    IssueYear != null && Int32.TryParse(IssueYear, out var i) && i >= 2010 && i <= 2020 &&
                    ExpirationYear != null && Int32.TryParse(ExpirationYear, out var e) && e >= 2020 && e <= 2030 &&
                    Height != null && IsHeightValid(Height) &&
                    HairColor != null && rgHairColor.IsMatch(HairColor) &&
                    EyeColor != null && eyesColor.Contains(EyeColor) &&
                    PassportId != null && rgPassportId.IsMatch(PassportId);
            }

            private bool IsHeightValid(string height)
            {
                if(height.EndsWith("cm")) {
                    return Int32.TryParse(height.Replace("cm", ""), out var h1) && h1 >= 150 && h1 <= 193;
                } else if(height.EndsWith("in")){
                    return Int32.TryParse(height.Replace("in", ""), out var h2) && h2 >= 59 && h2 <= 76;
                } else {
                    return false;
                }
            }
        }
    }
}