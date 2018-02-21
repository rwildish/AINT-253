#pragma strict

private var guiShow : boolean = false;
private var isOpen : boolean = false;

var door : GameObject;

var rayLength = 10;

function Update () {

    var hit : RaycastHit;
    var fwd = transform.TransformDirection(Vector3.forward);

    if(Physics.Raycast(transform.position, fwd, hit, rayLength))
    {
        if(hit.collider.gameObject.tag == "Door")
        {
            guiShow = true;
            if(Input.GetKeyDown("e") && isOpen == false)
            {
                door.GetComponent.<Animation>().Play("FrontDoorOpen");
                isOpen = true;
                guiShow = false;
            }
            else if(Input.GetKeyDown("e") && isOpen == true)
            {
                door.GetComponent.<Animation>().Play("FrontDoorClose");
                isOpen = false;
                guiShow = false;
            }

        }
    }
    else
    {
        guiShow = false;
    }

}

function OnGUI()
{
    if(guiShow == false && isOpen == false)
    {
        GUI.Box(Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Open Door");
    }

    if(guiShow == false && isOpen == true)
    {
        GUI.Box(Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Close Door");
    }
}