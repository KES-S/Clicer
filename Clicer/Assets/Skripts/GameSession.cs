using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameSession : MonoBehaviour
{

    [SerializeField] int money=0;
    public Text moneyText;
    public Text bestMoneyText;
    public Transform spawnPosition1;
    public Transform spawnPosition2;
    public Transform movePosition;
    public GameObject Enemy;
    public GameObject gameUI;
    public GameObject failWind;
    private byte enemyCaunt;
    public static Vector3 firstPointMove;
    public static Vector3 lastPointMove;
    private static Vector3 respPoint;
    public Vector2 firstRespPoint;
    public Vector2 lastRespPoint;
    private float speedSpawn = 3f;
    static public float speedMove = 0.01f;

    private void Start()
    {

        firstPointMove = new Vector3(movePosition.position.x - movePosition.localScale.x / 2, 
                                        20, 
                                            movePosition.position.z - movePosition.localScale.z / 2);
        lastPointMove = new Vector3(movePosition.position.x + movePosition.localScale.x / 2,
                                        20, 
                                            movePosition.position.z + movePosition.localScale.z / 2);

        //SpawnConstruct(1,30);
        bestMoneyText.text = (PlayerPrefs.GetInt("MaxVal", 0)).ToString();
        EventCall.next.killSomeOne += TrigerKillSome;
        StartCoroutine(SpawnEnemy(speedSpawn));

    }

    void SpawnConstruct(int i,float flip = 35)
    {   switch (i) {
            case 1:
                {
                    firstRespPoint = new Vector2(spawnPosition1.position.x , spawnPosition1.position.x );
                    lastRespPoint = new Vector2(spawnPosition1.position.z - flip, spawnPosition1.position.z + flip);
                    break;
                };
        case 2: {
                    firstRespPoint = new Vector2(spawnPosition2.position.x , spawnPosition2.position.x );
                    lastRespPoint = new Vector2(spawnPosition2.position.z - flip, spawnPosition2.position.z + flip);
                    break;
                };
        default: { break; };
        }

    }

    public void TrigerKillSome()
    {
        money++;
        moneyText.text = money.ToString();
        if (enemyCaunt != 0) enemyCaunt--;
        if (money % 10 == 0) { 
            speedSpawn -= 0.5f; 
            speedMove = speedMove + (money / 10000f);
        }
    }

    private void OnDestroy()
    {
        EventCall.next.killSomeOne -= TrigerKillSome;
    }

    void Repeat() {
        StartCoroutine(SpawnEnemy(speedSpawn));
    }


    void CheckEnd()
    {
        if (enemyCaunt>10) {
            gameUI.SetActive(false);
            failWind.SetActive(true);
            Time.timeScale = 0f;
            
            int valueNat = PlayerPrefs.GetInt("SaveVal", 0);
            int valueMax = PlayerPrefs.GetInt("MaxVal", 0); 

            if (money > valueMax)
            {
                valueNat++;
                string namePosNaw = "ValueOfRecord" + valueNat.ToString();
                PlayerPrefs.SetInt(namePosNaw, money);
                PlayerPrefs.SetInt("MaxVal", money); ;
                PlayerPrefs.SetInt("SaveVal", valueNat); ;
            };

            
        }
    }

    IEnumerator SpawnEnemy(float seconds=0.25f) {

        CheckEnd();

        SpawnConstruct(Random.Range(1, 3),30);

        respPoint = new Vector3(Random.Range(firstRespPoint.x, firstRespPoint.y),
                                    20,
                                        Random.Range(lastRespPoint.x, lastRespPoint.y));

        enemyCaunt++;
        yield return new WaitForSeconds(seconds);
        Instantiate(Enemy, respPoint, Quaternion.identity);
        Repeat();
    }

}
