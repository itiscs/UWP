using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayerService.DataObjects
{
    public class PlayerRank:EntityData
    {
        public int Score { get; set; }
        public int Rank { get; set; }

        //[ForeignKey("Id")]
        public virtual Player Player { get; set; }
    }
}