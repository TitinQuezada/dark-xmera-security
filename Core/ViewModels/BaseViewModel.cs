using System;

namespace Core.ViewModels
{
    public class BaseViewModel
    {
        public string Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
