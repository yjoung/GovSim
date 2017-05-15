using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiplomaticAxis : Values {

	public enum Label {
		cosmopolitan,
		internationalist,
		peaceful,
		balanced,
		patriotic,
		nationalist,
		chauvinist
	};
	public Label label;

	public DiplomaticAxis (int _value) {
		this.value = _value;
		SetLabel ();
	}

	void SetLabel () {
		if (value < 10) {
			label = Label.cosmopolitan;
		} else if (value < 25) {
			label = Label.internationalist;
		} else if (value < 40) {
			label = Label.peaceful;
		} else if (value < 61) {
			label = Label.balanced;
		} else if (value < 76) {
			label = Label.patriotic;
		} else if (value < 91) {
			label = Label.nationalist;
		} else if (value < 101) {
			label = Label.chauvinist;
		}

	}

}
