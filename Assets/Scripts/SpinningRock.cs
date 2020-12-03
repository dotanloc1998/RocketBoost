using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningRock : MonoBehaviour
{
    [SerializeField] private float spinningSpeed = 35f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward,spinningSpeed * Time.deltaTime);
    }
}
