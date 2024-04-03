using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kivi : MonoBehaviour
{

    private float paino = 3f;
    private Rigidbody2D keho;
    public Transform kotisi;




    // Start is called before the first frame update
    void Awake()
    {
        keho = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        Tippu();
    }

    private void Tippu()
    {
        if(kotisi == null)
        {
            getPlayer();
            return;
        }
        Vector2 loyto = (kotisi.position - transform.position).normalized;
        keho.MovePosition(keho.position + loyto * paino * Time.fixedDeltaTime);
    }

    void getPlayer(){
        kotisi = GameManager.Instance.getPlayer.transform;

    }
}
