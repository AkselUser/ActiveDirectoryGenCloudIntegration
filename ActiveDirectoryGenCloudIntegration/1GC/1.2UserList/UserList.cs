using System;
using System.Collections.Generic;
using System.Text;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;

namespace CircleK_GenesysCloudUpdate._1GC
{
    class UserList
    {
        public static List<Users> createListOfUsers(SCIMApi scimApi, UsersApi usersApi)
        {
            List<Users> userList = new List<Users>();

            // Setting up the fields that will make sure every user is iterated through
            int numberOfUsersPerPage = 25;
            int numberOfUsersPerPageUserLoop = numberOfUsersPerPage;
            int totalResults = (int)scimApi.GetScimUsers().TotalResults;
            int remainderOfUsersOnLastPage = totalResults % numberOfUsersPerPage;
            int iterations = 1;

            // For loop that iterates through the pages
            for (int pageNumber = 0; pageNumber * numberOfUsersPerPage <= totalResults - remainderOfUsersOnLastPage; pageNumber++)
            {
                // Gets the current page of users
                ScimUserListResponse pageOfScimUsers = new SCIMApi().GetScimUsers(count: numberOfUsersPerPage, startIndex: pageNumber*numberOfUsersPerPage+1);

                Console.WriteLine("pageOfScimUsers.ItemsPerPage: " + pageOfScimUsers.ItemsPerPage);
                Console.WriteLine("pageOfScimUsers.StartIndex: " + pageOfScimUsers.StartIndex);
                foreach (ScimV2User user in pageOfScimUsers.Resources)
                {
                    //Sends the current scim user to be converted to Users object and populated with the appropriate fields
                    userList.Add(UserRetriever.getUser(user, scimApi, usersApi));
                }
                iterations++;
                if (iterations * numberOfUsersPerPage >= 270)
                {
                    Console.WriteLine("Iterations: " + iterations);
                    iterations = 0;
                    //System.Threading.Thread.Sleep(60 * 1000);
                    Console.WriteLine("Start up again!");
                }
            }
            Console.WriteLine("GCUserlist retrieved");
            return userList;
        }
    }
}

/*
 * List<ScimV2User> userList = new List<ScimV2User>();

            int numberOfUsersPerPage = 25;
            int numberOfUsersPerPageUserLoop = numberOfUsersPerPage;
            int totalResults = (int)scimApi.GetScimUsers().TotalResults;
            int remainderOfUsersOnLastPage = totalResults % numberOfUsersPerPage;

            // For loop that iterates through the pages
            for (int pageNumber = 0; pageNumber * numberOfUsersPerPage <= totalResults - remainderOfUsersOnLastPage; pageNumber++)
            {
                // If its the last page, the number of pages is changed to the remainder, so the count is right
                //if (pageNumber * numberOfUsersPerPage >= totalResults - remainderOfUsersOnLastPage)
                //{
                //    numberOfUsersPerPageUserLoop = remainderOfUsersOnLastPage;
                //}
                // Gets the current page of users
                ScimUserListResponse pageOfScimUsers = new SCIMApi().GetScimUsers(count: numberOfUsersPerPage, startIndex: pageNumber * numberOfUsersPerPage + 1);

                foreach (ScimV2User user in pageOfScimUsers.Resources)
                {
                    userList.Add(user);
                }

                // Nested for-loop that iterates through through users per page.
                //for (int userNumber = 0; userNumber < numberOfUsersPerPageUserLoop; userNumber++)
                //{
                //    // User gets sent to getUser method to collect details from GC and added to the userList
                //    ScimV2User scimUser = pageOfScimUsers.Resources[userNumber];
                //    userIDList.Add(scimApi.GetScimUser(scimUser.Id).Id);
                //}
            }
            return userList;
*/
