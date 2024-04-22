using System.Net;
using Microsoft.AspNetCore.Mvc;
using GUL.Shared.Utils;

namespace GUL.Shared.FluentResults;

public static class ResultsExtension
{
    public static ActionResult ToActionResult<T>(this IFluentResults<T> result)
    {
        var message = result.Messages.Any() ? result.ToMultiLine(";") : null;
        var response = new HttpResponseMessage();

        if (result.Status == FluentResultsStatus.Success && result.Value is not null)
        {
            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = message;
            return new OkObjectResult(result.Value);
        }

        if (result.Status == FluentResultsStatus.NotFound)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.ReasonPhrase = message;

            return new NotFoundObjectResult(response);
        }

        if (result.Status == FluentResultsStatus.Failure)
        {
            return new InternalServerErrorObjectResult(result);
        }

        if (result.Status == FluentResultsStatus.BadRequest)
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.ReasonPhrase = message;
            return new BadRequestObjectResult(response);
        }

        return new OkResult();
    }

    public static ActionResult ToActionResult(this IFluentResults result)
    {
        var message = result.Messages.Any() ? result.ToMultiLine(";") : null;
        var response = new HttpResponseMessage();

        if (result.Status == FluentResultsStatus.Success)
        {
            if (result.Keys is not null || (result.Keys?.Count ?? 0) > 0)
            {
                return new ObjectResult(result.Keys);
            }

            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = message;
            return new ObjectResult(response);
        }

        if (result.Status == FluentResultsStatus.NotFound)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.ReasonPhrase = message;

            return new NotFoundObjectResult(response);
        }

        if (result.Status == FluentResultsStatus.Failure)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ReasonPhrase = message;
            return new InternalServerErrorObjectResult(response);
        }

        if (result.Status == FluentResultsStatus.BadRequest)
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.ReasonPhrase = message;
            return new BadRequestObjectResult(response);
        }

        return new OkResult();
    }

    public static ActionResult ToActionResult<T, T1>(this IFluentResults<T> result, T1 value)
    {
        var message = result.Messages.Any() ? result.ToMultiLine(";") : null;
        var response = new HttpResponseMessage();

        if (result.Status == FluentResultsStatus.Success && value is not null)
        {
            response.StatusCode = HttpStatusCode.OK;
            response.ReasonPhrase = message;
            return new OkObjectResult(value);
        }

        if (result.Status == FluentResultsStatus.NotFound)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.ReasonPhrase = message;

            return new NotFoundObjectResult(response);
        }

        if (result.Status == FluentResultsStatus.Failure)
        {
            response.StatusCode = HttpStatusCode.InternalServerError;
            response.ReasonPhrase = message;
            return new InternalServerErrorObjectResult(response);
        }

        if (result.Status == FluentResultsStatus.BadRequest)
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.ReasonPhrase = message;
            return new BadRequestObjectResult(response);
        }

        return new OkResult();
    }

    private static bool ContainsNewLineCharacter(this string value)
    {
        foreach (var character in value)
        {
            if (character == (char) 13 || character == (char) 10)
            {
                return true;
            }
        }

        return false;
    }
}
