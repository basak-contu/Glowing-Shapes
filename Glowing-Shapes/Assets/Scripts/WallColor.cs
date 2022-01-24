using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColor : MonoBehaviour
{
    Color[] colors;

    void Awake()
    {
        colors = new Color[6];
        colors[0] = new Color(0, 204, 204);
        colors[1] = new Color(255, 246, 0);
        colors[2] = new Color(255, 0, 102);
        colors[3] = new Color(25, 227, 177);
        colors[4] = new Color(255, 127, 51);
        colors[5] = new Color(184, 60, 130);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Color[] colors = { new Color(0, 204, 204), new Color(255, 246, 0), new Color(255, 0, 102), new Color(25, 227, 177), new Color(255, 127, 51), new Color(184, 60, 130) };
        var randomIndex = Random.Range(0, colors.Length);
        Color randomColor = colors[randomIndex];
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.GetComponent<Renderer>().material.color = randomColor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
