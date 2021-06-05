using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer.Factory
{
    public class RegularFactory : DepartmentFactory
    {
        public RegularFactory()
        {

        }
        public override DepartmentProduct GetDepartment(double value)
        {
            return new RegularDepartment(value);
        }
    }
}
