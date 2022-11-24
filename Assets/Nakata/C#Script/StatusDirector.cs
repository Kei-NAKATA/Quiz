using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusDirector : MonoBehaviour
{
    [SerializeField] GameObject number;
    [SerializeField] GameObject clear;

    private int quantity = 5;
    // Start is called before the first frame update
    void Start()
    {
        number.GetComponent<Text>().text = quantity + "‚Â";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NumberClick()
    {
        if(quantity > 0)
        {
            quantity = quantity - 1;
            number.GetComponent<Text>().text = quantity + "‚Â";

            if(quantity == 0)
            {
                clear.SetActive(true);
            }
        }
      
    }
}
