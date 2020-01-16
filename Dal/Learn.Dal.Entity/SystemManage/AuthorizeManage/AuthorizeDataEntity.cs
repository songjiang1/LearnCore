using Learn.Util.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Learn.Dal.Entity.BaseManage
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Table("sys_authorize_data")]
    public class AuthorizeDataEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 授权类型:1-仅限本人2-仅限本人及下属3-所在部门4-所在组织5-按明细设置
        /// </summary>		
        public AuthorizationTypeEnum authorize_ype { get; set; }
        /// <summary>
        /// 对象分类:1-部门2-角色3-岗位4-职位5-工作组
        /// </summary>		
        public RoleCategoryEnum category { get; set; }
        /// <summary>
        /// 对象主键
        /// </summary>		
        public string object_id { get; set; }
        /// <summary>
        /// 项目Id
        /// </summary>		
        public string item_id { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>		
        public string item_name { get; set; }
        /// <summary>
        /// 资源主键
        /// </summary>		
        public string resource_id { get; set; }
        /// <summary>
        /// 只读
        /// </summary>		
        public bool is_read { get; set; }
        /// <summary>
        /// 约束表达式
        /// </summary>		
        public string authorize_constraint { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? sort_code { get; set; }
        
        #endregion

    }
}