using FluentNHibernate.Mapping;
using System.Xml;

namespace RestapiInventory.Models
{
    public class PurchaseRequestDetail
    {
        public virtual required string Id { get; set; }
        public virtual DateTime? timestamp { get; set; }
        public virtual string? actor { get; set; }
        public virtual required string ItemName { get; set; }
        public virtual string? ItemDescription { get; set; }
        public virtual required int ItemQuantity { get; set; }
        public virtual required string ItemUnit { get; set; }
        public virtual required string Brand { get; set; }
        public virtual required string Spesification { get; set; }
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
            Map(x => x.ItemDescription).Column("ItemDescription").Nullable();
            Map(x => x.ItemQuantity).Column("ItemQuantity").Not.Nullable();
            Map(x => x.ItemUnit).Column("ItemUnit").Nullable();
            Map(x => x.Brand).Column("Brand").Nullable();
            Map(x => x.Spesification).Column("Spesification").Nullable();
            Map(x => x.PurchaseRequestHeaderId).Column("PurchaseRequestHeaderId").Nullable();

        }
    }
}
