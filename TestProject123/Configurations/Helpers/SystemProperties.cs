using System;

namespace TestProject123.Configurations.Helpers
{
    public class SystemProperties
    {
        public static string PathProject = AppDomain.CurrentDomain.BaseDirectory.ToString().Remove(AppDomain.CurrentDomain.BaseDirectory.ToString().LastIndexOf("\\") - 23);
    }
}