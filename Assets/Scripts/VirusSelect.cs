using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VirusSelect : MonoBehaviour {

	public GameObject SlotOne, SlotTwo, SlotThree, SlotFour;
	public GameObject SOne, STwo, SThree, SFour;

	int slotNumber = 4;
	public int slotAvailable;

	public int OStrength, BStrength, GStrength, PStrength;

	public int virusNumber;

	public void Start()
	{
		SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
		SOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
		SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
		STwo.gameObject.GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
		SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
		SThree.gameObject.GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
		SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
		SFour.gameObject.GetComponent<Image> ().color = new Color32 (0, 0, 0, 0);
	}

	void Upgrade()
	{
		slotAvailable++;
		Data.control.Points -= 50;

		if (slotAvailable == 1) {
			SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			SOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
		} else if (slotAvailable == 2) {
			SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			STwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
		}else if (slotAvailable == 3) {
			SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			SThree.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
		}else if (slotAvailable == 4) {
			SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			SFour.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
		}
	}

	public void ResetTurrets()
	{
		Select (0);
	}

	public void Select(int virus)
	{
		virusNumber = virus;

		if (virus == 0) 
		{
			if (slotAvailable == 1) {
				SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			} else if (slotAvailable == 2) {
				SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				STwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			} else if (slotAvailable == 3) {
				SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				STwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SThree.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			} else if (slotAvailable == 4) {
				SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SOne.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				STwo.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SThree.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
				SFour.gameObject.GetComponent<Image> ().color = new Color32 (255, 255, 255, 200);
			} 
			slotNumber = 4;
			BStrength = 0;
			GStrength = 0;
			OStrength = 0;
			PStrength = 0;
		

		}

		if (virus == 1) {
			if (slotNumber == 4) 
			{
				if (slotAvailable >= 1) 
				{
					SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					SOne.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					slotNumber--;
					OStrength++;
				}
			} 
			else if (slotNumber == 3) 
			{
				if (slotAvailable >= 2) 
				{
					SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					STwo.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					slotNumber--;
					OStrength++;
				}
			} 
			else if (slotNumber == 2) 
			{
				if (slotAvailable >= 3) 
				{
					SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					SThree.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					slotNumber--;
					OStrength++;
				}
			} 
			else if (slotNumber == 1) 
			{
				if (slotAvailable >= 4) 
				{
					SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					SFour.gameObject.GetComponent<Image> ().color = new Color32 (241, 90, 36, 200);
					slotNumber--;
					OStrength++;
				}
			} 
		
		}

		if (virus == 2) {
			if (slotNumber == 4) {
				if (slotAvailable >= 1) {
					SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					SOne.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					slotNumber--;
					BStrength++;
				}
			} else if (slotNumber == 3) {
				if (slotAvailable >= 2) {
					SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					STwo.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					slotNumber--;
					BStrength++;
				}
			} else if (slotNumber == 2) {
				if (slotAvailable >= 3) {
					SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					SThree.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					slotNumber--;
					BStrength++;
				}
			} else if (slotNumber == 1) {
				if (slotAvailable >= 4) {
					SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					SFour.gameObject.GetComponent<Image> ().color = new Color32 (38, 86, 150, 200);
					slotNumber--;
					BStrength++;
				}
			} 

		}
		if (virus == 3) {
			if (slotNumber == 4) {
				if (slotAvailable >= 1) {
					SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					SOne.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					slotNumber--;
					GStrength++;
				}
			} else if (slotNumber == 3) {
				if (slotAvailable >= 2) {
					SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					STwo.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					slotNumber--;
					GStrength++;
				}
			} else if (slotNumber == 2) {
				if (slotAvailable >= 3) {
					SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					SThree.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					slotNumber--;
					GStrength++;
				}
			} else if (slotNumber == 1) {
				if (slotAvailable >= 3) {
					SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					SFour.gameObject.GetComponent<Image> ().color = new Color32 (0, 104, 55, 200);
					slotNumber--;
					GStrength++;
				}
			} 

		}
		if (virus == 4) {
			if (slotNumber == 4) {
				if (slotAvailable >= 1) {
					SlotOne.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					SOne.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					slotNumber--;
					PStrength++;
				}
			} else if (slotNumber == 3) {
				if (slotAvailable >= 2) {
					SlotTwo.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					STwo.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					slotNumber--;
					PStrength++;
				}
			} else if (slotNumber == 2) {
				if (slotAvailable >= 3) {
					SlotThree.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					SThree.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					slotNumber--;
					PStrength++;
				}
			} else if (slotNumber == 1) {
				if (slotAvailable >= 4) {
					SlotFour.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					SFour.gameObject.GetComponent<Image> ().color = new Color32 (172, 32, 105, 200);
					slotNumber--;
					PStrength++;
				}
			} 
		}

	}

}
