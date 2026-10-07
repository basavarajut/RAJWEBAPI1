using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RAJWEBAPI1.Data;
using RAJWEBAPI1.Models.Domain;
using RAJWEBAPI1.Models.DTO;

namespace RAJWEBAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ContactsController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _context.Contacts.ToList();
            return Ok(contacts);
        }

        [HttpPost(Name="PostContact")]
        public IActionResult AddContact(ContactDTO contactDTO)
        {
            var _contact = new Contact() { 
                Id = Guid.NewGuid(),
                Name = contactDTO.Name, 
                Email = contactDTO.Email,
                Phone = contactDTO.Phone,
                Favorite = contactDTO.Favorite
            };
            _context.Contacts.Add(_contact);
            _context.SaveChanges();

            return Ok(_contact);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact(Guid id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact is not null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
            return Ok();
        }

    
    }
}
