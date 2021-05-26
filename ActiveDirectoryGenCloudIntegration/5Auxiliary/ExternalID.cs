using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Model;

namespace CircleK_GenesysCloudUpdate._5Auxiliary
{
    class ExternalID
    {
        // The method creates an externalID in the appropriate format (List<ScimGenesysUserExternalId>). This can be directly input into the externalIDs attribute. IMPORTANT: Make sure its the externalIDs attribute list in the ScimUserExtensions class. Not the ExternalID attribute in the User class
        public static List<ScimGenesysUserExternalId> CreateExternalID()
        {
            string finalString = StringBuilder.runsStringBuilder() + "-" + StringBuilder.runsStringBuilder() + "-" + StringBuilder.runsStringBuilder() + "-" + StringBuilder.runsStringBuilder();

            ScimGenesysUserExternalId extID = new ScimGenesysUserExternalId()
            {
                Authority = ConfigurationManager.AppSettings["ExternalIDAuthority"],
                Value = finalString
            };
            List<ScimGenesysUserExternalId> extIDList = new List<ScimGenesysUserExternalId>() { extID };

            return extIDList;
        }
    }
}
