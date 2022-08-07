using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineTarget : MonoBehaviour
{

    [SerializeField] Transform movingTarget;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, movingTarget.position, Time.deltaTime * 10);
    }

}
