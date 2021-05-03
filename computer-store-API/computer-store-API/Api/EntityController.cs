using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace computer_store_API.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController<HaUIController> : ControllerBase
    {
        DbConnector dbConnector = new DbConnector();

        [HttpGet]
        public IActionResult Get()
        {

            // Lấy dữ liệu từ Database:
            var entities = dbConnector.Get<HaUIController>();
            // Trả lại dữ liệu cho client:
            return Ok(entities);
        }

        [HttpGet("highlight")]
        public IActionResult GetHighlight()
        {

            // Lấy dữ liệu từ Database:
            var entities = dbConnector.GetHighlight<HaUIController>();
            // Trả lại dữ liệu cho client:
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public object Get(int id)
        {
            var entity = dbConnector.Get<HaUIController>(id);
            return entity;
        }

        [HttpGet("productcategory/{id}")]
        public IActionResult GetProductCategoryById(int id)
        {
            //Lấy dữ liệu từ Database
            var entity = dbConnector.GetProductsByCategory<HaUIController>(id);
            //Trả dữ liệu cho client
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult Insert(HaUIController entity)
        {
            var dataAffect = dbConnector.Post<HaUIController>(entity);
            return Ok(dataAffect);
         
        }


        [HttpPut("{id}")]
        public IActionResult Update(HaUIController entity, int id)
        {
            var dataAffect = dbConnector.Put<HaUIController>(entity, id);
            return Ok(dataAffect);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dataAffect = dbConnector.Delete<HaUIController>(id);
            return Ok(dataAffect);
        }
    }
}
