using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Remotion.Linq.Clauses;
using Swashbuckle.AspNetCore.Annotations;
using TestAPI.DTO;
using TestAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly SWD_SlicingPieProjectContext _context;
        public MembersController(SWD_SlicingPieProjectContext context)
        {
            _context = context;
        }

        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> Get()
        {
            var members = from m in _context.Members.Include(m => m.Company).Include(m => m.Role).Include(m => m.Status).Include(m => m.Assets)
                          select new MemberDTO()
                          {
                              MemberId = m.MemberId,
                              Account = m.Account,
                              Name = m.Name,
                              Email = m.Email,
                              PhoneNo = m.PhoneNo,
                              Job = m.Job,
                              MarketSalary = m.MarketSalary,
                              Salary = m.Salary,
                              CompanyName = m.Company.CompanyName,
                              Role = m.Role.NameRole,
                              Status = m.Status.StatusName,
                              Assets = (from a in _context.Assets
                                        where a.MemberId == m.MemberId

                                        select new AssetDTO
                                        {
                                            Description = a.Description,
                                            Quantity = a.Quantity,
                                            TimeAsset = a.TimeAsset
                                        }).ToList()
                          };
            return Ok(members);
        }

        [SwaggerOperation(Description = "Return membersssssss")]
        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDTO>> Get(string id)
        {
            var member = await _context.Members.Include(m => m.Company).Include(m => m.Role).Include(m => m.Status).Include(m => m.Assets).
                Select(m =>
             new MemberDTO()
             {
                 MemberId = m.MemberId,
                 Account = m.Account,
                 Name = m.Name,
                 Email = m.Email,
                 PhoneNo = m.PhoneNo,
                 Job = m.Job,
                 MarketSalary = m.MarketSalary,
                 Salary = m.Salary,
                 CompanyName = m.Company.CompanyName,
                 Role = m.Role.NameRole,
                 Status = m.Status.StatusName,
                 Assets = (from a in _context.Assets
                           where a.MemberId == m.MemberId
                           select new AssetDTO
                           {
                               Description = a.Description,
                               Quantity = a.Quantity,
                               TimeAsset = a.TimeAsset
                           }).ToList()
             }).SingleOrDefaultAsync(m => m.MemberId == id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        //POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult<Member>> Create(Member model)
        {

            _context.Members.Add(model);
            await _context.SaveChangesAsync();


            return CreatedAtAction(nameof(Get), new { id = model.MemberId }, model);
        }


        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id,Member  model)
        {
            if (id != model.MemberId)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
