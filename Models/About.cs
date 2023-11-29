using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JijonMateo_AppApuntes.Models
{
    internal class About
    {
        public string Title => AppInfo.Name;
        public string MJ_Version => AppInfo.VersionString;
        public string MJ_MoreInfoUrl => "https://aka.ms/maui";
        public string MJ_Message => "This app is written in XAML and C# with .NET MAUI.";
    }
}
