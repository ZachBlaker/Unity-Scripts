using UnityEngine;

// Instatiates a copy of each GameObject prefab from a path inside /Resources/
// before the first scene is loaded
// Used for creating instances of singleton classes or prefabs shared between all your scenes
// Instatiated GameObjects are marked with DontDestroyOnLoad 

public static class InstantatiateRequiredPrefabs
{
    const string folderPathFromResources = "LoadOnStart/";
    static bool instantatiationEnabled = true;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InstantatiatePrefabs()
    {
        if (!instantatiationEnabled)
            return;

        Debug.Log($"<b>Instantiating</b> required prefabs from {folderPathFromResources}");

        GameObject[] prefabsToInstantiate = Resources.LoadAll<GameObject>(folderPathFromResources);
        foreach (GameObject prefab in prefabsToInstantiate)
        {
            Debug.Log($"Instantiating {prefab.name}");
            GameObject prefabInstance = GameObject.Instantiate(prefab);
            GameObject.DontDestroyOnLoad(prefabInstance);
        }
        Debug.Log($"<b>Completed Instantiating</b> of {prefabsToInstantiate.Length} required prefabs");
    }
}
