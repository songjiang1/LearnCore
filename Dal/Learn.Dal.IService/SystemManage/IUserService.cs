
using Learn.Dal.IService.Base;
using sys.Dal.Entity.BaseManage;
using System.Threading.Tasks;

namespace Learn.Dal.IService
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserService :IBaseServices<UserEntity>
	{ 
		Task<UserEntity> CheckLogin(string userName);
	}
}
