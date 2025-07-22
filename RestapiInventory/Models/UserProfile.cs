using FluentNHibernate.Mapping;

namespace RestapiInventory.Models
{
    public class UserProfile
    {
        public virtual required string Id { get; set; }
        public virtual DateTime? timestamp { get; set; }
        public virtual string? actor { get; set; }
        public virtual string? NIK { get; set; }
        public virtual required string FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual string? ShortCode { get; set; }
        public virtual DateTime? JoinDate { get; set; }
        public virtual DateTime? ResignDate { get; set; }
        public virtual int? Company { get; set; }
        public virtual int? Gender { get; set; }
        public virtual string? RedmineToken { get; set; }
        public virtual Int64? WorkingHour { get; set; }
        public virtual string? DivisionId { get; set; }
        public virtual string? JobRoleId { get; set; }
    }
    public class UserProfileMap : ClassMap<UserProfile>
    {
        public UserProfileMap()
        {
            Table("userprofile");
            Id(x => x.Id).Column("Id").Not.Nullable();
            Map(x => x.timestamp).Column("timestamp").Nullable();
            Map(x => x.actor).Column("actor").Nullable();
            Map(x => x.NIK).Column("NIK").Nullable();
            Map(x => x.FirstName).Column("FirstName").Not.Nullable();
            Map(x => x.LastName).Column("LastName").Nullable();
            Map(x => x.PhoneNumber).Column("PhoneNumber").Nullable();
            Map(x => x.ShortCode).Column("ShortCode").Nullable();
            Map(x => x.JoinDate).Column("JoinDate").Nullable();
            Map(x => x.ResignDate).Column("ResignDate").Nullable();
            Map(x => x.Company).Column("Company").Nullable();
            Map(x => x.Gender).Column("Gender").Nullable();
            Map(x => x.RedmineToken).Column("RedmineToken").Nullable();
            Map(x => x.WorkingHour).Column("WorkingHour").Nullable();
            Map(x => x.DivisionId).Column("DivisionId").Nullable();
            Map(x => x.JobRoleId).Column("JobRoleId").Nullable();
        }
    }
}
