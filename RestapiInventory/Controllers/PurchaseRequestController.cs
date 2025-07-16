using Microsoft.AspNetCore.Mvc;
using RestapiInventory.Dto.Common;
using RestapiInventory.Models;
using RestapiInventory.Services;

namespace RestapiInventory.Controllers
{
    [ApiController]
    [Route("purchase_request")]
    public class PurchaseRequestController : Controller
    {
        private readonly PurchaseRequestService _purchaseRequestService;
        public PurchaseRequestController(PurchaseRequestService purchaseRequestService)
        {
            _purchaseRequestService = purchaseRequestService;
        }

        [HttpGet("Get_Header_ById")]
        public IActionResult GetHeaderById(string id)
        {
            FormDto<PurchaseRequestHeader> result = _purchaseRequestService.GetPurchaseRequestHeaderById(id);
            return Ok(result);
        }
        [HttpGet("Get_Detail_ByHeaderId")]
        public IActionResult GetDetailById(string headerId)
        {
            //PurchaseRequestDetail result = _purchaseRequestService.GetPurchaseRequestDetailByHeaderId(headerId);
            //return Ok(result);

            FormDto<IList<PurchaseRequestDetail>> list = _purchaseRequestService.GetPurchaseRequestDetailByHeaderId(headerId);
            return Ok(list);
        }

        [HttpPost("create-header")]
        public IActionResult CreatePRHeader(PurchaseRequestHeader entity)
        {
            FormDto<PurchaseRequestHeader> list = _purchaseRequestService.CreateHeader(entity);
            return Ok(list);

        }
    }
}
