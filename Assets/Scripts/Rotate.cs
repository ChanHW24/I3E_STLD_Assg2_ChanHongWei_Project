/*
 * Author: Chan Hong Wei
 * Date: 27/06/2024
 * Description: 
 * Contain script to keep items rotate automatically
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    private void Update()
    {
        transform.Rotate(0, 1f, 0);
    }

}
