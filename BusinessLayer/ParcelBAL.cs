using BusinessLayer.Factory;
using BusinessLayer.Interface;
using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    /// <summary>
    /// Business Layer 
    /// </summary>
     public class ParcelBAL :IParcel
    {
        /// <summary>
        /// Read XML File and get parcel data
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public Container GetParcelData(string filePath)
        {
            var container = DeserializeToObject<Container>(filePath);
            return container;
        }

        /// <summary>
        /// Get Department based on parcel weight and value
        /// </summary>
        /// <param name="xmlContainer"></param>
        /// <returns></returns>
        public Plans GeneratePlannedData(Container xmlContainer)
        {
            
            Plans plans = new Plans();
            foreach (var parcel in xmlContainer.Parcels.Parcel)
            {
                var plan = new Plan();
                DepartmentFactory department = null;
                plan.CCNumber = parcel.Sender.CcNumber;
                plan.SenderName = parcel.Sender.Name;
                plan.ReceipientName = parcel.Receipient.Name;
                plan.Weight = parcel.Weight;
                plan.Value = parcel.Value;
                if (parcel.Weight <= 1.0)
                {
                    department = new MailFactory();
                }
                else if(parcel.Weight>1.0 && parcel.Weight <= 10.0)
                {
                    department = new RegularFactory();
                }
                else
                {
                    department = new HeavyFactory();
                }
                DepartmentProduct _department = department.GetDepartment(parcel.Value);
                plan.IsSignedOffNeeded = _department.isSignedOffNeeded;
                plan.SignedOffDepartment = _department.signedOffDepartment;
                plan.HandledBy = _department.departmentType;
                plans.Plan.Add(plan);
               
            }
            return plans;
        }

        /// <summary>
        /// Generic method for deserialize file data into xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public T DeserializeToObject<T>(string filePath) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));
            using (StreamReader sr = new StreamReader(filePath))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
