using System.Collections.Generic;
using bugTracker.Core.DTO.ApiResponseModels;
using bugTracker.Core.DTO.ViewModels;
using bugTracker.Core.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace bugTracker.Core.Controllers
{
    public class BaseController : Controller
    {
        protected string IncorrectUseOfApi()
        {
            return CommonHelpers.IncorrectUsageOfApi();
        }
        
        protected JsonResult ErrorResponse(string message = "Not Found")
        {
            return Json(new BaseApiResponseModel{
                Success = false,
                Message = message
            });
        }

        protected JsonResult MessageResult(string message, bool success = true)
        {
            return Json(new BaseApiResponseModel{
                Success = success,
                Message = message
            });
        }

        protected JsonResult SingleResult(BaseViewModel singleResult)
        {
            return Json (new BaseApiMessageSingleResponseViewModel
            {
                Success = true,
                Result = singleResult
            });
        }

        protected JsonResult MultipleResults(IEnumerable<BaseViewModel> multipleResults)
        {
            return Json (new BaseApiMessageMultipleResponseModel{
                Success = true,
                Results = multipleResults
            });
        }
    }
}