using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OrderApi.Models.Extensions;

namespace OrderApi.Extensions
{
    public class PostTerminalNumberFilter : ActionFilterAttribute
    {
        public string ActionArgumentName = string.Empty;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionArguments.ContainsKey(ActionArgumentName))
            {
                var value = filterContext.ActionArguments[ActionArgumentName].ToString();

                if (PostTerminalNumberValidator.IsNumberValid(value))
                {
                    base.OnActionExecuting(filterContext);
                }
                else
                {
                    filterContext.Result = new BadRequestObjectResult($"Post terminal number={value} has invalid format.");
                    return;
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
