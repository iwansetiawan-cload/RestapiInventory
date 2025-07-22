using RestapiInventory.Dao;
using RestapiInventory.Dto.Common;
using RestapiInventory.Models;

namespace RestapiInventory.Services
{
    public class UserProfileService(UserProfileDao userProfileDao)
    {
        private UserProfileDao _userProfileDao = userProfileDao;
        public FormDto<IList<UserProfile>> GetAllData()
        {
            try
            {
                IList<UserProfile> list = _userProfileDao.GetAll();
                if (list == null)
                {
                    return new FormDto<IList<UserProfile>>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
                }

                return new FormDto<IList<UserProfile>>(list);
            }
            catch (Exception)
            {
                return new FormDto<IList<UserProfile>>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
            }
            
        }
        public FormDto<IList<UserProfile>> GetByDivision(string keyword)
        {
            try
            {
                IList<UserProfile> list = _userProfileDao.GetByDivision(keyword);
                if (list == null)
                {
                    return new FormDto<IList<UserProfile>>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
                }
                return new FormDto<IList<UserProfile>>(list);
            }
            catch (Exception)
            {
                return new FormDto<IList<UserProfile>>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");              
            }
            
        }
        public FormDto<IList<UserProfile>> GetByName(string keyword)
        {
            try
            {
                IList<UserProfile> list = _userProfileDao.GetByName(keyword);
                if (list == null)
                {
                    return new FormDto<IList<UserProfile>>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
                }

                return new FormDto<IList<UserProfile>>(list);
            }
            catch (Exception)
            {
                return new FormDto<IList<UserProfile>>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
            }
            
        }
        public FormDto<UserProfile> GetById(string id)
        {
            try
            {
                UserProfile result = _userProfileDao.GetById(id);
                if (result == null)
                {
                    return new FormDto<UserProfile>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
                }

                return new FormDto<UserProfile>(result);
            }
            catch (Exception)
            {
                return new FormDto<UserProfile>("DATA_NOT_FOUND", "Data user tidak dapat ditemukan");
            }

        }
    }
}
