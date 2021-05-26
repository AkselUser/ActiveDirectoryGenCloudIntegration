//using PureCloudPlatform.Client.V2.Api;
//using PureCloudPlatform.Client.V2.Model;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace CircleK_GenesysCloudUpdate._4UpdateUsers
//{
//    class Deleter
//    {
//        // Will delete a user, but only if it has been created by the AD integration(SyncedToAD)
//        public static void DeleteUser(SCIMApi scimApi, Users GCUser)
//        {
//            if (GCUser.SyncedToAD)
//            {
//                scimApi.DeleteScimUser(GCUser.ID);
//            }
//        }
//    }
//}
