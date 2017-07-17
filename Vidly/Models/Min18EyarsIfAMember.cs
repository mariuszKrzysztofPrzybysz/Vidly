using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18EyarsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;

            if (customer == null)
                return new ValidationResult("Customer object is required.");

            if (customer.MembershipTypeId == MembershipType.Unknown
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var now = int.Parse(DateTime.Now.ToString("yyyymmdd"));
            var dateOfBirth = int.Parse(customer.Birthdate.Value.ToString("yyyymmdd"));
            var age = (now - dateOfBirth) / 10000;

            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 1 years old to go on a mambership.");
        }
    }
}