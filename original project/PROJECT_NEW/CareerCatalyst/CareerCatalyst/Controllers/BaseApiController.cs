using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    public abstract class BaseApiController<T> : ControllerBase
    {

    }
}
