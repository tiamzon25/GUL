using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUL.Shared.Utils;

public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object value) : base(value)
    {
        StatusCode = 500;
    }

    public InternalServerErrorObjectResult() : this(null)
    {
        StatusCode = 500;
    }
}
