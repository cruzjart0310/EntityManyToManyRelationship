using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Utilities
{
    public static class HttpContextExtensions
    {
        public async static Task InsertaParametrosPaginacionEnCabecera<T>(this Microsoft.AspNetCore.Http.HttpContext httpContex, IQueryable<T> queryable)
        {
            if (httpContex == null)
            {
                throw new ArgumentNullException(nameof(httpContex));
            }

            double cantidad = await queryable.CountAsync();
            httpContex.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
        }
    }
}
