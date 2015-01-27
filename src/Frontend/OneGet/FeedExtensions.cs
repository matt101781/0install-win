using System.Linq;
using JetBrains.Annotations;
using NanoByte.Common.Collections;
using ZeroInstall.Store.Model;

namespace ZeroInstall.OneGet
{
    public static class FeedExtensions
    {
        [CanBeNull, Pure]
        public static Implementation GetLatestImplementation([NotNull] this Feed feed)
        {
            return feed.Elements.OfType<Implementation>().MaxBy(x => x.Version);
        }
    }
}