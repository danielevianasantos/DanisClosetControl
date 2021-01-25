using ClosetControl.Application.Interface;
using ClosetControl.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ClosetControl.Web.Controllers
{
    [ApiController]
    [Route("api/Clothes")]
    public class ClothesController : ControllerBase
    {
        protected readonly IClothesService _service;
        public ClothesController(IClothesService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Post(Clothes clothes)
        {
            var postResult = _service.Create(clothes);
            if (postResult.Success)
                return Ok(postResult);
            return BadRequest(postResult);
        }

        [HttpGet]
        [Route("FindByKind")]
        public ActionResult FindByKind(string clothesType)
        {
            var getThatKindResult = _service.FindByType(clothesType);
            if (getThatKindResult.Success)
                return Ok(getThatKindResult);
            return BadRequest(getThatKindResult);
        }

        [HttpGet]
        [Route("FindBySeason")]
        public ActionResult FindBySeason(int season)
        {
            var getThatKindResult = _service.FindBySeason(season);
            if (getThatKindResult.Success)
                return Ok(getThatKindResult);
            return BadRequest(getThatKindResult);
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult Get()
        {
            var getResult = _service.FindAll();
            if(getResult.Success)
                return Ok(getResult.DataList);
            return BadRequest(getResult.MessageList);
        }


        [HttpGet]
        [Route("GetOne")]
        public ActionResult GetById(Guid id)
        {
            var getOneResult = _service.FindOne(id);
            if (getOneResult.Success)
                return Ok(getOneResult);
            return BadRequest(getOneResult);
        }

        [HttpPut]
        [Route("Put")]
        public ActionResult Put(Clothes clothes)
        {
            var putResult = _service.Update(clothes);
            if (putResult.Success)
                return Ok(putResult);
            return BadRequest(putResult);
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(Guid id)
        {
            var deleteResult = _service.Delete(id);
            if (deleteResult.Success)
                return Ok(deleteResult);
            return BadRequest(deleteResult);
        }
    }
}
