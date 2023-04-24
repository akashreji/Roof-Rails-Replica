using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElements : MonoBehaviour
{
    public  GameObject smallLogPosition;
    public  GameObject largeLogPosition;

  //  Vector3 logPosition = new Vector3(-4.12f, 0f, 0f); 
  //  Quaternion logRotation = new Quaternion(-0f, 0f, 0f,0f); 
    void Start()
    {
        ObjectPooler.Instance.SpawnFromPool("SmallLog", smallLogPosition.transform.position, smallLogPosition.transform.rotation);
        ObjectPooler.Instance.SpawnFromPool("LargeLog", largeLogPosition.transform.position, largeLogPosition.transform.rotation);
    }

    private void FixedUpdate()
    {

    }
    void Update()
    {
        
    }
}
