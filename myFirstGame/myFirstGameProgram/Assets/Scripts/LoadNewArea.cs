using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string levelToLoad;

    public string exitPoint;

    private PlayerController thePlayer;

    private static bool loadAreaExists;    
    
    // Start is called before the first frame update
    void Start()
    {

//        if(!loadAreaExists) 
//        {
//            loadAreaExists = true;
//            DontDestroyOnLoad(transform.gameObject);
//        }
        
        thePlayer = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}