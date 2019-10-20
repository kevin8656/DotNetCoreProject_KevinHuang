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
        [HttpGet("{id}")]//這邊代表網址會變成api/member/{id變數}
        public Member Get(int id)//Member代表這個API會回傳的型態，int id代表這個API會傳入id來查詢單一個會員資料
        {
            return _memberservice.GetMemberById(id);//呼叫Service，去透過ID查詢單一個會員資料
        }

        [HttpPost]
        public string AddMember([FromBody] Member member)//這邊新增一個名為AddMember的API function ，使用HTTP POST 方法進行傳輸，然後會傳入此api的資料是一個完整Member型態的資料
        //然後特別標註[FromBody原因是之後他會從HTTP Request中的Body位置，帶整筆會員資料並且傳送過來，請看PostMan的Body的位置]
        //剛剛上面回傳值寫錯，這邊傳入要新增的會員資料後，最後傳回去的會是一個字串，字串內容是"新增會員成功" 或 "新增會員失敗"
        {
            return _memberservice.AddMember(member);
        }

        [HttpPut("{id}")]//這邊代表網址會變成api/member/{id變數}
        public string EditMember(int id, [FromBody] Member member)//這邊是在做修改會員資料，會傳入Id以及一個修改後的member資料
        {
            return _memberservice.EditMember(id, member);//呼叫Service去更新會員資料
        }

        [HttpDelete("{id}")] //這邊代表網址會變成api/member/{id變數}
        public string DeleteMember(int id)//這邊是在做刪除會員資料，會傳入id，並且呼叫Service把這個id的會員刪除
        {
            return _memberservice.DeleteMember(id);//呼叫Service，把id傳過去叫他刪除
        }
    }
}