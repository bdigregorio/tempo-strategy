using UnityEngine;

public class UnitActionSystem : MonoBehaviour {
    [SerializeField] private UnitController selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    // constants
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;

    void Update() {
        if (Input.GetMouseButtonDown(LeftMouseButton)) {
            if (TryUnitSelection()) return;
            HandleMovement();
        }
    }

    private bool TryUnitSelection() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue, unitLayerMask)) {
            if (hitInfo.transform.TryGetComponent<UnitController>(out UnitController unit)) {
                selectedUnit = unit;
                return true;
            }
        }

        return false;
    }

    private void HandleMovement() {
        selectedUnit.Move(MouseWorld.GetPosition());
    }
}
