using BlogAPI.Data;
using BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("authors")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await authorRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await authorRepository.GetByIDAsync(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            var result = await authorRepository.CreateAsync(author);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await authorRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> Update(int id, [FromBody] Author author)
        {
            await authorRepository.UpdateAsync(id, author);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/nomenclature")]
        public async Task<IActionResult> Nomenclature(int id)
        {
            var result = await authorRepository.GetNomenclatureAsync(id);
            return Ok(result);
        }
    }
}
