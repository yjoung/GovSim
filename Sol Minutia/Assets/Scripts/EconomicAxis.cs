using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomicAxis : Values {

	public enum Label {
		communist,
		socialist,
		social,
		centrist,
		market,
		capitalist,
		laissezFaire
	};
	public Label label;

	public EconomicAxis (int _value) {
		this.value = _value;
		SetLabel ();
	}

	void SetLabel () {
		if (value < 10) {
			label = Label.communist;
		} else if (value < 25) {
			label = Label.socialist;
		} else if (value < 40) {
			label = Label.social;
		} else if (value < 61) {
			label = Label.centrist;
		} else if (value < 76) {
			label = Label.market;
		} else if (value < 91) {
			label = Label.capitalist;
		} else if (value < 101) {
			label = Label.laissezFaire;
		}

	}

}
