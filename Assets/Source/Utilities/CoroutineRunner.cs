using UnityEngine;
using System.Collections;

public static class CoroutineRunner
{
    /// <summary>
    /// Starts the specified coroutine on the <see cref="CoroutineUtils"/>
    /// instance
    /// </summary>
    /// <param name="coroutine">The coroutine.</param>
    /// <returns></returns>
    public static Coroutine Start(this IEnumerator coroutine)
    {
        if (null == coroutine) return null;

        return CoroutineUtils.Instance.StartCoroutine(coroutine);
    }

    /// <summary>
    /// Stops the specified coroutine on the <see cref="CoroutineUtils"/>
    /// instance
    /// </summary>
    /// <param name="coroutine">The coroutine.</param>
    /// <returns></returns>
    public static void Stop(this Coroutine coroutine)
    {
        if (null == coroutine) return;

        CoroutineUtils.Instance.StopCoroutine(coroutine);
    }
}

