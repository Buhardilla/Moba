using UnityEngine;
public static class Transforms
{
    public static void DestroyChildren(this Transform t, bool destroyInmmediatly = false)
    {
        foreach (Transform child in t)
        {
            if (destroyInmmediatly)
                MonoBehaviour.DestroyImmediate(child.gameObject);
            else
                MonoBehaviour.Destroy(child.gameObject);
        }
    }
}
