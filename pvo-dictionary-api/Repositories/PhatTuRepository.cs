using AutoMapper;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Request;
using ThucTapQuanLyPhatTu.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using ThucTapQuanLyPhatTu.Entity;

namespace ThucTapQuanLyPhatTu.Repositories
{
    public class PhatTuRepository : BaseRespository<PhatTu>
    {
        private IMapper _mapper;
        public PhatTuRepository(ApiOption apiConfig, AppDbContext databaseContext, IMapper mapper) : base(apiConfig, databaseContext)
        {
            this._mapper = mapper;
        }

        /// <summary>
        /// UserLogin function. That return User by user login request
        /// </summary>
        /// <param name="userLoginRequest"></param>
        /// <returns></returns>
        public PhatTu UserLogin(UserLoginRequest userLoginRequest)
        {
            try
            {
                var passwordByMD5 = Untill.CreateMD5(userLoginRequest.password);
                return Model.Where(row => row.UserName == userLoginRequest.username && row.Password == passwordByMD5).FirstOrDefault();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        ///// <summary>
        ///// Check user register
        ///// </summary>
        ///// <param name="user"></param>
        ///// <returns></returns>
        //public bool CheckUserRegister(User user)
        //{
        //    try
        //    {
        //        var userlist = Model.Where(row => row.Username == user.Username || row.NumberPhone == user.NumberPhone).ToList();
        //        if(userlist.Count > 0)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        
    }
}
