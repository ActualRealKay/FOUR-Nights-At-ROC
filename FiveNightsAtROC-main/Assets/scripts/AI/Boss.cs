using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BOSS : MonoBehaviour
{
    [Header("Cams")]
    public GameObject[] bossCams;      // cams 1-9
    public GameObject[] staticCams;    // statics 1-9

    [Header("Office")]
    public GameObject bossOffice;
    public GameObject camerahandler;
    public AudioSource jumpscareSound;
    public AudioSource leaveSound;
    public AudioSource appearSound;    // play when boss spawns in a cam

    [Header("Controls")]
    public int aiLevel;
    public Canvas deurui;
    public GameObject doorcam;
    public Button backtoofficebutton;
    public GameObject shitdatindewegzit;

    [Header("Leave Buttons (bosslurebutton)")]
    public Button[] leaveButtons;      // one button per cam (skip cam 8)

    private int currentCamIndex = -1;
    private bool isInOffice = false;

    void Start()
    {
        // hook each leave button automatically to only affect its cam
        for (int i = 0; i < leaveButtons.Length; i++)
        {
            int index = i; // capture cam index
            leaveButtons[i].onClick.AddListener(() => LeaveCamSafely(index));
        }

        StartCoroutine(BossRoutine());
    }

    IEnumerator BossRoutine()
    {
        yield return new WaitForSeconds(5f); // initial delay
        while (!isInOffice)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));

            int chance = Random.Range(1, 21);
            if (chance <= aiLevel)
            {
                // pick random cam 1-9, skip cam 8 (index 7)
                int newCam;
                do
                {
                    newCam = Random.Range(0, bossCams.Length);
                } while (newCam == 7);

                // deactivate previous cam if it exists
                if (currentCamIndex != -1)
                    bossCams[currentCamIndex].SetActive(false);

                // activate new cam + flash static
                currentCamIndex = newCam;

                // play spawn sound
                if (appearSound != null)
                    appearSound.Play();

                bossCams[currentCamIndex].SetActive(true);
                staticCams[currentCamIndex].SetActive(true);
                yield return new WaitForSeconds(0.1f);
                staticCams[currentCamIndex].SetActive(false);

                // stay in cam for random timer
                float stayTime = Random.Range(5f, 10f);
                float elapsed = 0f;
                while (elapsed < stayTime)
                {
                    if (currentCamIndex == -1) // player pressed leave
                        break;

                    elapsed += Time.deltaTime;
                    yield return null;
                }

                // timer expired → jumpscare if still in cam
                if (currentCamIndex != -1 && elapsed >= stayTime)
                    BossJumpscare();
            }
        }
    }

    // leave button calls this with its cam index
    public void LeaveCamSafely(int camIndex)
    {
        // disable the button no matter what
        leaveButtons[camIndex].gameObject.SetActive(false);
        StartCoroutine(ReenableButton(camIndex, 5f));

        // only remove boss if he's actually in this cam
        if (currentCamIndex == camIndex)
        {
            bossCams[currentCamIndex].SetActive(false);
            leaveSound.Play();
            currentCamIndex = -1; // allow new random cam spawn
        }
    }

    private IEnumerator ReenableButton(int camIndex, float delay)
    {
        yield return new WaitForSeconds(delay);
        leaveButtons[camIndex].gameObject.SetActive(true);
    }

    void BossJumpscare()
    {
        if (currentCamIndex != -1)
            bossCams[currentCamIndex].SetActive(false);

        jumpscareSound.Play();
        isInOffice = true;
        bossOffice.SetActive(true);

        if (shitdatindewegzit) shitdatindewegzit.SetActive(false);
        if (deurui) deurui.gameObject.SetActive(false);
        if (backtoofficebutton) backtoofficebutton.gameObject.SetActive(false);
        if (camerahandler)
        {
            camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
            camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
        }

        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameOver");
    }
}
