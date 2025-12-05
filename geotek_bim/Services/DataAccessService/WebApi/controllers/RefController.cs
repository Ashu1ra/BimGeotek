using DataAccessService.Domain.Entities.Ref;
using Microsoft.AspNetCore.Mvc;
using DataAccessService.Domain.Interfaces.Repositories;

[Route("api/list_borehole_type")]
public class ListBoreholeTypeController : GenericCrudController<List_borehole_type>
{
    public ListBoreholeTypeController(ICrudRepository<List_borehole_type> repository) : base(repository) { }
}

[Route("api/list_borehole_standard")]
public class ListBoreholeStandardController : GenericCrudController<List_borehole_standard>
{
    public ListBoreholeStandardController(ICrudRepository<List_borehole_standard> repository) : base(repository) { }
}

[Route("api/list_borehole_interval_type")]
public class ListBoreholeIntervalTypeController : GenericCrudController<List_borehole_interval_type>
{
    public ListBoreholeIntervalTypeController(ICrudRepository<List_borehole_interval_type> repository) : base(repository) { }
}
