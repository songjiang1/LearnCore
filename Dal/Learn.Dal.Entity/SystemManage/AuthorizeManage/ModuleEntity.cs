 
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.10.27 09:16
    /// 描 述：系统功能
    /// </summary>
    /// 
    [Table("sys_module")]
    public class ModuleEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 父级主键
        /// </summary>
        public string parente_id { set; get; }
        /// <summary>
        /// 编号
        /// </summary>
        public string en_code { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string full_name { set; get; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { set; get; }
        /// <summary>
        /// 导航地址
        /// </summary>
        public string url_address { set; get; }
        /// <summary>
        /// 导航目标
        /// </summary>
        public string target { set; get; }
        /// <summary>
        /// 菜单选项
        /// </summary>
        public bool is_menu { set; get; }
        /// <summary>
        /// 允许展开
        /// </summary>
        public bool allow_expand { set; get; }
        /// <summary>
        /// 是否公开
        /// </summary>
        public bool is_public { set; get; }
        /// <summary>
        /// 允许编辑
        /// </summary>
        public bool allow_edit { set; get; }
        /// <summary>
        /// 允许删除
        /// </summary>
        public bool allow_delete { set; get; }
        /// <summary>
        /// 排序码
        /// </summary>
        public int? sort_code { set; get; }
       
        /// <summary>
        /// 备注
        /// </summary>
        public string description { set; get; } 
        #endregion

         
    }
}
