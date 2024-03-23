using AutoMapper;
using blog_.Net_be.dto;
using blog_.Net_be.Models;
using blog_.Net_be.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace blog_.Net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryController(UnitOfWork _unitOfWork,IMapper _mapper) {
           unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var rs =  await unitOfWork.CategoryRepository.getAll();
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto category)
        {
            var map = mapper.Map<Category>(category);
            var rs = await unitOfWork.CategoryRepository.create(map);
            await unitOfWork.SaveChanges();
            return Ok(rs);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var rs = await unitOfWork.CategoryRepository.delete(id);
            await unitOfWork.SaveChanges();
            return Ok(rs);
        }
    }
}
