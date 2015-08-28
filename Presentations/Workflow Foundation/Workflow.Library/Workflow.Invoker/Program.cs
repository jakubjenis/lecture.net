using System;
using System.Activities;

namespace Workflow.Invoker
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sample workflow
            WorkflowInvoker.Invoke(new Activity1());

            //Sample flowchart workflow
            WorkflowInvoker.Invoke(new Activity2());
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
