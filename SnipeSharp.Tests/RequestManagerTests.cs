﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnipeSharp.Exceptions;
using SnipeSharp.Common;
using System.Reflection;
using System.Net.Http;

namespace SnipeSharp.Tests
{
    [TestClass]
    public class RequestManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullApiTokenException), "No API Token Set")]
        public void CheckApiTokenAndUrl_NoTokenInApiSettings_ThrowException()
        {
            var reqManager = new RequestManager(new ApiSettings {BaseUrl = new Uri("http://google.com")});
            reqManager.CheckApiTokenAndUrl();
        }

        [TestMethod]
        [ExpectedException(typeof(NullApiBaseUrlException), "No API Base Url Set.")]
        public void CheckApiTokenAndUrl_NoUrlInApiSettings_ThrowException()
        {
            var reqManager = new RequestManager(new ApiSettings {ApiToken = "xxxxx"});
            reqManager.CheckApiTokenAndUrl();
        }

        [TestMethod]
        public void CheckApiTokenAndUrl_SetHttpClientBaseAddress_SetCorrectly()
        {
            var url = new Uri("http://google.com");
            var reqManager =
                new RequestManager(new ApiSettings
                {
                    BaseUrl = url,
                    ApiToken = "xxxxxx"
                });
            
            reqManager.CheckApiTokenAndUrl();

            // Get the Static property value
            Type type = typeof(RequestManager);
            PropertyInfo prop = type.GetProperty("Client", BindingFlags.Instance | BindingFlags.NonPublic);
            HttpClient value = prop.GetValue(reqManager) as HttpClient;

            Assert.AreEqual(url, value.BaseAddress);
        }

        [TestMethod]
        public void CheckApiTokenAndUrl_SetAuthorizationHeader_SetCorrectly()
        {
            var url = new Uri("http://google.com");
            var apiToken = "xxxxxx";
            var reqManager =
                new RequestManager(new ApiSettings
                {
                    BaseUrl = url,
                    ApiToken = apiToken
                });
            reqManager.CheckApiTokenAndUrl();

            // Get the Static property value
            Type type = typeof(RequestManager);
            PropertyInfo prop = type.GetProperty("Client", BindingFlags.Instance | BindingFlags.NonPublic);
            HttpClient value = prop.GetValue(reqManager) as HttpClient;

            Assert.IsTrue(value.DefaultRequestHeaders.Authorization.Scheme == "Bearer" &&
                value.DefaultRequestHeaders.Authorization.Parameter == apiToken);

        }
    }
}
