using System.Collections.Generic;
using UnityEditor;

public class MonoScriptUtility
{
    public static MonoScript[] GetAllMonoScriptAssets()
    {
        return (MonoScript[])UnityEngine.Object.FindObjectsOfTypeIncludingAssets(typeof(MonoScript));
    }

    public static MonoScript[] GetScriptAssetsOfType<T>(bool includeParentClass = false)
    {
        MonoScript[] scripts = GetAllMonoScriptAssets();

        List<MonoScript> result = new List<MonoScript>();

        foreach (MonoScript m in scripts)
        {
            if (m.GetClass() != null)
            {
                if (m.GetClass().IsSubclassOf(typeof(T)))
                    result.Add(m);
                else if (includeParentClass && m.GetClass().Equals(typeof(T)))
                    result.Add(m);
            }
        }
        return result.ToArray();
    }
}
