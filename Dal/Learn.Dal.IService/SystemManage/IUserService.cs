
using Learn.Dal.IService.Base;
using Learn.Dal.Entity.BaseManage;
using System.Threading.Tasks;

namespace Learn.Dal.IService
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserService :IBaseServices<UserEntity>
	{
		Task<UserEntity> CheckLogin(string userName);
		bool ExistAccount(string account);
		bool ExistMobile(string mobile);
		bool ExistEmail(string email);
		Task<int> SaveForm(UserEntity userEntity);
		Task<int> UpdateUser(UserEntity userEntity);

	}
}

