using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;

namespace BusinessLayer.Factory
{
    public class HeavyFactory : DepartmentFactory
    {
        public HeavyFactory()
        {

        }
        public override DepartmentProduct GetDepartment(double value)
        {
            return new HeavyDepartment(value);
        }
    }
}
