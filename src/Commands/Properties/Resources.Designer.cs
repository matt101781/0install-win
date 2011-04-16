﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroInstall.Commands.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ZeroInstall.Commands.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Downloading application.
        /// </summary>
        internal static string ActionDownload {
            get {
                return ResourceManager.GetString("ActionDownload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Preparing to launch application.
        /// </summary>
        internal static string ActionRun {
            get {
                return ResourceManager.GetString("ActionRun", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Selecting implementations.
        /// </summary>
        internal static string ActionSelection {
            get {
                return ResourceManager.GetString("ActionSelection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking for updates.
        /// </summary>
        internal static string ActionUpdate {
            get {
                return ResourceManager.GetString("ActionUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All required components have been downloaded..
        /// </summary>
        internal static string AllComponentsDownloaded {
            get {
                return ResourceManager.GetString("AllComponentsDownloaded", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Changes found:.
        /// </summary>
        internal static string ChangesFound {
            get {
                return ResourceManager.GetString("ChangesFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Command-line arguments:.
        /// </summary>
        internal static string CommandLineArguments {
            get {
                return ResourceManager.GetString("CommandLineArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Register an additional source of implementations (versions) of a program..
        /// </summary>
        internal static string DescriptionAddFeed {
            get {
                return ResourceManager.GetString("DescriptionAddFeed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to View or change configuration settings. With no arguments, &apos;0install config&apos; displays all configuration settings. With one argument, it displays the current value of the named setting. With two arguments, it sets the setting to the given value..
        /// </summary>
        internal static string DescriptionConfig {
            get {
                return ResourceManager.GetString("DescriptionConfig", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This behaves similarly to &apos;0install select&apos;, except that it also downloads the selected versions if they are not already cached. Unlike &apos;select&apos;, it does not print the selected versions by default. Returns an exit status of zero if it selected a suitable set of versions and they are now all downloaded and in the cache; returns a status of 1 otherwise..
        /// </summary>
        internal static string DescriptionDownload {
            get {
                return ResourceManager.GetString("DescriptionDownload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Import a feed from a local file, as if it had been downloaded from the network. This is useful when testing a feed file, to avoid uploading it to a remote server in order to download it again. The file must have a trusted digital signature, as when fetching from the network..
        /// </summary>
        internal static string DescriptionImport {
            get {
                return ResourceManager.GetString("DescriptionImport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List all known interface (program) URIs. If a search term is given, only URIs containing that string are shown (case insensitive)..
        /// </summary>
        internal static string DescriptionList {
            get {
                return ResourceManager.GetString("DescriptionList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to List all extra feeds added to URI using &apos;0install add-feed&apos;..
        /// </summary>
        internal static string DescriptionListFeeds {
            get {
                return ResourceManager.GetString("DescriptionListFeeds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Un-register a feed, reversing the effect of &apos;add-feed&apos;. .
        /// </summary>
        internal static string DescriptionRemoveFeed {
            get {
                return ResourceManager.GetString("DescriptionRemoveFeed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This behaves similarly to &apos;0install download&apos;, except that it also runs the program after ensuring it is in the cache. Returns an exit status of 1 if the download step failed. Otherwise, the exit status will be the exit status of the program being run..
        /// </summary>
        internal static string DescriptionRun {
            get {
                return ResourceManager.GetString("DescriptionRun", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select a version of the program identified by URI, and compatible versions of all of its dependencies. Returns an exit status of zero if it selected a set of versions, and a status of 1 if it could not find a consistent set..
        /// </summary>
        internal static string DescriptionSelect {
            get {
                return ResourceManager.GetString("DescriptionSelect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Check for updates to the program and download them if found. This is similar to &apos;0install download --refresh&apos;, except that it prints information about whether any changes were found..
        /// </summary>
        internal static string DescriptionUpdate {
            get {
                return ResourceManager.GetString("DescriptionUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Download complete.
        /// </summary>
        internal static string DownloadComplete {
            get {
                return ResourceManager.GetString("DownloadComplete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The feed was already registered for all appropriate interfaces..
        /// </summary>
        internal static string FeedAlreadyRegistered {
            get {
                return ResourceManager.GetString("FeedAlreadyRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Feed management.
        /// </summary>
        internal static string FeedManagement {
            get {
                return ResourceManager.GetString("FeedManagement", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The feed was not registered for any interfaces..
        /// </summary>
        internal static string FeedNotRegistered {
            get {
                return ResourceManager.GetString("FeedNotRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The feed was successfully registered for the following interfaces:
        /// {0}.
        /// </summary>
        internal static string FeedRegistered {
            get {
                return ResourceManager.GetString("FeedRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Feeds registered for &apos;{0}&apos;:.
        /// </summary>
        internal static string FeedsRegistered {
            get {
                return ResourceManager.GetString("FeedsRegistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The feed was successfully unregistered for the following interfaces:
        /// {0}.
        /// </summary>
        internal static string FeedUnregistered {
            get {
                return ResourceManager.GetString("FeedUnregistered", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Found feeds:.
        /// </summary>
        internal static string FoundFeeds {
            get {
                return ResourceManager.GetString("FoundFeeds", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This program comes with ABSOLUTELY NO WARRANTY, to the extent permitted by law.
        ///You may redistribute copies of this program under the terms of the GNU Lesser General Public License..
        /// </summary>
        internal static string LicenseInfo {
            get {
                return ResourceManager.GetString("LicenseInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Missing arguments..
        /// </summary>
        internal static string MissingArguments {
            get {
                return ResourceManager.GetString("MissingArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No interface ID (feed URI or file path) was specified..
        /// </summary>
        internal static string NoInterfaceSpecified {
            get {
                return ResourceManager.GetString("NoInterfaceSpecified", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No longer used: .
        /// </summary>
        internal static string NoLongerUsed {
            get {
                return ResourceManager.GetString("NoLongerUsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can only update with Feed IDs, not with selections documents..
        /// </summary>
        internal static string NoSelectionsDocumentUpdate {
            get {
                return ResourceManager.GetString("NoSelectionsDocumentUpdate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parse hasn&apos;t been called yet..
        /// </summary>
        internal static string NotParsed {
            get {
                return ResourceManager.GetString("NotParsed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No updates found.
        /// </summary>
        internal static string NoUpdatesFound {
            get {
                return ResourceManager.GetString("NoUpdatesFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run in batch mode: don&apos;t display progress reports to the user and silently answer all questions with &quot;No&quot;. Use a tray icon when in GUI mode..
        /// </summary>
        internal static string OptionBatch {
            get {
                return ResourceManager.GetString("OptionBatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chosen implementation&apos;s version number must be earlier than {VERSION}. i.e., force the use of an old version the program..
        /// </summary>
        internal static string OptionBefore {
            get {
                return ResourceManager.GetString("OptionBefore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instead of executing the default command, use {COMMAND} instead. Possible command names are defined in the program&apos;s interface..
        /// </summary>
        internal static string OptionCommand {
            get {
                return ResourceManager.GetString("OptionCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Forces the solver to target the CPU {CPU}.
        ///Supported values: i386, i486, i586, i686, x86_64, ppc, ppc64.
        /// </summary>
        internal static string OptionCpu {
            get {
                return ResourceManager.GetString("OptionCpu", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show the graphical policy editor. This allows you to select which version of a program or library to use..
        /// </summary>
        internal static string OptionGui {
            get {
                return ResourceManager.GetString("OptionGui", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show the built-in help text..
        /// </summary>
        internal static string OptionHelp {
            get {
                return ResourceManager.GetString("OptionHelp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run the specified executable {MAIN} instead of the default. If it starts with &apos;/&apos; or &apos;\&apos; then the path is relative to the implementation&apos;s top-level directory, whereas otherwise it is relative to the directory containing the default main program..
        /// </summary>
        internal static string OptionMain {
            get {
                return ResourceManager.GetString("OptionMain", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Chosen implementation&apos;s version number must not be earlier than {VERSION}. E.g., if you want to run version 2.0 or later, use --not-before=2.0..
        /// </summary>
        internal static string OptionNotBefore {
            get {
                return ResourceManager.GetString("OptionNotBefore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Immediately returns once the chosen program has been launched instead of waiting for it to finish executing..
        /// </summary>
        internal static string OptionNoWait {
            get {
                return ResourceManager.GetString("OptionNoWait", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Run in off-line mode, overriding the default setting. In off-line mode, no interfaces are refreshed even if they are out-of-date, and newer versions of programs won&apos;t be downloaded even if the injector already knows about them (e.g. from a previous refresh)..
        /// </summary>
        internal static string OptionOffline {
            get {
                return ResourceManager.GetString("OptionOffline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Forces the solver to target the operating system {OS}.
        ///Supported values: Linux, Solaris, MacOSX, Windows.
        /// </summary>
        internal static string OptionOS {
            get {
                return ResourceManager.GetString("OptionOS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Fetch a fresh copy of all used interfaces..
        /// </summary>
        internal static string OptionRefresh {
            get {
                return ResourceManager.GetString("OptionRefresh", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Options:.
        /// </summary>
        internal static string Options {
            get {
                return ResourceManager.GetString("Options", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show were the selected components are stored on the disk..
        /// </summary>
        internal static string OptionShow {
            get {
                return ResourceManager.GetString("OptionShow", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select source code rather than a binary. This is used internally by &apos;0compile&apos;..
        /// </summary>
        internal static string OptionSource {
            get {
                return ResourceManager.GetString("OptionSource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to More verbose output. Use twice for even more verbose output..
        /// </summary>
        internal static string OptionVerbose {
            get {
                return ResourceManager.GetString("OptionVerbose", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Display version information..
        /// </summary>
        internal static string OptionVersion {
            get {
                return ResourceManager.GetString("OptionVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Add {DIR} to the list of implementation caches to search.
        ///However, new downloads will not be written to this directory..
        /// </summary>
        internal static string OptionWithStore {
            get {
                return ResourceManager.GetString("OptionWithStore", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Instead of executing the chosen program directly, run {COMMAND} PROGRAM ARGS. This is useful for running debuggers and tracing tools on the program (rather than on Zero Install!). Note that the wrapper is executed in the environment selected by the program; hence, this mechanism cannot be used for sandboxing..
        /// </summary>
        internal static string OptionWrapper {
            get {
                return ResourceManager.GetString("OptionWrapper", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Write selected versions to console as machine-readable XML..
        /// </summary>
        internal static string OptionXml {
            get {
                return ResourceManager.GetString("OptionXml", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Selected implementations:.
        /// </summary>
        internal static string SelectedImplementations {
            get {
                return ResourceManager.GetString("SelectedImplementations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Too many arguments or unknown options..
        /// </summary>
        internal static string TooManyArguments {
            get {
                return ResourceManager.GetString("TooManyArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown command &apos;{0}&apos;..
        /// </summary>
        internal static string UnknownCommand {
            get {
                return ResourceManager.GetString("UnknownCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown option..
        /// </summary>
        internal static string UnknownOption {
            get {
                return ResourceManager.GetString("UnknownOption", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unable to check for updates.
        /// </summary>
        internal static string UpdateProblem {
            get {
                return ResourceManager.GetString("UpdateProblem", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usage:.
        /// </summary>
        internal static string Usage {
            get {
                return ResourceManager.GetString("Usage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Version information:.
        /// </summary>
        internal static string VersionInformation {
            get {
                return ResourceManager.GetString("VersionInformation", resourceCulture);
            }
        }
    }
}
