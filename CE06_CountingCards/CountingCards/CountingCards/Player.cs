using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingCards
{
    public class Player
    {
        public string playerName { get; set; }
        public int playerTotal { get; set; }
        public List<string> playerHand = new List<string>();
        public string place { get; set; }
    }
}
