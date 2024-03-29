using cafe.Domain.Common;
using Microsoft.AspNetCore.Mvc;
namespace cafe.Utils
{
    public static class ResponseResult
    {

        public static IActionResult ToResultResponse<T>(this BaseResponse<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.statusCode
            };
        }
    }
}

