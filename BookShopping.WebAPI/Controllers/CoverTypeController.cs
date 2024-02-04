using BookShopping.Model.Models;
using BookShopping.Service.Repository;
using BookShopping.Service.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookShopping.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoverTypeController : Controller
    {
        private readonly ICoverTypeRepository _coverTypeRepository;
        public CoverTypeController(ICoverTypeRepository coverTypeRepository)
        {
            _coverTypeRepository = coverTypeRepository;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var coverTypeList = _coverTypeRepository.GetAll();
            return Json(coverTypeList);
        }
        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        {
            var coverType = _coverTypeRepository.Get(id);
            return Json(coverType);
        }
        [HttpPost]
        public IActionResult Add([FromBody]CoverType model)
        {
            if(model != null)
            {
                _coverTypeRepository.Add(model);
                return Ok("CoverType is added");
            }
            return BadRequest("Model is null");
        }
        [HttpPut]
        public IActionResult Edit([FromBody]CoverType model)
        {
            if(model != null)
            {
                _coverTypeRepository.Update(model);
                return Ok("CoverType is updated");
            }
            return BadRequest("Model is null");
        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                _coverTypeRepository.Remove(id);
                return Ok("CoverType deleted successfully");
            }
            return BadRequest("Invalid Id");
        }
    }
}
