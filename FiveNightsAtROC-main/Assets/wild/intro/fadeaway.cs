using UnityEngine;
using UnityEngine.Video;

public class fadeaway : MonoBehaviour
{
    public VideoPlayer videoPlayer;   // Drag your VideoPlayer here
    public float disableDelay = 7f;   // Time before disabling

    void Awake()
    {
        if (videoPlayer != null)
            videoPlayer.Play(); // auto play on Awake

        Invoke(nameof(DisableObject), disableDelay);
    }

    void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
