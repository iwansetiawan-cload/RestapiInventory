namespace RestapiInventory.Models
{
    public class PurchaseRequestViewModel
    {
        public PurchaseRequestHeader? purchaseRequestHeader { get; set; }
        public IEnumerable<PurchaseRequestDetail>? purchaseRequestDetails { get; set; }
    }
}
