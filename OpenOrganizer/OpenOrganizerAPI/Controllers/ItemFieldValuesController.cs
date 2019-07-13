﻿using Microsoft.AspNetCore.Mvc;
using OpenOrganizerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenOrganizerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemFieldValuesController : ControllerBase
    {
        private readonly APIDBContext db = new APIDBContext();
        // GET api/itemfieldvalues
        [HttpGet]
        public ActionResult<List<ItemFieldValue>> Get()
        {
            List<ItemFieldValue> dataValues = new List<ItemFieldValue>();
            dataValues = db.ItemFieldValues.ToList();
            return dataValues;
        }

        // GET api/itemfieldvalues/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemFieldValue> Get(int id)
        {
            var itemValue = db.ItemFieldValues.Find(id);

            if (itemValue == null)
            {
                return NotFound();
            }

            return itemValue;
        }

        // POST api/itemfieldvalues
        [HttpPost]
        public void Post([FromBody] ItemFieldValue value)
        {
            // TODO: Add data validation
            db.ItemFieldValues.Add(value);
            db.SaveChanges();
        }

        // PUT api/itemfieldvalues/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ItemFieldValue value)
        {
            // TODO: Add data validation
            value.ID = id;
            db.ItemFieldValues.Update(value);
            db.SaveChanges();
        }

        // DELETE api/itemfieldvalues/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ItemFieldValue value = new ItemFieldValue();
            value.ID = id;
            db.ItemFieldValues.Remove(value);
            db.SaveChanges();
        }
    }
}
