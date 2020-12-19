/***********************************************************************;
* Project            : Game2014_F2020_FinalTest
*
* Author             : David Gasinec
* 
* Student Number     : 101187910
*
* Date created       : 20/12/19
*
* Description        : Controls shrinking platform logic.
*
* Last modified      : 20/12/19
*
* Revision History   :
*
*Date        Author Ref    Revision (Date in YYYYMMDD format) 
*201024    David Gasinec        Created script. 
*
|**********************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** Controls the platform. */
public class FloatingPlatform : MonoBehaviour
{
    public AudioSource shrinkSound;
    public AudioSource resetSound;
    public Vector3 groundLevel;
    public Rigidbody2D rb;
    public GameObject platform;
    public Vector3 startPOS;
    public Vector3 reset;
    private bool isOn;
    private bool playSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPOS = transform.localScale;
        reset = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        /** Makes the platform "float". */
        _toggle();


        /** Shrinks the platform. */
        if (isOn && this.transform.localScale.x >=0.1)
        {
            this.transform.localScale = this.transform.localScale -= new Vector3(0.5f, 0.5f, 0) * Time.deltaTime;
            playSound = false;
        }


        /** Grows the platform. */
        else if (!isOn && this.transform.localScale.x <= 2.4)
        {
            this.transform.localScale = this.transform.localScale += new Vector3(0.5f, 0.5f, 0) * Time.deltaTime;

            if (this.transform.localScale.x >= 2.4)
            {
                playSound = true;
                this.transform.localScale = new Vector3(2.5f, 2f, 0);
            }

            if(playSound)
            {
                resetSound.Play();
            }
        }


    }


    /** Shrink sound. */
    public void OnCollisionEnter2D(Collision2D collision)
    {
        shrinkSound.Play();
    }


    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           isOn = true;
           //shrinkSound.Play();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isOn = false;
    }


    private void _toggle()
    {

        {
            transform.position = new Vector3(transform.position.x,
            groundLevel.y + Mathf.PingPong(Time.time, 1), 0.0f);
        }
    }

}
