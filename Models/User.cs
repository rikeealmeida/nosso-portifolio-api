using System;
using Newtonsoft.Json;

namespace nosso_portifolio_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public string Password { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string GithubUrl { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
        public string Resume { get; set; }
        [JsonIgnore]
        public ICollection<Project> Projects { get; set; }


    }
}

