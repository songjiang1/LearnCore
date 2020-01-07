
using Learn.Web.Code;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learn.Dal.Entity
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class BaseEntity
    {

        /// <summary>
        /// token
        /// </summary>
        [NotMapped]
        public string token { get; set; }
        [Key]
        public string id { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public Boolean is_delete { get; set; }


        /// <summary>
        /// 有效标志
        /// </summary>
        public Boolean is_enabled { get; set; }

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

        public  async virtual void Create()
        {
            this.id = Guid.NewGuid().ToString(); 
            this.create_date = DateTime.Now;
            this.is_delete = false;
            this.is_enabled = true;
            OperatorInfo user = await Operator.Instance.Current(token);
            if (user != null)
            {
                this.create_user_id = user.UserId;
                this.create_user_name = user.Account;
            } 
        }
        
        /// <summary>
        /// 编辑调用
        /// </summary>
        /// <param name="keyValue">主键值</param> 
        public async virtual void Modify(string keyValue)
        {
            this.id = keyValue;
            this.modify_date = DateTime.Now;
            OperatorInfo user = await Operator.Instance.Current(token);
            if (user != null)
            {
                this.modify_user_id = user.UserId;
                this.modify_user_name = user.Account;
            }
        }

    }
}
