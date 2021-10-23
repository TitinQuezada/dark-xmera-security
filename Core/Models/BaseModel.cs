using System;

namespace Core.Models
{
    public class BaseModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int StatusId { get; set; }

        public StatusModel Status { get; set; }
    }
}
