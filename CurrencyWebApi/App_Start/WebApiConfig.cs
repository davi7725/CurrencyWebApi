﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CurrencyWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{value}/{isoFrom}/{isoTo}",
                defaults: new { value = RouteParameter.Optional, isoFrom = RouteParameter.Optional, isoTo = RouteParameter.Optional }
            );
        }
    }
}