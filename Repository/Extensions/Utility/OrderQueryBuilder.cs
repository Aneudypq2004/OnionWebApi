using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions.Utility
{
    public class OrderQueryBuilder
    {
        public static string CreateOrderQuery(string orderByQueryString)
        {
            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfo = typeof(Employee).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var ordernQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param)) continue;

                var propertyFromQuery = param.Split(" ")[0];

                var objectProperty = propertyInfo.FirstOrDefault(po => po.Name.Equals(propertyFromQuery, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null) continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                ordernQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction},");
            }

            var orderQuery = ordernQueryBuilder.ToString().TrimEnd(',', ' ');

            return orderQuery;
        }
    }
}
