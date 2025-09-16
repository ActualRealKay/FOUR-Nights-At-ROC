using UnityEngine;

public class BonusNightStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    void Start()
    {
        // Enable each star independently based on PlayerPrefs
        star1.SetActive(PlayerPrefs.GetInt("Star1Unlocked", 0) == 1);
        star2.SetActive(PlayerPrefs.GetInt("Star2Unlocked", 0) == 1);
        star3.SetActive(PlayerPrefs.GetInt("Star3Unlocked", 0) == 1);
    }
}
