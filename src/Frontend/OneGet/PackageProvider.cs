using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NanoByte.Common;
using NanoByte.Common.Collections;
using NanoByte.Common.Info;
using OneGet.Sdk;
using ZeroInstall.DesktopIntegration;
using ZeroInstall.Services;
using ZeroInstall.Services.Feeds;
using ZeroInstall.Store;
using ZeroInstall.Store.Model;

namespace ZeroInstall.OneGet
{
    /// <summary>
    /// A OneGet package provider for Zero Install.
    /// </summary>
    [UsedImplicitly]
    public class PackageProvider
    {
        /// <summary>
        /// Returns the name of the Provider.
        /// </summary>
        /// <returns>The name of this provider </returns>
        public string PackageProviderName { get { return "ZeroInstall"; } }

        /// <summary>
        /// Returns the version of the Provider.
        /// </summary>
        public string ProviderVersion { get { return AppInfo.Load(Assembly.GetExecutingAssembly()).Version.ToString(); } }

        /// <summary>
        /// Performs one-time initialization of the $provider.
        /// </summary>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void InitializeProvider(Request request)
        {
            request.Debug("Calling '{0}::InitializeProvider'", PackageProviderName);
        }

        /// <summary>
        /// The features that this package manager supports.
        /// </summary>
        private static readonly Dictionary<string, string[]> _features = new Dictionary<string, string[]>
        {
            {Constants.Features.SupportedExtensions, new[] {"xml"}},
            {Constants.Features.SupportedSchemes, new[] {"http", "https", "file"}}
        };

        /// <summary>
        /// Returns a collection of strings to the client advertizing features this provider supports.
        /// </summary>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void GetFeatures(Request request)
        {
            request.Debug("Calling '{0}::GetFeatures'", PackageProviderName);

            foreach (var feature in _features)
                request.Yield(feature);
        }

        /// <summary>
        /// This is just here as to give us some possibility of knowing when an unexception happens.
        /// </summary>
        public void OnUnhandledException(string methodName, Exception exception)
        {
            Log.Error("Unhandled exception in OneGet Provider (Method: " + methodName + ")");
            Log.Error(exception);
        }

        private const string
            MachineWide = "MachineWide",
            AccessPointCategories = "AccessPointCategories",
            NoDownload = "NoDownload";

        /// <summary>
        /// Returns dynamic option definitions to the HOST
        ///
        /// example response:
        ///     request.YieldDynamicOption( "MySwitch", OptionType.String.ToString(), false);
        ///
        /// </summary>
        /// <param name="category">The category of dynamic options that the HOST is interested in</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void GetDynamicOptions(string category, Request request)
        {
            request.Debug("Calling '{0}::GetDynamicOptions'", PackageProviderName);

            switch ((category ?? string.Empty).ToLowerInvariant())
            {
                case "package":
                    break;

                case "source":
                    break;

                case "install":
                    request.YieldDynamicOption(MachineWide, Constants.OptionType.Switch, false);
                    request.YieldDynamicOption(AccessPointCategories, Constants.OptionType.StringArray, false, CategoryIntegrationManager.Categories);
                    request.YieldDynamicOption(NoDownload, Constants.OptionType.Switch, false);
                    break;
            }
        }

        /// <summary>
        /// Resolves and returns Package Sources to the client.
        ///
        /// Specified sources are passed in via the request object (<c>request.GetSources()</c>).
        ///
        /// Sources are returned using <c>request.YieldPackageSource(...)</c>
        /// </summary>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void ResolvePackageSources(Request request)
        {
            request.Debug("Calling '{0}::ResolvePackageSources'", PackageProviderName);

            var registerdSources = CatalogManager.GetSources();

            if (request.Sources.Any())
            {
                // the system is requesting sources that match the values passed.
                // if the value passed can be a legitimate source, but is not registered, return a package source marked unregistered.
                foreach (var uri in request.Sources.TrySelect<string, FeedUri, UriFormatException>(x => new FeedUri(x)))
                {
                    bool isRegistered = registerdSources.Contains(uri);
                    request.YieldPackageSource(uri.ToStringRfc(), uri.ToStringRfc(), isTrusted: false, isRegistered: isRegistered, isValidated: false);
                }
            }
            else
            {
                // the system is requesting all the registered sources
                foreach (var uri in registerdSources)
                    request.YieldPackageSource(uri.ToStringRfc(), uri.ToStringRfc(), isTrusted: false, isRegistered: true, isValidated: false);
            }
        }

