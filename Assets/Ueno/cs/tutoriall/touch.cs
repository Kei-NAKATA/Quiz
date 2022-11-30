using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class touch : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("ok.");
        SceneManager.LoadScene("tutoriall10");
    }
}
