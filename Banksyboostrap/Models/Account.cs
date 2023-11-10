using System;
using Banksyboostrap.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banksyboostrap.Utilities;
namespace Banksyboostrap.Models
{
    internal class Account
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }

        public virtual User User { get; set; }
    }
}
