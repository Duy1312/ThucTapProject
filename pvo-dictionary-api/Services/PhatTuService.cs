using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing.Printing;
using ThucTapQuanLyPhatTu.Common;
using ThucTapQuanLyPhatTu.Common.Enum;
using ThucTapQuanLyPhatTu.Entity;
using ThucTapQuanLyPhatTu.Models;
using ThucTapQuanLyPhatTu.Repositories;

namespace ThucTapQuanLyPhatTu.Services
{
    public class PhatTuService
    {
        private readonly PhatTuRepository _phatTuRepository;
        private readonly ApiOption _apiOption;
        private readonly IMapper _mapper;

        private readonly AppDbContext _databaseContext;
        public PhatTuService(ApiOption apiOption, AppDbContext databaseContext, IMapper mapper)
        {
            _phatTuRepository = new PhatTuRepository(apiOption, databaseContext, mapper);
            _apiOption = apiOption;
            _mapper = mapper;
            _databaseContext = databaseContext;
        }
        public object SearchPhatTus(string? hoTen, string? email, GioiTinh? gioiTinh, int? status, int pageIndex, int pageSize)
        {
            try
            {
                var query = _phatTuRepository.GetAll();
               
                if (!string.IsNullOrEmpty(hoTen))
                {
                    query = query.Where(pt =>
                        pt.Ten.ToLower().Contains(hoTen.ToLower()) ||
                        pt.PhapDanh.ToLower().Contains(hoTen.ToLower()) ||
                        (pt.Ho + " " + pt.TenDem + " " + pt.Ten).ToLower().Contains(hoTen.ToLower())
                    );
                }

                if (!string.IsNullOrEmpty(email))
                {
                    query = query.Where(pt => pt.Email == email);
                }

                if (gioiTinh.HasValue)
                {
                    query = query.Where(pt => pt.GioiTinh == gioiTinh.Value);
                }

                if (status.HasValue)
                {
                    query = query.Where(pt => pt.status == status.Value);
                }

                int totalItems = query.Count();
                int skip = (pageIndex - 1) * pageSize;

                query = query.Skip(skip).Take(pageSize);

                var result = new PagedResult<PhatTu>(query.ToList(), pageSize, totalItems);

                return result;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }
        public object GetListPhatTu(int pageIndex, int pageSize)
        {
            try
            {
                var PhatTuList = _phatTuRepository.GetAll().Where(pt => pt.isActive == true);
                int totalItems = PhatTuList.Count();
                int skip = (pageIndex - 1) * pageSize;
                PhatTuList = PhatTuList.Skip(skip).Take(pageSize);

                var result = new PagedResult<PhatTu>(PhatTuList.ToList(), pageSize, totalItems);
                return PhatTuList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object DeletePhatTu(int PhatTuId)
        {
            try
            {
                var phatTu = _phatTuRepository.GetById(PhatTuId);
                if (phatTu == null)
                {
                    throw new ValidateError(2000, "phatTu doesn’t exist");
                }
                phatTu.isActive = false;
                _phatTuRepository.UpdateByEntity(phatTu);
                _phatTuRepository.SaveChange();
                return phatTu;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
