using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int currentLevel;
    public int currentExp; //current experience 
    public int[] toLevelUp; // creates arrary using []

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentExp >= toLevelUp[currentLevel])
        {
            currentLevel++; // shortened version of adding 1 to current level 
        }
    }


    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;    
    }
}
