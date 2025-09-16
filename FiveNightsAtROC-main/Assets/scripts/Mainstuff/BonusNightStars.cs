using UnityEngine;

public class BonusNightStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject specialButton; // The object that appears when both stars are unlocked

    void Start()
    {
        // Check which stars are unlocked
        bool s1 = PlayerPrefs.GetInt("Star1Unlocked", 0) == 1;
        bool s2 = PlayerPrefs.GetInt("Star2Unlocked", 0) == 1;

        // Enable stars individually
        star1.SetActive(s1);
        star2.SetActive(s2);

        // Enable the special button only if both stars are unlocked
        specialButton.SetActive(s1 && s2);
    }
}
