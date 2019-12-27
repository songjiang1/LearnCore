using Learn.Util.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
namespace sys.Dal.Entity.BaseManage
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Table("sys_user")]
    public class UserEntity
    {

        /// <summary>
        /// 用户主键
        /// </summary>
        public string user_id { get; set; }


        /// <summary>
        /// 用户编码
        /// </summary>
        public string encode { get; set; }


        /// <summary>
        /// 登录账户
        /// </summary>
        public string user_account { get; set; }


        /// <summary>
        /// 登录密码
        /// </summary>
        public string user_password { get; set; }


        /// <summary>
        /// 密码秘钥
        /// </summary>
        public string secret_key { get; set; }


        /// <summary>
        /// 真实姓名
        /// </summary>
        public string real_name { get; set; }


        /// <summary>
        /// 呢称
        /// </summary>
        public string nick_name { get; set; }


        /// <summary>
        /// 头像
        /// </summary>
        public string head_icon { get; set; }


        /// <summary>
        /// 快速查询
        /// </summary>
        public string quick_query { get; set; }


        /// <summary>
        /// 简拼
        /// </summary>
        public string simple_spelling { get; set; }


        /// <summary>
        /// 全拼
        /// </summary>
        public string full_spelling { get; set; }


        /// <summary>
        /// 性别
        /// </summary>
        public int? gender { get; set; }


        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? birthday { get; set; }


        /// <summary>
        /// 手机
        /// </summary>
        public string mobile { get; set; }


        /// <summary>
        /// 电话
        /// </summary>
        public string telephone { get; set; }


        /// <summary>
        /// 电子邮件
        /// </summary>
        public string email { get; set; }


        /// <summary>
        /// QQ号
        /// </summary>
        public string qicq { get; set; }


        /// <summary>
        /// 微信号
        /// </summary>
        public string wechat { get; set; }


        /// <summary>
        /// MSN
        /// </summary>
        public string msn { get; set; }


        /// <summary>
        /// 主管主键
        /// </summary>
        public string manager_id { get; set; }


        /// <summary>
        /// 主管
        /// </summary>
        public string manager { get; set; }


        /// <summary>
        /// 机构主键
        /// </summary>
        public string organize_id { get; set; }


        /// <summary>
        /// 部门主键
        /// </summary>
        public string department_id { get; set; }


        /// <summary>
        /// 角色主键
        /// </summary>
        public string role_id { get; set; }


        /// <summary>
        /// 岗位主键
        /// </summary>
        public string duty_id { get; set; }


        /// <summary>
        /// 岗位名称
        /// </summary>
        public string duty_name { get; set; }


        /// <summary>
        /// 职位主键
        /// </summary>
        public string post_id { get; set; }


        /// <summary>
        /// 职位名称
        /// </summary>
        public string post_name { get; set; }


        /// <summary>
        /// 工作组主键
        /// </summary>
        public string work_group_id { get; set; }


        /// <summary>
        /// 安全级别
        /// </summary>
        public int? security_level { get; set; }


        /// <summary>
        /// 在线状态
        /// </summary>
        public Boolean? user_online { get; set; }


        /// <summary>
        /// 微信OpenId
        /// </summary>
        public string  openId { get; set; }


        /// <summary>
        /// 单点登录标识
        /// </summary>
        public int? single_flag { get; set; }


        /// <summary>
        /// 密码提示问题
        /// </summary>
        public string question { get; set; }


        /// <summary>
        /// 密码提示答案
        /// </summary>
        public string answer_question { get; set; }


        /// <summary>
        /// 允许多用户同时登录
        /// </summary>
        public int? check_online { get; set; }


        /// <summary>
        /// 允许登录时间开始
        /// </summary>
        public DateTime? allow_start_time { get; set; }


        /// <summary>
        /// 允许登录时间结束
        /// </summary>
        public DateTime? allow_end_time { get; set; }


        /// <summary>
        /// 暂停用户开始日期
        /// </summary>
        public DateTime? lock_start_date { get; set; }


        /// <summary>
        /// 暂停用户结束日期
        /// </summary>
        public DateTime? lock_end_date { get; set; }


        /// <summary>
        /// 第一次访问时间
        /// </summary>
        public DateTime? first_visit { get; set; }


        /// <summary>
        /// 上一次访问时间
        /// </summary>
        public DateTime? previous_visit { get; set; }


        /// <summary>
        /// 最后访问时间
        /// </summary>
        public DateTime? last_visit { get; set; }


        /// <summary>
        /// 登录次数
        /// </summary>
        public int? logon_count { get; set; }


        /// <summary>
        /// 排序码
        /// </summary>
        public int? sort_code { get; set; }


        /// <summary>
        /// 删除标记
        /// </summary>
        public Boolean? is_delete { get; set; }


        /// <summary>
        /// 有效标志
        /// </summary>
        public Boolean? is_enabled { get; set; }


        /// <summary>
        /// 备注
        /// </summary>
        public string description { get; set; }


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


        /// <summary>
        /// 用户来源 如 1:网站注册，2，APP注册
        /// </summary>
        public PlatformEnum? usource { get; set; }

        public string web_token { get; set; }
        public string api_token { get; set; }
    }
}