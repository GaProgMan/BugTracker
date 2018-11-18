using System;

namespace bugTracker.Core.DTO.ViewModels
{
    public abstract class BaseViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
    }
}