using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Util.Enum
{
    public enum StatusEnum
    {
        [Description("禁用")]
        No = 0,

        [Description("启用")]
        Yes = 1
    }

    public enum IsEnum
    {
        [Description("是")]
        Yes = 1,

        [Description("否")]
        No = 0
    }

    public enum NeedEnum
    {
        [Description("不需要")]
        NotNeed = 0,

        [Description("需要")]
        Need = 1
    }

    public enum OperateStatusEnum
    {
        [Description("失败")]
        Fail = 0,

        [Description("成功")]
        Success = 1
    }

    public enum UploadFileType
    {
        [Description("头像")]
        Portrait = 1,

        [Description("新闻图片")]
        News = 2
    }

    public enum PlatformEnum
    {
        [Description("Web后台")]
        Web = 1,

        [Description("WebApi")]
        WebApi = 2
    }

    public enum PayStatusEnum
    {
        [Description("未知")]
        Unknown = 0,

        [Description("已支付")]
        Success = 1,

        [Description("转入退款")]
        Refund = 2,

        [Description("未支付")]
        NotPay = 3,

        [Description("已关闭")]
        Closed = 4,

        [Description("已撤销（付款码支付）")]
        Revoked = 5,

        [Description("用户支付中（付款码支付）")]
        UserPaying = 6,

        [Description("支付失败(其他原因，如银行返回失败)")]
        PayError = 7
    }
    public enum RequestTypeEnum
    {

        [Description("成功")]
        Success = 200,

        [Description("系统错误")]
        Error = 404,

        [Description("请求错误")]
        Fail = 0

    }
    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationTypeEnum
    {
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 0,
        /// <summary>
        /// 登陆
        /// </summary>
        [Description("登录")]
        Login = 1,
        /// <summary>
        /// 登陆
        /// </summary>
        [Description("退出")]
        Exit = 2,
        /// <summary>
        /// 访问
        /// </summary>
        [Description("访问")]
        Visit = 3,
        /// <summary>
        /// 离开
        /// </summary>
        [Description("离开")]
        Leave = 4,
        /// <summary>
        /// 新增
        /// </summary>
        [Description("新增")]
        Create = 5,
        /// <summary>
        /// 删除
        /// </summary>
        [Description("删除")]
        Delete = 6,
        /// <summary>
        /// 修改
        /// </summary>
        [Description("修改")]
        Update = 7,
        /// <summary>
        /// 提交
        /// </summary>
        [Description("提交")]
        Submit = 8,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("异常")]
        Exception = 9,
        /// <summary>
        /// 异常
        /// </summary>
        [Description("移动登录")]
        AppLogin = 10
    }
    /// <summary>
    /// 角色分类  1-部门2-角色3-岗位4-职位5-工作组
    /// </summary>
    public enum RoleCategoryEnum
    {
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        Department = 1,
        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        Role = 2,
        /// <summary>
        /// 岗位
        /// </summary>
        [Description("岗位")]
        Post = 3,
        /// <summary>
        /// 职位
        /// </summary>
        [Description("职位")]
        Position = 4,
        /// <summary>
        /// 工作组
        /// </summary>
        [Description("工作组")]
        WorkingGroup = 5
        
    }
    /// <summary>
    /// 授权类型:1-仅限本人2-仅限本人及下属3-所在部门4-所在组织5-按明细设置
    /// </summary>
    public enum AuthorizationTypeEnum
    {
        /// <summary>
        /// 所有权限
        /// </summary>
        [Description("所有权限")]
        All = 0,
        /// <summary>
        /// 仅限本人
        /// </summary>
        [Description("仅限本人")]
        OneSelf = 1,
        /// <summary>
        /// 仅限本人及下属
        /// </summary>
        [Description("仅限本人及下属")]
        OneSelfAndSubordinate = 2,
        /// <summary>
        /// 所在部门
        /// </summary>
        [Description("所在部门")]
        Department = 3,
        /// <summary>
        /// 所在组织
        /// </summary>
        [Description("所在组织")]
        Organization = 4,
        /// <summary>
        /// 按明细设置
        /// </summary>
        [Description("按明细设置")]
        DetailSetting = 5

    }


    /// <summary>
    /// 授权类型:项目类型:1-菜单2-按钮3-视图4表单
    /// </summary>
    public enum ViewTypeEnum
    {
        /// <summary>
        /// 菜单
        /// </summary>
        [Description("菜单")]
        Menu = 1,
        /// <summary>
        /// 按钮
        /// </summary>
        [Description("按钮")]
        Button = 2,
        /// <summary>
        /// 视图
        /// </summary>
        [Description("视图")]
        View = 3,
        /// <summary>
        /// 表单
        /// </summary>
        [Description("表单")]
        Form = 4

    }




}
