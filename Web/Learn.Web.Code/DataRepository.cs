using Learn.Bll;
using Learn.Bll.Repository;
using Learn.Util;
using Learn.Util.Extension;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Learn.Web.Code
{
    public class DataRepository : RepositoryFactory
    {
        public async Task<OperatorInfo> GetUserByToken(string token)
        {
			try
			{
                if (!Md5Helper.IsSafeSqlParam(token))
                {
                    return null;
                }
                token = token.ParseToString().Trim();

                var strSql = new StringBuilder();
                strSql.Append(@"SELECT  a.id as UserId, 
                                    a.user_account as Account,
                                    a.user_online as IsOnline,
                                    a.nick_name as NickName  ,
                                    a.real_name as RealName , 
                                    a.web_token as WebToken , 
                                    a.api_token as ApiToken ,  
                                    a.head_icon as HeadIcon , 
                                    a.open_id as OpenId ,  
                                    a.password as Password ,
                                    a.secret_key as Secretkey , 
                                    a.gender as Gender   
                            FROM    sys_user a
                            WHERE   web_token = '" + token + "' or api_token = '" + token + "'  ");
                var operatorInfo = await BaseRepository().FindObject<OperatorInfo>(strSql.ToString());
                //if (operatorInfo != null)
                //{
                //    #region 角色
                //    strSql.Clear();
                //    strSql.Append(@"SELECT  a.belong_id as RoleId
                //                    FROM    sys_user_belong a
                //                    WHERE   a.user_id = " + operatorInfo.UserId + " AND");
                //    //strSql.Append("         a.belong_type = " + UserBelongTypeEnum.Role.ParseToInt());
                //    strSql.Append("         a.belong_type = 1");
                //    IEnumerable<RoleInfo> roleList = await BaseRepository().FindList<RoleInfo>(strSql.ToString());
                //    operatorInfo.RoleIds = string.Join(",", roleList.Select(p => p.RoleId).ToArray());
                //    #endregion

                //    #region 部门名称
                //    strSql.Clear();
                //    strSql.Append(@"SELECT  a.department_name
                //                    FROM    sys_department a
                //                    WHERE   a.id = " + operatorInfo.DepartmentId);
                //    object departmentName = await BaseRepository().FindObject(strSql.ToString());
                //    operatorInfo.DepartmentName = departmentName.ParseToString();
                //    #endregion
                //}
                return operatorInfo;
            }
			catch (Exception ex)
			{

				throw;
			}
        }


        //public async Task<string> GetDataAuthor(string userId, bool isWrite = false) {

        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(userId))
        //        {
        //            return null;
        //        } 
        //        var strSql = new StringBuilder();
        //        StringBuilder whereSb = new StringBuilder(" select  id from sys_user where 1=1 ");
        //        string strAuthorData = "";
        //        if (isWrite)
        //        {
        //            strAuthorData = @"   SELECT    *
        //                                FROM      sys_authorize_data
        //                                WHERE     is_read=0 AND
        //                                object_id IN (
        //                                        SELECT  object_id
        //                                        FROM    sys_user_relation
        //                                        WHERE   user_id =@user_id) or object_id =@user_id";
        //        }
        //        else
        //        {
        //            strAuthorData = @"   SELECT    *
        //                                FROM      sys_authorize_data
        //                                WHERE     
        //                                object_id IN (
        //                                        SELECT  object_id
        //                                        FROM    sys_user_relation
        //                                        WHERE   user_id =@user_id) or object_id =@user_id";
        //        }
        //        var parameter = new List<DbParameter>();
        //        parameter.Add(DbParameterExtension.CreateDbParameter("@user_id", userId)); 
        //        whereSb.Append(string.Format("AND( UserId ='{0}'", userId));
        //        IEnumerable<AuthorizeDataEntity> listAuthorizeData = db.FindList<AuthorizeDataEntity>(strAuthorData, parameter);

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


    }
}
