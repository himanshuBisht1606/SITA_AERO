using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;

namespace BusinessLayer.Factory
{
    public class MailFactory : DepartmentFactory
    {
        public MailFactory()
        {

        }
        public override DepartmentProduct GetDepartment(double value)
        {
            return new MailDepartment(value);
        }
    }
}
