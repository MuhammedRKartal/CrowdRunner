using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speeding : MonoBehaviour
{
    public int x;
    public float y;
    public static int speedX;
    public static float seconds;
    void Start(){
        speedX = x;
        seconds = y;
    }

}
