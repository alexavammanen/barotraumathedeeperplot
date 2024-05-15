using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState nytpeli;
    public helm getPlayer{get;  set;}

    private void Awake(){
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else{

            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void vaihdo(GameState uusi_tial){
        nytpeli = uusi_tial;
        if(nytpeli == GameState.ei_peli){
            StartCoroutine(EI_peli_EI());


        }



    }

    IEnumerator EI_peli_EI(){
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        vaihdo(GameState.peli);

    }
}
