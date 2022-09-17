using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("types")]
    [ApiController]
    public class NomenclatureTypeController : ControllerBase
    {
        private readonly INomenclatureTypeRepository nomenclatureTypeRepository;

        public NomenclatureTypeController(INomenclatureTypeRepository nomenclatureTypeRepository)
        {
            this.nomenclatureTypeRepository = nomenclatureTypeRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await nomenclatureTypeRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await nomenclatureTypeRepository.GetByIDAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] NomenclatureType type)
        {
            var result = await nomenclatureTypeRepository.CreateAsync(type);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> Update(int id, [FromBody] NomenclatureType type)
        {
            await nomenclatureTypeRepository.UpdateAsync(id, type);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await nomenclatureTypeRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
