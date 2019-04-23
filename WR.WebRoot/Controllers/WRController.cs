using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WR.Models.ADODdesign;

namespace WR.WebRoot.Controllers
{
    [Authorize]
    public class WRController : Controller
    {
        // GET: WR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Project()
        {
            WRProjectDBDataContext dbContext = new WRProjectDBDataContext();
            var res = dbContext.项目信息.Select(e => e).ToList();
            var tree = TreeNode.GetTree(res);
            this.ViewBag.tree = Newtonsoft.Json.JsonConvert.SerializeObject(tree);
            return View();
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectEmpty()
        {
            return View();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public ActionResult ProjectEdit(int? id, int? parentID)
        {
            if (id != null)
            {
                WRProjectDBDataContext dbContext = new WRProjectDBDataContext();
                var project = dbContext.项目信息.SingleOrDefault((e => e.ID == id.Value));
                if (project == null)
                {
                    throw new Exception("未找到id=" + id + "的项目信息");
                }
                return View(project);
            }
            else if (parentID != null)
            {
                WRProjectDBDataContext dbContext = new WRProjectDBDataContext();
                var parentProject = dbContext.项目信息.Where(e => e.ID == parentID.Value).SingleOrDefault();
                项目信息 project = new 项目信息() { 启用标识 = true};
                project.上级项目信息 = parentProject;
                return View(project);
            }
            throw new Exception("id和parentid不能同时为空");
        }


        [HttpPost]
        public ActionResult ProjectEdit(项目信息 project)
        {
            if (string.IsNullOrEmpty(project.名称))
            {
                throw new ArgumentNullException("project.name");
            }

            WRProjectDBDataContext dbContext = new WRProjectDBDataContext();
            if (project.ID == 0)
            {
                //新增
                project.创建时间 = DateTime.Now;
                dbContext.项目信息.InsertOnSubmit(project);
            }
            else
            {
                //编辑
                var res = dbContext.项目信息.SingleOrDefault(e => e.ID == project.ID);
                res.名称 = project.名称;
                res.启用标识 = project.启用标识;
            }
            dbContext.SubmitChanges();
            return Redirect("/wr/projectedit?id=" + project.ID);
        }
    }

    public class TreeNode
    {
        public string id { get; set; }
        public string text { get; set; }
        public List<TreeNode> nodes { get; set; }

        private static Dictionary<string, TreeNode> TREES = new Dictionary<string, TreeNode>();
        public static List<TreeNode> GetTree(List<项目信息> projects)
        {
            List<TreeNode> tree = new List<TreeNode>();
            if (projects != null && projects.Count > 0)
            {
                var topProjects = projects.Where(e => e.上级ID == null).ToList();
                if (topProjects != null && topProjects.Count > 0)
                {
                    foreach (var item in topProjects)
                    {
                        tree.Add(GetTree(item, projects));
                    }
                }
            }
            return tree;
        }

        public static TreeNode GetTree(项目信息 project, List<项目信息> projects)
        {
            var tree = new TreeNode();
            tree.id = project.ID.ToString();
            tree.text = project.名称;
            //找到下级
            var childProjects = projects.Where(e => e.上级ID != null && e.上级ID.Value == project.ID).ToList();
            if (childProjects != null && childProjects.Count > 0)
            {
                tree.nodes = new List<TreeNode>();
                foreach (var item in childProjects)
                {
                    tree.nodes.Add(GetTree(item, projects));
                }
            }
            return tree;
        }
    }
}