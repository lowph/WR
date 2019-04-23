using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WR.Models.Base
{
    /// <summary>
    /// 项目任务
    /// </summary>
    public class ProjectsTask
    {
        public int ID { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public string ParentID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 优先
        /// </summary>
        public int IsPriority { get; set; }
        /// <summary>
        /// 完成
        /// </summary>
        public int IsCompleted { get; set; }
    }
}
