using FluentNHibernate.Mapping;
using System.Xml;

namespace RestapiInventory.Models
{
    public class PurchaseRequestDetail
    {
        public virtual required string Id { get; set; }
        public virtual DateTime? timestamp { get; set; }
        public virtual string? actor { get; set; }
        public virtual string? ItemName { get; set; }
        public virtual string? PurchaseRequestHeaderId { get; set; }
        
    } 

    public class PurchaseRequestDetailMap : ClassMap<PurchaseRequestDetail>
    {
        public PurchaseRequestDetailMap()
        {
            Table("purchaserequestdetail");
            Id(x => x.Id).Column("Id").Not.Nullable();
            Map(x => x.timestamp).Column("timestamp").Nullable();
            Map(x => x.actor).Column("actor").Nullable();
            Map(x => x.ItemName).Column("ItemName").Not.Nullable();
            Map(x => x.PurchaseRequestHeaderId).Column("PurchaseRequestHeaderId").Nullable();

        }
    }
}
