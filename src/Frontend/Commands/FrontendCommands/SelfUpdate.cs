﻿/*
 * Copyright 2010-2014 Bastian Eicher
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using NanoByte.Common;
using NanoByte.Common.Info;
using NanoByte.Common.Native;
using NanoByte.Common.Storage;
using NanoByte.Common.Tasks;
using NDesk.Options;
using ZeroInstall.Commands.Properties;
using ZeroInstall.Store.Implementations;
using ZeroInstall.Store.Model;

namespace ZeroInstall.Commands.FrontendCommands
{
    /// <summary>
    /// Updates Zero Install itself to the most recent version.
    /// </summary>
    [CLSCompliant(false)]
    public sealed class SelfUpdate : Run
    {
        #region Metadata
        /// <summary>The name of this command as used in command-line arguments in lower-case.</summary>
        public new const string Name = "self-update";

        /// <inheritdoc/>
        protected override string Description { get { return Resources.DescriptionSelfUpdate; } }

        /// <inheritdoc/>
        protected override string Usage { get { return "[OPTIONS]"; } }
        #endregion

        #region State
        /// <summary>Perform the update even if the currently installed version is the same or newer.</summary>
        private bool _force;

        /// <summary>Restart the <see cref="Central"/> GUI after the update.</summary>
        private bool _restartCentral;

        /// <inheritdoc/>
        public SelfUpdate([NotNull] ICommandHandler handler) : base(handler)
        {
            NoWait = true;
            FeedManager.Refresh = true;
            Config.AllowApiHooking = false;
            Requirements.Command = "update";

            //Options.Remove("no-wait");
            //Options.Remove("refresh");

            Options.Add("force", () => Resources.OptionForceSelfUpdate, _ => _force = true);
            Options.Add("restart-central", () => Resources.OptionRestartCentral, _ => _restartCentral = true);
        }
        #endregion

        /// <inheritdoc/>
        public override void Parse(IEnumerable<string> args)
        {
            if (Options.Parse(args).Count != 0) throw new OptionException(Resources.TooManyArguments + "\n" + AdditionalArgs.JoinEscapeArguments(), "");

            Requirements.InterfaceUri = Config.SelfUpdateUri;

            // Pass in the installation directory to the updater as an argument
            AdditionalArgs.Add(Locations.InstallBase);

            if (_restartCentral) AdditionalArgs.Add("--restart-central");
        }

        /// <inheritdoc/>
        public override int Execute()
        {
            if (StoreUtils.PathInAStore(Locations.InstallBase)) throw new NotSupportedException(Resources.NoSelfUpdateStore);

            Solve();

            if (UpdateFound())
            {
                DownloadUncachedImplementations();

                Handler.CancellationToken.ThrowIfCancellationRequested();
                var process = LaunchImplementation();
                if (process == null) return 0;
                if (NoWait) return (WindowsUtils.IsWindows ? process.Id : 0);
                else
                {
                    process.WaitForExit();
                    return process.ExitCode;
                }
            }
            else
            {
                Handler.OutputLow(Resources.ChangesFound, Resources.NoUpdatesFound);
                return 0;
            }
        }

        private bool UpdateFound()
        {
            var currentVersion = new ImplementationVersion(AppInfo.Current.Version);
            var newVersion = Selections.Implementations[0].Version;
            bool updatesFound = newVersion > currentVersion || _force;
            return updatesFound;
        }
    }
}
