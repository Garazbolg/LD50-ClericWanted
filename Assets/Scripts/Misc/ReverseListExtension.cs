using System.Collections;
using System.Collections.Generic;

public static class ReverseListExtension
{
    public static ReverseList<T> AsReverse<T>(this List<T> list) => new ReverseList<T>(list);

    public class ReverseList<T> : IEnumerable
    {
        List<T> list;
        public ReverseList(List<T> list) { this.list = list; }

        public IEnumerator GetEnumerator()
        {
            for (int i = list.Count - 1; i >= 0; i--)
                yield return list[i];
            yield break;
        }
    }
}
