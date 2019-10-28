using UnityEngine;
using System.Collections;
 
public class Rebote : MonoBehaviour
{
    [SerializeField]
    private string playerTag;//set to Player in inspector
    [SerializeField]
    private Vector3 direction;
    [SerializeField]
    private float force;
    [SerializeField]
    private Rigidbody rigidBody;

    private float maxVelocity=20f;
    private float randomx;
    private float randomz;
    Animator animacion;
    void Start (){
    }
    void FixedUpdate (){
        randomx=Random.Range(-0.5f,0.5f);
        randomz=Random.Range(-0.5f,0.5f);
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(this.playerTag))
        {
            Rigidbody rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            if (rigidBody != null)
            {
                direction.x=randomx;
                direction.y=0;
                direction.z=randomz;
                //rigidBody.velocity = rigidBody.velocity + this.direction * this.force;
                rigidBody.AddForce(this.direction * this.force, ForceMode.Impulse);
                //rigidBody.velocity = transform.up * rigidBody.velocity.magnitude;
                rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);
            }

        }

    }
    
}