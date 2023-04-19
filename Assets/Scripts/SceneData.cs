using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    public string sceneName;
    public int sceneIndex;

    public SceneData(string name, int index)
    {
        sceneName = name;
        sceneIndex = index;
    }

    public override string ToString()
    {
        return "Scene: " + sceneName + " (Build Index " + sceneIndex + ")";
    }
}
