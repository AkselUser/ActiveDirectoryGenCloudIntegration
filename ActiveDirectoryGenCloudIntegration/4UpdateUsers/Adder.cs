//using PureCloudPlatform.Client.V2.Api;
//using PureCloudPlatform.Client.V2.Model;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Configuration;
//using CircleK_GenesysCloudUpdate._5Auxiliary;

//namespace CircleK_GenesysCloudUpdate._4UpdateUsers
//{
//    class Adder
//    {
//        public static void AddUser(SCIMApi scimApi, Users ADUser)
//        {
//            // New user is created in GC. Field Mappings decide which fields from the ADUser is used to create the new GCUser
//            // Look up GC documentation to learn the structure of users
//            ScimV2CreateUser body = new ScimV2CreateUser();

//            body.DisplayName = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCName"], ADUser);

//            ScimV2EnterpriseUser enterpriseUser = new ScimV2EnterpriseUser();
//            enterpriseUser.Department = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCDepartment"], ADUser);

//            Manager manager = new Manager();
//            manager.Value = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCManager"], ADUser);
//            enterpriseUser.Manager = manager;
//            body.Urnietfparamsscimschemasextensionenterprise20User = enterpriseUser;

//            body.Title = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCTitle"], ADUser);

//            body.UserName = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCEmail"], ADUser);

//            ScimPhoneNumber cellPhoneNumber = new ScimPhoneNumber();
//            ScimPhoneNumber otherPhoneNumber = new ScimPhoneNumber();
//            List<ScimPhoneNumber> phoneNumberList = new List<ScimPhoneNumber>();

//            // If the user has the "Agent" role, telephone numbers will not be synced
//            if (ADUser.isAgent == false)
//            {
//                cellPhoneNumber.Value = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCMobile"], ADUser);
//                cellPhoneNumber.Type = ScimPhoneNumber.TypeEnum.Mobile;
//                cellPhoneNumber.Primary = false;

//                otherPhoneNumber.Value = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCPrimaryPhone"], ADUser);
//                otherPhoneNumber.Type = ScimPhoneNumber.TypeEnum.Other;
//                otherPhoneNumber.Primary = true;
                
//                phoneNumberList.Add(cellPhoneNumber);
//                phoneNumberList.Add(otherPhoneNumber);
//                body.PhoneNumbers = phoneNumberList;
//            }

//            // Sets externalID. ExternalID is used to mark the user as synced by this script rather than manually
//            body.Urnietfparamsscimschemasextensiongenesyspurecloud20User.ExternalIds = ExternalID.CreateExternalID();

//            scimApi.PostScimUsers(body);
//        }
//    }
//}
