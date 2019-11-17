using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCaveEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject FirstRoomObject, OusideObject, caveObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //cue door closing
            //play door closeing sound
            OusideObject.SetActive(true);//turn on outside room
            FirstRoomObject.SetActive(false);//turn off first room
            caveObject.SetActive(false);//turns off the cave so you just have an arch
        }
    }
}
