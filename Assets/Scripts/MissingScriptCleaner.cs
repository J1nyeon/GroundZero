using UnityEngine;
using UnityEditor;

public class MissingScriptCleaner : EditorWindow
{
    [MenuItem("Tools/Clean Missing Scripts")]
    public static void ShowWindow()
    {
        GetWindow<MissingScriptCleaner>("Clean Missing Scripts");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("현재 씬의 Missing Script 모두 삭제"))
        {
            CleanMissingScriptsInScene();
        }
    }

    private static void CleanMissingScriptsInScene()
    {
        GameObject[] goArray = Selection.gameObjects;
        if (goArray.Length == 0)
        {
            goArray = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        }

        int count = 0;
        foreach (GameObject go in goArray)
        {
            count += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(go);
            foreach (Transform child in go.GetComponentsInChildren<Transform>(true))
            {
                count += GameObjectUtility.RemoveMonoBehavioursWithMissingScript(child.gameObject);
            }
        }

        Debug.Log($"총 {count}개의 Missing Script를 제거했습니다.");
    }
}