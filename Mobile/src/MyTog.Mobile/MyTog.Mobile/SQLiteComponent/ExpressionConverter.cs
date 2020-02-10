﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kalinkin.MyTog.Mobile.SQLiteComponent
{
    internal class ExpressionConverter<TInput, TOutput> : ExpressionVisitor
    {
        public Expression<Func<TOutput, bool>> Convert(Expression<Func<TInput, bool>> expression)
        {
            return (Expression<Func<TOutput, bool>>)Visit(expression);
        }

        private ParameterExpression replaceParam;

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (typeof(T) == typeof(Func<TInput, bool>))
            {
                replaceParam = Expression.Parameter(typeof(TOutput), "p");
                return Expression.Lambda<Func<TOutput, bool>>(Visit(node.Body), replaceParam);
            }
            return base.VisitLambda<T>(node);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(TInput))
                return replaceParam;
            return base.VisitParameter(node);
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node.Member.DeclaringType == typeof(TInput))
            {
                var member = typeof(TOutput).GetMember(node.Member.Name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).FirstOrDefault();
                if (member == null)
                    throw new InvalidOperationException("Cannot identify corresponding member of DataObject");
                return Expression.MakeMemberAccess(Visit(node.Expression), member);
            }
            return base.VisitMember(node);
        }
    }
}
