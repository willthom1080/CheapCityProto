using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject GameManager;
    public Animator transition;
    public float transitionTime = 1f;

    public void ChangeLevels(int level){
        if(level == 6){
            StartCoroutine(LoadLevel(0));
        } else{
        StartCoroutine(LoadLevel(level));
        }
    }

    public IEnumerator LoadLevel(int level){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
