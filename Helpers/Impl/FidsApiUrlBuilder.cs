using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using FlightStatsSandbox.Models;

namespace FlightStatsSandbox.Helpers.Impl
{
    public class FidsApiUrlBuilder : IApiUrlBuilder
    {
        public string BuildUrl(Request request)
        {
            IAppSettings appSettings = new FidsAppSettings();

            string queryString = QueryString(new NameValueCollection {
                    { "appId", appSettings.AppID },
                    { "appKey", appSettings.AppKey},
                    { "lateMinutes", appSettings.LateMinutes.ToString() },
                    { "useRunwayTimes", appSettings.UseRunwayTimes.ToString() },
                    { "excludeCargoOnlyFlights", appSettings.ExcludeCargoOnlyFlights.ToString() },
                    { "requestedFields", String.Join(",", appSettings.RequestedFields)}
            });

            UriBuilder uriBuilder = new UriBuilder()
            {
                Scheme = "https",
                Host = "api.flightstats.com",
                Path = "flex/fids/rest/v1/json/ATH/departures",
                Query = queryString

            };

            return uriBuilder.Uri.ToString();
        }

		private string QueryString(NameValueCollection queryFieldsAndValues)
		{
			var array = (from key in queryFieldsAndValues.AllKeys
						 from value in queryFieldsAndValues.GetValues(key)
						 select string.Format("{0}={1}", 
                                              HttpUtility.UrlEncode(key), 
                                              HttpUtility.UrlEncode(value)))
				.ToArray();
			return string.Join("&", array);
		}

	}
}
