using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;
    public float startForceUp = 10f;
    public float startForceFoward = 10f;
    public float autodestructionTime = 5f;
    bool hit = false;

    [SerializeField]
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, startForceUp, -startForceFoward, ForceMode.Impulse);
        StartCoroutine(Suicide(autodestructionTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Suicide(float OmaeWaMouShindeiru)
    {
        yield return new WaitForSeconds(OmaeWaMouShindeiru);
        Destroy(gameObject);
    }

    void OnCollisionEnter (Collision collider){
        if (collider.gameObject.tag == "Hoop"){
            hit = true;
        }
        
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Point"){
            Debug.Log("Zdobyłem punkt!!");
            scorePoints();
        }
    }

    void scorePoints(){
        Debug.Log("Czy manager coś ma " + (manager!= null));
            manager.scorePoints();
    }
}
