using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToExtra : MonoBehaviour
{
    // Call this method when you want to switch to the Extra scene
    public void LoadExtraScene()
    {
        SceneManager.LoadScene("Extra");
    }
}