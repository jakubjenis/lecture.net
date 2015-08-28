using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;

namespace LinqIngredients
{
    class Lambdas
    {
        public Lambdas()
        {

            Func<int, int> lambda = i => i*2;

            Func<int, int> lambda2 = i =>
            {
                var d = i*2;
                return d;
            };

            lambda2(3);

            Expression<Func<int, int>> expr = i => (int)Math.Sqrt(i);

            var funcFromExpression2 = expr.Compile();
            funcFromExpression2(2);





            var list = new List<string>();

            list.Where(o => true);




            Action<int> actionStatementLambda = i => Console.WriteLine(i);

            Func<int, bool> statementLambda = i => i % 2 == 0;
            Func<int, bool> statementLambdaBody = i =>
            {
                var modulo = i % 2;
                return modulo == 0;
            };

            Func<int, bool> statementLambdaBodySimple = (i) =>
            {
                return i % 2 == 0;
            };

            Expression<Func<int, bool>> expressionLamdba = i => i % 2 == 0;

            var funcFromExpression = expressionLamdba.Compile();
            funcFromExpression(2);
        }
    }
}
