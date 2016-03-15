using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerService.DataObjects
{
    public class PlayerRankDto
    {
      public string Id { get; set; }
      public string PlayerName { get; set; }
      public int Score { get; set; }
      public int Rank { get; set; }        
    }
}