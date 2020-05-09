using ELCV.UI.WebApi.Common;
using ELCV.Core.Entities;
using ELCV.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Threading.Tasks;
using ELCV.Core.Common;
using System.Net;
using System.Collections.Generic;
using ELCV.Infrastructure.Data.Repositories;

namespace ELCV.UI.Controllers
{

    public class CountriesController : BaseApiController
    {
        private readonly CountryRepository _repository;
        private readonly IMapper _mapper;
      

        public CountriesController(ApiControllerErrorHandler _errorHandler, CountryRepository repository, IMapper mapper ) :base(_errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
         }

        // GET: api/Countries
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try 
            {
                var countries = await _repository.FindAllAsync();
                if(countries == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                var countryDTO = _mapper.Map<IEnumerable<CountryDTO>>(countries);
                return Ok(countryDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
            
        }

        // GET: api/Countries/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var country = await _repository.GetByIdAsync(id);
                if (country == null) return Ok(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                var countryDTO = _mapper.Map<CountryDTO>(country);
                return Ok(countryDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
           
        }

        // POST: api/Countries
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDTO countryData)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    var newCountry = _mapper.Map<CountryDTO, Country>(countryData);
                    newCountry.CreatedDate = DateTimeOffset.UtcNow;
                    await _repository.CreateAsync(newCountry);
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
        public async Task<IActionResult> Put([FromBody] CountryDTO countryData)
        {
            try
            {
                var country = await _repository.GetByIdAsync((int)countryData.Id);
                if (country == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                if (ModelState.IsValid)
                {
                    var updatedCountry = _mapper.Map<CountryDTO, Country>(countryData,country);
                    updatedCountry.ModifiedDate = DateTimeOffset.UtcNow;
                    await _repository.UpdateAsync(updatedCountry);
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
        public async Task<IActionResult> Delete(int id)
        {
            try 
            {
                var country= await _repository.GetByIdAsync(id);
                if (country == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                await _repository.DeleteAsync(country);
                return Ok(_errorHandler.JsonErrorMessage((int)HttpStatusCode.OK));
            }
            catch(Exception ex) {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }
            
        }
        
    }
}
