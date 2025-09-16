using UnityEngine;
using UnityEngine.SceneManagement;

public class WildCode : MonoBehaviour
{
    private KeyCode[] sequence = { KeyCode.W, KeyCode.I, KeyCode.L, KeyCode.D };
    private int currentIndex = 0;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(sequence[currentIndex]))
            {
                currentIndex++;

                if (currentIndex == sequence.Length)
                {
                    ChangeScene("wild");
                    currentIndex = 0;
                }
            }
            else
            {
                currentIndex = 0;
            }
        }
    }

    void ChangeScene(string sceneName)
    {
        Debug.Log("Changing scene to '" + sceneName + "'");
        SceneManager.LoadScene(sceneName);
    }
}
