using AGrynCo.Lib;
using AGrynCo.Lib.Settings;

namespace TBC_Test.Configuration
{
    public class ApplicationSettings : BaseSingletone<ApplicationSettings>
    {
        protected ApplicationSettings()
        {
            AppSettings = new ApplicationSettingsContainer();
            DbSetting = new DbSettingsContainer();
        }

        public ApplicationSettingsContainer AppSettings { get; }

        public DbSettingsContainer DbSetting { get; }

        public class DbSettingsContainer : BaseClass
        {
            public string ApplicationConnectionString => SettingsManager.Instance.GetConnectionString("tbc-test");
        }

        public class ApplicationSettingsContainer : BaseClass
        {
            public string ApplicationName => SettingsManager.Instance.GetAppSetting("applicationName", "TBC-Test");

            public AppEnvironment Environment => SettingsManager.Instance.GetAppSetting(
                "appEnvironment", AppEnvironment.Production);

            public string SerilogServerUrl
                => SettingsManager.Instance.GetAppSetting("serilog:ServerUrl", "logs.grynco.com.ua:5712");
        }
    }
}