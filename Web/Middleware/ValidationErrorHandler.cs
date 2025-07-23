using Microsoft.AspNetCore.Mvc;

namespace Web.Middleware
{
    public static class ValidationErrorHandler
    {
        public static IActionResult CustomModelStateResponse(ActionContext context)
        {
            var errors = context.ModelState
                .Where(e => e.Value?.Errors?.Count > 0)
                .ToDictionary(
                    e => e.Key,
                    e => e.Value!.Errors.Select(er => er.ErrorMessage).ToArray()
                );

            var response = new
            {
                status_code = StatusCodes.Status400BadRequest,
                message = "Validation failed.",
                body = new { errors }
            };

            return new BadRequestObjectResult(response);
        }
    }

}
