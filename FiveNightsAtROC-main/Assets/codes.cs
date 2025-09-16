using UnityEngine;

public class codes : MonoBehaviour
{
    public GameObject secretCodeObject;   // unlocked after Night 2
    public GameObject wildCodeObject;     // unlocked after Night 4
    public GameObject night5CodeObject;   // unlocked after Wild night

    void Start()
    {
        // Secret code unlocks after Night 2
        bool night2Completed = PlayerPrefs.GetInt("Night2Completed", 0) == 1;
        secretCodeObject.SetActive(night2Completed);

        // Wild code unlocks after Night 4
        bool night4Completed = PlayerPrefs.GetInt("Night4Completed", 0) == 1;
        wildCodeObject.SetActive(night4Completed);

        // Night 5 code unlocks after Wild night
        bool wildCompleted = PlayerPrefs.GetInt("WildCompleted", 0) == 1;
        night5CodeObject.SetActive(wildCompleted);
    }
}
