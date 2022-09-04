using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowerManager : MonoBehaviour
{

    public static ShowerManager instance;
    public TextMeshPro coinText;
    public float a; 
    public enum UpgradeCoin { First, Second, Third,};
    public UpgradeCoin CoinUpgrade;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        coinText.text = PlayerPrefs.GetFloat("Coin") + "";

    }

    private void Awake()
    {
        instance = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cube")
        {
            CoinLocation(other);

        }
    }

    public IEnumerator TimeBig(GameObject other)
    {
        for (int i = 0; i < other.transform.childCount; i++)
        {
            other.transform.GetChild(i).gameObject.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator FirstCoin(GameObject other, float yPos)
    {
        a += 1;
        other.gameObject.transform.GetComponent<StackObject>().allCount += 1;
        PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") + 0.5f);
        coinText.text = a.ToString();
        GameObject money = Instantiate(Resources.Load<GameObject>("1cent"), new Vector3(other.transform.position.x, other.transform.position.y + yPos, other.transform.position.z), Quaternion.identity);
        StartCoroutine(TimeBig(money));
        money.transform.SetParent(other.gameObject.transform);

        yield return null;

        
    }

    IEnumerator SecondCoin(GameObject other, float yPos)
    {
        PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") + 2.5f);
        a += 2;
        other.gameObject.transform.GetComponent<StackObject>().allCount += 2;

        coinText.text = a.ToString();
        GameObject money = Instantiate(Resources.Load<GameObject>("2cent"), new Vector3(other.transform.position.x, other.transform.position.y + yPos, other.transform.position.z), Quaternion.identity);
        StartCoroutine(TimeBig(money));
        money.transform.SetParent(other.gameObject.transform);

        yield return null;

        
    }

    IEnumerator ThirdCoin(GameObject other, float yPos)
    {
        PlayerPrefs.SetFloat("Coin", PlayerPrefs.GetFloat("Coin") + 5);
        a += 5;
        other.gameObject.transform.GetComponent<StackObject>().allCount += 5;

        coinText.text = a.ToString();
        GameObject money = Instantiate(Resources.Load<GameObject>("5cent"), new Vector3(other.transform.position.x, other.transform.position.y + yPos, other.transform.position.z), Quaternion.identity);
        StartCoroutine(TimeBig(money));
        money.transform.SetParent(other.gameObject.transform);

        yield return null;

        
    }

    public void DoBoolalt(Collider other)
    {
        other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().alt = true;
        other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt = true;
        other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt = true;
    }
    public void DoBoolorta(Collider other)
    {
        other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().orta = true;
        other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta = true;
        other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta = true;
    }
    public void DoBoolust(Collider other)
    {
        other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst = true;
        other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().üst = true;
        other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst = true;
    }

    public void CoinLocation(Collider other)
    {
        switch (CoinUpgrade)
        {
            case UpgradeCoin.First:


                if (other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst == false)
                {
                    StartCoroutine(FirstCoin(other.gameObject, 0));
                    DoBoolalt(other);
                    break;

                }

                if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        StartCoroutine(FirstCoin(other.gameObject, 0));
                        DoBoolalt(other);
                        break;

                    }
                }
                if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        StartCoroutine(FirstCoin(other.gameObject, .5f));
                        DoBoolorta(other);
                        break;

                    }
                }

                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(FirstCoin(other.gameObject, 0));
                        DoBoolalt(other);
                        break;

                    }
                }
                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(FirstCoin(other.gameObject, 1f));
                        DoBoolorta(other);
                        break;

                    }
                }
                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(FirstCoin(other.gameObject, 2f));
                        DoBoolust(other);
                        break;

                    }
                }


                break;
            case UpgradeCoin.Second:
                if (other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst == false)
                {
                    StartCoroutine(FirstCoin(other.gameObject, 0));
                    DoBoolalt(other);
                    break;

                }

                if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        StartCoroutine(SecondCoin(other.gameObject, 0));
                        DoBoolalt(other);
                        break;

                    }
                }
                if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        StartCoroutine(SecondCoin(other.gameObject, .5f));
                        DoBoolorta(other);
                        break;

                    }
                }

                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(SecondCoin(other.gameObject, 0));
                        DoBoolalt(other);
                        break;
                    }
                }
                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(SecondCoin(other.gameObject, 1f));
                        DoBoolorta(other);
                        break;

                    }
                }
                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(SecondCoin(other.gameObject, 2f));
                        DoBoolust(other);
                        break;

                        

                    }
                }

                break;
            case UpgradeCoin.Third:
                if (other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst == false)
                {
                    StartCoroutine(ThirdCoin(other.gameObject, 0));
                    DoBoolalt(other);
                    break;

                }

                if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        StartCoroutine(ThirdCoin(other.gameObject, 0));
                        DoBoolalt(other);
                        break;

                    }
                }
                if (other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(1).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(0).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(1).gameObject.activeSelf)
                    {
                        StartCoroutine(ThirdCoin(other.gameObject, .5f));
                        DoBoolorta(other);
                        break;

                    }
                }

                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(ThirdCoin(other.gameObject, 0));
                        DoBoolalt(other);
                        break;


                    }
                }
                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == false && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(ThirdCoin(other.gameObject, 1f));
                        DoBoolorta(other);
                        break;



                    }
                }
                if (other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().alt == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().orta == true && other.gameObject.transform.GetChild(2).GetComponent<ControlManager>().üst == false)
                {
                    if (other.gameObject.transform.GetChild(2).gameObject.activeSelf)
                    {
                        StartCoroutine(ThirdCoin(other.gameObject, 2f));
                        DoBoolust(other);
                        break;


                    }
                }


               
           


                break;
            default:
                break;
        }
    }

    

}
