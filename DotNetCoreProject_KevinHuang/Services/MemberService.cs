using DotNetCoreProject_KevinHuang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreProject_KevinHuang.Services
{
    public class MemberService
    {
        private readonly dotnetcoreContext _context = new dotnetcoreContext();
        public List<Member> GetMembers()
        {
            return _context.Member.ToList();
        }

        public Member GetMemberById(int id)
        {
            try
            {
                return _context.Member.Single(b => b.Id == id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string AddMember(Member member)
        {
            try
            {
                _context.Member.Add(member);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return "Add Member Fail.";
            }
            return "Add Member Success.";
        }

        public string UpdateMember(int id, Member member)
        {
            try
            {
                var oldMember = _context.Member.FirstOrDefault(x => x.Id == id);
                if (oldMember != null)
                {
                    oldMember.Account = member.Account;
                    oldMember.Password = member.Password;
                    oldMember.Name = member.Name != "" ? member.Name : oldMember.Name;
                    oldMember.Phone = member.Phone != "" ? member.Phone : oldMember.Phone;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                return "Update Member Fail.";
            }
            return "Update Member Success.";

        }

        public string DeleteMember(int id)
        {
            var member = _context.Member.FirstOrDefault(x => x.Id == id);
            if (member == null) return "Delete Member Success.";
            _context.Member.Remove(member);
            _context.SaveChanges();

            return "Delete Member Success.";
        }
    }
}
