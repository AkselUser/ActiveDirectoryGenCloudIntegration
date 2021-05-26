using Newtonsoft.Json;
using PureCloudPlatform.Client.V2.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Text;


namespace CircleK_GenesysCloudUpdate._2AD
{

    // Class that returns a list of 
    class UserList
    {
        // Method that retrieves users from AD
        // Parameters: directoryEntry(object that connects to AD), propertyList(list of properties to search for)
        // A list is created. Using directorySearcher with the connection obeject "directoryEntry" we set filter and load properties.
        // Then the search is made and stored in "results". For each result a user is created. Then, each property from "propertyList"
        // is collected from each result and stored in the appropriate container in the User object. The User is stored in the userList
        // and the process is repeated until every result is handled
        public static List<Users> RetrieveUsers(DirectoryEntry directoryEntry, List<string> propertyList)
        {
            UsersApi usersApi = new UsersApi();
            List<Users> ADUserList = new List<Users>();
            using (DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry)
            {
                // CircleK Filter
                Filter = ConfigurationManager.AppSettings["filter"]
            } )
            {
                foreach (var property in propertyList)
                {
                    directorySearcher.PropertiesToLoad.Add(property);
                }
                // run the search and and it will output a collection of the entries that are found.
                using (SearchResultCollection results = directorySearcher.FindAll())
                {
                    foreach (SearchResult result in results)
                    {
                        Users newUser = new Users();

                        if (result.Properties.Contains("Mail"))
                        {
                            newUser.Email = result.Properties["Mail"][0].ToString();
                        }
                        if (result.Properties.Contains("displayName"))
                        {
                            newUser.Name = result.Properties["displayName"][0].ToString();
                        }
                        if (result.Properties.Contains("Manager"))
                        {
                            string managerDN = result.Properties["Manager"][0].ToString();
                            Console.WriteLine(managerDN + "asap");
                            try
                            {
                                string managerUserName = (ADUsersManagerEmail.GetADUsersManagerEmail(directoryEntry, managerDN));
                                string managerID = GetManagersIDForEmail.postSearch(usersApi, managerUserName);
                                newUser.Manager = managerID;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                        if (result.Properties.Contains("Department"))
                        {
                            newUser.Department = result.Properties["Department"][0].ToString();
                        }
                        if (result.Properties.Contains("Title"))
                        {
                            newUser.Title = result.Properties["Title"][0].ToString();
                        }
                        if (result.Properties.Contains("telephoneNumber"))
                        {
                            newUser.TelephoneNumber = result.Properties["telephoneNumber"][0].ToString();
                        }
                        if (result.Properties.Contains("mobile"))
                        {
                            newUser.Mobile = result.Properties["mobile"][0].ToString();
                        }

                        string userAsJson = JsonConvert.SerializeObject(newUser, Formatting.Indented);

                        ADUserList.Add(newUser);
                    }
                }
                // Release resources
                directorySearcher.Dispose();
                directoryEntry.Dispose();

                // string readJsonUserFile = File.ReadAllText(Environment.CurrentDirectory + @"\ADUsers.json");
                Console.WriteLine("ADUserList retrieved");
                return ADUserList;
            }
        }
    }
}
