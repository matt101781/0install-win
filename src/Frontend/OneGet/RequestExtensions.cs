using System.Globalization;
using System.Linq;
using JetBrains.Annotations;
using OneGet.Sdk;
using ZeroInstall.Store.Model;

namespace ZeroInstall.OneGet
{
    public static class RequestExtensions
    {
        public static void YieldFeed([NotNull] this Request request, [NotNull] Feed feed)
        {
            var bestVersion = feed.Elements.OfType<Implementation>().Max(x => x.Version);
            request.YieldSoftwareIdentity(
                fastPath: feed.Uri.ToStringRfc(),
                name: feed.Name,
                version: (bestVersion == null) ? null : bestVersion.ToString(),
                versionScheme: null,
                summary: feed.Summaries.GetBestLanguage(CultureInfo.CurrentUICulture),
                source: feed.Uri.ToStringRfc(),
                searchKey: feed.Name,
                fullPath: null,
                packageFileName: null);
        }
    }
}