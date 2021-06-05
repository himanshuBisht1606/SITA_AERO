using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Plan
    {
        public string SenderName { get; set; }
        public int CCNumber { get; set; }
        public string ReceipientName { get; set; }
        public double Weight { get; set; }
        public double Value { get; set; }
        public string HandledBy { get; set; }
        public bool IsSignedOffNeeded { get; set; }
        public string SignedOffDepartment { get; set; }
    }
}
