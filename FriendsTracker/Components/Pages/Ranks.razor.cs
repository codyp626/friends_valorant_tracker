using MediatR;
using Microsoft.AspNetCore.Components;
using FriendsTracker.Components.Infrastructure;

namespace FriendsTracker.Components.Pages;

public partial class Ranks : IDisposable
{
    [Inject] private IMediator Mediator { get; set; } = null!;

    private readonly CancellationTokenSource _cts = new();
    private readonly RankRequest _request = new();
    private RankResponse _response = new();
    private bool _isLoading;

    protected override async Task OnInitializedAsync()
    {
        _isLoading = true;
        try
        {
            _response = await Mediator.Send(_request, _cts.Token);
        }
        catch (Exception ex)
        {
            // Handle any errors here, e.g., logging or displaying an error message
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }
        finally
        {
            _isLoading = false;
        }
    }

    public void Dispose()
    {
        _cts.Cancel();
        _cts.Dispose();
    }
}

public class RankRequest : IRequest<RankResponse>
{
}

public class RankRequestHandler(HttpClient httpClient) : IRequestHandler<RankRequest, RankResponse>
{
    public async Task<RankResponse> Handle(RankRequest request, CancellationToken cancellationToken = default)
    {
        var players = new List<string>() {"Jsav16/9925", "cadennedac/na1", "augdog922/2884", "mingemuncher14/misa", "BootyConsumer/376", "Brewt/0000", "Stroup22/na1", "WildKevDog/house"};
        var ranks = new List<Rank>();

        foreach (var player in players)
        {
            var json_string = await httpClient.GetStringAsync($"https://api.henrikdev.xyz/valorant/v2/mmr/na/{player}");
            var rank = GetRankResponse.FromJson(json_string)!.Data;
            ranks.Add(rank);
        }
        ranks = ranks.OrderByDescending(r => r.CurrentData.Elo).ToList();

        return new RankResponse { Ranks = ranks };
    }
}

public class RankResponse
{
    public IEnumerable<Rank> Ranks { get; set; } = [];

}

