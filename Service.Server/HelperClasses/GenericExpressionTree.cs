using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace service.server.HelperClasses
{
    public class GenericExpressionTree
    {

        public static Expression<Func<T, bool>> CreateWhereClause<T>(
  string propertyName, object propertyValue)
        {
            var parameter = Expression.Parameter(typeof(T));
            return Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(parameter, propertyName),
                    Expression.Constant(propertyValue)),
                parameter);
        }

    }
}
