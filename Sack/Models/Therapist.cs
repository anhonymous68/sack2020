using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sack.Models
{
    public class TherapistOutput
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<DateTime> timeAvailable { get; set; }
        public List<string> specialty { get; set; }
    }
    public class Therapist
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
