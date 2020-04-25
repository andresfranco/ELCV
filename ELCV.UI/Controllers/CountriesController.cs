using ELCV.UI.WebApi.Common;
using ELCV.Core.Entities;
using ELCV.Core.Interfaces;
using ELCV.UI.Models;
using ELCV.UI.Filters;
using ELCV.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELCV.UI.Controllers
{
    //TO DO: Map Entities to models/DTOS ,Build API Handle Error Class
    public class CountriesController : BaseApiController
    {
        private readonly EfRepository _repository;
        public CountriesController(EfRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Countries/{}
        [HttpGet]
        public IActionResult List()
        {
            var items = _repository.List<Country>()
                            .Select(CountryDTO.FromCountry);
            return Ok(items);
        }

        // GET: api/Countries/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var item = CountryDTO.FromCountry(_repository.GetById<Country>(id));
            return Ok(item);
        }

        // POST: api/Countries
        [HttpPost]
        public IActionResult Post([FromBody] CountryDTO item)
        {
            var country= new Country()
            {
                CountryCode = item.CountryCode,
                CountryName = item.CountryName,
                CreatedDate = DateTimeOffset.UtcNow

            };
            _repository.Add(country);
            return Ok(CountryDTO.FromCountry(country));
        }

        // PUT api/Countries/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CountryDTO item)
        {
            Country country = _repository.GetById<Country>(id);
            if (country == null) return BadRequest("BadRequest");
            if (country.Id == id)
                {
                    country.CountryCode = item.CountryCode;
                    country.CountryName = item.CountryName;
                    country.ModifiedDate = DateTimeOffset.UtcNow;
                    _repository.Update(country);

                    return Ok(CountryDTO.FromCountry(country));
                }
               
              return BadRequest("Bad Request");
        }

        // DELETE api/Countries/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Country country = _repository.GetById<Country>(id);
            if (country == null) return BadRequest("Bad Request");
           _repository.Delete(country);
            return Ok("Record deleted");
            
        }

        
    }
}
