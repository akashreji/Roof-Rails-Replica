using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogCutter :MonoBehaviour
{
    private void Start()
    {
        
    }

    public void Cut(Transform cutter)
    {
        if (cutter.transform.position.x < 0)
        {
            // scale 2 x:1 cutter x -0.5      
            // left
            float y = transform.localScale.y;
            y -= transform.position.x;
            float dist = y + cutter.position.x;
            Debug.Log("dist : " + dist);
            if (dist / 2 > 0)
            {
                // 3 -0.5=2.5
                // 0 + 0.5 = 0.5

                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x + dist / 2, transform.position.y, transform.position.z);
                 gameObject.SetActive(false);
                GameObject cutOffCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);

                cutOffCylinder.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                cutOffCylinder.transform.rotation = transform.rotation;
                cutOffCylinder.transform.position = new Vector3(-(y - cutOffCylinder.transform.localScale.y), transform.position.y, transform.position.z);

                cutOffCylinder.AddComponent<Rigidbody>();
                cutOffCylinder.gameObject.SetActive(false);
            }
            // cutter -1 yeni pos -2 scale 1
            // cutter -0.5 yeni pos -1.75 scale 1.25
        }
        else
        {
            // right
            // scale 3 cutter 1 
            float y = transform.localScale.y;
            y += transform.position.x;
            float dist = y - cutter.position.x;

            if (dist / 2 > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - dist / 2, transform.localScale.z);
                transform.position = new Vector3(transform.position.x - dist / 2, transform.position.y, transform.position.z);

                GameObject cutOffCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                cutOffCylinder.transform.localScale = new Vector3(transform.localScale.x, dist / 2, transform.localScale.z);
                cutOffCylinder.transform.rotation = transform.rotation;
                cutOffCylinder.transform.position = new Vector3(y - cutOffCylinder.transform.localScale.y, transform.position.y, transform.position.z);
                
                cutOffCylinder.AddComponent<Rigidbody>();
                cutOffCylinder.gameObject.SetActive(false);
            }
        }
    }
    [SerializeField] public static float diamondsCollected;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Saw")
        {
            if (transform.localScale.y < 0.05)
            {
                this.gameObject.SetActive(false);
                GameHandler.current.GameHasEndedFunc();
            }
            else
            Cut(other.gameObject.transform);
        }
        else
            if(other.gameObject.tag == "Diamonds")
        {
            diamondsCollected += 50;
            other.gameObject.SetActive(false);
        }
    }
}