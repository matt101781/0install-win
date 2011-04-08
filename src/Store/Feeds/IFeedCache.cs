﻿using System;
using System.Collections.Generic;
using System.IO;
using ZeroInstall.Model;

namespace ZeroInstall.Store.Feeds
{
    /// <summary>
    /// Provides access to a cache of <see cref="Feed"/>s that were downloaded via HTTP(S).
    /// </summary>
    /// <remarks>
    ///   <para>Local feed files may be simply passed through the cache.</para>
    ///   <para>Once a feed has been added to this cache it is considered trusted (signature is not checked again).</para>
    /// </remarks>
    public interface IFeedCache
    {
        /// <summary>
        /// Determines whether this cache contains a local copy of a feed identified by a specific URL.
        /// </summary>
        /// <param name="feedID">The ID used to identify the feed. May be an HTTP(S) URL or an absolute local path.</param>
        /// <returns>
        ///   <see langword="true"/> if the specified feed is available in this cache;
        ///   <see langword="false"/> if the specified feed is not available in this cache.
        /// </returns>
        /// <exception cref="InvalidInterfaceIDException">Thrown if <paramref name="feedID"/> is an invalid interface ID.</exception>
        bool Contains(string feedID);

        /// <summary>
        /// Returns a list of all <see cref="Feed"/>s stored in this cache.
        /// </summary>
        /// <returns>
        /// A list of feed URIs (e.g. "http://somedomain.net/interface.xml") in C-sorted order (ordinal comparison, increasing).
        /// Usually these can also be considered interface IDs.
        /// </returns>
        /// <exception cref="IOException">Thrown if a problem occured while reading from the cache.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if read access to the cache is not permitted.</exception>
        IEnumerable<string> ListAll();

        /// <summary>
        /// Gets a specific <see cref="Feed"/> from this cache.
        /// </summary>
        /// <param name="feedID">The ID used to identify the feed. May be an HTTP(S) URL or an absolute local path.</param>
        /// <returns>The parsed <see cref="Feed"/> object.</returns>
        /// <exception cref="InvalidInterfaceIDException">Thrown if <paramref name="feedID"/> is an invalid interface ID.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the requested <paramref name="feedID"/> was not found in the cache.</exception>
        /// <exception cref="IOException">Thrown if a problem occured while reading the feed file.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if read access to the cache is not permitted.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the feed file could not be parsed.</exception>
        Feed GetFeed(string feedID);

        /// <summary>
        /// Adds a new <see cref="Feed"/> file to the cache. Only do this after the feed source has been verified and trusted!
        /// </summary>
        /// <param name="feedID">The ID used to identify the feed. May be an HTTP(S) URL or an absolute local path.</param>
        /// <param name="path">The local path of the file to be added.</param>
        /// <exception cref="InvalidInterfaceIDException">Thrown if <paramref name="feedID"/> is an invalid interface ID.</exception>
        /// <exception cref="ReplayAttackException">Thrown if the file to be added is older than a version already located in the cache.</exception>
        /// <exception cref="IOException">Thrown if a problem occured while reading or writing the feed file.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if write access to the cache is not permitted.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the feed file could not be parsed.</exception>
        void Add(string feedID, string path);

        /// <summary>
        /// Removes a specific <see cref="Feed"/> from this cache.
        /// </summary>
        /// <param name="feedID">The ID used to identify the feed. May be an HTTP(S) URL or an absolute local path.</param>
        /// <exception cref="InvalidInterfaceIDException">Thrown if <paramref name="feedID"/> is an invalid interface ID.</exception>
        /// <exception cref="KeyNotFoundException">Thrown if the requested <paramref name="feedID"/> was not found in the cache.</exception>
        /// <exception cref="IOException">Thrown if the feed could not be deleted.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if write access to the cache is not permitted.</exception>
        void Remove(string feedID);
    }
}
