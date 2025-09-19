using System.ComponentModel.DataAnnotations;

namespace Toska.Models.Base
{
    public abstract class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }


        // Concurrency token
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();
    }
}
