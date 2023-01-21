using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateObject : MonoBehaviour
{
    public GameObject player;
    public GameObject barrier;
    public GameObject coin;
    private List<float> posX = new List<float>() { -2.5f, 0, 2.5f };
    private List<GameObject> barriers = new List<GameObject>() { };

    private int lastBarrier;
    public int playerUpdatePos;

    void Start()
    {
       
        for(int i = 20; i<=220; i += 10)
        {
            int random = Random.Range(0, 3);

            int randomCoin = Random.Range(0, 3);
            
            Instantiate(barrier, new Vector3(posX[random], 0f, i), Quaternion.identity);
            Instantiate(coin, new Vector3(posX[randomCoin], 0f, i + 5), Quaternion.identity);

            if (i == 200)
            {
                lastBarrier = i + 20;
            }
        }


       
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.localPosition.z >= playerUpdatePos && player.transform.localPosition.z <= 400)
        {
            Debug.Log("Ge�ti");
            createObject();
        }

        

    }


    private void createObject()
    {
        for(int j = 20; j<=200; j += 10)
        {
            int random = Random.Range(0, 3);
            int randomCoin = Random.Range(0, 3);

            Instantiate(barrier, new Vector3(posX[random], 0f, j + lastBarrier), Quaternion.identity);
            Instantiate(coin, new Vector3(posX[randomCoin], 0f, j + lastBarrier + 5), Quaternion.identity);
            if (j == 200)
            {
                lastBarrier += j;
            }
        }

        playerUpdatePos += 200;
    }

}
