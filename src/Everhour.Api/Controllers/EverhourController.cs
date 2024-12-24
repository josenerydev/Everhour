using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Refit;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everhour.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EverhourController : ControllerBase
{
    private readonly IEverhourApi _everhourApi;
    private readonly string _apiKey;
    private readonly string _projectId;

    public EverhourController(IEverhourApi everhourApi, IConfiguration configuration)
    {
        _everhourApi = everhourApi;
        _apiKey = configuration["Everhour:ApiKey"]; // Lê a chave da configuração
        _projectId = configuration["Everhour:ProjectId"]; // Lê o ProjectId da configuração
    }

    [HttpGet("fetch")]
    public async Task<IActionResult> FetchEverhourData([FromQuery] string fromDate, [FromQuery] string toDate)
    {
        try
        {
            var data = await _everhourApi.GetTimeEntriesAsync(_projectId, fromDate, toDate, _apiKey);

            var groupedData = data
                .GroupBy(item => new { item.Task.Name, item.Date })
                .Select(group => new
                {
                    equipe = group.Key.Name,
                    data = group.Key.Date,
                    tarefas = group.Select(g => g.Comment).ToList()
                })
                .OrderBy(g => g.equipe == "Desenvolvimento de Software" ? 0 : 1)
                .ThenBy(g => g.data)
                .ToList();

            return Ok(groupedData);
        }
        catch (ApiException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Content);
        }
    }
}
