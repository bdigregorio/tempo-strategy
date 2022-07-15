using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedIndicator : MonoBehaviour {
    [SerializeField] private UnitController unit;
    private MeshRenderer meshRenderer;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() {
        UnitActionSystem.Instance.OnSelectedUnitChanged += OnSelectedUnitChanged;
    }

    private void OnSelectedUnitChanged(object sender, EventArgs empty) {
        if (UnitActionSystem.Instance.GetSelectedUnit() == unit) {
            meshRenderer.enabled = true;
        } else {
            meshRenderer.enabled = false;
        }
    }
}
