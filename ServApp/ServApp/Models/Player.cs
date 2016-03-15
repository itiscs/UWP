using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServApp.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class PlayerRank
    {
        public string Id { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public int Rank { get; set; }
    }

    public class PlayerScore
    {
        public string PlayerId { get; set; }
        public int Score { get; set; }
    }
}
