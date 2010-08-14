﻿using System;
using System.Collections.Generic;
using System.IO;
using Common.Helpers;
using Common.Properties;
using ICSharpCode.SharpZipLib.Zip;

namespace Common.Archive
{
    /// <summary>
    /// Provides methods for extracting a ZIP archive.
    /// </summary>
    public class ZipExtractor : Extractor
    {
        #region Variables
        private ZipFile _zip;
        #endregion

        #region Constructor
        /// <summary>
        /// Prepares to extract a ZIP archive contained in a stream.
        /// </summary>
        /// <param name="archive">The stream containing the archive's data.</param>
        /// <param name="startOffset">The number of bytes at the beginning of the stream which should be ignored.</param>
        /// <param name="target">The path to the directory to extract into.</param>
        /// <exception cref="IOException">Thrown if the archive is damaged.</exception>
        public ZipExtractor(Stream archive, long startOffset, string target) : base(archive, startOffset, target)
        {
            try
            {
                _zip = new ZipFile(Stream) { IsStreamOwner = false };
            }
            catch (ZipException ex)
            {
                throw new IOException(Resources.ArchiveInvalid, ex);
            }
        }
        #endregion

        //--------------------//

        #region Content
        public override IEnumerable<string> ListContent()
        {
            var contentList = new List<string>((int)_zip.Count);
            try
            {
                foreach (ZipEntry entry in _zip)
                    contentList.Add(StringHelper.UnifySlashes(entry.Name));
            }
            catch (ZipException ex)
            {
                throw new IOException(Resources.ArchiveInvalid, ex);
            }

            return contentList;
        }

        public override IEnumerable<string> ListDirectories()
        {
            var directoryList = new List<string>((int)_zip.Count);
            try
            {
                foreach (ZipEntry entry in _zip)
                    if (entry.IsDirectory) directoryList.Add(StringHelper.UnifySlashes(entry.Name));
            }
            catch (ZipException ex)
            {
                throw new IOException(Resources.ArchiveInvalid, ex);
            }

            return directoryList;
        }
        #endregion

        #region Extraction
        protected override void RunExtraction()
        {
            try
            {
                int i = 0;
                foreach (ZipEntry entry in _zip)
                {
                    string entryName = GetSubEntryName(entry.Name);
                    if (string.IsNullOrEmpty(entryName)) continue;

                    if (entry.IsDirectory) CreateDirectory(entryName, entry.DateTime);
                    else if (entry.IsFile)
                    {
                        using (var stream = _zip.GetInputStream(entry))
                            WriteFile(entryName, entry.DateTime, stream, entry.Size, IsXbitSet(entry));

                        // ToDo: Report progess
                    }
                }
            }
            #region Error handling
            catch (ZipException ex)
            {
                lock (StateLock)
                {
                    ErrorMessage = Resources.ArchiveInvalid + "\n" + ex.Message;
                    State = ProgressState.IOError;
                }
                return;
            }
            catch (IOException ex)
            {
                lock (StateLock)
                {
                    ErrorMessage = ex.Message;
                    State = ProgressState.IOError;
                }
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                lock (StateLock)
                {
                    ErrorMessage = ex.Message;
                    State = ProgressState.IOError;
                }
                return;
            }
            #endregion

            State = ProgressState.Complete;
        }

        /// <summary>
        /// Determines whether an <see cref="ZipEntry"/> was packed on a Unix-system with the executable flag set to true.
        /// </summary>
        private static bool IsXbitSet(ZipEntry entry)
        {
            if (entry.HostSystem != (int)HostSystemID.Unix) return false;
            const int userExecuteFlag = 0x0040 << 16;
            return ((entry.ExternalFileAttributes & userExecuteFlag) != 0);
        }
        #endregion
    }
}
