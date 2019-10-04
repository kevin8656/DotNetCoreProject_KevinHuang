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
        private MemberService _memberservice = new MemberService();
        [HttpGet]
        public List<Member> Get()
        {
            
            return _memberservice.GetMembers(); ;
        }
    }
}