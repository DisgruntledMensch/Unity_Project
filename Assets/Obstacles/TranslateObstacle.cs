using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateObstacle : MonoBehaviour
{

    public float speed;
    public float distance;
    private float xStartPosition;
    // Start is called before the first frame update
    void Start()
    {
        xStartPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < xStartPosition || transform.position.x > xStartPosition + distance)
        {
            speed *= -1;
        }
        
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
   
    }
}
