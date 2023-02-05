using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public bool touching = false;

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            print("touching");
            StartCoroutine(LoadLevel(1));
        }
    }

    IEnumerator LoadLevel(int level){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
