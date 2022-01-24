using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Shapes
    [SerializeField] GameObject sphere;
    [SerializeField] GameObject cube;
    [SerializeField] GameObject prism;

    [SerializeField] GameObject spherePrefab;

    [SerializeField] GameObject[] shapes;

    AudioPlayer audioPlayer;

    CharacterController controller;

    private Vector3 direction;
    [SerializeField] float speed = 10.0f;

    private int desiredLane = 1;
    public float laneDistance = 10;

    private string currentShape = "sphere";

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        sphere.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        direction.z = speed;

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if(desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        /*transform.position = Vector3.Lerp(transform.position, targetPosition, 80* Time.deltaTime);
        controller.center = controller.center; */

        //transform.position = targetPosition;
        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                controller.Move(moveDir);
            else
                controller.Move(diff);
        }

        
       // if(spherePrefab != null)
            //spherePrefab.transform.position = Vector3.Lerp(start.position, end.position, Time.time);
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.deltaTime);
    }

    public float GetSpeed()
    {
        return speed;
    }

    private void ActivatePrism()
    {
        PlayerManager.numberOfPoints += 1;
        audioPlayer.PlayShapeCollisionClip();
        sphere.SetActive(false);
        cube.SetActive(false);
        prism.SetActive(true);
        currentShape = "prism";
        
    }

    private void ActivateCube()
    {
        PlayerManager.numberOfPoints += 1;
        audioPlayer.PlayShapeCollisionClip();
        sphere.SetActive(false);
        cube.SetActive(true);
        prism.SetActive(false);
        currentShape = "cube";
    }

    private void ActivateSphere()
    {
        PlayerManager.numberOfPoints += 1;
        audioPlayer.PlayShapeCollisionClip();
        sphere.SetActive(true);
        cube.SetActive(false);
        prism.SetActive(false);
        currentShape = "sphere"; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (currentShape == "sphere" && other.gameObject.tag == "Circle Hole")
            return;
        if (currentShape == "cube" && other.gameObject.tag == "Square Hole")
            return;
        if (currentShape == "prism" && other.gameObject.tag == "Triangle Hole")
            return;
        if (other.gameObject.tag == "Sphere")
        {
            Destroy(other.gameObject);
            ActivateSphere();
            return;
        }
        if (other.gameObject.tag == "Cube")
        {
            Destroy(other.gameObject);
            ActivateCube();
            return;
        }
        if(other.gameObject.tag == "Prism")
        {
            Destroy(other.gameObject);
            ActivatePrism();
            return;
        } 
        else
        {
            PlayerManager.gameOver = true;
            return;
        }
        
    }

}
