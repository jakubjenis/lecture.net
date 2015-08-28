using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Workflow.Services
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<Person> GetData();
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        public string Name{ get; set;}
    }
}
