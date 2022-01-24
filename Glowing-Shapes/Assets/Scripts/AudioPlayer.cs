using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shape Collision")]
    [SerializeField] AudioClip shapeCollisionClip;
    [SerializeField] [Range(0f, 1f)] float shapeCollisionVolume = 1f;
    
    public void PlayShapeCollisionClip()
    {
        if(shapeCollisionClip != null)
        {
            AudioSource.PlayClipAtPoint(shapeCollisionClip, 
                                        Camera.main.transform.position, 
                                        shapeCollisionVolume);
        }
    }
}
