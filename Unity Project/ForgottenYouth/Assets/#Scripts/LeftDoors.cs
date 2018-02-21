using UnityEngine;
using System.Collections;

public class LeftDoors : MonoBehaviour {

    public float timeLeft = 0;

    public RaycastHit hit;

    public Transform currentDoor;

    public bool open;

    public bool isOpeningDoor;

    public Transform cam;

    public LayerMask mask;

    public AudioSource audio;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && timeLeft <= 0.0f)
        {
            CheckDoor();
        }

        if (isOpeningDoor)
        {
            OpenAndCloseDoor();
        }

    }

    public void CheckDoor()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 10, mask))
        {
            print(hit.collider.gameObject.name);
            open = false;
            if (hit.transform.localRotation.eulerAngles.y > 45)
            {
                open = true;

            }
            isOpeningDoor = true;
            currentDoor = hit.transform;
            audio.Play();

        }
    }

    public void OpenAndCloseDoor()
    {

        timeLeft += Time.deltaTime;

        if (open)
        {
            currentDoor.localRotation = Quaternion.Slerp(currentDoor.localRotation, Quaternion.Euler(0, 0, 0), timeLeft / 4);
        }
        else
        {
            currentDoor.localRotation = Quaternion.Slerp(currentDoor.localRotation, Quaternion.Euler(0, 90, 0), timeLeft / 4);
        }

        if (timeLeft > 1)
        {
            timeLeft = 0;
            isOpeningDoor = false;
        }
    }
}
