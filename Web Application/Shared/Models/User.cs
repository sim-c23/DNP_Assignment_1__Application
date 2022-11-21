using System.Text.Json.Serialization;

namespace Shared.Models;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
  
    public string Password { get; set; }
   
    public string Email { get; set; }
   
    public string Domain { get; set; }
   
    public string Name { get; set; }
   
    public string Role { get; set; }
   
    public int Age { get; set; }
   
    public int SecurityLevel { get; set; }
    
    /*/*Todo Ved ikke om dette skal være med. Se Troles: Todo App Part 3 - EFC --> (9 Configuring Relationships)#1#
    [JsonIgnore]/*Todo kan finders under Tilføj bruger 13 Næste problem#1#
    public ICollection<Todo> Todos { get; set; }*/

}