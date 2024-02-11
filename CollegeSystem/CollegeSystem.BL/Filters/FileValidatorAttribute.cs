using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FileUploadingWebAPI.Filter;

public class FileValidatorAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var image = context.ActionArguments["file"] as IFormFile;
        if(image is null || image.Length ==0)
            context.Result = new BadRequestObjectResult("Select File!!");

        if(!IsImage(image))
            context.Result = new BadRequestObjectResult("Invalid File Format!!");
    }

    private bool IsImage(IFormFile formFile)
    {
        return formFile.ContentType.Contains("application/octet-stream") ||
               formFile.ContentType.Contains("image/jpeg") ||
               formFile.ContentType.Contains("image/png") ||
               formFile.ContentType.Contains("image/gif") ||
               formFile.ContentType.Contains("image/jpg");
    }

}
