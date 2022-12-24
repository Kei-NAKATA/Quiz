using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggDirector : MonoBehaviour
{
    [SerializeField] GameObject clear;
    int hp = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (hp > 0){
                hp = hp - 1;
            }
        }

        if (hp == 0)
        {
            Sprite gazo = Resources.Load<Sprite>("egg2");
            GameObject.Find("Canvas/Image").GetComponent<UnityEngine.UI.Image>().sprite = gazo;
            clear.SetActive(true);
        }
    }
}
