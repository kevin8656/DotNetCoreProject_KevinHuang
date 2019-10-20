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

        public Member GetMemberById(int id)//Service裡面這個方法會回傳Member型態資料，會從Controller傳入ID，用於查詢會員資料
        {
            try
            {
                return _context.Member.Single(x => x.Id == id); //透過EFcore以及LinQ語法，查詢單一個會員資料，詳細語法請上網查使用方式
            }
            catch
            {
                return null;//這邊加入try catch，當上面發生錯誤(找不到會員資料)的時候，就return null
            }
        }

        public string AddMember(Member member)
        {
            try
            {
                //這邊我們要做新增會員的操作
                _context.Member.Add(member);//.Add()是LinQ用於EFCore的用法，詳情請上網查使用方式
                _context.SaveChanges();//對資料庫實體進行操作之後，如果要儲存資料(新增或者修改資料通常後面都會需要儲存)，則需要下這行savechange
                return "新增會員成功";
            }
            catch (Exception e)//這邊補上一個抓到錯誤訊息的東西，把程式碼停在這行 看一下錯誤訊息是什麼
            {
                return "新增會員失敗";//這邊新增try catch，當catch到error的時候，就return 新增會員失敗 並且到時候再來程式碼裡面找原因
            }
        }

        public string EditMember(int id, Member member)
        {
            try
            {
                //更新過程中 先想法透過Id找到這筆資料
                var oldMember = _context.Member.FirstOrDefault(x => x.Id == id);
                //找到之後
                if (oldMember != null)
                {
                    oldMember.Account = member.Account;//拿傳進來Service的編輯後的會員資料取代找到的資料
                    oldMember.Password = member.Password;//拿傳進來Service的編輯後的會員資料取代找到的資料
                    oldMember.Name = member.Name != "" ? member.Name : oldMember.Name;//因為這個欄位不是必填，所以要判斷有沒有填寫，若沒有填寫就不改他
                    oldMember.Phone = member.Phone != "" ? member.Phone : oldMember.Phone;//因為這個欄位不是必填，所以要判斷有沒有填寫，若沒有填寫就不改他
                }

                _context.SaveChanges();//有新增或修改都要記得呼叫context去儲存資料
                return "修改會員成功";
            }
            catch (Exception e)
            {
                return "修改會員失敗";
            }
        }

        public string DeleteMember( int id)
        {
            try
            {
                //首先先找到那筆資料
                var member = _context.Member.FirstOrDefault(x => x.Id == id);
                if (member == null)
                {
                    return "刪除會員成功";//如果上面沒有找到那筆會員資料，就直接當作刪除成功回傳
                }

                _context.Member.Remove(member);//透過LinQ的語法，把這筆member資料刪除
                _context.SaveChanges();//這邊也需要儲存
                return "刪除會員成功";//刪除會員成功就回傳
            }
            catch (Exception e)
            {
                return "刪除會員失敗";//發生例外狀況就catch error來看
            }
        }
    }
}
