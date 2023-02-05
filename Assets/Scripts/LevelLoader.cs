using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject GameManager;
    public Animator transition;
    public float transitionTime = 1f;
    public int nextLevel;


    void Update()
    {
        if (GameManager.GetComponent<GameManager>().victory)
        {
            StartCoroutine(LoadLevel(nextLevel));
        }
    }

    IEnumerator LoadLevel(int level){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
