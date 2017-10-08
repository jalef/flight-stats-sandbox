using System;
using FlightStatsSandbox.Types;

namespace FlightStatsSandbox.Helpers
{
    public interface IAppSettings
    {
        string AppID { get; }
        string AppKey { get; }
        string[] RequestedFields { get; }
        string[] OrderByFields { get; }
        bool ExcludeCargoOnlyFlights { get; }
        string AirportCode { get; }
        int MinutesBeforeNow { get; }
        int MinutesAfterNow { get; }
        TimeFormatEnum TimeFormat {get; }
        int LateMinutes { get; }
        bool UseRunwayTimes { get; }
    }
}
