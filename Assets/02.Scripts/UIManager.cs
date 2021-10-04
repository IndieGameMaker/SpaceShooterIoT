using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void OnStartGameBtnClick()
    {
        SceneManager.LoadScene("Level01");
        SceneManager.LoadScene("Play", LoadSceneMode.Additive);
    }
}
