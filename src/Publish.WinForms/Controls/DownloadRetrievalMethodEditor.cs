﻿/*
 * Copyright 2010-2013 Bastian Eicher
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

using ZeroInstall.Model;
using ZeroInstall.Publish.WinForms.Properties;

namespace ZeroInstall.Publish.WinForms.Controls
{
    /// <summary>
    /// A common base for <see cref="DownloadRetrievalMethod"/> editors.
    /// </summary>
    /// <typeparam name="T">The type of <see cref="DownloadRetrievalMethod"/> to edit.</typeparam>
    public abstract class DownloadRetrievalMethodEditor<T> : RetrievalMethodEditor<T>
        where T : DownloadRetrievalMethod
    {
        /// <summary>
        /// Displays hints explaining why calling "Update" may be required.
        /// </summary>
        protected override void UpdateHint()
        {
            if (Target.Size == 0) ShowUpdateHint(Resources.SizeMissing);
            else base.UpdateHint();
        }
    }
}
