using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Rigidbody spawnObject;

    public float Timer = 2.0f;

    private float timeElasped;

    private const float SCALE = 500f;

    public float spawnSpeed = 5;

    void Start()
    {
        timeElasped = 0f;

    }
	
	// Update is called once per frame
    void Update()
    {
        timeElasped += Time.deltaTime;
        if (timeElasped >= Timer)
        {
            Rigidbody clone = (Rigidbody) Instantiate(spawnObject, transform.position, Quaternion.identity);
            float x = (Random.value - 0.5f) * SCALE * 2;
            float y = (Random.value - 0.5f) * SCALE;
            float z = -(0.5f + Random.value) * SCALE * spawnSpeed;
            clone.AddForce(new Vector3(x, y, z));
            timeElasped = 0f;
        }
    }
}
