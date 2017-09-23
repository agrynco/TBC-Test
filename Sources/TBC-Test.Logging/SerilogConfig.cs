using Serilog;
using Serilog.Events;
using TBC_Test.Configuration;

namespace TBC_Test.Logging
{
    public class SerilogConfig
    {
        public static ILogger Configure()
        {
            //ApplicationLifecycleModule.LogPostedFormData = LogPostedFormDataOption.Always;
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                //.Enrich.WithThreadId()
                //.Enrich.With<HttpRequestIdEnricher>()
                //.Enrich.With<UserNameEnricher>()
                //.Enrich.With<HttpRequestEnricher>()
                .Enrich.WithProperty(nameof(ApplicationSettings.Instance.AppSettings.ApplicationName),
                    ApplicationSettings.Instance.AppSettings.ApplicationName)
                .Enrich.WithProperty(nameof(ApplicationSettings.Instance.AppSettings.Environment),
                    ApplicationSettings.Instance.AppSettings.Environment)
                .WriteTo.Seq(ApplicationSettings.Instance.AppSettings.SerilogServerUrl, LogEventLevel.Debug)
                .WriteTo.LiterateConsole(
                    outputTemplate: "{Timestamp:HH:mm} [{Level}] ({ThreadId}) {Message}{NewLine}{Exception}")
                .CreateLogger();

            return Log.Logger;
        }
    }
}