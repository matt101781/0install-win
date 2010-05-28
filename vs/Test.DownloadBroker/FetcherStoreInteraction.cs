﻿using NUnit.Framework;
using ZeroInstall.Store.Implementation;

namespace ZeroInstall.DownloadBroker
{
    [TestFixture]
    public class DefaultFetcherInteraction
    {
        [Test]
        public void ShouldUseDefaultStore()
        {
            Assert.AreEqual(Fetcher.Default.Store, StoreProvider.Default, "Default store must use default store");
        }
    }
}