
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity.SystemManage
{
    /// <summary>
    /// 版 本 2.0
    /// Copyright (c)  
    /// 创建人：宋江
    /// 日 期：2016.04.26 09:16
    /// 描 述：系统表单实例
    /// </summary>
    [Table("sys_module_forminstance")]
    public class ModuleFormInstanceEntity : BaseEntity
    {
        #region 实体成员 
        /// <summary>
        /// 功能主键
        /// </summary>
        public string form_id { set; get; }
        /// <summary>
        /// 编码
        /// </summary>
        public string form_instance_json { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string object_id { set; get; }
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


