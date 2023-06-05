using System;
namespace nosso_portifolio_api.DTOs
{
    public class UpdateProjectDto
    {
#nullable enable
        public string? Name { get; set; }
        public string? Resume { get; set; }
        public List<string>? Stacks { get; set; }
        public string? Website { get; set; }
        public List<string>? Images { get; set; }

        public int? UserId { get; set; }
#nullable disable 
    }
}

