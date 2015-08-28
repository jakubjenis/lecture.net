using System.Collections.Generic;

namespace LinqIngredients
{
    public static class Iterator
    {
        public static IEnumerable<string> GetDemoEnumerable()
        {
            yield return "start";
            for (int i = 0; i < 5; i++)
            {
                yield return i.ToString();
            }
            yield return "end";
        }

        static IEnumerator<string> GetEmptyCollection()
        {
            yield break;
        }
    }
}
