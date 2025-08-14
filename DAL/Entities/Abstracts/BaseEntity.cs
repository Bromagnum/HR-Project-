using DAL.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Abstracts
{
    public abstract class BaseEntity : IBaseEntity<Guid>
    {
        public Guid MasterId { get; set; }
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string? DeletedComputerName { get; set; }
        public string? DeletedIpAddress { get; set; }
        public ServiceResponse<Guid> Response { get; set; }

        public void CreatedAudit()
        {
            CreatedDate = DateTime.UtcNow;
            CreatedComputerName = Environment.MachineName;
            CreatedIpAddress = "0.0.0.0";
        }
        public void UpdatedAudit()
        {
            UpdatedDate = DateTime.UtcNow;
            UpdatedComputerName = Environment.MachineName;
            UpdatedIpAddress = "0.0.0.0";
        }
        public void DeletedAudit()
        {
            DeletedDate = DateTime.UtcNow;
            DeletedComputerName = Environment.MachineName;
            DeletedIpAddress = "0.0.0.0";
        }
    }
}
