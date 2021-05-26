using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;

namespace CircleK_GenesysCloudUpdate._2AD
{
    class ADUsersManagerEmail
    {
        // Class that takes an AD style distinguished name and returns that users email.
        
        public static string GetADUsersManagerEmail(DirectoryEntry directoryEntry, string managerDN)
        {
            DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                // The email is collected by searching for the user, inputting the the DN in the "distinguishedName" field
                Filter = String.Format("(&(objectCategory=person)(objectClass=user)(mail=*.*@*)(distinguishedName={0})(name=*)((!userAccountControl:1.2.840.113556.1.4.803:=2) (memberof:1.2.840.113556.1.4.1941:=cn=Domain Users Office,CN=Users,DC=statoilfuelretail,DC=com)))", managerDN)
            };

            directorySearcher.PropertiesToLoad.Add("Mail");
            SearchResult result = directorySearcher.FindOne();
            
            string resultString = result.Properties["Mail"][0].ToString();
            return resultString;
        }
    }
}
