﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using voidUpdate.Data.Models;

namespace voidUpdate.Data
{
    public interface IApplicationUser
    {
        ApplicationUser GetById(string id);
        IEnumerable<ApplicationUser> GetAll();

        Task SetProfileImage(string id, Uri uri);
        Task IncrementRating(string id, Type type);
    }
}
