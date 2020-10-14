using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class forProgressBar : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public GameObject player;

    private Slider slider;
    private float s;
    private float f;
    void Start()
    {
        slider = GetComponent<Slider>();

        s = start.transform.position.x;
        f = finish.transform.position.x;

        slider.minValue = s;
        slider.maxValue = f;
    }

    // Update is called once per frame
    void Update()
    {

       if(player.transform.position.x>s &&player.transform.position.x<f)
        {
            slider.value = player.transform.position.x;
        }

    }
}
