using UnityEngine;

public class BonusNightStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject specialButton; // The object that appears when all stars are unlocked

    void Start()
    {
        // Check which stars are unlocked
        bool s1 = PlayerPrefs.GetInt("Star1Unlocked", 0) == 1;
        bool s2 = PlayerPrefs.GetInt("Star2Unlocked", 0) == 1;
        bool s3 = PlayerPrefs.GetInt("Star3Unlocked", 0) == 1;

        // Enable stars individually
        star1.SetActive(s1);
        star2.SetActive(s2);
        star3.SetActive(s3);

        // Enable the special button only if ALL stars are unlocked
        specialButton.SetActive(s1 && s2 && s3);
    }
}
