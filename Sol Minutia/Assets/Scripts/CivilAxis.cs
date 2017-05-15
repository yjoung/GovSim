using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilAxis : Values {

	public enum Label {
		anarchist,
		libertarian,
		liberal,
		moderate,
		statist,
		authoritarian,
		totalitarian
	};
	public Label label;

	public CivilAxis (int _value) {
		this.value = _value;
		SetLabel ();
	}

	void SetLabel () {
		if (value < 10) {
			label = Label.anarchist;
		} else if (value < 25) {
			label = Label.libertarian;
		} else if (value < 40) {
			label = Label.liberal;
		} else if (value < 61) {
			label = Label.moderate;
		} else if (value < 76) {
			label = Label.statist;
		} else if (value < 91) {
			label = Label.authoritarian;
		} else if (value < 101) {
			label = Label.totalitarian;
		}

	}

}
