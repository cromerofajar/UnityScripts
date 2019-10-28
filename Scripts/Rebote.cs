using UnityEngine;
using System.Collections;
 
public class Rebote : MonoBehaviour
{
    [SerializeField]
    //Tag del jugador
    private string playerTag;
    [SerializeField]
    //Direccion en la que se mueve en 3D
    private Vector3 direction;
    [SerializeField]
    //Fuerza del moviento
    private float force;
    [SerializeField]
    //Cuerpo al que se aplica
    private Rigidbody rigidBody;
    
    //Velocidad maxima que puede alcanzar el cuerpo al salir rebotado.
    private float maxVelocity=20f;
    //Variables aleatorias con la direccion del rebote.
    private float randomx;
    private float randomz;
    
    void Start (){
    }
    void FixedUpdate (){
        //Asignacion de las variables aleatorias con la direccion de rebote.
        randomx=Random.Range(-0.5f,0.5f);
        randomz=Random.Range(-0.5f,0.5f);
        //Se comprueba la velocidad del cuerpo y si ha alcanzado la velocidad maxima.
        rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);
    }
    void OnTriggerEnter(Collider collider)
    {
        //Comprueba si choco con el jugador
        if (collider.gameObject.CompareTag(this.playerTag))
        {
            //En caso de chocar el jugador comprueba si fue el cuerpo correcto
            Rigidbody rigidBody = collider.gameObject.GetComponent<Rigidbody>();
            //Si choca un cuerpo correcto realiza el rebote
            if (rigidBody != null)
            {
                //le asigna las variables aleatorias a X,Z y se deja a 0 para evitar que el cuerpo salga disparado hacia arriba
                direction.x=randomx;
                direction.y=0;
                direction.z=randomz;
                //velocidad del cuerpo es = velocidad del cuerpo + direccion aleatoria * fuerza
                //ForceMode.Impulse realiza la repulsion de la esfera hacia la dirrecion aleatoria en caso de ser opuesta a la
                // que esta realizaria el efecto contrario, magnetismo.
                rigidBody.AddForce(this.direction * this.force, ForceMode.Impulse);
                //Comprueba que no sobrepase la velocidad maxima del cuerpo.
                rigidBody.velocity = Vector3.ClampMagnitude(rigidBody.velocity, maxVelocity);
            }

        }

    }
    
}
