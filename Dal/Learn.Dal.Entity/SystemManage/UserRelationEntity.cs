using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Learn.Dal.Entity.BaseManage
{
    [Table("sys_user_relation")]
    /// <summary>
    /// 
    /// </summary>
    public class UserRelationEntity:BaseEntity
    {
         
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
        public Boolean is_default { get ; set ; }

       
        /// <summary>
        /// 排序码
        /// </summary>
        public int sort_code { get ; set ; } 
        
    }
}