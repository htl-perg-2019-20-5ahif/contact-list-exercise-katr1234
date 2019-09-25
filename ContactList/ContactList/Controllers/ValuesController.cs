using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{
    [ApiController]
    [Route("contacts")]
    public class ContactListController : ControllerBase
    {
        private static readonly List<Contact> contact = new List<Contact>();

        // GET ALL: api/contact-list
        [HttpGet]
        public IActionResult GetAllItems()
        {
            return Ok(contact);
        }

        // GET: api/contact-list/string
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetItem(string name)
        {
            if (name != null || name.Length != 0)
            {
                foreach(Contact c in contact)
                {
                    if (c.firstName.Equals(name) || c.lastName.Equals(name))
                    {
                        // 200: Successful operation
                        return Ok(c);
                    }
                }
                
            }
            // 400: Invalid ID supplied
            return BadRequest("Invalid ID supplied!");
        }

        // POST: api/contact-list
        [HttpPost]
        public IActionResult AddItem([FromBody] Contact newContact)
        {
            contact.Add(newContact);
            return CreatedAtRoute("GetSpecificItem", new { index = contact.IndexOf(newContact) }, newContact);
        }

        // DELETE: api/contact-list/id
        [Route("{index}")]
        public IActionResult DeleteItem(int index)
        {
            if (index >= 0)
            {
                foreach (Contact c in contact)
                {
                    if (c.id == index)
                    {
                        // 204: Successful operation
                        contact.RemoveAt(index);
                        return NoContent();
                    }
                }
                // 404: Person not found
                return BadRequest("Person not found!");
            }
            return BadRequest("Invalid ID supplied!");
        }
    }
}
