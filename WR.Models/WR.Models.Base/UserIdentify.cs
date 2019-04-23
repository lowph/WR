using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR.Models.Base
{
    /// <summary>
    /// 用户认证
    /// </summary>
    public class UserIdentify
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }
    }
}
