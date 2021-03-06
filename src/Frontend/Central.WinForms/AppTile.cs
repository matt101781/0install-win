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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Windows.Forms;
using JetBrains.Annotations;
using NanoByte.Common;
using NanoByte.Common.Tasks;
using ZeroInstall.Central.WinForms.Properties;
using ZeroInstall.Commands.FrontendCommands;
using ZeroInstall.DesktopIntegration;
using ZeroInstall.Store;
using ZeroInstall.Store.Icons;
using ZeroInstall.Store.Model;
using Icon = ZeroInstall.Store.Model.Icon;
using SharedResources = ZeroInstall.Central.Properties.Resources;

namespace ZeroInstall.Central.WinForms
{
    /// <summary>
    /// Represents an application as a tile with buttons for launching, managing, etc..
    /// </summary>
    public sealed partial class AppTile : UserControl, IAppTile
    {
        #region Variables
        // Static resource preload
        private static readonly string _runButtonText = SharedResources.RunButtonText;
        private static readonly Bitmap _addButton = Resources.AddButton, _removeButton = Resources.RemoveButton, _setupButton = Resources.SetupButton, _modifyButton = Resources.ModifyButton;
        private static readonly string _addButtonTooltip = SharedResources.AddButtonTooltip, _removeButtonTooltip = SharedResources.RemoveButtonTooltip, _setupButtonTooltip = SharedResources.SetupButtonTooltip, _modifyButtonTooltip = SharedResources.ModifyButtonTooltip;
        private static readonly string _selectCommandButton = SharedResources.SelectCommandButton, _selectVersionButton = SharedResources.SelectVersionButton, _updateButtonText = SharedResources.UpdateButtonText;

        /// <summary>Apply operations machine-wide instead of just for the current user.</summary>
        private readonly bool _machineWide;

        private static readonly ITaskHandler _handler = new SilentTaskHandler();

        /// <summary>The icon cache used to retrieve icons specified in <see cref="Feed"/>; can be <see langword="null"/>.</summary>
        [CanBeNull]
        private readonly IIconCache _iconCache;
        #endregion

        #region Properties
        private Feed _feed;

        /// <inheritdoc/>
        public Feed Feed
        {
            get { return _feed; }
            set
            {
                #region Sanity checks
                if (InvokeRequired) throw new InvalidOperationException("Method called from a non UI thread.");
                #endregion

                _feed = value;
                if (value == null)
                {
                    buttonSelectCommand.Visible = false;
                    return;
                }
                else buttonSelectCommand.Visible = true;

                // Get application summary from feed
                labelSummary.Text = value.Summaries.GetBestLanguage(CultureInfo.CurrentUICulture);

                if (_iconCache != null)
                {
                    // Load application icon in background
                    var icon = value.GetIcon(Icon.MimeTypePng);
                    if (icon != null) iconDownloadWorker.RunWorkerAsync(icon.Href);
                    else pictureBoxIcon.Image = Resources.App; // Fall back to default icon
                }
                else pictureBoxIcon.Image = Resources.App; // Fall back to default icon
            }
        }

        /// <inheritdoc/>
        public FeedUri InterfaceUri { get; private set; }

        /// <inheritdoc/>
        public string AppName { get { return labelName.Text; } }

        private AppStatus _status;

