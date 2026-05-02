using System;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;



// Token: 0x020000E9 RID: 233
[RequireComponent(typeof(PhotonView))]
public class LuckyBreakable : MonoBehaviour
{
	// Token: 0x06000757 RID: 1879 RVA: 0x00027A64 File Offset: 0x00025C64
	private void Awake()
	{
		this.item = base.GetComponent<Item>();
		this.rig = base.GetComponent<Rigidbody>();
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x00027A80 File Offset: 0x00025C80
	private void OnCollisionEnter(Collision collision)
	{
		if (!this.item.photonView.IsMine)
		{
			return;
		}
		if (this.item.itemState == ItemState.Ground && this.breakOnCollision && this.item.rig && collision.relativeVelocity.magnitude > this.minBreakVelocity)
		{
			this.Break(collision);
		}
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x00027AE4 File Offset: 0x00025CE4
	private void FixedUpdate()
	{
		if (this.rig == null || this.rig.isKinematic)
		{
			return;
		}
		this.lastVelocity = this.rig.linearVelocity;
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x00027B14 File Offset: 0x00025D14
	public virtual void Break(Collision coll)
	{
		if (this.alreadyBroke)
		{
			return;
		}
		this.alreadyBroke = true;
		for (int i = 0; i < this.breakSFX.Count; i++)
		{
			this.breakSFX[i].Play(base.transform.position);
		}
		if (this.ragdollCharacterOnBreak)
		{
			Character componentInParent = coll.transform.GetComponentInParent<Character>();
			if (componentInParent)
			{
				Rigidbody componentInParent2 = coll.transform.GetComponentInParent<Rigidbody>();
				Vector3 vector = this.lastVelocity.normalized * this.pushForce;
				componentInParent.AddForceToBodyPart(componentInParent2, vector * this.pushForce, vector * this.wholeBodyPushForce);
				componentInParent.Fall(2f, 15f);
			}
		}
		Outcomes.TriggerRandom(this,coll);
        

		PhotonNetwork.Destroy(base.gameObject);
	}

	// Token: 0x040006E1 RID: 1761
	public Item item = null!;

	// Token: 0x040006E2 RID: 1762
	public bool breakOnCollision = true;

	// Token: 0x040006E3 RID: 1763
	public float minBreakVelocity = 5f;

	// Token: 0x040006E7 RID: 1767
	public List<SFX_Instance> breakSFX = null!;

	// Token: 0x040006E8 RID: 1768
	public List<GameObject> instantiateNonItemOnBreak = null!;

	// Token: 0x040006E9 RID: 1769
	public List<Transform> instantiatePoints = null!;

	// Token: 0x040006EA RID: 1770
	public bool spawnsItemsKinematic = false;

	// Token: 0x040006EB RID: 1771
	public bool playAnimationOnInstantiatedObject = false;

	// Token: 0x040006EC RID: 1772
	public string animString = null!;

	// Token: 0x040006ED RID: 1773
	public bool ragdollCharacterOnBreak = false;

	// Token: 0x040006EE RID: 1774
	private Rigidbody rig = null!;

	// Token: 0x040006EF RID: 1775
	private bool alreadyBroke = false;

	// Token: 0x040006F0 RID: 1776
	private Vector3 lastVelocity = Vector3.zero;

	// Token: 0x040006F1 RID: 1777
	public float pushForce = 2f;

	// Token: 0x040006F2 RID: 1778
	public float wholeBodyPushForce = 1f;
}
