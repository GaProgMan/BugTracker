using System.Collections.Generic;
using bugTracker.Core.DTO.ViewModels;

namespace bugTracker.Core.DTO.ApiResponseModels
{
    public class BaseApiResponseModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class BaseApiMessageSingleResponseViewModel : BaseApiResponseModel
    {
        public BaseViewModel Result { get; set; }
    }

    public class BaseApiMessageMultipleResponseModel : BaseApiResponseModel
    {
        public IEnumerable<BaseViewModel> Results { get; set; }
    }
}