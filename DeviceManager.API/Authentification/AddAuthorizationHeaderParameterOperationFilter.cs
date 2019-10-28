using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace DeviceManager.API.Authentification
{
    public class AddAuthorizationHeaderParameterOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter()
            {
                name = "Authorization",
                @in = "header",
                description = "admin or user",
                required = false,
                type = "string"

            });
        }
    }
}