        /// <summary>
        /// This is called when the user is adding (or updating) a package source
        ///
        /// If this PROVIDER doesn't support user-defined package sources, remove this method.
        /// </summary>
        /// <param name="name">The name of the package source. If this parameter is null or empty the PROVIDER should use the location as the name (if the PROVIDER actually stores names of package sources)</param>
        /// <param name="location">The location (ie, directory, URL, etc) of the package source. If this is null or empty, the PROVIDER should use the name as the location (if valid)</param>
        /// <param name="trusted">A boolean indicating that the user trusts this package source. Packages returned from this source should be marked as 'trusted'</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void AddPackageSource(string name, string location, bool trusted, Request request)
        {
            request.Debug("Calling '{0}::AddPackageSource'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));
            services.CatalogManager.AddSource(new FeedUri(location));
        }

        /// <summary>
        /// Removes/Unregisters a package source
        /// </summary>
        /// <param name="name">The name or location of a package source to remove.</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void RemovePackageSource(string name, Request request)
        {
            request.Debug("Calling '{0}::RemovePackageSource'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));
            services.CatalogManager.RemoveSource(new FeedUri(name));
        }

        /// <summary>
        /// Searches package sources given name and version information
        ///
        /// Package information must be returned using <c>request.YieldPackage(...)</c> function.
        /// </summary>
        /// <param name="name">a name or partial name of the package(s) requested</param>
        /// <param name="requiredVersion">A specific version of the package. Null or empty if the user did not specify</param>
        /// <param name="minimumVersion">A minimum version of the package. Null or empty if the user did not specify</param>
        /// <param name="maximumVersion">A maximum version of the package. Null or empty if the user did not specify</param>
        /// <param name="id">if this is greater than zero (and the number should have been generated using <c>StartFind(...)</c>, the core is calling this multiple times to do a batch search request. The operation can be delayed until <c>CompleteFind(...)</c> is called</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void FindPackage(string name, string requiredVersion, string minimumVersion, string maximumVersion, int id, Request request)
        {
            request.Debug("Calling '{0}::FindPackage'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));

            Catalog catalog;
            try
            {
                catalog = services.CatalogManager.GetOnline();
            }
            catch (Exception ex)
            {
                request.Warning(ex.Message);
                try
                {
                    catalog = services.CatalogManager.GetCached() ?? new Catalog();
                }
                catch (Exception ex2)
                {
                    request.Warning(ex2.Message);
                    catalog = new Catalog();
                }
            }

            // TODO: Find multiple matches
            var feed = catalog.FindByShortName(name);
            if (feed != null) request.YieldFeed(feed);
        }

        /// <summary>
        /// Finds packages given a locally-accessible filename
        ///
        /// Package information must be returned using <c>request.YieldPackage(...)</c> function.
        /// </summary>
        /// <param name="file">the full path to the file to determine if it is a package</param>
        /// <param name="id">if this is greater than zero (and the number should have been generated using <c>StartFind(...)</c>, the core is calling this multiple times to do a batch search request. The operation can be delayed until <c>CompleteFind(...)</c> is called</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void FindPackageByFile(string file, int id, Request request)
        {
            request.Debug("Calling '{0}::FindPackageByFile'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));

            var feed = services.FeedManager.GetFeed(new FeedUri(file));
            request.YieldFeed(feed);
        }

        /// <summary>
        /// Finds packages given a URI.
        ///
        /// The function is responsible for downloading any content required to make this work
        ///
        /// Package information must be returned using <c>request.YieldPackage(...)</c> function.
        /// </summary>
        /// <param name="uri">the URI the client requesting a package for.</param>
        /// <param name="id">if this is greater than zero (and the number should have been generated using <c>StartFind(...)</c>, the core is calling this multiple times to do a batch search request. The operation can be delayed until <c>CompleteFind(...)</c> is called</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void FindPackageByUri(Uri uri, int id, Request request)
        {
            request.Debug("Calling '{0}::FindPackageByUri'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));

            var feed = services.FeedManager.GetFeed(new FeedUri(uri));
            request.YieldFeed(feed);
        }

        /// <summary>
        /// Returns package references for all the dependent packages
        /// </summary>
        /// <param name="fastPackageReference"></param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void GetPackageDependencies(string fastPackageReference, Request request)
        {
            request.Debug("Calling '{0}::GetPackageDependencies'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));

            var feed = services.FeedManager.GetFeedFresh(new FeedUri(fastPackageReference));
            var latestImplementation = feed.GetLatestImplementation();
            if (latestImplementation == null) return;
            foreach (var dependency in latestImplementation.Dependencies)
            {
                var dependencyFeed = services.FeedManager.GetFeed(dependency.InterfaceUri);
                request.YieldFeed(dependencyFeed);
            }
        }

        /// <summary>
        /// Installs a given package.
        /// </summary>
        /// <param name="fastPackageReference">A provider supplied identifier that specifies an exact package</param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void InstallPackage(string fastPackageReference, Request request)
        {
            request.Debug("Calling '{0}::InstallPackage'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));
            var feedUri = new FeedUri(fastPackageReference);
            bool machineWide = request.OptionKeys.Contains(MachineWide);
            bool noDownload = request.OptionKeys.Contains(NoDownload);
            var categories = request.Options.ContainsKey(AccessPointCategories)
                ? request.Options[AccessPointCategories]
                : new[] {CategoryIntegrationManager.AllCategoryName};

            var feed = services.FeedManager.GetFeedFresh(feedUri);
            using (var integrationManager = new CategoryIntegrationManager(services.Handler, machineWide))
            {
                var appEntry = integrationManager.AddApp(feedUri, feed);
                integrationManager.AddAccessPointCategories(appEntry, feed, categories);
            }

            if (!noDownload)
            {
                var selections = services.Solver.Solve(new Requirements(feedUri));
                var missing = services.SelectionsManager.GetUncachedImplementations(selections);
                services.Fetcher.Fetch(missing);
            }
        }

        /// <summary>
        /// Uninstalls a package.
        /// </summary>
        /// <param name="fastPackageReference"></param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void UninstallPackage(string fastPackageReference, Request request)
        {
            request.Debug("Calling '{0}::UninstallPackage'", PackageProviderName);

            var feedUri = new FeedUri(fastPackageReference);
            bool machineWide = request.OptionKeys.Contains(MachineWide);

            using (var integrationManager = new IntegrationManager(new OneGetHandler(request), machineWide))
                integrationManager.RemoveApp(integrationManager.AppList[feedUri]);
        }

        /// <summary>
        /// Get installed packages.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="request">An object passed in from the CORE that contains functions that can be used to interact with the CORE and HOST</param>
        public void GetInstalledPackages(string name, Request request)
        {
            request.Debug("Calling '{0}::GetInstalledPackages'", PackageProviderName);

            var services = new ServiceLocator(new OneGetHandler(request));
            bool machineWide = request.OptionKeys.Contains(MachineWide);

            using (var integrationManager = new IntegrationManager(new OneGetHandler(request), machineWide))
            {
                foreach (var appEntry in integrationManager.AppList.Entries)
                {
                    var feed = services.FeedManager.GetFeed(appEntry.InterfaceUri);
                    if (string.IsNullOrEmpty(name) || feed.Name.ContainsIgnoreCase(name))
                        request.YieldFeed(feed);
                }
            }
        }
    }
}
