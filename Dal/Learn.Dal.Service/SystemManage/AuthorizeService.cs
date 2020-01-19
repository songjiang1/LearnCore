using Learn.Bll;
using Learn.Bll.Repository;
using Learn.Dal.Entity.BaseManage;
using Learn.Dal.Entity.SystemManage;
using Learn.Dal.IService.SystemManage;
using Learn.Dal.Service.Base;
using Learn.Util.Enum;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Dal.Service.SystemManage
{
    public class AuthorizeService: BaseServices<ModuleEntity>, IAuthorizeService
    {
        /// <summary>
        /// 获取授权功能菜单
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<List<ModuleEntity>> GetModuleList(string userId)
        {
            string strSql = string.Empty;
            strSql= string.Format(@"SELECT  *
                                    FROM    dbo.sys_module
                                    WHERE   id IN (
                                            SELECT  item_id
                                            FROM    dbo.sys_authorize
                                            WHERE   item_type = '{0}'
                                                    AND ( [object_id] IN (
                                                          SELECT    [object_id]
                                                          FROM      dbo.sys_user_relation
                                                          WHERE     [user_id] = @UserId ) )
                                                    OR (item_type = '{0}' and [object_id] = @UserId) )
                                    AND is_enabled =1   AND is_delete = 0  Order By sort_code", (int)ViewTypeEnum.Menu);  
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", userId)); 
            var list = await this.BaseRepository().FindList<ModuleEntity>(strSql, parameter.ToArray());
            return list.ToList();
        }
        /// <summary>
        /// 获取授权功能按钮
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<List<ModuleButtonEntity>> GetModuleButtonList(string userId) {
            string strSql = string.Empty;
            strSql = string.Format(@"  SELECT  *
                            FROM    dbo.sys_module_button
                            WHERE   id IN (
                                    SELECT  item_id
                                    FROM    dbo.sys_authorize
                                    WHERE   item_type =  '{0}'
                                            AND ( [object_id] IN (
                                                  SELECT    [object_id]
                                                  FROM      dbo.sys_user_relation
                                                  WHERE     [user_id] = @UserId ) )
                                            OR (item_type =  '{0}' and [object_id] = @UserId) ) 
                              AND is_enabled =1   AND is_delete = 0  Order By sort_code", (int)ViewTypeEnum.Button);
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", userId));
            var list = await this.BaseRepository().FindList<ModuleButtonEntity>(strSql, parameter.ToArray());
            return list.ToList();
        }
        /// <summary>
        /// 获取授权功能视图
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public async Task<List<ModuleColumnEntity>> GetModuleColumnList(string userId)
        {
            string strSql = string.Empty;
            strSql = string.Format(@"  SELECT  *
                            FROM    dbo.sys_module_column
                            WHERE   id IN (
                                    SELECT  item_id
                                    FROM    sys_authorize
                                    WHERE   item_type =  '{0}'
                                            AND ( [object_id] IN (
                                                  SELECT    [object_id]
                                                  FROM      sys_user_relation
                                                  WHERE     [user_id] = @UserId ) )
                                            OR (item_type =  '{0}' and [object_id] = @UserId) ) AND is_enabled=1 AND is_delete=0 
                            Order By sort_code", (int)ViewTypeEnum.View);
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", userId));
            var list = await this.BaseRepository().FindList<ModuleColumnEntity>(strSql, parameter.ToArray());
            return list.ToList();
        }

        /// <summary>
        /// 获取授权功能Url、操作Url
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<AuthorizeUrlModel>> GetUrlList(string userId)
        {
            string strSql = string.Empty;
            strSql = string.Format(@"  SELECT  id AS AuthorizeId ,
                                    id  AS ModuleId,
                                    url_address  AS UrlAddress ,
                                    full_name  AS FullName,
                                    {0} AS ViewType
                            FROM    dbo.sys_module
                            WHERE   id IN (
                                    SELECT  item_id
                                    FROM    sys_authorize
                                    WHERE   item_type = {0}
                                            AND ( [object_id] IN (
                                                  SELECT    [object_id]
                                                  FROM      sys_user_relation
                                                  WHERE     [user_id] = @UserId ) )
                                            OR (item_type = {0} and [object_id]  = @UserId) )
                                    AND is_enabled = 1
                                    AND is_delete = 0
                                    AND is_menu = 1
                                    AND url_address IS NOT NULL
                            UNION
                            SELECT  id AS AuthorizeId ,
                                    module_id   AS ModuleId,
                                    action_address AS UrlAddress ,
                                    full_name  AS FullName,
                                    {1} AS ViewType
                            FROM    dbo.sys_module_button
                            WHERE   id IN (
                                    SELECT  item_id
                                    FROM    dbo.sys_authorize
                                    WHERE   item_type = {1}
                                            AND ( [object_id] IN (
                                                  SELECT    [object_id]
                                                  FROM      dbo.sys_user_relation
                                                  WHERE     [user_id] = @UserId ) )
                                            OR (item_type = {1} and [object_id] = @UserId) )
									AND is_enabled = 1
                                    AND is_delete = 0
                                    AND action_address IS NOT NULL", (int)ViewTypeEnum.Menu, (int)ViewTypeEnum.Button);
            var parameter = new List<DbParameter>();
            parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", userId));
            var list = await this.BaseRepository().FindList<AuthorizeUrlModel>(strSql, parameter.ToArray());
            return list.ToList();
        }
        /// <summary>
        /// 获取关联用户关系
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UserRelationEntity> GetUserRelationList(string userId) { 
            var list = await this.BaseRepository().FindList<UserRelationEntity>(t=>t.is_enabled==true && t.is_delete==false && t.user_id== userId);
            return list.FirstOrDefault();
        }
        /// <summary>
        /// 获得权限范围用户ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public async Task<string> GetDataAuthorUserId(string userId, bool isWrite = false)
        {
            string userIdList = await GetDataAuthor(userId, isWrite);
            if (string.IsNullOrWhiteSpace(userIdList))
            {
                return "";
            }
            var userListT = await this.BaseRepository().FindList<UserEntity>(userIdList);
            var userList= userListT.ToList();
            StringBuilder userSb = new StringBuilder("");
            if (userList != null)
            {
                int a = 0;
                foreach (var item in userList)
                {

                    userSb.Append(item.id);
                    if (a < userList.Count - 1)
                    {
                        userSb.Append(",");
                    }
                    a++;
                }
            }
            return userSb.ToString();
        }
        /// <summary>
        /// 获得可读数据权限范围SQL
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="isSystem"></param>
        /// <param name="isWrite"></param>
        /// <returns></returns>
        public async Task<string> GetDataAuthor(string userId, bool isSystem = false, bool isWrite = false)
        {
            if (isSystem)
            {
                return "";
            }
            string strAuthorData = string.Empty;
            if (isWrite)
            {
                strAuthorData = @"   SELECT    *
                                        FROM      dbo.sys_authorize_data
                                        WHERE     is_read=1 AND
                                        [object_id] IN (
                                                SELECT  [object_id]
                                                FROM    dbo.sys_user_relation
                                                WHERE   [user_id] =@UserId) or [object_id] =@UserId";
            }
            else
            {
                strAuthorData = @"  SELECT    *
                                        FROM      dbo.sys_authorize_data
                                        WHERE   [object_id] IN (
                                                SELECT  [object_id]
                                                FROM    dbo.sys_user_relation
                                                WHERE   [user_id] =@UserId) or [object_id] =@UserId"; 
            }

            var parameter = new List<DbParameter>();
            parameter.Add(DbParameterExtension.CreateDbParameter("@UserId", userId)); 
            StringBuilder whereSb = new StringBuilder(" select id from dbo.sys_user where 1=1 "); 
            whereSb.Append(string.Format("AND( id ='{0}'", userId)); 
            var list = await this.BaseRepository().FindList<AuthorizeDataEntity>(strAuthorData, parameter.ToArray());
            List<AuthorizeDataEntity> listAuthorizeData =   list.ToList();
            foreach (AuthorizeDataEntity item in listAuthorizeData)
            {

                switch (item.authorize_ype)
                {
                    //0代表最大权限
                    case AuthorizationTypeEnum.All://
                        return "";
                    case AuthorizationTypeEnum.OneSelf://本人
                        whereSb.Append("");
                        break;
                    //本人及下属
                    case AuthorizationTypeEnum.OneSelfAndSubordinate://
                        whereSb.Append(string.Format("  OR manager_id ='{0}'", userId));
                        break;
                    case AuthorizationTypeEnum.Department:
                        whereSb.Append(string.Format(@" OR department_id = (  SELECT  department_id
                                                                    FROM    sys_user
                                                                    WHERE   id ='{0}'
                                                                  )", userId));
                        break;
                    case AuthorizationTypeEnum.Organization:
                        whereSb.Append(string.Format(@"  OR organize_id = (    SELECT  organize_id
                                                                    FROM    sys_user
                                                                    WHERE   id ='{0}'
                                                                  )", userId));
                        break;
                    case AuthorizationTypeEnum.DetailSetting:
                        whereSb.Append(string.Format(@"  OR department_id='{0}'", item.resource_id));
                        break;
                }
            }
            whereSb.Append(")");
            return whereSb.ToString();
        }

    }
}
