using System;
using System.Collections.Generic;
using System.Text;
using PureCloudPlatform.Client.V2.Client;
using PureCloudPlatform.Client.V2.Extensions;

namespace CircleK_GenesysCloudUpdate._1GC
{
    class Configure
    {
        public static void RunConfig()
        {
            SetEnvironment();
            SetToken();
        }
        public static void SetToken()
        {
            // StatoilFuelRetail test
            //string clientID = "3f3b1dc7-01a8-41e7-9533-01f346575764";
            //string clientSecret = "AgX5QWFGl0eIOVNfoAlGljxzbQqXv0rFqjbfA3Hvrl4";

            // CircleKEurope prod
            string clientID = "";
            string clientSecret = "";

            // Set access token as described in GC documentation
            AuthTokenInfo accessTokenInfo = PureCloudPlatform.Client.V2.Client.Configuration.Default.ApiClient.PostToken(
                clientID,
                clientSecret);
            PureCloudPlatform.Client.V2.Client.Configuration.Default.AccessToken = accessTokenInfo.AccessToken;
        }
        public static void SetEnvironment()
        {
            // Set environment
            PureCloudRegionHosts region = PureCloudRegionHosts.eu_west_1;
            Configuration.Default.ApiClient.setBasePath(region);
        }
    }
}
