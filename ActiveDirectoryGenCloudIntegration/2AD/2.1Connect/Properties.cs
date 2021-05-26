using System;
using System.Collections.Generic;
using System.Text;

namespace CircleK_GenesysCloudUpdate._2AD
{
    public static class Properties
    {
        // Makes a list of properties that DirectorySearcher will use for searching the AD to make a userList
        public static List<string> makePropertyList()
        {
            List<string> propertyList = new List<string>();

            propertyList.Add("Mail");
            propertyList.Add("displayName");
            propertyList.Add("ThumbnailPhoto");
            propertyList.Add("Manager");
            propertyList.Add("Department");
            propertyList.Add("Title");
            propertyList.Add("telephoneNumber");
            propertyList.Add("mobile");
            return propertyList;
        }

    }
}
