using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using Inshapardaz.Desktop.Domain.Jobs;
using Inshapardaz.Desktop.Domain.Queries;
using Paramore.Darker;

namespace Inshapardaz.Desktop.Domain.QueryHandlers
{
    public class GetDictionaryDownloadJobQueryHandler : QueryHandlerAsync<GetDictionaryDownloadJobQuery, bool>
    {
        public override Task<bool> ExecuteAsync(GetDictionaryDownloadJobQuery query, CancellationToken cancellationToken = default(CancellationToken))
        {
            var monitoring = JobStorage.Current.GetMonitoringApi();
            var queuedJobList = monitoring.EnqueuedJobs("default", 0, 100);
            var runninJobList = monitoring.ProcessingJobs(0, 100);
            var scheduedJobList = monitoring.ScheduledJobs(0, 100);

            var queuedJob = queuedJobList.Exists(j => j.Value.Job.Type == typeof(DownloadDictionaryJob) && j.Value.Job.Args.Count > 0 && ((int)j.Value.Job.Args[0]) == query.DictionaryId);
            var runningJob = queuedJobList.Exists(j => j.Value.Job.Type == typeof(DownloadDictionaryJob) && j.Value.Job.Args.Count > 0 && ((int)j.Value.Job.Args[0]) == query.DictionaryId);
            var scheduedJob = scheduedJobList.Exists(j => j.Value.Job.Type == typeof(DownloadDictionaryJob) && j.Value.Job.Args.Count > 0 && ((int)j.Value.Job.Args[0]) == query.DictionaryId);

            return Task.FromResult(queuedJob | runningJob | scheduedJob);
        }
    }
}
