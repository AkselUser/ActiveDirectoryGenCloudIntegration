using System;
using System.Collections.Generic;
using System.Text;
using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Model;

namespace CircleK_GenesysCloudUpdate._2AD
{
    class GetManagersIDForEmail
    {
        // This function takes a GC email and returns a GC ID. Email is sent with a POST request, to get the user in response. ID is then extracted from the user
        public static string postSearch(UsersApi usersApi, string email)
        {
            // Criteria is provided as specified in GC documentation
            List<string> fieldList = new List<string>() { "username" };
            UserSearchCriteria userSearchCriteria = new UserSearchCriteria(Type: UserSearchCriteria.TypeEnum.Exact, Fields: fieldList, Value: email.ToLower());

            List<UserSearchCriteria> userSearchCriteriaList = new List<UserSearchCriteria>() { userSearchCriteria };

            // Request is provided as specified in GC documentation
            UserSearchRequest userSearchRequest = new UserSearchRequest(Query: userSearchCriteriaList);

            // Response from Postrequest yields the user the user corresponding to the email address
            UsersSearchResponse userSearchResponse = usersApi.PostUsersSearch(userSearchRequest);

            // Since the response is a list of one, the first element is selected to get the user.
            User user = userSearchResponse.Results[0];
            // id of user is returned
            return user.Id;
        }
    }
}
