using System;
using System.Collections.Generic;
using NanoByte.Common.Tasks;
using OneGet.Sdk;

namespace ZeroInstall.OneGet
{
    public class OneGetHandler : ITaskHandler
    {
        private readonly Request _request;

        /// <summary>
        /// Used to signal the <see cref="CancellationToken"/>.
        /// </summary>
        protected readonly CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        public OneGetHandler(Request request)
        {
            _request = request;
        }

        /// <inheritdoc/>
        public CancellationToken CancellationToken { get { return CancellationTokenSource.Token; } }

        /// <inheritdoc/>
        public void RunTask(ITask task)
        {
            #region Sanity checks
            if (task == null) throw new ArgumentNullException("task");
            #endregion

            task.Run(CancellationToken, new OneGetProgress(_request, task.Name));
        }

        /// <inheritdoc/>
        public int Verbosity { get; set; }

        /// <inheritdoc/>
        public virtual bool Batch { get; set; }

        /// <inheritdoc/>
        public virtual bool AskQuestion(string question, string batchInformation = null)
        {
            return _request.AskPermission(question);
        }

        /// <inheritdoc/>
        public virtual void Output(string title, string message)
        {
            _request.Warning(message);
        }

        /// <inheritdoc/>
        public virtual void Output<T>(string title, IEnumerable<T> data)
        {
            foreach (var entry in data)
                _request.Warning(entry.ToString());
        }

        #region Dispose
        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) CancellationTokenSource.Dispose();
        }
        #endregion
    }
}