        /// <inheritdoc/>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public AppStatus Status
        {
            get { return _status; }
            set
            {
                #region Sanity checks
                if (value < AppStatus.Candidate || value > AppStatus.Integrated) throw new InvalidEnumArgumentException("value", (int)value, typeof(AppStatus));
                if (InvokeRequired) throw new InvalidOperationException("Property set from a non UI thread.");
                #endregion

                _status = value;

                UpdateButtons();
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new application tile.
        /// </summary>
        /// <param name="interfaceUri">The interface URI of the application this tile represents.</param>
        /// <param name="appName">The name of the application this tile represents.</param>
        /// <param name="status">Describes whether the application is listed in the <see cref="AppList"/> and if so whether it is integrated.</param>
        /// <param name="iconCache">The icon cache used to retrieve icons specified in <see cref="Feed"/>; can be <see langword="null"/>.</param>
        /// <param name="machineWide">Apply operations machine-wide instead of just for the current user.</param>
        public AppTile([NotNull] FeedUri interfaceUri, [NotNull] string appName, AppStatus status, [CanBeNull] IIconCache iconCache = null, bool machineWide = false)
        {
            #region Sanity checks
            if (interfaceUri == null) throw new ArgumentNullException("interfaceUri");
            if (appName == null) throw new ArgumentNullException("appName");
            #endregion

            _machineWide = machineWide;

            InitializeComponent();
            buttonRun.Text = _runButtonText;
            buttonAdd.Image = _addButton;
            buttonRemove.Image = _removeButton;
            buttonIntegrate.Image = _setupButton;
            toolTip.SetToolTip(buttonAdd, _addButtonTooltip);
            toolTip.SetToolTip(buttonRemove, _removeButtonTooltip);
            buttonSelectCommand.Text = _selectCommandButton;
            buttonSelectVersion.Text = _selectVersionButton;
            buttonUpdate.Text = _updateButtonText;

            InterfaceUri = interfaceUri;
            labelName.Text = appName;
            labelSummary.Text = "";
            Status = status;

            _iconCache = iconCache;

            CreateHandle();
        }
        #endregion

        //--------------------//

        #region Feed processing
        private void iconDownloadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Download and load icon in background
            try
            {
                Debug.Assert(_iconCache != null);
                string path = _iconCache.GetIcon((Uri)e.Argument, _handler);
                using (var stream = File.OpenRead(path))
                    e.Result = Image.FromStream(stream);
            }
                #region Error handling
            catch (OperationCanceledException)
            {}
            catch (IOException ex)
            {
                Log.Warn("Unable to store icon");
                Log.Warn(ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                Log.Warn("Unable to store icon");
                Log.Warn(ex);
            }
            catch (WebException ex)
            {
                Log.Warn("Unable to store icon");
                Log.Warn(ex);
            }
            #endregion
        }

        private void iconDownloadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            { // Display icon in UI thread
                var image = e.Result as Image;
                if (image != null) pictureBoxIcon.Image = image;
            }
            else
            {
                Log.Error("Unable to load icon");
                Log.Error(e.Error);
            }
        }
        #endregion

        #region Buttons
        /// <summary>
        /// Updates the visibility and icons of buttons based on the <see cref="Status"/>.
        /// </summary>
        private void UpdateButtons()
        {
            buttonAdd.Enabled = buttonAdd.Visible = (Status == AppStatus.Candidate);
            buttonRemove.Enabled = buttonRemove.Visible = (Status >= AppStatus.Added);

            toolTip.SetToolTip(buttonIntegrate, (Status == AppStatus.Integrated) ? _modifyButtonTooltip : _setupButtonTooltip);
            buttonIntegrate.Image = (Status == AppStatus.Integrated) ? _modifyButton : _setupButton;
            buttonIntegrate.Enabled = (Status >= AppStatus.Added);
        }

        private void linkLabelDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (InterfaceUri.IsFake) return;
            Program.OpenInBrowser(this, InterfaceUri.OriginalString);
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;
            if (Feed != null && Feed.NeedsTerminal) new SelectCommandDialog(Feed).Show(this);
            else Program.RunCommand(Run.Name, "--no-wait", InterfaceUri.ToStringRfc());
        }

        private void buttonSelectVersion_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;
            Program.RunCommand(Run.Name, "--no-wait", "--customize", InterfaceUri.ToStringRfc());
        }

        private void buttonSelectCommand_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;
            new SelectCommandDialog(Feed).Show(this);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;
            Program.RunCommand(Commands.FrontendCommands.Update.Name, InterfaceUri.ToStringRfc());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;

            // Disable button while operation is running
            buttonAdd.Enabled = false;

            Program.RunCommand(UpdateButtons, _machineWide, AddApp.Name, InterfaceUri.ToStringRfc());
        }

        private void buttonIntegrate_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;

            // Disable buttons while operation is running
            buttonRemove.Enabled = buttonIntegrate.Enabled = false;

            Program.RunCommand(UpdateButtons, _machineWide, IntegrateApp.Name, InterfaceUri.ToStringRfc());
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (InterfaceUri.IsFake) return;

            if (!Msg.YesNo(this, string.Format(SharedResources.AppRemoveConfirm, AppName), MsgSeverity.Warn)) return;

            // Disable buttons while operation is running
            buttonRemove.Enabled = buttonIntegrate.Enabled = false;

            Program.RunCommand(UpdateButtons, _machineWide, RemoveApp.Name, InterfaceUri.ToStringRfc());
        }
        #endregion

        #region Drag and drop handling
        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            // Copy the interface URI and make sure it goes into another window
            MainForm.DisableDragAndDrop = true;
            DoDragDrop(InterfaceUri, DragDropEffects.Copy);
            MainForm.DisableDragAndDrop = true;
        }
        #endregion
    }
}
