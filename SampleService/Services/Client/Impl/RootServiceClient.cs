using RootServiceNamespace;

namespace SampleService.Services.Client.Impl
{
    public class RootServiceClient : IRootServiceClient
    {
        private readonly ILogger<RootServiceClient> _logger;
        private readonly RootServiceNamespace.RootServiceClient _rootServiceClient;
        public RootServiceClient(HttpClient httpClient, ILogger<RootServiceClient> logger)
        {
            _logger = logger;
            _rootServiceClient = new RootServiceNamespace.RootServiceClient("http://localhost:5298", httpClient);
        }
        RootServiceNamespace.RootServiceClient IRootServiceClient.RootServiceClient => _rootServiceClient;
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
           return await _rootServiceClient.GetWeatherForecastAsync();
        }
    }
}
