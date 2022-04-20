using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Camera_follow : MonoBehaviour
{
    public Transform transform_player;
    private Transform transform1;
    public float smooth;

   
    // Start is called before the first frame update
    void Start()
    {
        transform1=GetComponent<Transform>();
    }
    void LateUpdate()
    { 

        if (transform_player != null)
        {
            if (transform1.position != transform_player.position)
            {
                Vector3 CameraFollow = transform_player.position;
                transform1.position = Vector3.Lerp(transform1.position, CameraFollow, smooth);
            }
        }
    }
}
