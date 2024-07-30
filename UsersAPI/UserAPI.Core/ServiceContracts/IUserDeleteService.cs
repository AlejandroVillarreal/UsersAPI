using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.ServiceContracts
{
	public interface IUserDeleteService
	{
		Task<bool> DeleteAsync(Guid? id);
	}
}
