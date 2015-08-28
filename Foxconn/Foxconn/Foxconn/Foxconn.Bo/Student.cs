using System;
using System.Runtime.Serialization;

namespace Foxconn.Bo
{
    [DataContract]
    public class Student
    {
        /// <summary>
        ///    Meno - musi byt vyplnene
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime DateOfBirth { get; set; }
    }
}
