using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string path =
                Path.Combine(Directory.GetCurrentDirectory(),
                "errorlog.txt");

            File.AppendAllText(
                path,
                DateTime.Now + " : " +
                context.Exception.Message +
                Environment.NewLine);

            context.Result =
                new ObjectResult("Internal Server Error")
                {
                    StatusCode = 500
                };

            context.ExceptionHandled = true;
        }
    }
}