using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{
    public int currentSlide = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if(currentSlide == 3){
                FindObjectOfType<LevelLoader>().ChangeLevels(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else {
                this.gameObject.transform.GetChild(3).SetSiblingIndex(0);
                currentSlide++;
            }
        }
    }
}