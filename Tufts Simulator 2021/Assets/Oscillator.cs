using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    float t = 0;

    float speed;
    float h;
    float w;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2; 
        h = 4; 
        w = 4;
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime*speed;
        float x = Mathf.Cos(t * w); 
        float y = Mathf.Cos(t * h);
        float z = 5; 

        transform.position = new Vector3(x, y, z);

    }
}
