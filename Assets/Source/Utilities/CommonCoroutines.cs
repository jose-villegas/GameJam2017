using UnityEngine;
using System.Collections;

public static class CommonCoroutines
{
    public static IEnumerator ScaleToZero(Transform transform, float time, bool destroyAfter = false)
    {
        Vector3 scale = transform.localScale;

        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / time)
        {
            transform.localScale = Vector3.Lerp(scale, Vector3.zero, t);
            yield return null;
        }

        if (destroyAfter)
        {
            GameObject.Destroy(transform.gameObject, 0.5f);
        }
    }
}

