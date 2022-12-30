using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroDirector : MonoBehaviour
{
    public Text CountText;
    float countdown = 10f;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        count = (int)countdown;
        CountText.text = count.ToString() + " 秒後スタート";

        if(SceneManager.GetActiveScene().name == "IntroScene01")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("EggScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "IntroScene01")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("EggScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "IntroScene02")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("PinchiScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "IntroScene03")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("IceScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "IntroScene04")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("MatigaeScene");
            }
        }

        if (SceneManager.GetActiveScene().name == "IntroScene05")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("tumu");
            }
        }

        if (SceneManager.GetActiveScene().name == "IntroScene06")
        {
            if (countdown < 0)
            {
                SceneManager.LoadScene("ChairScene");
            }
        }
    }
}
