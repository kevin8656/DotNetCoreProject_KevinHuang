using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreProject_KevinHuang.Models;
using DotNetCoreProject_KevinHuang.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreProject_KevinHuang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private MemberService _memberService = new MemberService();
        [HttpGet]
        public List<Member> Get()
        {

            return _memberService.GetMembers(); ;
        }
        [HttpGet("{Id}")]
        public Member GetMemberById(int Id)
        {
            return _memberService.GetMemberById(Id);
        }
        [HttpPost]
        public string AddMember([FromBody]Member member)
        {
            return _memberService.AddMember(member); ;
        }
        [HttpPut("{Id}")]
        public string UpdateMember(int id, [FromBody]Member member)
        {
            return _memberService.UpdateMember(id, member); ;
        }
        [HttpDelete("{Id}")]
        public string DeleteMember(int Id)
        {
            return _memberService.DeleteMember(Id);
        }
    }
}