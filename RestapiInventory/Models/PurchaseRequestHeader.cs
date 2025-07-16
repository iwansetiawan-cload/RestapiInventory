using FluentNHibernate.Mapping;
using System.Xml;

namespace RestapiInventory.Models
{
    public class PurchaseRequestHeader
    {
        public virtual required string Id { get; set; }
        public virtual DateTime? timestamp { get; set; }
        public virtual string? actor { get; set; }
        public virtual required string DocumentNumber { get; set; }
        public virtual required DateTime DocumentDate { get; set; }
        public virtual required DateTime CreatedDate { get; set; }
        public virtual DateTime? DeadlineDate { get; set; }
        public virtual required string ProjectName { get; set; }
        public virtual required string Company { get; set; }
        public virtual string? Description { get; set; }
        public virtual Int16? IsCancel { get; set; }
        public virtual string? UserProfileId { get; set; }
        public virtual string? ApproverId { get; set; }

    } 

    public class PurchaseRequestHeaderMap : ClassMap<PurchaseRequestHeader>
    {
        public PurchaseRequestHeaderMap()
        {
            Table("purchaserequestheader");
            //Id(x => x.Id).Column("Id").GeneratedBy.UuidString();
            Id(x => x.Id).Column("Id").Not.Nullable();
            Map(x => x.timestamp).Column("timestamp").Nullable();
            Map(x => x.actor).Column("actor").Nullable();
            Map(x => x.DocumentNumber).Column("DocumentNumber").Not.Nullable();
            Map(x => x.DocumentDate).Column("DocumentDate").Not.Nullable();
            Map(x => x.CreatedDate).Column("CreatedDate").Not.Nullable();
            Map(x => x.DeadlineDate).Column("DeadlineDate").Nullable();
            Map(x => x.ProjectName).Column("ProjectName").Not.Nullable();
            Map(x => x.Company).Column("Company").Not.Nullable();
            Map(x => x.Description).Column("Description").Nullable();
            Map(x => x.IsCancel).Column("IsCancel").Nullable();
            Map(x => x.UserProfileId).Column("UserProfileId").Nullable();
            Map(x => x.ApproverId).Column("ApproverId").Nullable();
        }
    }

}
