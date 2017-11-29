using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFunction : MonoBehaviour {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_rate">true rate</param>
    /// <returns></returns>
    public static bool randomTrueAndFalse(float _rate) {
        float index = Random.Range(0, 100);
        if(index < _rate)
        {
            return true;
        }else{
           return false;
        }

    }
}
