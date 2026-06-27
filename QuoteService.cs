using System.Net.Http;
using System.Net.Http.Json;

public class QuoteService
{
    private readonly HttpClient _http;

    public QuoteService(HttpClient http)
    {
        _http = http;
    }

    public async Task<Quote?> GetQuoteAsync()
    {
        var result = await _http.GetFromJsonAsync<List<Quote>>(
            "https://zenquotes.io/api/random");

        return result?.FirstOrDefault();
    }
}

public class Quote
{
    public string q { get; set; } = "";
    public string a { get; set; } = "";
}
