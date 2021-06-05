using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    public abstract class DepartmentProduct
    {
        public abstract string departmentType { get; }
        public abstract bool isSignedOffNeeded { get; set; }
        public abstract string signedOffDepartment { get; set; }
        //string GetDepartment();
    }
}
