using System;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour {
    public static UnitActionSystem Instance { get; private set; }
    
    [SerializeField] private UnitController selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;

    // constants
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    public event EventHandler OnSelectedUnitChanged;

    private void Awake() {
        if (Instance != null) {
            Debug.Log($"There is more than one UnitActionSystem - {transform} - {Instance}");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

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
                SetSelectedUnit(unit);
                return true;
            }
        }

        return false;
    }

    private void SetSelectedUnit(UnitController unit) {
        selectedUnit = unit;
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public UnitController GetSelectedUnit() {
        return selectedUnit;
    }

    private void HandleMovement() {
        selectedUnit.Move(MouseWorld.GetPosition());
    }
}
