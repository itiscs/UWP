using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace SqliteApp.Models
{
    internal class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull,MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Default(value:0)]
        public decimal Price { get; set; } 
    }
}
