using UnityEngine;


public class Raycaster
{
    private Camera playerCamera;
    private Ray _cursorRay;
    private RaycastHit rayHitInformation;

    public Raycaster(Camera playerCamera)
    {
        this.playerCamera = playerCamera;
    }

    public void InitializeCursorRay()
    {
        _cursorRay = playerCamera.ScreenPointToRay(Input.mousePosition);
    }

    public bool CastRay(Vector3 startPoint, Vector3 direction)
    {
        return Physics.Raycast(startPoint, direction, out rayHitInformation, 100);
    }

    public bool CastCursorRay()
    {
        return Physics.Raycast(_cursorRay, out rayHitInformation, 100);
    }

    public RaycastHit GetRayHitInformation()
    {
        return rayHitInformation;
    }

    public GameObject GetGameObjectUnderCursor()
    {
        return rayHitInformation.transform?.gameObject;
    }

/*     public IInteractable GetInteractableUnderCursor()
    {
        InitializeCursorRay();
        CastCursorRay();
        GameObject gameObject = GetGameObjectUnderCursor();
        return gameObject?.GetComponent<IInteractable>();
    } */
}
