/*
 * Copyright 2010-2015 Bastian Eicher
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
using System.IO;
using System.Linq;
using System.Security;
using JetBrains.Annotations;
using NanoByte.Common;
using NanoByte.Common.Storage;
using NanoByte.Common.Tasks;
using ZeroInstall.Store.Model;
using ZeroInstall.Store.Model.Capabilities;

namespace ZeroInstall.Publish.Capture
{
    /// <summary>
    /// Manages the process of taking two <see cref="Snapshot"/>s and comparing them to generate a <see cref="Feed"/>.
    /// </summary>
    public class CaptureSession
    {
        [NotNull]
        private readonly Snapshot _snapshot;

        /// <summary>
        /// The fully qualified path to the installation directory; leave <see langword="null"/> for auto-detection.
        /// </summary>
        [CanBeNull]
        public string InstallationDir { get; set; }

        /// <summary>
        /// The relative path to the main EXE; leave <see langword="null"/> for auto-detection.
        /// </summary>
        [CanBeNull]
        public string MainExe { get; set; }

        private CaptureSession([NotNull] Snapshot snapshotBefore)
        {
            _snapshot = snapshotBefore;
        }

        /// <summary>
        /// Captures the current system state as a snapshot of the system state before the target application was installed.
        /// </summary>
        /// <exception cref="IOException">There was an error accessing the registry or file system.</exception>
        /// <exception cref="UnauthorizedAccessException">Access to the registry or the file system was not permitted.</exception>
        [NotNull]
        public static CaptureSession Start()
        {
            return new CaptureSession(Snapshot.Take());
        }

        /// <summary>
        /// Collects data from the locations indicated by the differences between <see cref="_snapshot"/> and the current system state.
        /// </summary>
        /// <param name="handler">A callback object used when the the user needs to be informed about IO tasks.</param>
        /// <returns>A <see cref="Feed"/> containing the colelcted data.</returns>
        /// <exception cref="IOException">There was an error accessing the registry or file system.</exception>
        /// <exception cref="UnauthorizedAccessException">Access to the registry or file system was not permitted.</exception>
        [NotNull]
        public SignedFeed Finish([NotNull] ITaskHandler handler)
        {
            var diff = new SnapshotDiff(before: _snapshot, after: Snapshot.Take());

            if (string.IsNullOrEmpty(InstallationDir)) InstallationDir = diff.GetInstallationDir();

            var builder = new FeedBuilder();
            builder.SetImplementationDirectory(InstallationDir, handler);
            if (MainExe != null)
            {
                builder.MainCandidate = builder.Candidates.FirstOrDefault(x =>
                    StringUtils.EqualsIgnoreCase(FileUtils.UnifySlashes(x.RelativePath), MainExe));
            }

            var feed = builder.Build();
            var commandMapper = new CommandMapper(InstallationDir, ((Implementation)feed.Feed.Elements[0]).Commands);

            try
            {
                feed.Feed.CapabilityLists.Add(GetCapabilityList(commandMapper, diff));
            }
                #region Error handling
            catch (SecurityException ex)
            {
                // Wrap exception since only certain exception types are allowed in tasks
                throw new UnauthorizedAccessException(ex.Message, ex);
            }
            #endregion

            return feed;
        }

        [NotNull]
        private static CapabilityList GetCapabilityList(CommandMapper commandMapper, SnapshotDiff diff)
        {
            var capabilities = new CapabilityList {OS = OS.Windows};
            string appName = null, appDescription = null;

            diff.CollectFileTypes(commandMapper, capabilities);
            diff.CollectContextMenus(commandMapper, capabilities);
            diff.CollectAutoPlays(commandMapper, capabilities);
            diff.CollectDefaultPrograms(commandMapper, capabilities, ref appName);

            var appRegistration = diff.GetAppRegistration(commandMapper, capabilities, ref appName, ref appDescription);
            if (appRegistration != null) capabilities.Entries.Add(appRegistration);
            else
            { // Only collect URL protocols if there wasn't already an application registration that covered them
                diff.CollectProtocolAssocs(commandMapper, capabilities);
            }

            return capabilities;
        }

        /// <summary>
        /// 
        /// </summary>
        public void CollectFiles()
        {
            throw new NotImplementedException();
        }

        #region Storage
        /// <summary>
        /// Loads a capture session from a snapshot file.
        /// </summary>
        /// <param name="path">The file to load from.</param>
        /// <exception cref="IOException">A problem occured while reading the file.</exception>
        /// <exception cref="UnauthorizedAccessException">Read access to the file is not permitted.</exception>
        /// <exception cref="InvalidDataException">A problem occurred while deserializing the binary data.</exception>
        [NotNull]
        public static CaptureSession Load([NotNull] string path)
        {
            #region Sanity checks
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            #endregion

            return new CaptureSession(BinaryStorage.LoadBinary<Snapshot>(path));
        }

        /// <summary>
        /// Saves the capture session to a snapshot file.
        /// </summary>
        /// <param name="path">The file to save in.</param>
        /// <exception cref="IOException">A problem occured while writing the file.</exception>
        /// <exception cref="UnauthorizedAccessException">Write access to the file is not permitted.</exception>
        public void Save([NotNull] string path)
        {
            #region Sanity checks
            if (string.IsNullOrEmpty(path)) throw new ArgumentNullException("path");
            #endregion

            _snapshot.SaveBinary(path);
        }
        #endregion
    }
}
