using API_For_TCG_Card_Shop_Simulator.Helpers;
using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace API_For_TCG_Card_Shop_Simulator.SUPER_OBJECTS.Objects
{
    public class InteractableObjectModded : MonoBehaviour
    {
        public string m_ObjectType = "";
        public GameObject m_HighlightGameObj;
        public GameObject m_NavMeshCut;
        public MeshRenderer m_Mesh;
        public SkinnedMeshRenderer m_SkinMesh;
        public float m_HighlightOutlineWidth = 5f;
        public bool m_IsGenericObject;
        public bool m_CanPickupMoveObject;
        public bool m_CanBoxUpObject;
        public bool m_CanScanByCounter;
        public bool m_PlaceObjectInShopOnly = true;
        public bool m_PlaceObjectInWarehouseOnly;
        public MeshFilter m_PickupObjectMesh;
        public Transform m_MoveStateValidArea;
        public ShelfMoveStateValidArea m_ShelfMoveStateValidArea;
        public BoxCollider m_BoxCollider;
        public List<BoxCollider> m_BoxColliderList;
        public Dictionary<string, int> m_GameActionInputDisplayList = EnumListScript.GameActions;
        public bool m_IsRaycasted;
        public bool m_IsLerpingToPos;
        public bool m_IsHideAfterFinishLerp;
        public bool m_IsMovingObject;
        public bool m_IsBeingHold;
        public bool m_IsBoxedUp;
        public bool m_HasInit;
        public bool m_IsSnappingPos;
        public int m_OriginalLayer;
        public Vector3 m_OriginalScale;
        public Vector3 m_TargetSnapPos;
        public Transform m_OriginalParent;
        public Material m_Material;
        public Transform m_Shelf_WorldUIGrp;
        public InteractablePackagingBox_Shelf m_InteractablePackagingBox_Shelf;
        public List<ShelfCompartment> m_ItemCompartmentList = new();
        public bool m_IsMovingObjectValidState;
        public float m_LerpPosTimer;
        public float m_LerpPosSpeed = 3f;
        public Vector3 m_StartLerpPos;
        public Vector3 m_StartLerpScale;
        public Vector3 m_TargetMoveObjectPosition;
        public Quaternion m_StartLerpRot;
        public Transform m_TargetLerpTransform;
        public float m_MoveObjectLerpSpeed = 0.002f;

        public virtual void Start()
        {
            Init();
        }

        public virtual void Init()
        {
            if (!m_HasInit)
            {
                m_HasInit = true;
                if ((bool)m_Mesh)
                {
                    m_Material = m_Mesh.material;
                    m_Material.SetFloat("_Outline", 0f);
                }
                else if ((bool)m_SkinMesh)
                {
                    m_Material = m_SkinMesh.material;
                    m_Material.SetFloat("_Outline", 0f);
                }
                else if ((bool)m_HighlightGameObj)
                {
                    m_HighlightGameObj.SetActive(value: false);
                }

                m_OriginalLayer = base.gameObject.layer;
                m_TargetMoveObjectPosition = base.transform.position;
                if (m_IsGenericObject && m_ObjectType != "")
                {
                    ShelfManager.InitInteractableObject(this);
                }
            }
        }

        public void EvaluateSnapping()
        {
            if (m_IsSnappingPos)
            {
                if ((m_TargetMoveObjectPosition - m_TargetSnapPos).magnitude > 0.5f)
                {
                    m_IsSnappingPos = false;
                    if (m_TargetMoveObjectPosition.y < 0f)
                    {
                        m_TargetMoveObjectPosition.y = 0f;
                    }

                    base.transform.position = m_TargetMoveObjectPosition;
                }
                else
                {
                    base.transform.position = m_TargetSnapPos;
                }
            }

            if (m_IsSnappingPos || !m_MoveStateValidArea || !m_ShelfMoveStateValidArea || !m_ShelfMoveStateValidArea.m_CanSnap)
            {
                return;
            }

            int mask = LayerMask.GetMask("MoveStateBlockedArea");
            Collider[] array = Physics.OverlapBox(m_MoveStateValidArea.position, m_MoveStateValidArea.lossyScale / 2f * 1.01f, m_MoveStateValidArea.rotation, mask);
            if (array.Length == 0)
            {
                return;
            }

            ShelfMoveStateValidArea shelfMoveStateValidArea = null;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].name == "MoveStateValidArea" && array[i].transform.parent != m_MoveStateValidArea && (array[i].transform.position - m_TargetMoveObjectPosition).magnitude <= 5f)
                {
                    shelfMoveStateValidArea = array[i].transform.parent.GetComponent<ShelfMoveStateValidArea>();
                    if ((bool)shelfMoveStateValidArea && shelfMoveStateValidArea.m_CanSnap)
                    {
                        break;
                    }

                    shelfMoveStateValidArea = null;
                }
            }

            if (!shelfMoveStateValidArea)
            {
                return;
            }

            Transform transform = null;
            float num = 0.3f;
            for (int j = 0; j < m_ShelfMoveStateValidArea.m_SnapLocList.Count; j++)
            {
                for (int k = 0; k < shelfMoveStateValidArea.m_SnapLocList.Count; k++)
                {
                    float magnitude = (shelfMoveStateValidArea.m_SnapLocList[k].position - m_ShelfMoveStateValidArea.m_SnapLocList[j].position).magnitude;
                    if (magnitude <= num)
                    {
                        num = magnitude;
                        transform = shelfMoveStateValidArea.m_SnapLocList[k];
                    }
                }
            }

            if (!transform)
            {
                return;
            }

            Transform transform2 = null;
            num = 0.3f;
            for (int l = 0; l < m_ShelfMoveStateValidArea.m_SnapLocList.Count; l++)
            {
                float magnitude2 = (transform.position - m_ShelfMoveStateValidArea.m_SnapLocList[l].position).magnitude;
                if (magnitude2 <= num)
                {
                    num = magnitude2;
                    transform2 = m_ShelfMoveStateValidArea.m_SnapLocList[l];
                }
            }

            Vector3 position = m_MoveStateValidArea.position;
            position.y = 0f;
            Vector3 normalized = (position - transform2.position).normalized;
            float magnitude3 = (m_ShelfMoveStateValidArea.transform.position - transform2.position).magnitude;
            Vector3 vector = transform.position + (normalized * 0.005f) + (normalized * magnitude3);
            vector.y = 0f;
            base.transform.position = vector;
            m_IsSnappingPos = true;
            m_TargetSnapPos = vector;
        }


        public virtual void Update()
        {
            if (m_IsLerpingToPos)
            {
                m_LerpPosTimer += Time.deltaTime * m_LerpPosSpeed;
                base.transform.position = Vector3.Lerp(m_StartLerpPos, m_TargetLerpTransform.position, m_LerpPosTimer);
                base.transform.rotation = Quaternion.Lerp(m_StartLerpRot, m_TargetLerpTransform.rotation, m_LerpPosTimer);
                base.transform.localScale = Vector3.Lerp(m_StartLerpScale, m_TargetLerpTransform.localScale, m_LerpPosTimer);
                if (m_LerpPosTimer >= 1f)
                {
                    m_LerpPosTimer = 0f;
                    m_IsLerpingToPos = false;
                    if (m_IsHideAfterFinishLerp)
                    {
                        m_IsHideAfterFinishLerp = false;
                        base.gameObject.SetActive(value: false);
                    }
                }
            }
            else
            {
                if (!m_IsMovingObject)
                {
                    return;
                }

                if (!m_IsSnappingPos)
                {
                    base.transform.position = Vector3.Lerp(base.transform.position, m_TargetMoveObjectPosition, Time.deltaTime * 7.5f);
                }

                EvaluateSnapping();
                int mask = LayerMask.GetMask("MoveStateBlockedArea", "Customer");
                Collider[] array = Physics.OverlapBox(m_MoveStateValidArea.position, m_MoveStateValidArea.lossyScale / 2f, m_MoveStateValidArea.rotation, mask);
                bool flag = true;
                if (m_PlaceObjectInShopOnly)
                {
                    int mask2 = LayerMask.GetMask("MoveStateValidArea");
                    if (Physics.OverlapBox(m_MoveStateValidArea.position, m_MoveStateValidArea.lossyScale / 2f, m_MoveStateValidArea.rotation, mask2).Length == 0)
                    {
                        flag = false;
                    }
                }
                else if (m_PlaceObjectInWarehouseOnly)
                {
                    int mask3 = LayerMask.GetMask("MoveStateValidWarehouseArea");
                    if (Physics.OverlapBox(m_MoveStateValidArea.position, m_MoveStateValidArea.lossyScale / 2f, m_MoveStateValidArea.rotation, mask3).Length == 0)
                    {
                        flag = false;
                    }
                }

                if (array.Length != 0 || base.transform.position.y > 0.1f)
                {
                    flag = false;
                }

                if (m_IsMovingObjectValidState != flag)
                {
                    m_IsMovingObjectValidState = flag;
                    ShelfManager.SetMoveObjectPreviewModelValidState(m_IsMovingObjectValidState);
                }
            }
        }

        public virtual void StartMoveObject()
        {
            if (m_CanPickupMoveObject)
            {
                CSingleton<InteractionPlayerController>.Instance.OnEnterMoveObjectMode();
                OnRaycastEnded();
                m_IsMovingObject = true;
                m_IsMovingObjectValidState = false;
                m_OriginalLayer = base.gameObject.layer;
                base.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                m_BoxCollider.enabled = false;
                for (int i = 0; i < m_BoxColliderList.Count; i++)
                {
                    m_BoxColliderList[i].enabled = false;
                }

                m_MoveStateValidArea.gameObject.SetActive(value: false);
                ShelfManager.ActivateMoveObjectPreviewMode(base.transform, m_PickupObjectMesh, m_MoveStateValidArea);
                ShelfManager.SetMoveObjectPreviewModelValidState(isValid: false);
                if ((bool)m_BoxCollider)
                {
                    CSingleton<ShelfManager>.Instance.m_MoveObjectCustomerBlocker.transform.position = base.transform.position;
                    CSingleton<ShelfManager>.Instance.m_MoveObjectCustomerBlocker.transform.rotation = base.transform.rotation;
                    CSingleton<ShelfManager>.Instance.m_MoveObjectCustomerBlocker.transform.localScale = m_MoveStateValidArea.transform.lossyScale + (Vector3.one * 0.1f);
                    CSingleton<ShelfManager>.Instance.m_MoveObjectCustomerBlocker.gameObject.SetActive(value: true);
                }

                SoundManager.PlayAudio("SFX_WhipSoft", 0.6f);
            }
        }

        public void PlaceMovedObject()
        {
            if (m_IsMovingObjectValidState)
            {
                m_IsBoxedUp = false;
                OnPlacedMovedObject();
                PlayPlaceMoveObjectSFX();
            }
        }


        public virtual void PlayPlaceMoveObjectSFX()
        {
            SoundManager.PlayAudio("SFX_PlaceShelf", 0.5f);
        }


        public virtual void OnPlacedMovedObject()
        {
            m_IsSnappingPos = false;
            CSingleton<InteractionPlayerController>.Instance.OnExitMoveObjectMode();
            m_IsMovingObject = false;
            base.gameObject.layer = m_OriginalLayer;
            m_BoxCollider.enabled = true;
            for (int i = 0; i < m_BoxColliderList.Count; i++)
            {
                m_BoxColliderList[i].enabled = true;
            }

            Vector3 position = base.transform.position;
            position.y = 0f;
            base.transform.position = position;
            m_MoveStateValidArea.gameObject.SetActive(value: true);
            ShelfManager.DisableMoveObjectPreviewMode();
            if ((bool)m_BoxCollider)
            {
                CSingleton<ShelfManager>.Instance.m_MoveObjectCustomerBlocker.gameObject.SetActive(value: false);
            }

            if (!m_IsBoxedUp && (bool)m_InteractablePackagingBox_Shelf)
            {
                if ((bool)m_Shelf_WorldUIGrp)
                {
                    m_Shelf_WorldUIGrp.transform.position = base.transform.position;
                }

                m_InteractablePackagingBox_Shelf.EmptyBoxShelf();
                m_InteractablePackagingBox_Shelf.OnDestroyed();
            }

            if ((bool)m_Shelf_WorldUIGrp && !m_IsBoxedUp)
            {
                m_Shelf_WorldUIGrp.transform.position = base.transform.position;
                m_Shelf_WorldUIGrp.transform.rotation = base.transform.rotation;
            }

            if ((bool)m_NavMeshCut)
            {
                m_NavMeshCut.SetActive(value: false);
                m_NavMeshCut.SetActive(value: true);
            }
        }

        public virtual void BoxUpObject(bool holdBox)
        {
            OnPlacedMovedObject();
            m_IsBoxedUp = true;
            if (!m_InteractablePackagingBox_Shelf)
            {
                m_InteractablePackagingBox_Shelf = RestockManager.SpawnPackageBoxShelf(this, holdBox);
            }
            else
            {
                m_InteractablePackagingBox_Shelf.ExecuteBoxUpObject(this, holdBox);
            }

            if ((bool)m_Shelf_WorldUIGrp)
            {
                m_Shelf_WorldUIGrp.transform.position = Vector3.one * -10f;
            }

            if (holdBox)
            {
                SoundManager.PlayAudio("SFX_BoxClose", 0.5f);
            }
        }

        public void SetTargetMovePosition(Vector3 pos)
        {
            m_TargetMoveObjectPosition = pos;
            if (m_TargetMoveObjectPosition.y < 0f)
            {
                m_TargetMoveObjectPosition.y = 0f;
            }
        }

        public void SetMovePositionToCamera(float forwardDistnace = 3f)
        {
            m_TargetMoveObjectPosition = CSingleton<InteractionPlayerController>.Instance.m_Cam.transform.position + (CSingleton<InteractionPlayerController>.Instance.m_Cam.transform.forward * forwardDistnace);
            m_TargetMoveObjectPosition += CSingleton<InteractionPlayerController>.Instance.m_Cam.transform.up * -0.1f;
            if (m_TargetMoveObjectPosition.y < 0f)
            {
                m_TargetMoveObjectPosition.y = 0f;
            }
        }

        public void AddObjectRotation(float rotY, float snapAmount = 0f)
        {
            base.transform.Rotate(0f, rotY, 0f);
            if (snapAmount > 0f)
            {
                Quaternion rotation = base.transform.rotation;
                Vector3 eulerAngles = rotation.eulerAngles;
                float y = (float)Mathf.RoundToInt(rotation.eulerAngles.y / snapAmount) * snapAmount;
                eulerAngles.y = y;
                rotation.eulerAngles = eulerAngles;
                base.transform.rotation = rotation;
            }
        }

        public virtual void OnRaycasted()
        {
            if (!m_IsRaycasted)
            {
                if ((bool)m_Material)
                {
                    m_Material.SetFloat("_Outline", m_HighlightOutlineWidth);
                }

                if ((bool)m_HighlightGameObj)
                {
                    m_HighlightGameObj.SetActive(value: true);
                }

                m_IsRaycasted = true;
                ShowToolTip();
            }
        }


        public virtual void ShowToolTip()
        {
            for (int i = 0; i < m_GameActionInputDisplayList.Count; i++)
            {
                InteractionPlayerController.AddToolTip(m_GameActionInputDisplayList.Keys.ElementAt(i));
            }
        }

        public virtual void OnRaycastEnded()
        {
            if (m_IsRaycasted)
            {
                if ((bool)m_Material)
                {
                    m_Material.SetFloat("_Outline", 0f);
                }

                if ((bool)m_HighlightGameObj)
                {
                    m_HighlightGameObj.SetActive(value: false);
                }

                m_IsRaycasted = false;
            }

            for (int i = 0; i < m_GameActionInputDisplayList.Count; i++)
            {
                InteractionPlayerController.RemoveToolTip(m_GameActionInputDisplayList.Keys.ElementAt(i));
            }
        }

        public virtual void OnDestroyed()
        {
            for (int i = 0; i < m_ItemCompartmentList.Count; i++)
            {
                if ((bool)m_ItemCompartmentList[i])
                {
                    m_ItemCompartmentList[i].DisableAllItem();
                }
            }

            if (m_IsGenericObject && !m_ObjectType.IsNullOrWhiteSpace())
            {
                ShelfManager.RemoveInteractableObject(this);
            }

            if ((bool)m_Shelf_WorldUIGrp)
            {
                UnityEngine.Object.Destroy(m_Shelf_WorldUIGrp.gameObject);
            }

            UnityEngine.Object.Destroy(base.gameObject);
        }

        public void LerpToTransform(Transform targetTransform, Transform targetParent)
        {
            m_LerpPosTimer = 0f;
            base.transform.parent = targetParent;
            m_StartLerpPos = base.transform.position;
            m_StartLerpRot = base.transform.rotation;
            m_StartLerpScale = base.transform.localScale;
            m_TargetLerpTransform = targetTransform;
            m_IsLerpingToPos = true;
            m_IsHideAfterFinishLerp = false;
        }

        public void StopLerpToTransform()
        {
            m_LerpPosTimer = 0f;
            m_IsLerpingToPos = false;
            m_IsHideAfterFinishLerp = false;
        }

        public void SetHideItemAfterFinishLerp()
        {
            m_IsHideAfterFinishLerp = true;
        }

        public bool CanPickup()
        {
            return !m_IsLerpingToPos;
        }

        public virtual bool IsValidObject()
        {
            if (!m_IsMovingObject && !m_IsBoxedUp)
            {
                return !m_IsBeingHold;
            }

            return false;
        }

        public bool GetIsBoxedUp()
        {
            return m_IsBoxedUp;
        }

        public bool GetIsMovingObject()
        {
            return m_IsMovingObject;
        }

        public InteractablePackagingBox_Shelf GetPackagingBoxShelf()
        {
            return m_InteractablePackagingBox_Shelf;
        }
    }
}
