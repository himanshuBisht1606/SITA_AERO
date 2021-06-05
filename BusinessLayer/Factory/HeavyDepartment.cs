using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Factory
{
    class HeavyDepartment : DepartmentProduct
    {
        private readonly string _departmentType;
        private bool _isSignedOffNeeded;
        private string _SignedOffDepartment;

        public HeavyDepartment(double value)
        {
            _departmentType = "Heavy";
            _isSignedOffNeeded = value > 1000 ? true : false;
            _SignedOffDepartment = value > 1000 ? "Insurance" : "";
        }
        public override string departmentType
        {
            get { return _departmentType; }
        }
        public override bool isSignedOffNeeded
        {
            get { return _isSignedOffNeeded; }
            set { _isSignedOffNeeded = value; }
        }
        public override string signedOffDepartment
        {
            get { return _SignedOffDepartment; }
            set { _SignedOffDepartment = value; }
        }
    }
}
