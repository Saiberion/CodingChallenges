using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.AoC2021
{
    public class BITSPacket
    {
        public int Version { get; set; }
        public int TypeID { get; set; }
        public List<int> Data { get; set; } = [];
        public List<BITSPacket> SubPackets { get; set; } = [];
    }
}
