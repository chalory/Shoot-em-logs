using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class log : Monster {

    private Rigidbody2D myRigidbody;

    public Transform target;
    public Transform homePosition;
    public float chaseRadius;
    public float attackRadius;

    private Animator anim;

    // Start is called before the first frame update
    void Start(){
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        CheckDistance();
    }

    void CheckDistance(){
        // find distance between log and target
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius){

            anim.SetBool("wakeUp", true);

            Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

            myRigidbody.MovePosition(temp);
        }
        else{
             anim.SetBool("wakeUp", false);

        }
    }
}
