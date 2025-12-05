using Microsoft.AspNetCore.Mvc;
using DataAccessService.Domain.Interfaces.Repositories;
using DataAccessService.Domain.Entities.Test;

[Route("api/Field_test")]
public class Field_testController : GenericCrudController<Field_test>
{
    public Field_testController(ICrudRepository<Field_test> repository) : base(repository) { }
}

[Route("api/Lab_test")]
public class Lab_test : GenericCrudController<Lab_test>
{
    public Lab_test(ICrudRepository<Lab_test> repository) : base(repository) { }
}
