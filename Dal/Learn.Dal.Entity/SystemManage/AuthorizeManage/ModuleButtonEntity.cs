
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2015.08.01 14:00
    /// 描 述：系统按钮
    /// </summary>
    ///  
    [Table("sys_module_button")]
    public class ModuleButtonEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 功能主键
        /// </summary>		
        public string module_id { get; set; }
        /// <summary>
        /// 父级主键
        /// </summary>		
        public string parente_id { get; set; }
        /// <summary>
        /// 图标
        /// </summary>		
        public string icon { get; set; }
        /// <summary>
        /// 编码
        /// </summary>		
        public string en_code { get; set; }
        /// <summary>
        /// 名称
        /// </summary>		
        public string full_name { get; set; }
        /// <summary>
        /// Action地址
        /// </summary>		
        public string action_address { get; set; }
        /// <summary>
        /// 排序码
        /// </summary>		
        public int? sort_code { get; set; }
        #endregion

         
    }
}