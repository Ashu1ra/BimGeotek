using DataAccessService.Domain.Entities.Igt;
using Microsoft.AspNetCore.Mvc;
using DataAccessService.Domain.Interfaces.Repositories;

[Route("api/boreholeinterval")]
public class BoreholeIntervalController : GenericCrudController<Borehole_interval>
{
    public BoreholeIntervalController(ICrudRepository<Borehole_interval> repository) : base(repository) { }
}

[Route("api/sample")]
public class SampleController : GenericCrudController<Sample>
{
    public SampleController(ICrudRepository<Sample> repository) : base(repository) { }
}

[Route("api/borehole")]
public class BoreholeController : GenericCrudController<Borehole>
{
    public BoreholeController(ICrudRepository<Borehole> repository) : base(repository) { }
}
