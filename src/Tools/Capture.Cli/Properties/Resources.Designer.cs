﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZeroInstall.Capture.Cli.Properties {
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ZeroInstall.Capture.Cli.Properties.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Missing arguments. Try {0} --help.
        /// </summary>
        internal static string MissingArguments {
            get {
                return ResourceManager.GetString("MissingArguments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Collect installation files in addition to registry data and use them to create a first implementation. Only applicable to the &quot;collect&quot; operation..
        /// </summary>
        internal static string OptionFiles {
            get {
                return ResourceManager.GetString("OptionFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ignore warnings and perform the operation anyway..
        /// </summary>
        internal static string OptionForce {
            get {
                return ResourceManager.GetString("OptionForce", resourceCulture);
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
        ///   Looks up a localized string similar to Set {DIR} as the directory the application to be captured is installed in.  Only applicable to the &quot;collect&quot; operation. Will try to determine correct directory automatically if not specified..
        /// </summary>
        internal static string OptionInstallationDir {
            get {
                return ResourceManager.GetString("OptionInstallationDir", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Set {PATH} as the relative path to the main EXE of the application to be captured.  Only applicable to the &quot;collect&quot; operation. Will try to determine correct file automatically if not specified..
        /// </summary>
        internal static string OptionMainExe {
            get {
                return ResourceManager.GetString("OptionMainExe", resourceCulture);
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
        ///   Looks up a localized string similar to Display version information..
        /// </summary>
        internal static string OptionVersion {
            get {
                return ResourceManager.GetString("OptionVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unknown operation mode.
        ///Try {0} --help.
        /// </summary>
        internal static string UnknownMode {
            get {
                return ResourceManager.GetString("UnknownMode", resourceCulture);
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
        ///   Looks up a localized string similar to Post-installation snapshot already exists. Rerun with --force to ignore..
        /// </summary>
        internal static string WarnExistingPostInstallSnapshot {
            get {
                return ResourceManager.GetString("WarnExistingPostInstallSnapshot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pre-installation snapshot does not exists yet. Rerun with --force to ignore..
        /// </summary>
        internal static string WarnMissingPreInstallSnapshot {
            get {
                return ResourceManager.GetString("WarnMissingPreInstallSnapshot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Collected feed already exists. Rerun with --force to overwrite..
        /// </summary>
        internal static string WarnOverwriteCollect {
            get {
                return ResourceManager.GetString("WarnOverwriteCollect", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Post-installation snapshot already exists. Rerun with --force to overwrite..
        /// </summary>
        internal static string WarnOverwritePostInstallSnapshot {
            get {
                return ResourceManager.GetString("WarnOverwritePostInstallSnapshot", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Pre-installation snapshot already exists. Rerun with --force to overwrite..
        /// </summary>
        internal static string WarnOverwritePreInstallSnapshot {
            get {
                return ResourceManager.GetString("WarnOverwritePreInstallSnapshot", resourceCulture);
            }
        }
    }
}
