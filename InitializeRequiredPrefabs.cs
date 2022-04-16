using UnityEngine;

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
