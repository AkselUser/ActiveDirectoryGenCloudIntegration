using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PureCloudPlatform.Client.V2.Api;

namespace CircleK_GenesysCloudUpdate._3Compare
{
    // This class has a meth
    class ListComparison
    {
        // This method iterates through each GC user and compares them to every ADUser. If there is a match. User is removed from both lists. If there is a partial match, user is updated and then removed of both lists. Remaining users in ADUserList will get added to GC. Remaining users in GCUserList will get deleted from GC.
        public static void CompareLists(List<Users> GCUserList, List<Users> ADUserList)
        {
            List<Users> ADlistOfUsersToUpdate = new List<Users>();
            List<Users> GClistOfUsersToUpdate = new List<Users>();

            // Iterates through list to get each user
            foreach (Users GCUser in GCUserList.ToArray())
            {
                // Users have to be converted to JObject. Because JObject is the appropriate format for the DeepEquals method that we use to do the comparison
                string GCUserJson = JsonConvert.SerializeObject(GCUser);
                JObject GCJToken = JObject.Parse(GCUserJson);

                // Nested loop extracts each ADUser in the GCUser loop
                foreach (Users ADUser in ADUserList.ToArray())
                {
                    // Users converted to JObject for use in DeepEquals method later
                    string ADUserJson = JsonConvert.SerializeObject(ADUser);
                    JObject ADJToken = JObject.Parse(ADUserJson);
                    // *** Now that both AD and GC users are JObjects, we can compare them ***
                    // First if statement checks if the user is the same by Email, which is the defining attribute for GC users
                    if (JToken.DeepEquals(GCJToken["Email"], ADJToken["Email"]))
                    {
                        // If the first statement discovers that the users correspond to eachother, the second if statement checks all other attributes to see if the user should be updated
                        if (!(JToken.DeepEquals(GCJToken["Name"], ADJToken["Name"]) && JToken.DeepEquals(GCJToken["Manager"], ADJToken["Manager"]) && JToken.DeepEquals(GCJToken["Department"], ADJToken["Department"]) && JToken.DeepEquals(GCJToken["Title"], ADJToken["Title"]) && JToken.DeepEquals(GCJToken["TelephoneNumber"], ADJToken["TelephoneNumber"]) && JToken.DeepEquals(GCJToken["Mobile"], ADJToken["Mobile"])))
                        {

                            ADlistOfUsersToUpdate.Add(ADUser);
                            GClistOfUsersToUpdate.Add(GCUser);
                            //_4UpdateUsers.Updater.UserUpdate(scimApi, ADUser, GCUser);
                        }
                        ADUserList.Remove(ADUser);
                        GCUserList.Remove(GCUser);
                    }
                }
            }
            Console.WriteLine("*** USERS TO CREATE ***");
            Printer.printUsers(ADUserList);
            Console.WriteLine("*** USERS TO UPDATE ***");
            Console.WriteLine("** GCUSERS ** : ");
            Printer.printUsers(GClistOfUsersToUpdate);
            Console.WriteLine("** ADUSERS ** : ");
            Printer.printUsers(ADlistOfUsersToUpdate);
            Console.WriteLine("\n\n*** USERS TO DELETE ***");
            Printer.printUsers(GCUserList);
            //Console.WriteLine("*** USERS TO CREATE ***");
            //foreach (Users ADUser in ADUserList)
            //{
            //    _4UpdateUsers.Adder.AddUser(scimApi, ADUser);
            //}

            //foreach (Users GCUser in GCUserList)
            //{
            //    _4UpdateUsers.Deleter.DeleteUser(scimApi, GCUser);
            //}


        }
    }
}
