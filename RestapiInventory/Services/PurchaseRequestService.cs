using RestapiInventory.Dao;
using RestapiInventory.Dto.Common;
using RestapiInventory.Models;

namespace RestapiInventory.Services
{
    public class PurchaseRequestService(PurchaseRequestHeaderDao purchaseRequestHeaderDao, PurchaseRequestDetailDao purchaseRequestDetailDao)
    {
        private PurchaseRequestHeaderDao _purchaseRequestHeaderDao = purchaseRequestHeaderDao;
        private PurchaseRequestDetailDao _purchaseRequestDetailDao = purchaseRequestDetailDao;
        public FormDto<PurchaseRequestHeader> GetPurchaseRequestHeaderById(string id)
        {
            try
            {
                PurchaseRequestHeader obj = _purchaseRequestHeaderDao.GetById(id);
                return new FormDto<PurchaseRequestHeader>(obj);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return new FormDto<PurchaseRequestHeader>("ERORR", error);
            }
            
        }
        public FormDto<IList<PurchaseRequestDetail>>  GetPurchaseRequestDetailByHeaderId(string id)
        {
            IList<PurchaseRequestDetail> list = _purchaseRequestDetailDao.GetByHeaderId(id);

            //if (id == null || list == null)
            //{
            //    return new FormDto<PurchaseRequestDetail>("DATA_NOT_FOUND", "Data detail tidak dapat ditemukan");
            //}

            return new FormDto<IList<PurchaseRequestDetail>>(list);
        }
        public FormDto<PurchaseRequestHeader> CreateHeader(PurchaseRequestHeader entity)
        {
            try
            {                
                entity.Id = Guid.NewGuid().ToString();
                var result = _purchaseRequestHeaderDao.Add(entity);
                if (result.IsCompletedSuccessfully)
                {
                    return new FormDto<PurchaseRequestHeader>(entity);
                }
                else
                {
                    return new FormDto<PurchaseRequestHeader>("FAILED_POST_TO_PurchaseRequestHeader", "Failed to make POST request to Purchase Request Header", null);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return new FormDto<PurchaseRequestHeader>("FAILED_POST_TO_PurchaseRequestHeader", "Failed to make POST request to Purchase Request Header", null);
            }           

        }
    }
}
