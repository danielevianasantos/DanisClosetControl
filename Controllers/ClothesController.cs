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
        protected readonly ILiteDbClothesService _service;
        public ClothesController(ILiteDbClothesService service)
        {
            _service = service;
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

        [HttpPost]
        [Route("Create")]
        public ActionResult Post(Clothes clothes)
        {
            var postResult = _service.Create(clothes);
            if(postResult.Success)
                return Ok(postResult);
            return BadRequest(postResult);
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

        [HttpGet]
        [Route("GetOne")]
        public ActionResult GetById(Guid id)
        {
            var getOneResult = _service.FindOne(id);
            if (getOneResult.Success)
                return Ok(getOneResult);
            return BadRequest(getOneResult);
        }

        [HttpPost]
        [Route("FindByKind")]
        public ActionResult FindByKind(string clothesType)
        {
            var getThatKindResult = _service.FindSome(clothesType);
            if (getThatKindResult.Success)
                return Ok(getThatKindResult);
            return BadRequest(getThatKindResult);
        }
    }
}
