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
        public FormDto<IList<PurchaseRequestDetail>> GetPurchaseRequestDetailByHeaderId(string id)
        {
            try
            {
                IList<PurchaseRequestDetail> list = _purchaseRequestDetailDao.GetByHeaderId(id.ToUpper());
                if (id == null || list == null)
                {
                    return new FormDto<IList<PurchaseRequestDetail>>("DATA_NOT_FOUND", "Data detail tidak dapat ditemukan");
                }

                return new FormDto<IList<PurchaseRequestDetail>>(list);
            }
            catch (Exception)
            {
                return new FormDto<IList<PurchaseRequestDetail>>("DATA_NOT_FOUND", "Data detail tidak dapat ditemukan");
            }
           
        }
        public FormDto<PurchaseRequestViewModel> GetPurchaseRequestByNoreq(string noreq)
        {
            try
            {
                PurchaseRequestViewModel PR = new PurchaseRequestViewModel();
                PR.purchaseRequestHeader = _purchaseRequestHeaderDao.GetByNoDocument(noreq);
                if (PR.purchaseRequestHeader != null)
                    PR.purchaseRequestDetails = _purchaseRequestDetailDao.GetByHeaderId(PR.purchaseRequestHeader.Id.ToUpper());

                return new FormDto<PurchaseRequestViewModel>(PR);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return new FormDto<PurchaseRequestViewModel>("ERORR", error);
            }

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
                    return new FormDto<PurchaseRequestHeader>("FAILED_POST_TO_PRHEADER", "Failed to make POST request to Purchase Request Header", null);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return new FormDto<PurchaseRequestHeader>("FAILED_POST_TO_PRHEADER", "Failed to make POST request to Purchase Request Header", null);
            }           

        }
        public FormDto<PurchaseRequestDetail> CreateDetail(PurchaseRequestDetail entity)
        {
            try
            {
                entity.Id = Guid.NewGuid().ToString();
                var result = _purchaseRequestDetailDao.Add(entity);
                if (result.IsCompletedSuccessfully)
                {
                    return new FormDto<PurchaseRequestDetail>(entity);
                }
                else
                {
                    return new FormDto<PurchaseRequestDetail>("FAILED_POST_TO_PRDETAIL", "Failed to make POST request to Purchase Request Detail", null);
                }

            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                return new FormDto<PurchaseRequestDetail>("FAILED_POST_TO_PRDETAIL", "Failed to make POST request to Purchase Request Detail", null);
            }

        }
    }
}
