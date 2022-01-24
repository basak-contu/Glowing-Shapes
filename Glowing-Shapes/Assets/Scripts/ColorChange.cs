using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material mymat = GetComponent<Renderer>().material;
        float H, S, V;

        //Color.RGBToHSV(mymat.GetColor("_EmissionColor"), out H, out S, out V);
        //Debug.Log("H: " + H + " S: " + S + " V: " + V);
        float m_Hue = Random.Range(0.0f, 1.0f);
        float m_Saturation = 1.0f;
        float m_Value = 4.0f;
        //m_Renderer.material.color = Color.HSVToRGB(m_Hue, m_Saturation, m_Value);
        mymat.SetColor("_EmissionColor", Color.HSVToRGB(m_Hue, m_Saturation, m_Value));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
