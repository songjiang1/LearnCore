using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace Learn.Dal.Entity.BaseManage
{
    [Table("sys_role")]
    /// <summary>
    /// 
    /// </summary>
    public class RroleEntity
    {
        
       
        /// <summary>
        /// 机构主键
        /// </summary>
        public string organize_id { get ; set ; }

       
        /// <summary>
        /// 分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>
        public int? category { get ; set ; }

       
        /// <summary>
        /// 角色编码
        /// </summary>
        public string encode { get ; set ; }

       
        /// <summary>
        /// 角色名称
        /// </summary>
        public string full_name { get ; set ; }

       
        /// <summary>
        /// 公共角色
        /// </summary>
        public Boolean is_public { get ; set ; }

       
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? overdue_ime { get ; set ; }

       
        /// <summary>
        /// 排序码
        /// </summary>
        public int? sort_code { get ; set ; }  
        /// <summary>
        /// 备注
        /// </summary>
        public string description { get ; set ; }

        
    }
}