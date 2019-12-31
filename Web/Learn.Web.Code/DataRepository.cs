using Learn.Bll.Repository;
using Learn.Util;
using Learn.Util.Extension;
using System;
using System.Collections.Generic;
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
                                   -- a.user_status as UserStatus,
                                    a.user_online as IsOnline,
                                    a.nick_name as NickName  
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

    }
}
