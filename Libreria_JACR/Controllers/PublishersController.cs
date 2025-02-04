﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Libreria_JACR.Data.Services;
using Libreria_JACR.Data.ViewModels;
using System;
using Libreria_JACR.Exceptions;

namespace Libreria_JACR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublishersService _publishersService;
        public PublishersController(PublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            try
            {
                var newPublisher = _publishersService.AddPublisher(publisher);
                return Created(nameof(AddPublisher), newPublisher);
            }
            catch (PublisherNameException ex)
            {
                return BadRequest($"{ex.Message}, Nombre de la editora: {ex.PublisherName}");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var _response = _publishersService.GetPublisherByID(id);
            if (_response != null)
            {
                return Ok(_response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPubliserData(int id)
        {
            var _response = _publishersService.GetPublisherData(id);
            return Ok(_response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            try
            {
                _publishersService.DeletePublisher(id);
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

    }
}
