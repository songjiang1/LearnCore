using System;
using System.Collections.Generic;
using System.Text;

namespace Learn.Dal.Model.Param.SystemManage
{
    public class UserListParam : DateTimeParam
    {
        public string UserName { get; set; }

        public string Mobile { get; set; }

        public int? UserStatus { get; set; }

        public string  DepartmentId { get; set; }

        public List<string> ChildrenDepartmentIdList { get; set; }

        public string UserIds { get; set; }
    }

    public class ChangePasswordParam
    {
        public string  Id { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
