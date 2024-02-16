using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenHandScript : MonoBehaviour
{
    private Singleton _singletonManager;
    public UDPReceive _udpReceive;
    public GameObject greenHand;
    public SpriteRenderer greenHandSprite;

    private string center_2, type_2;
    private int margin = 5, divider = 100;


    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void Update() {
        if (_udpReceive.receivedData.Length != 0) {
            type_2 = _udpReceive.type_1;
            if (type_2 == "Right")
                greenHandSprite.flipX = false;
            else
                greenHandSprite.flipX = true;

            center_2 = _udpReceive.center_2;
            if (center_2.Length != 0) {
                center_2 = center_2.Remove(0, 1);
                center_2 = center_2.Remove(center_2.Length - 1, 1);

                string[] center_coor = center_2.Split(',');
                float hand_x = margin - float.Parse(center_coor[0]) / divider;
                float hand_y = float.Parse(center_coor[1]) / divider;

                greenHand.transform.localPosition = new Vector3(hand_x, -hand_y, 0);
            }
        }
    } //-- update end

    /*
    private float speed = 20.0f;
    private Rigidbody2D rb;

    void Start() {
        _singletonManager = Singleton.Instance;

        rb = GetComponent<Rigidbody2D>();
    } //-- start end

    void Update() {
        float h = Input.GetAxis("LeftHand_X");
        float v = Input.GetAxis("LeftHand_Y");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
    } //-- Update end
    */


} //-- class end


/*
Project: 
Made by: 
*/

