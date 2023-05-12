using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClose : MonoBehaviour
{
    ListScene ListScene;

    public void Clicked(int index)
    {
        ListScene.GoToScene(index);
    }

    public void Clicked(string scenename)
    {
        ListScene.GoToScene(scenename);
    }
}
