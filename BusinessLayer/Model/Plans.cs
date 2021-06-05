using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Plans
    {
        public Plans()
        {
            Plan = new List<Plan>();
        }
        public List<Plan> Plan { get; set; }
    }
}
