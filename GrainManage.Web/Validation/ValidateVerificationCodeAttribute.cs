using GrainManage.Web.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GrainManage.Web.Validation
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateVerificationCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool isValid = true;
            string strValue = value as string;
            if (string.IsNullOrEmpty(strValue))
            {
                ErrorMessage = AccountResx.VerificationCodeRequired;
                isValid = false;
            }
            else if (strValue.Length != 4)
            {
                ErrorMessage = AccountResx.VeryCodeLength;
                isValid = false;
            }
            else
            {
                string code = HttpContext.Current.Session[GlobalVar.ValidateCode] as string;
                if (!string.Equals(strValue, code, StringComparison.CurrentCultureIgnoreCase))
                {
                    ErrorMessage = AccountResx.VerificationNotMatch;
                    isValid = false;
                }
            }
            return isValid;
        }
    }
}