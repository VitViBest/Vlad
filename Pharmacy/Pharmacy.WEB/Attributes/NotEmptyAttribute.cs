using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pharmacy.WEB.Attributes
{
    public class NotEmptyAttribute:ValidationAttribute
    {

        public NotEmptyAttribute(string text="Необходимо заполнить"):base(text)
        {

        }

        public override bool IsValid(object value)
        {
            return !String.IsNullOrWhiteSpace(value?.ToString());
        }
    }
}