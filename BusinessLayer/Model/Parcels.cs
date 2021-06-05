using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BusinessLayer.Model
{
    [XmlRoot(ElementName = "parcels")]
    public class Parcels
    {

        [XmlElement(ElementName = "Parcel")]
        public List<Parcel> Parcel { get; set; }
    }
}
