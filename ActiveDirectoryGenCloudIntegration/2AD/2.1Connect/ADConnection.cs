using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Text;
using PureCloudPlatform.Client.V2.Client;

namespace CircleK_GenesysCloudUpdate._2AD
{
    // Class that logs in to AD and returns the connection object
    public static class ADConnection
    {
        static string IP = ConfigurationManager.AppSettings["IP"];
        static string domain = ConfigurationManager.AppSettings["domain"];
        static string userName = ConfigurationManager.AppSettings["userName"];
        static string password = ConfigurationManager.AppSettings["password"];

        // Set active directory connection
        public static DirectoryEntry connectTotAD()
        {
            DirectoryEntry directoryEntry = new DirectoryEntry("LDAP://" + IP + "/" + domain, userName, password);
            return directoryEntry;
        }
    }
}
