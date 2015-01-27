using NanoByte.Common.Tasks;
using OneGet.Sdk;

namespace ZeroInstall.OneGet
{
    public class OneGetProgress : IProgress<TaskSnapshot>
    {
        private readonly Request _request;
        private readonly string _name;
        private readonly int _activityId;

        public OneGetProgress(Request request, string name)
        {
            _request = request;
            _name = name;
            _activityId = _request.StartProgress(0, name);
        }

        public void Report(TaskSnapshot snapshot)
        {
            switch (snapshot.State)
            {
                case TaskState.Canceled:
                case TaskState.IOError:
                case TaskState.WebError:
                    _request.CompleteProgress(_activityId, false);
                    break;

                case TaskState.Header:
                case TaskState.Data:
                    _request.Progress(_activityId, (int)(snapshot.Value * 100), _name);
                    break;

                case TaskState.Complete:
                    _request.CompleteProgress(_activityId, true);
                    break;
            }
        }
    }
}
