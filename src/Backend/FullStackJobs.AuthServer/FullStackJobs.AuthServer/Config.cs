﻿using System;
using System.Collections.Generic;
using IdentityServer4.Models;

namespace FullStackJobs.AuthServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceapi", "Resource API")
                {
                    Scopes = {new Scope("api.read")}
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client {
                    RequireConsent = false,
                    ClientId = "js_test_client",
                    ClientName = "Javascript Test Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    AllowedScopes = { "openid", "profile", "email", "api.read" },
                    RedirectUris = {"https://localhost:5001/test-client/callback.html"},
                    AllowedCorsOrigins = {"https://localhost:5001"},                    
                    AccessTokenLifetime = (int)TimeSpan.FromDays(224).TotalSeconds
                }
            };
        }
    }
}
