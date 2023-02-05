using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestroyElement : MonoBehaviour
{
    public Image Frame1;
    public Image Frame2;
    public Image Frame3;
    void start()
    {

        Destroy(Frame1, 3);
        Destroy(Frame2, 3);
        Destroy(Frame3, 3);
        SceneManager.LoadScene("Level 1");
    }
}
