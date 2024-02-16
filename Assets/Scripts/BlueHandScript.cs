using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueHandScript : MonoBehaviour
{
    private Singleton _singletonManager;
    public UDPReceive _udpReceive;
    public GameObject blueHand;
    public SpriteRenderer blueHandSprite;

    private string center_1, type_1;
    private int margin = 5, divider = 100;


    void Start() {
        _singletonManager = Singleton.Instance;
    } //-- start end

    void Update() {
        if(_udpReceive.receivedData.Length != 0) {
            type_1 = _udpReceive.type_1;
            if(type_1 == "Right")
                blueHandSprite.flipX = true;
            else
                blueHandSprite.flipX = false;

            center_1 = _udpReceive.center_1;
            if(center_1.Length != 0) {
                center_1 = center_1.Remove(0, 1);
                center_1 = center_1.Remove(center_1.Length - 1, 1);

                string[] center_coor = center_1.Split(',');
                float hand_x = margin - float.Parse(center_coor[0]) / divider;
                float hand_y = float.Parse(center_coor[1]) / divider;

                blueHand.transform.localPosition = new Vector3(hand_x, -hand_y, 0);
            }
        }
    } //-- update end

    /*
    private float speed = 20.0f;
    private Rigidbody2D rb;

    void Start()
    {
        _singletonManager = Singleton.Instance;

        rb = GetComponent<Rigidbody2D>();
    } //-- start end

    void Update()
    {
        float h = Input.GetAxis("RightHand_X");
        float v = Input.GetAxis("RightHand_Y");

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

