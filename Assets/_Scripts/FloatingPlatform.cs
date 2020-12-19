/***********************************************************************;
* Project            : Game2014_F2020_FinalTest
*
* Author             : David Gasinec
* 
* Student Number     : 101187910
*
* Date created       : 20/12/19
*
* Description        : Controls exit gate logic.
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

public class FloatingPlatform : MonoBehaviour
{
    public AudioSource shrinkSound;
    public AudioSource resetSound;
    public Vector3 groundLevel;
    public Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _toggle();
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shrinkSound.Play();
            Destroy(gameObject);
        }
    }

    private void _toggle()
    {

        {
            transform.position = new Vector3(transform.position.x,
            groundLevel.y + Mathf.PingPong(Time.time, 1), 0.0f);
        }
    }

}
