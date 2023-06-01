using System;
using Newtonsoft.Json;

namespace nosso_portifolio_api.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Resume { get; set; }
        public List<string> Stacks { get; set; }
        public string Website { get; set; }
        public List<string> Images { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}