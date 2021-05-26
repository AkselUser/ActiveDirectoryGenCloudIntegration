using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PureCloudPlatform.Client.V2.Model;

namespace CircleK_GenesysCloudUpdate._5Auxiliary
{
    class FieldMappings
    {
        // Class for configuring field mappings
        public static string SelectFieldMapping(string input, Users ADUser)
        {
            if (input == "ADEmail")
            {
                return ADUser.Email;
            }
            else if (input == "ADName")
            {
                return ADUser.Name;
            }
            else if (input == "ADManager")
            {
                return ADUser.Manager;
            }
            else if (input == "ADDepartment")
            {
                return ADUser.Department;
            }
            else if (input == "ADPrimaryPhone")
            {
                return ADUser.TelephoneNumber;
            }
            else if (input == "ADMobile")
            {
                return ADUser.Mobile;
            }
            else
            {
                return null;
            }
        }
    }
}
