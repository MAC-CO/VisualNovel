using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListScene : MonoBehaviour
{
    public List<SceneData> sceneDataList = new List<SceneData>();

    private void Awake()
    {
        GetScenes();
    }
    void GetScenes()
    {
        // Get the number of scenes in the Build Settings
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        // Loop through each scene and add its data to the list
        for (int i = 0; i < sceneCount; i++)
        {
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
            SceneData sceneData = new SceneData(sceneName, i);
            sceneDataList.Add(sceneData);
        }

        // Print the scene data to the console
        //foreach (SceneData sceneData in sceneDataList)
        //{
        //    Debug.Log(sceneData.ToString());
        //}
    }

    public void GoToScene(int sceneIndex)
    {
        // Check if the scene index is valid
        if (sceneIndex >= 0 && sceneIndex < sceneDataList.Count)
        {
            SceneManager.LoadScene(sceneDataList[sceneIndex].sceneName);
        }
        //else
        //{
        //    Debug.LogError("Invalid scene index: " + sceneIndex);
        //}
    }

    public void GoToScene(string sceneName)
    {
        // Check if the scene name is valid
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        //else
        //{
        //    Debug.LogError("Invalid scene name: " + sceneName);
        //}
    }

    public static List<SceneData> GetSceneDataList()
    {
        ListScene sceneListManager = FindObjectOfType<ListScene>();
        if (sceneListManager == null)
        {
            //Debug.LogError("SceneListManager not found");
            return null;
        }
        return sceneListManager.sceneDataList;
    }

    //AgregarSistemadeGuardado
    public void QuitApplication()
    {
        //Debug.LogWarning("Salio de la App");
        Application.Quit();
    }
}
