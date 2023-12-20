using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using StoreAppMVC.Exceptions;

namespace StoreAppMVC.Filters
{
    public class AppExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<AppExceptionFilter> _logger;

        public AppExceptionFilter(ILogger<AppExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            switch (context.Exception.GetType().Name)
            {
                case nameof(OrderNumberIsNotUniqueException):
                    _logger.LogError("Не должно существовать 2х заказов от одного поставщика с одинаковыми номерами");
                    context.Result = new ViewResult { ViewName = "ErrorViewUniqueOrderNumber", ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) };
                    break;
                default:
                    _logger.LogError(context.Exception.GetType().Name, context.Exception.Message, context.HttpContext.Response.StatusCode);
                    context.Result = new StatusCodeResult(500);
                    break;
            }
        }
    }
}
