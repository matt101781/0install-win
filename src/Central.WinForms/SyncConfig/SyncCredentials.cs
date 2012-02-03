﻿/*
 * Copyright 2010-2012 Bastian Eicher
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

namespace ZeroInstall.Central.WinForms.SyncConfig
{
    /// <summary>
    /// Stores login credentials for a Sync server.
    /// </summary>
    internal struct SyncCredentials
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public SyncCredentials(string username, string password) : this()
        {
            Username = username;
            Password = password;
        }
    }
}