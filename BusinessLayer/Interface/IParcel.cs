using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IParcel
    {
        Container GetParcelData(string filePath);
        Plans GeneratePlannedData(Container xmlContainer);
    }
}
