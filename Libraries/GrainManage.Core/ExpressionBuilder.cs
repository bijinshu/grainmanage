﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GrainManage.Core
{
    public sealed class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;
        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = (map ?? new Dictionary<ParameterExpression, ParameterExpression>());
        }
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }
        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression parameterExpression;
            if (this.map.TryGetValue(p, out parameterExpression))
            {
                p = parameterExpression;
            }
            return base.VisitParameter(p);
        }
    }
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, bool>> Where<T>(Expression<Func<T, bool>> condition)
        {
            return condition;
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, new Func<Expression, Expression, Expression>(Expression.And));
        }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, new Func<Expression, Expression, Expression>(Expression.Or));
        }
        private static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            Dictionary<ParameterExpression, ParameterExpression> map = first.Parameters.Select((ParameterExpression f, int i) => new
            {
                f = f,
                s = second.Parameters[i]
            }).ToDictionary(p => p.s, p => p.f);
            Expression arg = ParameterRebinder.ReplaceParameters(map, second.Body);
            return Expression.Lambda<T>(merge(first.Body, arg), first.Parameters);
        }
    }
}
