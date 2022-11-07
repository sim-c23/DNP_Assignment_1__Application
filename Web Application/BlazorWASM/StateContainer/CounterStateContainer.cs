namespace BlazorWASM.StateContainer;

public class CounterStateContainer
{
    public Action<int> OnChange { get; set; }

    private int count = 0;

    public void Increment()
    {
        count++;
        OnChange?.Invoke(count);
    }
    
    //todo Det skal måske skrive end i Properties launchSettings.json
    /*
     * {
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:63207",
      "sslPort": 44395
    }
  },
  "profiles": {
    "BlazorLoginApp": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": false,
      "applicationUrl": "https://localhost:7289;http://localhost:5289",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
     */
}