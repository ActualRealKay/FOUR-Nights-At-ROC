using UnityEngine;

public class BonusNightStars : MonoBehaviour
{
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    void Start()
    {
        int starToShow = PlayerPrefs.GetInt("BonusStar", 0); // Default 0 = none

        // Disable all stars first
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        // Enable the correct star
        if (starToShow == 1) star1.SetActive(true);
        else if (starToShow == 2) star2.SetActive(true);
        else if (starToShow == 3) star3.SetActive(true);
    }
}
