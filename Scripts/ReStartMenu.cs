using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartMenu : MonoBehaviour
{
    public void ReStartGame()
    {
        SceneManager.LoadScene(0);
    }
}
