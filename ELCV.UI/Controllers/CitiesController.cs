using AutoMapper;
using ELCV.Core.Common;
using ELCV.Core.Entities;
using ELCV.Infrastructure.Data.Repositories;
using ELCV.UI.Models;
using ELCV.UI.WebApi.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ELCV.UI.Controllers
{
    public class CitiesController:BaseApiController
    {
        private readonly CityRepository _repository;
        private readonly IMapper _mapper;
        public CitiesController(ApiControllerErrorHandler _errorHandler, CityRepository repository, IMapper mapper) :base(_errorHandler)
        {
            _repository = repository;
            _mapper = mapper;

        }

        // GET: api/Cities
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var cities = await _repository.FindAllAsync();
                if (cities == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                var cityDTO = _mapper.Map<IEnumerable<CityDTO>>(cities);
                return Ok(cityDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // GET: api/Cities/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var city = await _repository.GetByIdAsync(id);
                if (city == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                var cityDTO = _mapper.Map<CityDTO>(city);
                return Ok(cityDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // POST: api/Cities
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CityDTO cityData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newcity = _mapper.Map<CityDTO,City>(cityData);
                    newcity.CreatedDate = DateTimeOffset.UtcNow;
                    await _repository.CreateAsync(newcity);
                    return Ok(newcity);
                }
                return Json(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // PUT api/Cities
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CityDTO cityData)
        {
            try
            {
                var city = await _repository.GetByIdAsync((int)cityData.Id);
                if (city == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                if (ModelState.IsValid)
                {
                    var updatedcity = _mapper.Map<CityDTO, City>(cityData, city);
                    updatedcity.ModifiedDate = DateTimeOffset.UtcNow;
                    await _repository.UpdateAsync(updatedcity);
                    return Ok(CityDTO.FromCity(updatedcity));
                }
                return Json(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // DELETE api/Cities/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var city = await _repository.GetByIdAsync(id);
                if (city == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                await _repository.DeleteAsync(city);
                return Ok(_errorHandler.JsonErrorMessage((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

    }
}
