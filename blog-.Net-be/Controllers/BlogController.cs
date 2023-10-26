using AutoMapper;
using blog_.Net_be.CustomRepositories;
using blog_.Net_be.dto;
using blog_.Net_be.Models;
using blog_.Net_be.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_.Net_be.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IBlogRepository blogRepository;
        public BlogController(UnitOfWork unitOfWork,IMapper mapper,IBlogRepository _blogRepository)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            blogRepository = _blogRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _unitOfWork.BlogRepository.getAll();
            return Ok(rs);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var rs = await _unitOfWork.BlogRepository.findById(id);
            return Ok(rs);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogDto blog)
        {
            var map = mapper.Map<Blog>(blog); 
            var rs = await _unitOfWork.BlogRepository.create(map);
            await _unitOfWork.SaveChanges();
            return Ok(rs);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var rs = await _unitOfWork.BlogRepository.delete(id);
            await _unitOfWork.SaveChanges();
            return Ok(rs);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] BlogDto blog)
        {
            var map = mapper.Map<Blog>(blog);
            var rs =  await blogRepository.updateById(id, map);
            
            return Ok(rs);
        }
    }
}
