using UnityEngine;
using UnityEngine.SceneManagement;

public class Night5Code : MonoBehaviour
{
    // Example code sequence; change to whatever you want
    private KeyCode[] sequence = { KeyCode.N, KeyCode.I, KeyCode.G, KeyCode.H, KeyCode.T, KeyCode.F, KeyCode.I, KeyCode.V, KeyCode.E };
    private int currentIndex = 0;

    void Update()
    {
        // Only process input if the object is active
        if (!gameObject.activeInHierarchy) return;

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(sequence[currentIndex]))
            {
                currentIndex++;

                // Sequence complete → load Night 5
                if (currentIndex == sequence.Length)
                {
                    SceneManager.LoadScene("Night5");
                    currentIndex = 0;
                }
            }
            else
            {
                // Wrong key → reset sequence
                currentIndex = 0;
            }
        }
    }
}
