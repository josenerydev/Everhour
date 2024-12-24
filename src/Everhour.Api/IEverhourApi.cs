using Refit;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Everhour.Api
{
    public interface IEverhourApi
    {
        [Get("/projects/{projectId}/time")]
        Task<List<EverhourResponse>> GetTimeEntriesAsync(
            string projectId, // Adiciona o parâmetro dinâmico
            [AliasAs("from")] string fromDate,
            [AliasAs("to")] string toDate,
            [Header("X-Api-Key")] string apiKey
        );
    }

    public class EverhourResponse
    {
        public TaskDetails Task { get; set; }
        public string Date { get; set; }
        public string Comment { get; set; }
    }

    public class TaskDetails
    {
        public string Name { get; set; }
    }
}
