using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestAPI.DTO;
using TestAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly SWD_SlicingPieProjectContext _context;
        public CompaniesController(SWD_SlicingPieProjectContext context)
        {
            _context = context;
        }
        // GET: api/<CompaniesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> Get()
        {
            var company = from c in _context.Companies 
                          select new CompanyDTO()
                          {
                              CompanyId = c.CompanyId,
                              CompanyName = c.CompanyName,
                              ComapnyIcon = c.ComapnyIcon
                          };

            return Ok(company);
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDTO>> Get(string id)
        {
            var company = from c in _context.Companies
                          where c.CompanyId == id
                          select new CompanyDTO()
                          {
                              CompanyId = c.CompanyId,
                              ComapnyIcon = c.ComapnyIcon,
                              CompanyName = c.CompanyName
                          };
            if (!company.Any())
            {
                return NotFound();
            }

            return Ok(company);
        }


        [HttpPost]
        public async Task<ActionResult<CompanyDTO>> Create(CompanyDTO model)
        {

            Company company = new Company()
            {
                CompanyId = model.CompanyId,
                ComapnyIcon = model.ComapnyIcon,
                CompanyName = model.CompanyName
            };
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(Get), new { id = model.CompanyId }, model);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, CompanyDTO model)
        {
            if (id != model.CompanyId)
            {
                return BadRequest();
            }

            Company company = new Company
            {
                CompanyId = model.CompanyId,
                ComapnyIcon = model.ComapnyIcon,
                CompanyName = model.CompanyName
            };

            _context.Entry(company).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
