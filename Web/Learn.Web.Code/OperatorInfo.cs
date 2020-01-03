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
        public bool IsOnline { get; set; }
        
        public string Account { get; set; }
        
        public string RealName { get; set; }
        public string NickName { get; set; }
        
        public string WebToken { get; set; }
        
        public string ApiToken { get; set; }
        
        public bool IsSystem { get; set; }
        
        public string HeadIcon { get; set; }
        [NotMapped] 
        /// <summary>
        /// 用户数据权限
        /// </summary>
        public AuthorizeDataModel DataAuthorize { get; set; }
    }
    
}
