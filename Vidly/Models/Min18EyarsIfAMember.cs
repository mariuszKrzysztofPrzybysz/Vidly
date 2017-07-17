using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Vidly.Dtos;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Vidly.Models
{
    public class Min18EyarsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;

            if (customer == null)
            {
                var customerDto = validationContext.ObjectInstance as CustomerDto;

                if (customerDto == null)
                    return new ValidationResult("Customer or CustomerDto object is required.");

                customer=new Customer();

                Mapper.Map(customerDto, customer);
            }

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