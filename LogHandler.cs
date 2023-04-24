using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogHandler : MonoBehaviour
{
    [SerializeField] public static int logId; //to identify which gameobject has player collided with
    [SerializeField] private GameObject defaultLog;
    Rigidbody logRB;
    private void Awake()
    {
        gameObject.SetActive(true);
    }
    void Start()
    {
        defaultLog = GameObject.FindGameObjectWithTag("DefaultLog");
        GameHandler.current.playerTriggeredEvent += PlayerTriggeredLog;
        logRB = GetComponent<Rigidbody>();
    }

    public void PlayerTriggeredLog(string item)
    {
        if (defaultLog != null && defaultLog.transform.localScale.y < 9 && item == "Log")
        {
            Vector3 temp = defaultLog.transform.localScale;
            temp.y += 0.1f;
            defaultLog.transform.localScale = temp;
        }
       
        if (defaultLog != null && defaultLog.transform.localScale.y >=0 && item == "Lava")
        {
            Vector3 temp = defaultLog.transform.localScale;
            temp.y -= 0.005f;
            defaultLog.transform.localScale = temp;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Rod"))
        {
            logRB.AddForce(transform.up * 20f);
        }
    }

    private void OnDestroy()
    {
        GameHandler.current.playerTriggeredEvent -= PlayerTriggeredLog;
    }
}
