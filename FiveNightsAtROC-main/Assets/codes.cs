using UnityEngine;

public class codes : MonoBehaviour
{
    public GameObject secretCodeObject;  // unlocked after Night 2
    public GameObject wildCodeObject;    // unlocked after Night 4

    void Start()
    {
        // Secret code only available if Night 2 completed
        bool night2Completed = PlayerPrefs.GetInt("Night2Completed", 0) == 1;
        secretCodeObject.SetActive(night2Completed);

        // Wild code only available if Night 4 completed
        bool night4Completed = PlayerPrefs.GetInt("Night4Completed", 0) == 1;
        wildCodeObject.SetActive(night4Completed);
    }
}
