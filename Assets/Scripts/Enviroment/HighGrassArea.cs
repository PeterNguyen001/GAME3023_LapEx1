using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighGrassArea : MonoBehaviour
{
    public float baseEncounterRate = 0.1f;
    public float maxEncounterRate = 0.5f;
    public int stepsBetweenRateIncrease = 50;
    public float rateIncreaseAmount = 0.05f;

    private Transform playerTransform;
    private int stepsTaken = 0;
    private float currentEncounterRate;
    private bool isPlayerInsideGrass = false;

    private bool isCheckingMovement = false;
private Vector3 previousPosition;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Assuming "Player" is tagged.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideGrass = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInsideGrass = false;
        }
    }

    private void Update()
    {
        if (isPlayerInsideGrass)
        {
            if (!isCheckingMovement)
            {
                previousPosition = playerTransform.position;
                StartCoroutine(DelayedMovementCheck());
            }
        }
    }

    IEnumerator DelayedMovementCheck()
    {
        isCheckingMovement = true;

        // Wait for a delay (e.g., 1 second).
        yield return new WaitForSeconds(0.5f);

        if (Vector3.Distance(previousPosition, playerTransform.position) > 0)
        {
            stepsTaken++;

            if (stepsTaken % stepsBetweenRateIncrease == 0 && currentEncounterRate < maxEncounterRate)
            {
                currentEncounterRate += rateIncreaseAmount;
            }
        }

        if (Random.value < currentEncounterRate)
        {
            StartRandomEncounter();
        }

        isCheckingMovement = false;
    }
    private void StartRandomEncounter()
    {
        //int randomIndex = Random.Range(0, possibleEncounters.Length);
        //GameObject encounterPrefab = possibleEncounters[randomIndex];
        //Instantiate(encounterPrefab, other.transform.position, Quaternion.identity);
        SceneManager.LoadScene("Encounter");
    }
}