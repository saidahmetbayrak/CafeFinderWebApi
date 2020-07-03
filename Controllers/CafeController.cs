using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using CafeFinderWebApi.Services;
using CafeFinderWebApi.Model;

namespace CafeFinderWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CafeController : Controller
    {
        private readonly ICafeService _cafeService;

        public CafeController(ICafeService cafeService)
        {
            _cafeService=cafeService; 
        }

        
        /// <summary>Get All Cafe</summary>
        //GET : Cafe
        [HttpGet]
        public  IEnumerable<Cafe> Get(){

           return _cafeService.GetAllCafes();
        }
        
        /// <summary>Get By Id Cafe</summary>
        //GET : Cafe/5
        [HttpGet("{id}", Name="GetCafe")]
        public IActionResult GetById(int id){

            var cafeId = _cafeService.GetCafeById(id);
            
            if(cafeId == null){
                
                return NotFound();
            }

            return Ok(cafeId);
        }

        /// <summary>Create an Cafe</summary>
        // POST Cafe
        [HttpPost]
        public IActionResult Post([FromBody]Cafe value){

            if (value == null)
            {
                return BadRequest();
            }
            var createdCafe = _cafeService.CreateCafe(value);

            return CreatedAtRoute("GetCafe", new{id= createdCafe.Id},createdCafe);
        }

        /// <summary>Update the Cafe</summary>
        // PUT Cafe/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Cafe value){

             if (value == null)
            {
                return BadRequest();
            }


            var note = _cafeService.GetCafeById(id);


            if (note == null)
            {
                return NotFound();
            }


            value.Id = id;
            _cafeService.UpdateCafe(value);


            return NoContent();
        }

        /// <summary>Delete the Cafe</summary>
        //DELETE cafe/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){

           var cafeId = _cafeService.GetCafeById(id);

            if (cafeId == null)
            {
                return NotFound();
            }
            _cafeService.DeleteCafe(cafeId.Id);

            return NoContent();
        }
    }
}
