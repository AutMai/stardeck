using Microsoft.AspNetCore.Mvc;
using NavigationDomain.Repositories.Interfaces;

namespace NavigationAPI.Controllers {
    public class AController<TEntity> : ControllerBase where TEntity : class {
        protected IRepository<TEntity> _repo;

        public AController(IRepository<TEntity> repo) {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<TEntity>>> ReadAsync()  => Ok(await _repo.ReadAsync());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TEntity>> ReadAsync(int id) => Ok(await _repo.ReadAsync(id));

        [HttpPost]
        public async Task<ActionResult<TEntity>> CreateAsync(TEntity e) => Ok(await _repo.CreateAsync(e));

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateAsync(int id, TEntity e) {
            var e2 = await _repo.ReadAsync(id);
            if (e2 is null) return NotFound();

            await _repo.UpdateAsync(e);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteAsync(int id, TEntity e) {
            var e2 = await _repo.ReadAsync(id);
            if (e2 is null) return NotFound();

            await _repo.DeleteAsync(e2);
            return NoContent();
        }
    }
}