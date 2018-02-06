using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class set_gradient_colors : MonoBehaviour {

	/* THIS WAS NOT IMPLEMENTED IN THE END */

	public Color red;
	public Color blue;
	public Color black;
	public Color white;
	public Color green;

	public Material skyboxGradient;

	public void setColor1(Dropdown input) {
		
		if (input.value == 0) {
			skyboxGradient.SetColor ("_Color1", black);
		} else if (input.value == 1) {
			skyboxGradient.SetColor ("_Color1", blue);
		} else if (input.value == 2) {
			skyboxGradient.SetColor ("_Color1", red);
		} else if (input.value == 3) {
			skyboxGradient.SetColor ("_Color1", white);
		} else if (input.value == 4) {
			skyboxGradient.SetColor ("_Color1", green);
		}
	}

	public void setColor2(Dropdown input) {

		if (input.value == 0) {
			skyboxGradient.SetColor ("_Color2", black);
		} else if (input.value == 1) {
			skyboxGradient.SetColor ("_Color2", blue);
		} else if (input.value == 2) {
			skyboxGradient.SetColor ("_Color2", red);
		} else if (input.value == 3) {
			skyboxGradient.SetColor ("_Color2", white);
		} else if (input.value == 4) {
			skyboxGradient.SetColor ("_Color2", green);
		}
	}

	public void setColor3(Dropdown input) {

		if (input.value == 0) {
			skyboxGradient.SetColor ("_Color3", black);
		} else if (input.value == 1) {
			skyboxGradient.SetColor ("_Color3", blue);
		} else if (input.value == 2) {
			skyboxGradient.SetColor ("_Color3", red);
		} else if (input.value == 3) {
			skyboxGradient.SetColor ("_Color3", white);
		} else if (input.value == 4) {
			skyboxGradient.SetColor ("_Color3", green);
		}
	}

	public void setColor4(Dropdown input) {

		if (input.value == 0) {
			skyboxGradient.SetColor ("_Color4", black);
		} else if (input.value == 1) {
			skyboxGradient.SetColor ("_Color4", blue);
		} else if (input.value == 2) {
			skyboxGradient.SetColor ("_Color4", red);
		} else if (input.value == 3) {
			skyboxGradient.SetColor ("_Color4", white);
		} else if (input.value == 4) {
			skyboxGradient.SetColor ("_Color4", green);
		}
	}

	public void setColor5(Dropdown input) {

		if (input.value == 0) {
			skyboxGradient.SetColor ("_Color5", black);
		} else if (input.value == 1) {
			skyboxGradient.SetColor ("_Color5", blue);
		} else if (input.value == 2) {
			skyboxGradient.SetColor ("_Color5", red);
		} else if (input.value == 3) {
			skyboxGradient.SetColor ("_Color5", white);
		} else if (input.value == 4) {
			skyboxGradient.SetColor ("_Color5", green);
		}
	}
}
