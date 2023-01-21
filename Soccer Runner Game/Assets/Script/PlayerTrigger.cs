using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    public static int coinCount = 0;
    public TextMeshProUGUI TM_coin;
    public Animator animator;

    /* void Start()
    {
        
    }
    */

    /* void Update()
    {
        
    }
    */

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Coin"))
        {
            trigger.gameObject.transform.parent.gameObject.GetComponent<AudioSource>().Play();
            coinCount++;
            Debug.Log("Çarptı " + coinCount.ToString());
            TM_coin.SetText(coinCount.ToString());
            Destroy(trigger.gameObject);
            Destroy(trigger.gameObject.transform.parent.gameObject, 1f);
            
        }

        if (trigger.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Engeli Ge�ti");
            Destroy(trigger.gameObject, 1f);
        }

        if (trigger.gameObject.CompareTag("Finish"))
        {
            animator.SetTrigger("GoToFinal");
            
        }
    }


}
