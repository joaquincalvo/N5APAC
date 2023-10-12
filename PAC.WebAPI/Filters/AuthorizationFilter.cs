using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PAC.WebAPI.Filters
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {

        public string RoleNeeded { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var authorizationHeader = context.HttpContext.Request.Headers["Authorization"].ToString();
            Guid token = Guid.Empty;


            if (string.IsNullOrEmpty(authorizationHeader) || !Guid.TryParse(authorizationHeader, out token))
            {
                // Si asigno un result se corta la ejecucion de la request y ya devuelve la response
                context.Result = new ObjectResult(new { Message = "Authorization header is missing" })
                {
                    StatusCode = 401
                };
            }

            var sessionManager = GetSessionService(context);
            

            
                // Si asigno un result se corta la ejecucion de la request y ya devuelve la response
                context.Result = new ObjectResult(new { Message = "No me pude autentificar" })
                {
                    StatusCode = 401
                };
            
            
        }

        protected ISessionService GetSessionService(AuthorizationFilterContext context)
        {
            var sessionManagerObject = context.HttpContext.RequestServices.GetService(typeof(ISessionService));
            var sessionService = sessionManagerObject as ISessionService;

            return sessionService;
        }
    }
}

