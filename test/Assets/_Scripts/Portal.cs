using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private Animator levelLoaderAnimator;
    [SerializeField] private string sceneName;
    [SerializeField] private Canvas portalTxt;
    string CROSSFADE_START = "Crossfade_Start";
    string CROSSFADE_END = "Crossfade_End";

    private void Start()
    {
        portalTxt.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            portalTxt.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E");
                 LoadScene();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        portalTxt.enabled = false;
    }

    private void Update()
    {

    }

    private void LoadScene()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        levelLoaderAnimator.Play(CROSSFADE_START);

        yield return new WaitForSeconds(1f);

        levelLoaderAnimator.Play(CROSSFADE_END);

        SceneManager.LoadScene(sceneName);
    }
}
