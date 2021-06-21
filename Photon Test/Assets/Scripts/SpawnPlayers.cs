using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;

    [SerializeField] Vector2 xRandPos = new Vector2();
    [SerializeField] Vector2 yRandPos = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(xRandPos.x, xRandPos.y), Random.Range(yRandPos.x, yRandPos.y));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
