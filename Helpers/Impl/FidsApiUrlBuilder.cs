using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using FlightStatsSandbox.Models;

namespace FlightStatsSandbox.Helpers.Impl
{
    public class FidsApiUrlBuilder : IApiUrlBuilder
    {
        private readonly IAppSettings _appSettings;

        public FidsApiUrlBuilder(IAppSettings appSettings)
        {
            _appSettings = appSettings;   
        }

        public string BuildUrl(Request request)
        {
            string queryString = QueryString(new NameValueCollection {
                    { "appId", _appSettings.AppID },
                    { "appKey", _appSettings.AppKey},
                    { "lateMinutes", _appSettings.LateMinutes.ToString() },
                    { "useRunwayTimes", _appSettings.UseRunwayTimes.ToString() },
                    { "excludeCargoOnlyFlights", _appSettings.ExcludeCargoOnlyFlights.ToString() },
                    { "requestedFields", String.Join(",", _appSettings.RequestedFields)}
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