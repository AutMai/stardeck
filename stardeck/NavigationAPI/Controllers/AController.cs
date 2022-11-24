using EventBusConnection;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;

namespace NavigationAPI.Controllers {
    public abstract class AController<TEntity, TCreateDto, TDto> : ControllerBase
        where TEntity : class
        where TCreateDto : class
        where TDto : class {
        protected IRepository<TEntity> Repo;
        protected IEventBusClient EventBusClient;

        public AController(IRepository<TEntity> repo, IEventBusClient eventBusClient) {
            Repo = repo;
            EventBusClient = eventBusClient;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TDto>>> ReadAsync() =>
            Ok((await Repo.ReadAsync()).Select(e => e.Adapt<TDto>()));

        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<TDto>> ReadAsync(int id) =>
            Ok((await Repo.ReadAsync(id)).Adapt<TDto>());

        [HttpPost]
        public async Task<ActionResult<TDto>> CreateAsync(TCreateDto e) =>
            Ok((await Repo.CreateAsync(e.Adapt<TEntity>())).Adapt<TDto>());

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAsync(int id, TDto e) {
            var e2 = await Repo.ReadAsync(id);
            if (e2 is null) return NotFound();

            await Repo.UpdateAsync(e.Adapt<TEntity>());
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id) {
            var e2 = await Repo.ReadAsync(id);
            if (e2 is null) return NotFound();

            await Repo.DeleteAsync(e2);
            return NoContent();
        }
    }
}