using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Workflow.Services
{
    public class Service1 : IService1
    {
        public List<Person> GetData()
        {
            return new List<Person>()
            {
                new Person()
                {
                    IsValid = true,
                    Name = "Janko Hrasko"
                },
                new Person()
                {
                    IsValid = true,
                    Name = "Cerny Petr"
                }
            };
        }
    }
}
