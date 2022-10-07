using Mapster;
using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;

namespace NavigationAPI.Controllers {
    public abstract class AController<TEntity, TCreateDto, TDto> : ControllerBase
        where TEntity : class
        where TCreateDto : class
        where TDto : class {
        protected IRepository<TEntity> _repo;

        public AController(IRepository<TEntity> repo) {
            _repo = repo;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<TDto>>> ReadAsync() =>
            Ok((await _repo.ReadAsync()).Select(e => e.Adapt<TDto>()));

        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<TDto>> ReadAsync(int id) =>
            Ok((await _repo.ReadAsync(id)).Adapt<TDto>());

        [HttpPost]
        public async Task<ActionResult<TDto>> CreateAsync(TCreateDto e) =>
            Ok((await _repo.CreateAsync(e.Adapt<TEntity>())).Adapt<TDto>());

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAsync(int id, TDto e) {
            var e2 = await _repo.ReadAsync(id);
            if (e2 is null) return NotFound();

            await _repo.UpdateAsync(e.Adapt<TEntity>());
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id) {
            var e2 = await _repo.ReadAsync(id);
            if (e2 is null) return NotFound();

            await _repo.DeleteAsync(e2);
            return NoContent();
        }
    }
}