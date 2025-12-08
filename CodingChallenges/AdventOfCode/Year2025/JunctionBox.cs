using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges.AdventOfCode.Year2025
{
    class JunctionBox(int x, int y, int z)
    {
        public Coordinate3D Position { get; set; } = new(x, y, z);
        public int Circuit { get; set; } = -1;
        public List<JunctionBox> ConnectedBoxes = [];
    }
}
