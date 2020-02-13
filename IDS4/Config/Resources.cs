using System.Collections.Generic;
using IdentityServer4.Models;

namespace IDS4.Config
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResource
                {
                    Name = "user-api",
                    UserClaims = new List<string>
                    {
                        "role"
                    }
                },
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "client-api",
                    DisplayName = "client-api",
                    Description = "Client Api Access",
                    UserClaims = new List<string>
                    {
                        "role"
                    },
                    ApiSecrets = new List<Secret>
                    {
                        new Secret("scopeSecret".Sha256())
                    },
                    Scopes = new List<Scope>
                    {
                        new Scope("client-api.read"),
                        new Scope("client-api.write")
                    }
                }
            };



            //Type = ScopeType.Resource,
            //Claims = new List<ScopeClaim>
            //    {
            //        new ScopeClaim(Constants.ClaimTypes.Email, true),
            //        new ScopeClaim(Constants.ClaimTypes.Subject, true)
            //    }

            //    //Name = "client-api",
            //    //Type = ScopeType.Resource,
            //    //Claims = new List<ScopeClaim>
            //    //{
            //    //    new ScopeClaim(Constants.ClaimTypes.Email, true),
            //    //    new ScopeClaim(Constants.ClaimTypes.Subject, true)
            //    //}


            // IdentityServerConstants.StandardScopes.OpenId,
            //IdentityServerConstants.StandardScopes.Email,
            //IdentityServerConstants.StandardScopes.Profile,
            //IdentityServerConstants.StandardScopes.OfflineAccess
        }
    }
}