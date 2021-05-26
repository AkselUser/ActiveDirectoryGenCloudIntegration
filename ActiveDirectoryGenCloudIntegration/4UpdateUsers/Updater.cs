//using System;
//using System.Collections.Generic;
//using System.Text;
//using PureCloudPlatform.Client.V2.Api;
//using PureCloudPlatform.Client.V2.Model;
//using System.Configuration;

//namespace CircleK_GenesysCloudUpdate._4UpdateUsers
//{
//    class Updater
//    {
//        // Will update a user, but only if it has been created by the AD integration(SyncedToAD)
//        public static void UserUpdate(SCIMApi scimApi, Users ADUser, Users GCUser)
//        {
//            if (GCUser.SyncedToAD)
//            {
//                // First the existing body of the user is collected from GC. This is the template we will populate new attributes to. This is to make sure all other information is preserved
//                ScimV2User body = scimApi.GetScimUser(GCUser.ID);

//                // Each attribute of "body" is assigned a value from field mapping using the current ADUser input
//                body.DisplayName = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCName"], ADUser);


//                body.UserName = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCEmail"], ADUser);


//                Manager manager = new Manager();
//                manager.Value = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCManager"], ADUser);
//                body.Urnietfparamsscimschemasextensionenterprise20User.Manager = manager;


//                body.Urnietfparamsscimschemasextensionenterprise20User.Department = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCDepartment"], ADUser);


//                body.Title = _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCTitle"], ADUser);

//                // Only update the phone numbers if the user does not have the agent role
//                if (ADUser.isAgent == false)
//                {
//                    ScimPhoneNumber scimPhoneNumber1 = new ScimPhoneNumber(Value: _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCPrimaryPhone"], ADUser), ScimPhoneNumber.TypeEnum.Other, Primary: true);

//                    ScimPhoneNumber scimPhoneNumber2 = new ScimPhoneNumber(Value: _5Auxiliary.FieldMappings.SelectFieldMapping(ConfigurationManager.AppSettings["GCMobile"], ADUser), ScimPhoneNumber.TypeEnum.Mobile, Primary: false);

//                    List<ScimPhoneNumber> scimPhoneNumbers = new List<ScimPhoneNumber>()
//                    {
//                        scimPhoneNumber1,
//                        scimPhoneNumber2
//                    };

//                    body.PhoneNumbers = scimPhoneNumbers;
//                }

//                scimApi.PutScimUser(GCUser.ID, body);
//            }
//        }
//    }
//}
