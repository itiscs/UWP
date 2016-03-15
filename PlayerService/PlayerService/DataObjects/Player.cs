using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayerService.DataObjects
{
    public class Player:EntityData
    {
        public string Name { get; set; }
    }
}