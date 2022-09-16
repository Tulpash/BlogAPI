using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("nomenclature")]
    [ApiController]
    public class NomenclatureController : ControllerBase
    {
        private readonly INomeclatureRepository nomenclatureRepository;

        public NomenclatureController(INomeclatureRepository nomenclatureRepository)
        {
            this.nomenclatureRepository = nomenclatureRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await nomenclatureRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await nomenclatureRepository.GetByIDAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Nomenclature nomenclature)
        {
            var result = await nomenclatureRepository.CreateAsync(nomenclature);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await nomenclatureRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> Update(int id, [FromBody] Nomenclature nomenclature)
        {
            await nomenclatureRepository.UpdateAsync(id, nomenclature);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/author")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            var result = await nomenclatureRepository.GetAuthorAsync(id);
            return Ok(result);
        }
    }
}
