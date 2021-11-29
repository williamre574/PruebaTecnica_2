﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica_2.Context;
using PruebaTecnica_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GestoresController : ControllerBase
    {
        private readonly AppDBContext context;
        
        public GestoresController(AppDBContext context)
        {
            this.context = context;
        }
        
        // GET: api/<GestoresController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.chores.ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<GestoresController>/5
        [HttpGet("{id}", Name = "GetGestor")]

        public ActionResult Get(int id)
        {
            try
            {
                var gestor = context.chores.FirstOrDefault(g => g.id == id);
                return Ok(gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<GestoresController>
        [HttpPost]
        public ActionResult Post([FromBody] chores gestor)
        {
            try
            {
                context.chores.Add(gestor);
                context.SaveChanges();
                return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }



        }

        // PUT api/<GestoresController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] chores gestor)
        {
            try
            {
                if (gestor.id == id)
                {
                    context.Entry(gestor).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetGestor", new { id = gestor.id }, gestor);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<GestoresController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var gestor = context.chores.FirstOrDefault(g => g.id == id);
                if (gestor != null)
                {
                    context.chores.Remove(gestor);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
