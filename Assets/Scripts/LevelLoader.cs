using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject GameManager;
    public Animator transition;
    public float transitionTime = 1f;


    void Update()
    {
        if (GameManager.GetComponent<GameManager>().victory)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void ChangeLevels(int level){
        StartCoroutine(LoadLevel(level));
    }

    public IEnumerator LoadLevel(int level){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
