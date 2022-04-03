using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAggroTarget : MonoBehaviour
{
    [SerializeField] TeamManager team;

    // Update is called once per frame
    void Update()
    {
        var target = team.GetAggroTarget();
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        var pos = target.gameObject.transform.position;
        pos.z = transform.position.z;
        transform.position = pos;
    }
}
