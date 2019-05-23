using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour {

    public Button restart;

    public void RestartGame()
    {
        gSceneManager.Instance.proxScene = gSceneManager.Instance.gameScene;
        gSceneManager.Instance.life = 3;
    }
}
