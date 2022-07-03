using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Click : MonoBehaviour, IPointerClickHandler
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    private float progress;
    public Transform zone;
    public Boolean doshiel;

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("ElementCube");
        EventCall.next.TrigerKillSome();
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       GetRandPoint();
       startPoint = new Vector3(transform.position.x, 20 , transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        transform.position = Vector3.Lerp(startPoint,endPoint,progress);
        progress += GameSession.speedMove;
        if (progress >= 1) {
            GetRandPoint();
        }
    }

    
    void GetRandPoint() {
        progress = 0;
        startPoint = new Vector3(endPoint.x,20 ,endPoint.z);

        endPoint = new Vector3(Random.Range(GameSession.firstPointMove.x, GameSession.lastPointMove.x),
                               20,
                                Random.Range(GameSession.firstPointMove.z, GameSession.lastPointMove.z));
    }


}
