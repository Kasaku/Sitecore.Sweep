namespace Kasaku.Sitecore.Modules.Sweep.Configuration
{
    public static class SweepConfig
    {
        public static bool CleanOnItemSave
        {
            get { return global::Sitecore.Configuration.Settings.GetBoolSetting("Sitecore.Sweep.CleanOnItemSave", true); }
        }
    }
}
