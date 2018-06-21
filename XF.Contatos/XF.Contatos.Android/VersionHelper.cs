using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XF.Contatos.API;
using Xamarin.Forms;
using XF.Contatos.Droid;
using XF.Contatos.Global;

[assembly: Dependency(typeof(VersionHelper))]
namespace XF.Contatos.Droid
{
    public class VersionHelper : IVersionHelper
    {
        public string GetVersionNumber()
        {
            var versionNumber = string.Empty;
            if (MainApplication.CurrentContext != null)
            {
                versionNumber = MainApplication.CurrentContext.PackageManager.GetPackageInfo(MainApplication.CurrentContext.PackageName, 0).VersionName;
            }
            return versionNumber;
        }
    }
}