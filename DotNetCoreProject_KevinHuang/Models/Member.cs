using System;
using System.Collections.Generic;

namespace DotNetCoreProject_KevinHuang.Models
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
