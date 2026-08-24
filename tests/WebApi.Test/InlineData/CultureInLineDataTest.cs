using System.Collections;

namespace WebApi.Test.InlineData;

public class CultureInLineDataTest : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { "en" };
        yield return new object[] { "es" };
        yield return new object[] { "fr" };
        yield return new object[] { "ja-JP" };
        yield return new object[] { "pt-BR" };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
