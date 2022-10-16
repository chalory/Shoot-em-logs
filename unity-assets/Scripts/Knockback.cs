using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour{

    public float thrust;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("monster")){
            Debug.Log("collide");
            Rigidbody2D monster = other.GetComponent<Rigidbody2D>();
            if(monster != null){
                monster.isKinematic = false;
                Vector2 difference = monster.transform.position - transform.position;
                difference = difference.normalized * thrust;
                monster.AddForce(difference, ForceMode2D.Impulse);
                monster.isKinematic = true;
            }
        }
    }
}
