﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR.Models.Base
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime LastLoginTime { get; set; }
    }
}
