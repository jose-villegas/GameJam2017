using UnityEngine;

public static class ComponentExtensions
{
    #region GETTERS
    /// <summary>
    /// If the referenced component is null it finds the required
    /// component in <see cref="self"/>'s hierarchy.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="self">The self.</param>
    /// <param name="component">The component.</param>
    /// <returns></returns>
    public static bool FindComponent<T>(this Component self, ref T component, bool includeChildren = false) where T : Component
    {
        if (includeChildren && null == component)
        {
            component = self.GetComponentInChildren<T>();
        }
        else if (null == component)
        {
            component = self.GetComponent<T>();
        }

        return null != component;
    }
    #endregion
}

