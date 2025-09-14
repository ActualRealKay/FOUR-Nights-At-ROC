using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secretcode : MonoBehaviour
{
    private Dictionary<string, KeyCode[]> codes = new Dictionary<string, KeyCode[]>();
    private Dictionary<string, int> progress = new Dictionary<string, int>();

    void Start()
    {
        // Define all secret codes here
        codes["secretam"] = new KeyCode[] { KeyCode.Alpha6, KeyCode.Alpha9, KeyCode.Alpha4, KeyCode.Alpha2, KeyCode.Alpha0 };
        codes["wild"] = new KeyCode[] { KeyCode.W, KeyCode.I, KeyCode.L, KeyCode.D };

        // Initialize progress trackers for each code
        foreach (var key in codes.Keys)
        {
            progress[key] = 0;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (var entry in codes)
            {
                string sceneName = entry.Key;
                KeyCode[] sequence = entry.Value;
                int currentIndex = progress[sceneName];

                if (Input.GetKeyDown(sequence[currentIndex]))
                {
                    currentIndex++;

                    // If finished the sequence → load the scene
                    if (currentIndex == sequence.Length)
                    {
                        ChangeScene(sceneName);
                        currentIndex = 0;
                    }
                }
                else if (Input.anyKeyDown) // wrong key → reset progress for this code
                {
                    currentIndex = 0;
                }

                progress[sceneName] = currentIndex;
            }
        }
    }

    void ChangeScene(string sceneName)
    {
        Debug.Log("Changing scene to '" + sceneName + "'");
        SceneManager.LoadScene(sceneName);
    }
}
