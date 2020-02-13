using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace IDS4.Config.Client
{
    public class DevClients
    {
        public static List<IdentityServer4.Models.Client> GetClients()
        {
            return new List<IdentityServer4.Models.Client>
            {

                //UserAccess client
                new IdentityServer4.Models.Client
                {
                    ClientName = "user_consumer1",
                    ClientId = "user_consumer1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("<SOME BLOODY LONG STRING TO CONVERT>".Sha256())
                    },
                    Enabled = true,
                    AllowedScopes = new List<string>
                    {
                        "client-api.read"
                    },
                    RequireConsent = false,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44303",
                        "https://dev-groupapi"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44303",
                        "https://dev-groupapi"
                    }
                },
                
                //UserAccess client
                new IdentityServer4.Models.Client
                {
                    ClientName = "useraccess",
                    ClientId = "useraccess",
                    Enabled = true,
                    AllowedGrantTypes = 
                    {
                        GrantType.Implicit
                    },
                    AllowedScopes = new List<string>
                    {
                        "user-api",
                        IdentityServerConstants.StandardScopes.OpenId
                    },
                    RequireConsent = false,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:44303",
                        "https://dev-groupapi"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:44303",
                        "https://dev-groupapi"
                    },
                },

                // Website Client
                new IdentityServer4.Models.Client
                {
                    ClientName = "website_consumer",
                    ClientId = "website_consumer",
                    Enabled = true,
                    AllowedGrantTypes =
                    {
                        GrantType.ClientCredentials
                    },
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("<SOME BLOODY LONG STRING TO CONVERT>".Sha256())
                    },
                    AllowedScopes = new List<string>
                    {
                        "client-api"
                    }
                }
            };
        }
    }
}
