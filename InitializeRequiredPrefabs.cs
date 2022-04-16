using UnityEngine;

// Initializes a copy of each GameObject prefab from a path inside /Resources/
// before the first scene is loaded
// Used for creating instances of singleton classes or required global prefabs like Camera

public static class InitializeRequiredPrefabs
{
    const string folderPathFromResources = "LoadOnStart/";
    static bool intiailizationEnabled = true;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void InitializePrefabsFromFolder()
    {
        if (!intiailizationEnabled)
            return;

        Debug.Log($"<b>Initializing</b> required prefabs from {folderPathFromResources}");

        GameObject[] prefabsToInstantiate = Resources.LoadAll<GameObject>(folderPathFromResources);
        foreach (GameObject prefab in prefabsToInstantiate)
        {
            Debug.Log($"Instatiating {prefab.name}");
            GameObject prefabInstance = GameObject.Instantiate(prefab);
            GameObject.DontDestroyOnLoad(prefabInstance);
        }
        Debug.Log($"<b>Completed Initialization</b> of {prefabsToInstantiate.Length} required prefabs");
    }
}
