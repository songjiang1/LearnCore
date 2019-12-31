
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// 新增调用
        /// </summary>
        [NotMapped]
        public string Token { get; set; }

        public string id { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? create_date { get; set; }


        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string create_user_id { get; set; }


        /// <summary>
        /// 创建用户
        /// </summary>
        public string create_user_name { get; set; }


        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? modify_date { get; set; }


        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string modify_user_id { get; set; }


        /// <summary>
        /// 修改用户
        /// </summary>
        public string modify_user_name { get; set; }

        public virtual void Create()
        {
            this.id = Guid.NewGuid().ToString(); 
            this.create_date = DateTime.Now;
            //this.create_user_id = OperatorProvider.Provider.Current().UserId;
            //this.create_user_name = OperatorProvider.Provider.Current().UserName;
        }
        /// <summary>
        /// 新增调用
        /// </summary>
        public virtual void CreateApp()
        {
        }
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue">主键值</param>
        public virtual void Modify(string keyValue)
        {
            this.id = keyValue;
            this.modify_date = DateTime.Now;
            //this.modify_user_id = OperatorProvider.Provider.Current().UserId;
            //this.modify_user_name = OperatorProvider.Provider.Current().UserName;
        }
        
    }
}
