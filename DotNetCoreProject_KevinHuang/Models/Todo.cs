﻿using System;
using System.Collections.Generic;

namespace DotNetCoreProject_KevinHuang.Models
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
    }
}
