using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace Workflow.Invoker.CodeActivities
{

    public sealed class GetData : CodeActivity
    {
        public OutArgument<List<Person>> People { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            People.Set(context, new List<Person>()
            {
                new Person()
                {
                    IsValid = true,
                    Name = "Janko Hrasko"
                }, 
                new Person()
                {
                    IsValid = true,
                    Name = "Cerny Petr"
                }
            });
        }
    }

    public class Person
    {
        public bool IsValid { get; set; }
        public string Name { get; set; }
    }
}
