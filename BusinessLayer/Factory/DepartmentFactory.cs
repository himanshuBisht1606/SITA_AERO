using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
     public abstract class DepartmentFactory
    {
        public abstract DepartmentProduct GetDepartment(double value);
    }
}
