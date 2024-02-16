using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private Singleton _singletonManager;
    private Rigidbody2D rb;
    private Animator animator;

    public float accelerationTime = 2.0f;
    public float maxSpeed = 5.0f;
    public float bounds = 1.0f;

    private Vector2 movement;
    private float rotSpeed;

    private float timeLeft = 0.1f;
    private float elapsedTime = 0.0f, seconds = 5.0f;


    void Start() {
        _singletonManager = Singleton.Instance;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rotSpeed = Random.Range(0, 2) * 2 - 1;

        
        // bubble scale
        float scale = Random.Range(0.8f, 1.5f);
        transform.localScale = new Vector3(scale, scale, scale);

        /*
        Vector3 initScale = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 targetScale = new Vector3(scale, scale, scale);

        while(elapsedTime < seconds) {
            transform.localScale = Vector3.Lerp(initScale, targetScale, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
        }
        */
        
    }


    void Update() {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0 ) {
            movement = new Vector2(Random.Range(bounds, -bounds), Random.Range(bounds, -bounds));
            timeLeft += accelerationTime;
        }
    } //-- Update end


    void FixedUpdate() {
        rb.AddForce(movement * maxSpeed);
        rb.rotation = bounds * Time.deltaTime;
    } //-- FixedUpdate end

    private void OnCollisionEnter2D(Collision2D other) {
        if(this.tag == "GreenBubble" && other.gameObject.tag == "GreenHand") {
            StartCoroutine(BubblePop());
        }

        if (this.tag == "BlueBubble" && other.gameObject.tag == "BlueHand") {
            StartCoroutine(BubblePop());
        }
    } //-- OnCollisionEnter2D end

    IEnumerator BubblePop() {
        animator.SetTrigger("BubblePop");
        yield return new WaitForSeconds(0.8f);
        Destroy(this.gameObject);
    } //-- BubblePop

} //-- class end


/*
Project: 
Made by: 
*/

