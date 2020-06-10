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
    public Material normalBall;
    public Material superBall;
    bool pointScored = false;
    bool isSuperBall = false;

    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = normalBall;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, startForceUp, -startForceFoward, ForceMode.Impulse);
        //StartCoroutine(Suicide(autodestructionTime));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -1f){
            if (!pointScored){
                GameManager.instance.GameOver();
            }
            Destroy(gameObject);
        }
        if (GameManager.instance.superBall != isSuperBall){
            ChangeBall();
        }
    }

    /*IEnumerator Suicide(float OmaeWaMouShindeiru)
    {
        yield return new WaitForSeconds(OmaeWaMouShindeiru);
        Destroy(gameObject);
    }*/

    void OnCollisionEnter (Collision collider){
        bool gotThisCollision = false;
        if (collider.gameObject.tag == "Hoop" && !gotThisCollision){
            gotThisCollision = true;
            GameManager.instance.ResetCombo();
        }
    }

    void OnTriggerEnter(Collider collider){
        if (collider.tag == "Point"){
            GameManager.instance.ballCounter += 1;
            ScorePoints();
            pointScored = true;
        }
    }

    void ScorePoints(){
            GameManager.instance.ScorePoints();
    }

    void ChangeBall(){
        if (isSuperBall){
            rend.sharedMaterial = normalBall;
            isSuperBall = false;
        }else{
            rend.sharedMaterial = superBall;
            isSuperBall = true;
        }
    }
}
