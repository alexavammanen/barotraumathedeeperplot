using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allas : MonoBehaviour
{
    public static allas Instace;
    public GameObject pilotti;
    public int pilotinkoko = 20;

private Queue<GameObject> pilottiallas = new Queue<GameObject>();




    // Start is called before the first frame update
    void Awake()
    {
        Instace = this;
        InitializePool();
        
    }

    private void InitializePool(){
        for(int i = 0; i < pilotinkoko; i++){
            GameObject alokas = Instantiate(pilotti);
            alokas.SetActive(false);
            pilottiallas.Enqueue(alokas);


        }


    }
    public GameObject Recall(){
        if(pilottiallas.Count > 0){
            GameObject pilotti = pilottiallas.Dequeue();
            pilotti.SetActive(true);
            return pilotti;
        }
        return null;



    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
