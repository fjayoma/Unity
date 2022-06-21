using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public int damageToGive;
    public GameObject damageBurst;
    public Transform HitPoint;
    public GameObject damageNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy") 
        {
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToGive);
            Instantiate(damageBurst,HitPoint.position,HitPoint.rotation);
            var clone = (GameObject) Instantiate(damageNumber,HitPoint.position,Quaternion.Euler(Vector3.zero)); // creating an object
            clone.GetComponent<FloatingNumbers>().damageNumber = damageToGive;
        }
    }        
}
