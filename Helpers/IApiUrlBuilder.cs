using System;
using FlightStatsSandbox.Models;

namespace FlightStatsSandbox.Helpers
{
    public interface IApiUrlBuilder
    {
        string BuildUrl(Request request);
    }
}
