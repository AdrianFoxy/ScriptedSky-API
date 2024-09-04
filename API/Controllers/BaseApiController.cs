using API.RequestHelpers;
using AutoMapper;
using Core.Entities.Base;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<ActionResult> CreatePagedResult<T, TDto>(IGenericRepository<T> repo,
            ISpecification<T> spec, int pageIndex, int pageSize, IMapper? mapper = null) where T : BaseEntity
        {
            var items = await repo.ListWithSpecAsync(spec);
            var count = await repo.CountAsync(spec);

            if (mapper != null)
            {
                var itemsDto = mapper.Map<IReadOnlyList<TDto>>(items);
                var pagination = new Pagination<TDto>(pageIndex, pageSize, count, itemsDto);
                return Ok(pagination);
            }
            else
            {
                var pagination = new Pagination<T>(pageIndex, pageSize, count, items);
                return Ok(pagination);
            }
        }
    }
}
