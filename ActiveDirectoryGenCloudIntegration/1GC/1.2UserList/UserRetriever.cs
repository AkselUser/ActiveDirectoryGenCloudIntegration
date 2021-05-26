using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;
using System.Configuration;

namespace CircleK_GenesysCloudUpdate._1GC
{
    static class UserRetriever
    {
        // Class takes a specific user from a collection (page) and assigns its relevant attributes to a new Users object, as specified in the "Users" class
        public static Users getUser(ScimV2User scimUser, SCIMApi scimApi, UsersApi usersApi)
        {

            // The Users object that will be assigned values
            Users newUser = new Users();

            // The if statements checks if the attribute exists, to avoid the program crashing from error
            if (scimUser.Urnietfparamsscimschemasextensiongenesyspurecloud20User != null)
            {
                if (scimUser.Urnietfparamsscimschemasextensiongenesyspurecloud20User.ExternalIds != null)
                {
                    List<ScimGenesysUserExternalId> externalIDList = scimUser.Urnietfparamsscimschemasextensiongenesyspurecloud20User.ExternalIds;
                    if (externalIDList != null)
                    {
                        foreach (ScimGenesysUserExternalId externalID in externalIDList)
                        {
                            if (externalID.Authority == ConfigurationManager.AppSettings["ExternalIDAuthority"])
                            {
                                newUser.SyncedToAD = true;
                            }
                        }
                    }
                }
            }

            if (scimUser.Id != null)
            {
                newUser.ID = scimUser.Id;
            }

            if (scimUser.UserName != null)
            {
                newUser.Email = scimUser.UserName;
            }

            if (scimUser.DisplayName != null)
            {
                newUser.Name = scimUser.DisplayName;
            }

            if (scimUser.Urnietfparamsscimschemasextensionenterprise20User != null)
            {
                if (scimUser.Urnietfparamsscimschemasextensionenterprise20User.Department != null)
                {
                    newUser.Department = scimUser.Urnietfparamsscimschemasextensionenterprise20User.Department;
                }
                if (scimUser.Urnietfparamsscimschemasextensionenterprise20User.Manager != null)
                {
                    newUser.Manager = scimUser.Urnietfparamsscimschemasextensionenterprise20User.Manager.Value;
                }
            }

            if (scimUser.Title != null)
            {
                newUser.Title = scimUser.Title;
            }

            if (scimUser.PhoneNumbers != null)
            {
                foreach (ScimPhoneNumber number in scimUser.PhoneNumbers)
                {
                    if (number.Type == ScimPhoneNumber.TypeEnum.Other)
                    {
                        newUser.TelephoneNumber = number.Value;
                    }
                    if (number.Type == ScimPhoneNumber.TypeEnum.Mobile)
                    {
                        newUser.Mobile = number.Value;
                    }
                }
            }

            newUser.isAgent = _5Auxiliary.AgentRole.CheckIfUserIsAgent(usersApi, scimUser.Id);

            return newUser;
        }
    }
}
