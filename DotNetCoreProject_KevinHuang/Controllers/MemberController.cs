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
        private readonly MemberService _memberService = new MemberService();//引入memberServer
        #region 取得所有會員資料
        [HttpGet]
        public List<Member> Get()
        {
            return _memberService.GetMembers(); ;
        }
        #endregion

        #region 使用Id取得單一會員資料
        [HttpGet("{Id}")]
        public Member GetMemberById(int id)
        {
            return _memberService.GetMemberById(id);
        }
        #endregion

        #region 新增會員資料
        [HttpPost]
        public string AddMember([FromBody]Member member)
        {
            return _memberService.AddMember(member); ;
        }
        #endregion
        
        #region 更新會員資料
        [HttpPut("{Id}")]
        public string UpdateMember(int id, [FromBody]Member member)
        {
            return _memberService.UpdateMember(id, member); ;
        }
        #endregion

        #region 刪除會員資料
        [HttpDelete("{Id}")]
        public string DeleteMember(int id)
        {
            return _memberService.DeleteMember(id);
        }
        #endregion
    }
}