using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public Animator ShootBarAnimator;
    public Animator PlayerAnimator;
    public Animator ballAnimator;
    public Animator transitionAnimator;

    public TextMeshProUGUI coin;
    public TextMeshProUGUI multiplier;
    public TextMeshProUGUI total;

    public AudioSource sutSesi;
    public AudioSource agSesi;



    private List<string> shoot2x = new List<string>() { "2xShoot", "2xShoot2", "2xShoot3", "2xShoot4" } ;

    private List<string> shoot15x = new List<string>() { "1_5xShoot", "1_5xShoot2", "1_5xShoot3", "1_5xShoot4" };

    private List<string> shoot1x = new List<string>() { "1xShoot", "1xShoot2", "1xShoot3", "1xShoot4" };

    private bool isPressed = false;

    private int earnedCoin = 200;
    private float multiplierCoin = 0;

    // Start is called before the first frame update
    void Start()
    {
        int sound = PlayerPrefs.GetInt("sound");

        if (sound == 1)
        {
            sutSesi.enabled = true;
            agSesi.enabled = true;
        }
        else
        {
            sutSesi.enabled = false;
            agSesi.enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !isPressed)
        {
            sutSesi.PlayDelayed(0.65f);
            agSesi.PlayDelayed(1.5f);
            isPressed = true;
            PlayerAnimator.enabled = true;
            Vector3 scale = gameObject.transform.localScale;
            Debug.Log(scale.x);
            if(scale.x < 0.3)
            {
                int random = Random.Range(0, 4);
                Debug.Log(random);
                ballAnimator.Play(shoot2x[random]);
                Debug.Log("2x Kazan�ld�");
                multiplierCoin = 2;
                StartCoroutine(playAnimator());
                
            }
            
            else if(scale.x >= 0.3 && scale.x <= 0.4)
            {
                Debug.Log("1.5x Kazan�ld�");
                int random = Random.Range(0, 4);
                Debug.Log(random);
                ballAnimator.Play(shoot15x[random]);
                multiplierCoin = 1.5f;
                StartCoroutine(playAnimator());
            }
            else if(scale.x > 0.4)
            {
                Debug.Log("1x Kazan�ld�");
                int random = Random.Range(0, 4);
                Debug.Log(random);
                ballAnimator.Play(shoot1x[random]);
                multiplierCoin = 1;
                StartCoroutine(playAnimator());
            }

        }
    }

    IEnumerator playAnimator()
    {
        coin.SetText(earnedCoin.ToString());
        multiplier.SetText(multiplierCoin.ToString() + "x");
        total.SetText((multiplierCoin * earnedCoin).ToString());
        yield return new WaitForSeconds(2f);
        transitionAnimator.SetTrigger("Start");


    }
}
