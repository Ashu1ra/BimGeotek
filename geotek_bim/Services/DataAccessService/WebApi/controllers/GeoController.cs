using DataAccessService.Domain.Entities.Geo;
using Microsoft.AspNetCore.Mvc;
using DataAccessService.Domain.Interfaces.Repositories;

[Route("api/project")]
public class ProjectController : GenericCrudController<Project>
{
    public ProjectController(ICrudRepository<Project> repository) : base(repository) { }
}

[Route("api/site")]
public class SiteController : GenericCrudController<Site>
{
    public SiteController(ICrudRepository<Site> repository) : base(repository) { }
}
