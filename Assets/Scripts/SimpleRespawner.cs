using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRespawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] respawns;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject RelativePlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int closestPoint = 0;

            for (int i = 0; i < respawns.Length; i++)            
                if (Vector3.Distance(Player.transform.position, respawns[i].position) < Vector3.Distance(Player.transform.position, respawns[closestPoint].position))
                    closestPoint = i;

            //RelativePlayer.transform.position = respawns[closestPoint].position;
            Player.transform.localPosition = RelativePlayer.transform.InverseTransformPoint(respawns[closestPoint].position);
            //Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}