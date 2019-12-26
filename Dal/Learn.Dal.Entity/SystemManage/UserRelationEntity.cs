using System;
using System.Data;
namespace sys.Dal.Entity.BaseManage
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRelationEntity
    {
       
        /// <summary>
        /// 用户关系主键
        /// </summary>
        public string user_relation_id { get ; set  ; }

       
        /// <summary>
        /// 用户主键
        /// </summary>
        public string user_id { get ; set ; }

       
        /// <summary>
        /// 分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>
        public int? category { get ; set ; }

       
        /// <summary>
        /// 对象主键
        /// </summary>
        public string object_id { get ; set ; }

       
        /// <summary>
        /// 默认对象
        /// </summary>
        public Boolean? is_default { get ; set ; }

       
        /// <summary>
        /// 排序码
        /// </summary>
        public int? sort_code { get ; set ; }

       
        /// <summary>
        /// 
        /// </summary>
        public DateTime? create_date { get ; set ; }

       
        /// <summary>
        /// 
        /// </summary>
        public string create_user_id { get ; set ; }

       
        /// <summary>
        /// 
        /// </summary>
        public string create_user_name { get ; set ; }
    }
}