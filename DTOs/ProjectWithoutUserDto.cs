using System;
using nosso_portifolio_api.Models;

namespace nosso_portifolio_api.DTOs
{
    public class ProjectWithoutUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Resume { get; set; }
        public List<string> Stacks { get; set; }
        public string Website { get; set; }
        public List<string> Images { get; set; }
    }
}

