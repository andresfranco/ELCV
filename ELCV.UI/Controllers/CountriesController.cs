using ELCV.UI.WebApi.Common;
using ELCV.Core.Entities;
using ELCV.Core.Interfaces;
using ELCV.UI.Models;
using ELCV.UI.Filters;
using ELCV.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using AutoMapper;
using System.Threading.Tasks;
using ELCV.Core.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELCV.UI.Controllers
{
    //TO DO: Map Entities to models/DTOS ,Build API Handle Error Class
    public class CountriesController : BaseApiController
    {
        private readonly EfRepository _repository;
        private readonly IMapper _mapper;
        private readonly ApiControllerErrorHandler _errorHandler;

        public CountriesController(EfRepository repository,IMapper mapper, ApiControllerErrorHandler errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _errorHandler = errorHandler;
        }

        // GET: api/Countries/{}
        [HttpGet]
        public IActionResult List()
        {
            try 
            {
                var countries = _repository.List<Country>()
                            .Select(CountryDTO.FromCountry);
                if (countries != null) return Ok(countries);
                return NotFound();
            }
            catch(Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage(ex.Message));
            }
            
        }

        // GET: api/Countries/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var country = CountryDTO.FromCountry(_repository.GetById<Country>(id));
                return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage(ex.Message));
            }
           
        }

        // POST: api/Countries
        [HttpPost]
        public IActionResult Post([FromBody] CountryDTO countryData)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    var newCountry = _mapper.Map<CountryDTO, Country>(countryData);
                    newCountry.CreatedDate = DateTimeOffset.UtcNow;
                    _repository.Add(newCountry);
                    return Ok(newCountry);
                }
                 return Json(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest("Bad request"+ex.Message);
            }
        
        }

        // PUT api/Countries
        [HttpPut]
        public IActionResult Put([FromBody] CountryDTO countryData)
        {
            try
            {
                var countryEntity = _repository.GetById<Country>((int)countryData.Id);
                if (countryEntity == null) return NotFound(_errorHandler.JsonErrorMessage("Invalid Model Data"));

                if (ModelState.IsValid)
                {
                    var updatedCountry = _mapper.Map<CountryDTO, Country>(countryData,countryEntity);
                    updatedCountry.ModifiedDate = DateTimeOffset.UtcNow;
                    _repository.Update(updatedCountry);
                    return Ok(CountryDTO.FromCountry(updatedCountry));
                }
                return Json(ModelState);
              
               
            }
            catch(Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage(ex.Message));
            }
            
        }

       

        // DELETE api/Countries/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try 
            {
                Country country = _repository.GetById<Country>(id);
                if (country == null) return BadRequest(_errorHandler.JsonErrorMessage("Model data null"));
                _repository.Delete(country);
                return Ok("Record deleted");
            }
            catch(Exception ex) {
                return BadRequest(_errorHandler.JsonErrorMessage(ex.Message));
            }
            
        }

        
    }
}
