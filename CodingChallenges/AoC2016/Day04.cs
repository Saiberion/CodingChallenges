using CodingChallenges;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallenges.AoC2016
{
    public class Day04 : Challenge
    {
        static string GetRoomChecksum(List<string> roomName)
        {
            StringBuilder sb = new();

            SortedDictionary<char, int> letterOccurance = [];

            foreach (string namePart in roomName)
            {
                foreach (char c in namePart)
                {
                    if (letterOccurance.TryGetValue(c, out int value))
                    {
                        letterOccurance[c] = ++value;
                    }
                    else
                    {
                        letterOccurance.Add(c, 1);
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                int maxVal = int.MinValue;
                char key = char.MinValue;
                foreach (KeyValuePair<char, int> kvp in letterOccurance)
                {
                    if (kvp.Value > maxVal)
                    {
                        maxVal = kvp.Value;
                        key = kvp.Key;
                    }
                }
                letterOccurance.Remove(key);
                sb.Append(key);
            }

            return sb.ToString();
        }

        static string DecryptRoomName(List<string> roomName, int sectorId)
        {
            StringBuilder sb = new();
            int shifts = sectorId % 26;
            string lookupAlphabet = "abcdefghijklmnopqrstuvwxyz";

            foreach (string namePart in roomName)
            {
                foreach (char c in namePart)
                {
                    int newIdx = c - 'a';
                    newIdx += shifts;
                    newIdx %= 26;
                    sb.Append(lookupAlphabet[newIdx]);
                }
                sb.Append(' ');
            }

            return sb.ToString().Trim();
        }

        static int[] SumIdRealRooms(List<string> input)
        {
            int[] results = new int[2];
            List<string> decryptedRoomNames = [];

            foreach (string line in input)
            {
                string[] roomCode = line.Split(['-', '[', ']'], StringSplitOptions.RemoveEmptyEntries);
                string checksumGiven = roomCode[^1];
                int sectorId = int.Parse(roomCode[^2]);
                List<string> roomName = new(roomCode);
                roomName.RemoveAt(roomName.Count - 1);
                roomName.RemoveAt(roomName.Count - 1);
                string checksumCalculated = GetRoomChecksum(roomName);

                if (checksumGiven.Equals(checksumCalculated))
                {
                    results[0] += sectorId;
                    decryptedRoomNames.Add(DecryptRoomName(roomName, sectorId));
                    if (DecryptRoomName(roomName, sectorId).Contains("north"))
                    {
                        results[1] = sectorId;
                    }
                }
            }

            return results;
        }

        public override void Solve()
        {
            int[] results = SumIdRealRooms(Input);
            Part1Solution = results[0].ToString();

            Part2Solution = results[1].ToString();
        }
    }
}
