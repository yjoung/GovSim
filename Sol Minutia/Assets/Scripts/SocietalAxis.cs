using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocietalAxis : Values {

	public enum Label {
		reactionary,
		veryTraditional,
		traditional,
		neutral,
		progressive,
		veryProgressive,
		revolutionary
	};
	public Label label;

	public SocietalAxis (int _value) {
		this.value = _value;
		SetLabel ();
	}

	void SetLabel () {
		if (value < 10) {
			label = Label.reactionary;
		} else if (value < 25) {
			label = Label.veryTraditional;
		} else if (value < 40) {
			label = Label.traditional;
		} else if (value < 61) {
			label = Label.neutral;
		} else if (value < 76) {
			label = Label.progressive;
		} else if (value < 91) {
			label = Label.veryProgressive;
		} else if (value < 101) {
			label = Label.revolutionary;
		}

	}

}
