using System;
using nosso_portifolio_api.DTOs;

namespace nosso_portifolio_api.DTOs
{
    public class ProjectWithUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Resume { get; set; }
        public List<string> Stacks { get; set; }
        public string Website { get; set; }
        public List<string> Images { get; set; }


        public UserWithoutProjectsDto User { get; set; }
    }
}

