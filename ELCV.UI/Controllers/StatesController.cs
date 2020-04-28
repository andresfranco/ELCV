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
    public class StatesController:BaseApiController
    {
        private readonly StateRepository _repository;
        private readonly IMapper _mapper;
        public StatesController(ApiControllerErrorHandler _errorHandler, StateRepository repository, IMapper mapper) :base( _errorHandler)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/States
        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var states = await _repository.FindAllAsync();
                if (states == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                var stateDTO = _mapper.Map<IEnumerable<StateDTO>>(states);
                return Ok(stateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // GET: api/States/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var state = await _repository.GetByIdAsync(id);
                if (state == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                var stateDTO = _mapper.Map<StateDTO>(state);
                return Ok(stateDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }

        // POST: api/States
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StateDTO stateData)
        {
            try
            {    
                if (ModelState.IsValid)
                {
                    var newState = _mapper.Map<StateDTO,State>(stateData);
                    newState.CreatedDate = DateTimeOffset.UtcNow;
                    await _repository.CreateAsync(newState);
                    return Ok(newState);
                }
                return Json(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message+ex.InnerException.Message));
            }

        }

        // PUT api/States
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StateDTO stateData)
        {
            try
            {
                var state = await _repository.GetByIdAsync((int)stateData.Id);
                if (state == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                if (ModelState.IsValid)
                {
                    var updatedState = _mapper.Map<StateDTO, State>(stateData, state);
                    updatedState.ModifiedDate = DateTimeOffset.UtcNow;
                    await _repository.UpdateAsync(updatedState);
                    return Ok(StateDTO.FromState(updatedState));
                }
                return Json(ModelState);
            }
            catch (Exception ex)
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
                var state = await _repository.GetByIdAsync(id);
                if (state == null) return NotFound(_errorHandler.JsonErrorMessage((int)HttpStatusCode.NotFound));
                await _repository.DeleteAsync(state);
                return Ok(_errorHandler.JsonErrorMessage((int)HttpStatusCode.OK));
            }
            catch (Exception ex)
            {
                return BadRequest(_errorHandler.JsonErrorMessage((int)HttpStatusCode.BadRequest, ex.Message));
            }

        }
    }
}
