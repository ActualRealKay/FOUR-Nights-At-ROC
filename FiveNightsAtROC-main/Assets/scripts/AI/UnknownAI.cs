using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnknownAI : MonoBehaviour
{
    private string currentlocation;

    public int ailevel;

    private int hallwindow;

    public GameObject wait;
    public GameObject Hidden;
    public GameObject Cam1;
    public GameObject Cam2;

    public GameObject jumpscareobject;

    public GameObject cam2static;
    public GameObject cam1static;

    public GameObject shitdatindewegzit;

    public AudioSource gonegeluid;
    public AudioSource glitchgeluid;
    public Canvas deurui;
    public GameObject doorcam;
    public Button backtoofficebutton;
    public GameObject camerahandler;
    public AudioSource jumpscare;

    // 👇 Object that should blink in Cam2
    public GameObject blinkObject;
    private Coroutine blinkRoutine;

    void Start()
    {
        currentlocation = "scriptedwait";

        // Make sure blink object is off at start
        blinkObject.SetActive(false);

        StartCoroutine(UnknownMove());
    }

    IEnumerator UnknownMove()
    {
        yield return new WaitForSeconds(5f);

        int chance = UnityEngine.Random.Range(1, 21);
        Debug.Log(chance);

        if (currentlocation == "scriptedwait")
        {
            yield return new WaitForSeconds(150f);
            wait.gameObject.SetActive(false);
            currentlocation = "hidden";
            Hidden.gameObject.SetActive(true);
        }
        else
        {
            if (chance <= ailevel || currentlocation == "hidden")
            {
                if (currentlocation == "hidden")
                {
                    Hidden.gameObject.SetActive(false);
                    cam2static.SetActive(true);
                    currentlocation = "cam2";
                    Cam2.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam2static.SetActive(false);

                    // 🔥 Start blinking when in cam2
                    if (blinkRoutine == null)
                        blinkRoutine = StartCoroutine(Blink(blinkObject, 0.5f));
                }
                else if (currentlocation == "cam2")
                {
                    cam2static.SetActive(true);
                    cam1static.SetActive(true);
                    Cam2.gameObject.SetActive(false);
                    currentlocation = "cam1";
                    Cam1.gameObject.SetActive(true);
                    yield return new WaitForSeconds(0.1f);
                    cam2static.SetActive(false);
                    cam1static.SetActive(false);

                    // 🛑 Stop blinking and fully disable when leaving cam2
                    if (blinkRoutine != null)
                    {
                        StopCoroutine(blinkRoutine);
                        blinkRoutine = null;
                        blinkObject.SetActive(false);
                    }
                }
                if (currentlocation == "cam1")
                {
                    yield return new WaitForSeconds(6f);
                    if (doorcam.activeSelf && !(backtoofficebutton.IsActive()))
                    {
                        Cam1.gameObject.SetActive(false);
                        currentlocation = "hidden";
                        glitchgeluid.Play();
                        gonegeluid.Play();
                        Hidden.gameObject.SetActive(true);
                    }
                    else
                    {
                        Cam1.gameObject.SetActive(false);
                        shitdatindewegzit.SetActive(false);
                        backtoofficebutton.gameObject.SetActive(false);
                        currentlocation = "office";
                        camerahandler.GetComponent<Cameras>().SwitchToCamDown(true);
                        camerahandler.GetComponent<Cameras>().BackToTheOffice(true);
                        jumpscareobject.gameObject.SetActive(true);
                        jumpscare.Play();
                        yield return new WaitForSeconds(1f);

                        Application.Quit();
                    }
                }
            }
        }

        // Continue the coroutine
        StartCoroutine(UnknownMove());
    }

    // 👇 Blinking effect coroutine
    IEnumerator Blink(GameObject obj, float interval)
    {
        while (true)
        {
            obj.SetActive(!obj.activeSelf);
            yield return new WaitForSeconds(interval);
        }
    }
}
