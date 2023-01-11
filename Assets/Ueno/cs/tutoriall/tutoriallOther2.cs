using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutoriallOther2 : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClick()
    {
        Debug.Log("ok.");
        SceneManager.LoadScene("StageSelect");
    }
}