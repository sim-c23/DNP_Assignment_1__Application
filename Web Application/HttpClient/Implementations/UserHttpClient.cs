using System.Net.Http.Json;
using System.Text.Json;
using HttpClient.ClientInterfaces;
using Shared.DTOs;
using Shared.Models;

namespace HttpClient.Implementations;

public class UserHttpClient : IUserService
{
    private readonly System.Net.Http.HttpClient Client;

    public UserHttpClient(System.Net.Http.HttpClient client)
    {
        this.Client = client;
    }
    
    public async Task<User> Create(UserCreationDto dto)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync("/users", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return user;
    }
}