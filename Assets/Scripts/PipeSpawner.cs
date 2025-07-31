using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject pipePrefab;

    [SerializeField] float spawnCooldown;
    float currentTime;

    // Update is called once per frame
    void Update()
    {
        if(gameManager.HasGameStarted() == true)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                SpawnPipe();
            }
        }
    }

    public void ResetSpawner()
    {
        currentTime = 0;

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    void SpawnPipe()
    {
        currentTime = spawnCooldown;
        Instantiate(pipePrefab, transform);
    }
}
