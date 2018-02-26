using GrainManage.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrainManage.Web.Cache
{
    public class UrlCache
    {
        private static readonly List<string> urlList = new List<string>();
        private static DateTime lastModifiedAt = DateTime.Now;
        private static readonly object lockObj = new object();
        private static int cacheMinute = 30;

        public static void RefreshUrlList(bool forceRefresh = false)
        {
            var now = DateTime.Now;
            if (forceRefresh || !urlList.Any() || lastModifiedAt.AddMinutes(cacheMinute) < now)
            {
                lock (lockObj)
                {
                    if (forceRefresh || !urlList.Any() || lastModifiedAt.AddMinutes(cacheMinute) < now)
                    {
                        var urls = AddressService.GetUrl();
                        urlList.Clear();
                        urlList.AddRange(urls.Where(f => !string.IsNullOrEmpty(f)).Select(s => s.Trim()));
                        lastModifiedAt = now;
                    }
                }
            }
        }
        public static bool IsUrlExisted(string url)
        {
            RefreshUrlList(false);
            return urlList.Any(s => string.Equals(s, url, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
