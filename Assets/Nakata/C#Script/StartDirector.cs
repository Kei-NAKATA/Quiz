using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    //’·‰Ÿ‚µ‚Æ”»’è‚·‚éŽžŠÔ‚ðŠÇ—
    float span = 2.0f;
    //’·‰Ÿ‚µ‚µ‚Ä‚¢‚éƒtƒŒ[ƒ€”‚ð‹L˜^
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            this.delta += Time.deltaTime;
        }

        if (this.delta > this.span)
        {
            SceneManager.LoadScene("tutoriall");
        }
    }
}
