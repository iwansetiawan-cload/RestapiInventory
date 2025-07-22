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

        [HttpGet("get_header_byId")]
        public IActionResult GetHeaderById(string id)
        {
            FormDto<PurchaseRequestHeader> result = _purchaseRequestService.GetPurchaseRequestHeaderById(id);
            return Ok(result);
        }
        [HttpGet("get_detail_byheaderid")]
        public IActionResult GetDetailById(string headerId)
        {
            FormDto<IList<PurchaseRequestDetail>> list = _purchaseRequestService.GetPurchaseRequestDetailByHeaderId(headerId);
            return Ok(list);
        }
        [HttpGet("get_purchase_request_bydocument")]
        public IActionResult GetPRByNoreq(string NomorDocument)
        {
            FormDto<PurchaseRequestViewModel> result = _purchaseRequestService.GetPurchaseRequestByNoreq(NomorDocument);
            return Ok(result);
        }
        [HttpPost("post_header")]
        public IActionResult PostPRHeader(PurchaseRequestHeader entity)
        {
            FormDto<PurchaseRequestHeader> list = _purchaseRequestService.CreateHeader(entity);
            return Ok(list);

        }
        [HttpPost("post_detail")]
        public IActionResult PostPRDetail(PurchaseRequestDetail entity)
        {
            FormDto<PurchaseRequestDetail> list = _purchaseRequestService.CreateDetail(entity);
            return Ok(list);

        }
    }
}
