using System;
using System.Data;
namespace sys.Dal.Entity.BaseManage
{
    /// <summary>
    /// 
    /// </summary>
    public class RroleEntity
    {
       
        /// <summary>
        /// 角色主键
        /// </summary>
        public string role_id { get ; set  ; }

       
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
        public Boolean? is_public { get ; set ; }

       
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime? overdue_ime { get ; set ; }

       
        /// <summary>
        /// 排序码
        /// </summary>
        public int? sort_code { get ; set ; }

       
        /// <summary>
        /// 删除标记
        /// </summary>
        public Boolean? is_delete { get ; set ; }

       
        /// <summary>
        /// 有效标志
        /// </summary>
        public Boolean? is_enabled { get ; set ; }

       
        /// <summary>
        /// 备注
        /// </summary>
        public string description { get ; set ; }

       
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

       
        /// <summary>
        /// 
        /// </summary>
        public DateTime? modify_date { get ; set ; }

       
        /// <summary>
        /// 
        /// </summary>
        public string modify_user_id { get ; set ; }

       
        /// <summary>
        /// 
        /// </summary>
        public string modify_user_name { get ; set ; }
    }
}