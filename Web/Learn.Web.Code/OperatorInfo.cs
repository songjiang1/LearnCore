using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.Web.Code
{
    public class OperatorInfo
    {
        public string  UserId { get; set; }
        [NotMapped]
        public int? UserStatus { get; set; }
        public bool IsOnline { get; set; }
        [NotMapped]
        public string Account { get; set; }
        [NotMapped]
        public string RealName { get; set; }
        public string NickName { get; set; }
        [NotMapped]
        public string WebToken { get; set; }
        [NotMapped]
        public string ApiToken { get; set; }
        [NotMapped]
        public int? IsSystem { get; set; }
        [NotMapped]
        public string Portrait { get; set; }
        [NotMapped] 
        public string  DepartmentId { get; set; }

        [NotMapped]
        public string DepartmentName { get; set; }

        /// <summary>
        /// 岗位Id
        /// </summary>
        [NotMapped]
        public string PositionIds { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [NotMapped]
        public string RoleIds { get; set; }
    }
    public class RoleInfo
    {
        public long RoleId { get; set; }
    }

}
