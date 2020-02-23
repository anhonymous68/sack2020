using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sack
{
    public class UserOutput
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<DateTime> timeAvailable { get; set; }
        public List<String> illnesses { get; set; }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
