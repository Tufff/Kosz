using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;
    public float startForceUp = 10f;
    public float startForceFoward = 10f;
    public float autodestructionTime = 5f;
    bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
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
            UnityEngine.Debug.Log("collision"); // PROBL3M
            GameManager.instance.ResetCombo();
        }
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Point"){
            ScorePoints();
        }
    }

    void ScorePoints(){
            GameManager.instance.ScorePoints();
    }
}
