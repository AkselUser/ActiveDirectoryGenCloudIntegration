using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PureCloudPlatform.Client.V2.Api;

namespace CircleK_GenesysCloudUpdate._5Auxiliary
{
    class AgentRole
    {
        public static bool CheckIfUserIsAgent(UsersApi usersApi, string userID)
        {
            bool isAgent = false;
            try
            {
                foreach (var role in usersApi.GetUserRoles(userID).Roles)
                {
                    if (role.Id == ConfigurationManager.AppSettings["roleID"])
                    {
                        isAgent = true;
                        break;
                    }
                }
            }
            catch { }
            return isAgent;
        }
    }
}
