using System;
using System.ComponentModel.DataAnnotations;

namespace Smart.Models
{
    public class Contract
    {
        [Display(Name = "Seller")]
        public Person Seller { get; set; }

        [Display(Name = "Buyer")]
        public Person Buyer { get; set; }

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [Display(Name = "DateCreated")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "IsValid")]
        public bool IsValid { get; set; }

        [Display(Name = "NullableBool")]
        public bool? NullableBool { get; set; }
    }

    public class Person
    {
        [Display(Name = "Ssn")]
        public string Ssn { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [DataType(DataType.Date)]
        [UIHint("Date")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Employment")]
        public EmploymentInfo Employment { get; set; }

        [Display(Name = "Address")]
        public Address Address { get; set; }
    }

    public class EmploymentInfo
    {
        [Display(Name = "Income")]
        public decimal Income { get; set; }

        [Display(Name = "Employer")]
        public string Employer { get; set; }

        [Display(Name = "Type")]
        public EmploymentType Type { get; set; }
    }

    public enum EmploymentType
    {
        [Display(Name = "Regular")]
        Regular,
        [Display(Name = "SelfEmployed")]
        SelfEmployed,
        [Display(Name = "PartTime")]
        PartTime,
        [Display(Name = "Freelancer")]
        Freelancer
    }

    public class Address
    {
        [Display(Name = "CareOf")]
        public string CareOf { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Street")]
        public string Street { get; set; }

        [Display(Name = "ZipCode")]
        public string Zip { get; set; }
    }
}