using AdventOfCode;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode.AoC2020
{
    public class Day04 : AoCDay
    {
        private static bool IsPassportValid(Dictionary<string, string> p)
        {
            return p.ContainsKey("byr") && p.ContainsKey("iyr") && p.ContainsKey("eyr") && p.ContainsKey("hgt") && p.ContainsKey("hcl") && p.ContainsKey("ecl") && p.ContainsKey("pid");
        }

        private static bool IsPassportDataValid(Dictionary<string, string> p)
        {
            int i;

            i = int.Parse(p["byr"]);
            if ((i < 1920) || (i > 2002))
            {
                return false;
            }

            i = int.Parse(p["iyr"]);
            if ((i < 2010) || (i > 2020))
            {
                return false;
            }

            i = int.Parse(p["eyr"]);
            if ((i < 2020) || (i > 2030))
            {
                return false;
            }

            if (p["hgt"].EndsWith("cm"))
            {
                i = int.Parse(p["hgt"].TrimEnd(['c', 'm']));
                if ((i < 150) || (i > 193))
                {
                    return false;
                }
            }
            else if (p["hgt"].EndsWith("in"))
            {
                i = int.Parse(p["hgt"].TrimEnd(['i', 'n']));
                if ((i < 59) || (i > 76))
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            if (p["hcl"].Length != 7)
            {
                return false;
            }
            else
            {
                if (p["hcl"][0] != '#')
                {
                    return false;
                }
                else
                {
                    string hex = p["hcl"].Remove(0, 1);
                    if (!int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out _))
                    {
                        return false;
                    }
                }
            }

            if (!(p["ecl"].Equals("amb") || p["ecl"].Equals("blu") || p["ecl"].Equals("brn") || p["ecl"].Equals("gry") || p["ecl"].Equals("grn") || p["ecl"].Equals("hzl") || p["ecl"].Equals("oth")))
            {
                return false;
            }

            if (p["pid"].Length != 9)
            {
                return false;
            }
            else
            {
                if (!int.TryParse(p["pid"], System.Globalization.NumberStyles.Integer, null, out _))
                {
                    return false;
                }
            }

            return true;
        }

        override public void Solve()
        {
            List<Dictionary<string, string>> passports = [];
            Dictionary<string, string> passport;
            int validPassports = 0;
            int validPassportsAdvanced = 0;

            passport = [];
            for (int i = 0; i < Input.Count; i++)
            {
                if (string.IsNullOrEmpty(Input[i]))
                {
                    // blank line --> new passwort
                    passports.Add(passport);
                    passport = [];
                }
                else
                {
                    string[] splitted = Input[i].Split([' '], StringSplitOptions.RemoveEmptyEntries);
                    foreach (string s in splitted)
                    {
                        string[] splitted2 = s.Split([':'], StringSplitOptions.RemoveEmptyEntries);
                        if (passport.ContainsKey(splitted2[0]))
                        {
                            passport[splitted[0]] = splitted[1];
                        }
                        else
                        {
                            passport.Add(splitted2[0], splitted2[1]);
                        }
                    }
                }
            }
            passports.Add(passport);

            foreach (Dictionary<string, string> p in passports)
            {
                if (IsPassportValid(p))
                {
                    validPassports++;
                    if (IsPassportDataValid(p))
                    {
                        validPassportsAdvanced++;
                    }
                }
            }

            Part1Solution = validPassports.ToString();
            Part2Solution = validPassportsAdvanced.ToString();
        }
    }
}
