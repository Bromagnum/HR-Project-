using DAL.Entities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.Utilities;

namespace DAL.Entities.Abstracts
{
    public interface IBaseEntity<T>
    {
        public T MasterId { get; set; }

        public int Id { get; set; }
        

        //CreatedProperties
        public DateTime? CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }

        //UpdatedProperties

        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }

        //DeletedProperties
        public DateTime? DeletedDate { get; set; }
        public string? DeletedComputerName { get; set; }
        public string? DeletedIpAddress { get; set; }


        public ServiceResponse<T> Response { get; set; }
    }
}
