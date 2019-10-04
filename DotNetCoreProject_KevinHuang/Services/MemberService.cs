using DotNetCoreProject_KevinHuang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject_KevinHuang.Services
{
    public class MemberService
    {
        private dotnetcoreContext _context = new dotnetcoreContext();
        public List<Member> GetMembers()
        {
            return _context.Member.ToList();
        }
    }
}
