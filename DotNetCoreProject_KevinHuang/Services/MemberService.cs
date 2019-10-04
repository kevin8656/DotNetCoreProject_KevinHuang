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

        public Member GetMemberById(int Id)
        {
            return _context.Member.Single(b => b.Id == Id);
        }

        public string AddMember(Member member)
        {
            try
            {
                _context.Member.Add(member);
                _context.SaveChanges();
            }
            catch
            {
                return "False";
            }
            return "Success";
        }

        public string UpdateMember(int id, Member member)
        {
            try
            {
                var oldMember = _context.Member.Where(x => x.Id == id).FirstOrDefault();
                oldMember.Account = member.Account;
                oldMember.Password = member.Password;
                oldMember.Name = member.Name != "" ? member.Name : oldMember.Name;
                oldMember.Phone = member.Phone != "" ? member.Phone : oldMember.Phone;

                _context.SaveChanges();
            }
            catch
            {
                return "False";
            }
            return "Success";

        }

        public string DeleteMember(int id)
        {
            try
            {
                var member = _context.Member.Where(x => x.Id == id).FirstOrDefault();
                _context.Member.Remove(member);
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            return "Success";
        }
    }
}
