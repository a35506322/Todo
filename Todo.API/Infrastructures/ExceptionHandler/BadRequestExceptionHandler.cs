namespace Todo.API.Infrastructures.ExceptionHandler;

public static class BadRequestExceptionHandler
{
    public static BadRequestObjectResult TryHandler(ActionContext context)
    {
        // Create a dictionary from the ModelState entries that are invalid.
        var errors = context.ModelState
            .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
            .ToDictionary(
                // Use the full property path as the dictionary key, splitting and rejoining with dots.
                x => string.Join('.', x.Key.Split('.')).ToCamelCase(),
                // Select the first error message from the errors collection of each entry.
                x => x.Value.Errors.Select(e => e.ErrorMessage)
            );

        // Return a BadRequest with the errors dictionary as the content.
        return new BadRequestObjectResult(ResponseExtension.Exception.BadRequest(errors));
    }
}
