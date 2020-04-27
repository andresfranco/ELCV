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
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELCV.UI.Controllers
{
    //TO DO: Map Entities to models/DTOS ,Build API Handle Error Class
    public class CountriesController : BaseApiController
    {
        private readonly EfRepository _repository;
        private readonly IMapper _mapper;
      

        public CountriesController(EfRepository repository,IMapper mapper, ApiControllerErrorHandler _errorHandler) :base(_errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
         }

        // GET: api/Countries/{}
        [HttpGet]
        public IActionResult List()
        {
            try 
            {
                var countries = CheckValidEntity(_repository.List<Country>().Select(CountryDTO.FromCountry));
                return Ok(countries);
            }
            catch(Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
            
        }

        // GET: api/Countries/{id}
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
               var country = (Country)CheckValidEntity(_repository.GetById<Country>(id));
               return Ok(country);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
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
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
        
        }

        // PUT api/Countries
        [HttpPut]
        public IActionResult Put([FromBody] CountryDTO countryData)
        {
            try
            {
                var country = (Country)CheckValidEntity(_repository.GetById<Country>((int)countryData.Id));

                if (ModelState.IsValid)
                {
                    var updatedCountry = _mapper.Map<CountryDTO, Country>(countryData,country);
                    updatedCountry.ModifiedDate = DateTimeOffset.UtcNow;
                    _repository.Update(updatedCountry);
                    return Ok(CountryDTO.FromCountry(updatedCountry));
                }
                return Json(ModelState);       
            }
            catch(Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
            
        }

        // DELETE api/Countries/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try 
            {
                var country=(Country)CheckValidEntity(_repository.GetById<Country>(id)) ;
                _repository.Delete(country);
                return Ok(_errorHandler.JsonErrorMessage((int)HttpStatusCode.OK));
            }
            catch(Exception ex) {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
            
        }

        
    }
}
