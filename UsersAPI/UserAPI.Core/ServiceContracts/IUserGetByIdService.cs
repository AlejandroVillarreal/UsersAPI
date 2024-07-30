﻿using UserAPI.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPI.Core.ServiceContracts
{
	public interface IUserGetByIdService
	{
		Task<UserEntity> GetByIdAsync(Guid? id);
	}
}
