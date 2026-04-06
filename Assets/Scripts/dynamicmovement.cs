using UnityEngine;

public class dynamicmovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(20, 60, 50) * Time.deltaTime);
    }
}
