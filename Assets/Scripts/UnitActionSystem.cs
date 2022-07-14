using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour {
    [SerializeField] private UnitController unit;
    
    // constants
    private const int LeftMouseButton = 0;
    private const int RightMouseButton = 1;
    
    void Update() {
        ReadInput();
    }

    private void ReadInput() {
        if (Input.GetMouseButtonDown(LeftMouseButton)) {
            unit.Move(MouseWorld.GetPosition());
        }
    }
}
