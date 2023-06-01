using System;
using nosso_portifolio_api.Context;

namespace nosso_portifolio_api.Repositories
{

    public interface IProjectRepository
    {

    }
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }


    }
}

