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
        CountText.text = count.ToString() + "　秒後にスタート";

        if(countdown < 0)
        {
            SceneManager.LoadScene("EggScene");
        }
    }
}
