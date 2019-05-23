using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Button start;

    // Use this for initialization
    public void StartGame()
    {
        gSceneManager.Instance.proxScene = gSceneManager.Instance.gameScene;
    }

}
