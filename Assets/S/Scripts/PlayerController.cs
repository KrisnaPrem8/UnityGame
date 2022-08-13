using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public float horizontalInput;
    public float xRange = 3.0f;
    public bool isJumping;
    private Animator playerAnim;
    public GameObject BallPrefab;
    private Vector3 position = new Vector3(0, 1.2f, 0.5f);
    private SpawnManager spawnManager;
    private float InstantiationTimer = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); 
        }

      if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime *speed);
        playerAnim.SetFloat("horizontal", horizontalInput);
        InstantiationTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && spawnManager.isGameActive && InstantiationTimer <= 0 && isJumping == false)
        {
            Instantiate(BallPrefab, transform.position + position , BallPrefab.transform.rotation);
            InstantiationTimer = 0.25f;
        }
        if (Input.GetKeyDown(KeyCode.W) && spawnManager.isGameActive && InstantiationTimer <= 0 && isJumping == false)
        {
            StartCoroutine(JumpCharacter());
        }
    }

    public IEnumerator JumpCharacter()
    {
        playerAnim.SetTrigger("Jump");
        yield return new WaitForSeconds(1.150f); 
        playerAnim.ResetTrigger("Jump");
    }
}
