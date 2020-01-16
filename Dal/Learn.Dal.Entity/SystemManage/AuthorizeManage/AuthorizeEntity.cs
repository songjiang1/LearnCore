
using Learn.Util.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.11.27
    /// 描 述：授权功能
    /// </summary
    [Table("sys_authorize")]
    public class AuthorizeEntity : BaseEntity
    {
        #region 实体成员
         
        /// <summary>
        /// 对象分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>		
        public RoleCategoryEnum category { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>		
        public string object_id { get; set; }
        /// <summary>
        /// 项目类型:1-菜单2-按钮3-视图4表单
        /// </summary>		
        public ViewTypeEnum item_type { get; set; }
        /// <summary>
        /// 项目主键
        /// </summary>		
        public string item_id { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? sort_code { get; set; }
        
        #endregion
         
    }
}