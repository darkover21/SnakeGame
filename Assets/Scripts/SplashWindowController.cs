using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashWindowController : MonoBehaviour
{
    public GameObject escButton;
    public GameObject escButtonClicked;
    public Image gamesIcon;
    public Image businessIcon;
    public Image formationIcon;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(SplashWindow());

    }

    IEnumerator SplashWindow()
    {
        // Clicked 1
        escButton.SetActive(false);
        escButtonClicked.SetActive(true);
        audioSource.Play(0);
        yield return new WaitForSeconds(0.5f);
        escButton.SetActive(true);
        escButtonClicked.SetActive(false);

        businessIcon.gameObject.SetActive(true);
        gamesIcon.gameObject.SetActive(true);
        formationIcon.gameObject.SetActive(true);
        // Move company icons from center to their place
        for (int i = 0; i < 150; i+=20) {
            businessIcon.rectTransform.position = escButtonClicked.transform.position + new Vector3(0,1, 0) * i;
            gamesIcon.rectTransform.position = escButtonClicked.transform.position + new Vector3(-1, -1, 0) * i;
            formationIcon.rectTransform.position = escButtonClicked.transform.position + new Vector3(1, -1, 0) * i;
            yield return new WaitForSeconds(0.1f);
        }
/*
        // Clicked 2
        escButton.SetActive(false);
        escButtonClicked.SetActive(true);
        audioSource.Play(0);
        yield return new WaitForSeconds(0.5f);
        escButton.SetActive(true);
        escButtonClicked.SetActive(false);

        gamesIcon.gameObject.SetActive(true);
        // games Icon move down left
        for (int i = 0; i < 400; i += 40)
        {
            gamesIcon.rectTransform.position = escButtonClicked.transform.position + new Vector3(-1, -1, 0) * i; 
            yield return new WaitForSeconds(0.1f);
        }

        // Clicked 3
        escButton.SetActive(false);
        escButtonClicked.SetActive(true);
        audioSource.Play(0);
        yield return new WaitForSeconds(0.5f);
        escButton.SetActive(true);
        escButtonClicked.SetActive(false);

        formationIcon.gameObject.SetActive(true);
        // education Icon move down right
        for (int i = 0; i < 400; i += 40)
        {
            formationIcon.rectTransform.position = escButtonClicked.transform.position + new Vector3(1, -1, 0) * i; 
            yield return new WaitForSeconds(0.1f);
        }
        */
        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene(1);
    }
}
