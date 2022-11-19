using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackDirector : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("OK");
        SceneManager.LoadScene("StageSelect");
    }
}
