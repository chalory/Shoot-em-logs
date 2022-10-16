using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    // public float maxBulletDistance;
    public float thrust;
    public float knockBackTime;

    private int hitCount = 0;

    // Start is called before the first frame update
    void Start(){
        Object.Destroy(gameObject, 1.0f);

        GameObject player = GameObject.FindGameObjectWithTag("Player");     
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }


    // void Update(){
    //     if (transform.position.magnitude >= maxBulletDistance){
    //         Object.Destroy(gameObject);
    //     }
    // }

   void OnCollisionEnter2D(Collision2D collision) {
        Object.Destroy(gameObject);
   }

    private void OnTriggerEnter2D(Collider2D other) {
        Object.Destroy(gameObject);

        if(other.CompareTag("breakable")){
            other.GetComponent<pot>().Smash();
        }

         if(other.gameObject.CompareTag("monster")){
            Rigidbody2D monster = other.GetComponent<Rigidbody2D>();
            if(monster != null){
                hitCount = hitCount +  1;
                Debug.Log(hitCount);
                other.gameObject.SetActive(false);
                // Vector2 difference = monster.transform.position - transform.position;
                // difference = difference.normalized * thrust;
                // monster.AddForce(difference, ForceMode2D.Impulse);
                // StartCoroutine(KnockCo(monster));
               
            }
        }    
       
    }

    private IEnumerator KnockCo(Rigidbody2D monster){
        if(monster != null){
            yield return new WaitForSeconds(knockBackTime);
            monster.velocity = Vector2.zero;
        }
    }
}


