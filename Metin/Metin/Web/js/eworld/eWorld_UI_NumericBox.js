/*************************************************************************
* Excentrics World Numeric Box Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.9
* Date Last Updated: January 27, 2004
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@SupportedIE
/*************************************************************************
* Upper Browser Javascript (IE)
*************************************************************************/
var old_onkeypress = null;
function NumericBox_IE_addEvent(id) {
	old_onkeypress = document.getElementById(id).onkeypress;
	document.getElementById(id).onkeypress = NumericBox_IE_AddNumericItem;
	document.getElementById(id).onpaste = NumericBox_IE_Paste;
}

function NumericBox_IE_AddNumericItem(e) {
	if (old_onkeypress != null && typeof(old_onkeypress) == 'function') 
	{
		var ret = old_onkeypress(e);
		if (!ret)
			return false;
	}

	if(document.selection != null) {
		if(document.selection.createRange().text != '')
			document.selection.clear();
	}
	var keyCode = event.keyCode;
	var decPlaces = parseInt(event.srcElement.decPlaces);
	if(event.srcElement.decPlaces == null)
		decPlaces = parseInt(event.srcElement.attributes[NumericBox_IE_FindAttributeIndex(event.srcElement, "decplaces")].value);

	var decSign = event.srcElement.decSign;
	if(decSign == null)
		decSign = event.srcElement.attributes[NumericBox_IE_FindAttributeIndex(event.srcElement, "decsign")].value;

	var isReal = event.srcElement.isReal;
	if(isReal == null)
		isReal = event.srcElement.attributes[NumericBox_IE_FindAttributeIndex(event.srcElement, "isreal")].value;
	var isPos = event.srcElement.isPos;
	if(isPos == null)
		isPos = event.srcElement.attributes[NumericBox_IE_FindAttributeIndex(event.srcElement, "ispos")].value;
	var placesBeforeDec = event.srcElement.placesBeforeDec;
	if(placesBeforeDec == null)
		placesBeforeDec = parseInt(event.srcElement.attributes[NumericBox_IE_FindAttributeIndex(event.srcElement, "placesbeforedec")].value);
	
	if((keyCode >= 48 && keyCode <= 57) || keyCode == 13 || keyCode == 8) {
		if(decPlaces == -1 || isReal == 'false' || keyCode == 13 || keyCode == 8) {
			var tempVal = event.srcElement.value;
			if(tempVal.indexOf('-', 0) == 0)
				tempVal = tempVal.replace('-', '');
			if(tempVal.indexOf(decSign, 0) == -1) {
				if(tempVal.length < placesBeforeDec || placesBeforeDec == -1)
					return true;
				else
					return false;
			} else {
				return true;
			}
		} else {
			var tempVal = event.srcElement.value;
			if(tempVal.indexOf('-', 0) == 0)
				tempVal = tempVal.replace('-', '');
			if(tempVal.indexOf(decSign, 0) == -1) {
				if(tempVal.length < placesBeforeDec || placesBeforeDec == -1)
					return true;
				else
					return false;
			} else {
				if(tempVal.indexOf(decSign, 0) == -1)
					return true;
				else {
					if((tempVal.length - tempVal.indexOf(decSign, 0)) <= decPlaces)
						return true;
					else
						return false;
				}
			}
		}
	} else if(keyCode == 45 || keyCode == 46 || keyCode == 44) {
		if(keyCode == 45) {
			var tempVal = event.srcElement.value + "-";
			if(tempVal.indexOf("-") == 0 && tempVal.indexOf("-", 1) == -1) {
				if(isPos == 'true')
					return false;
				else
					return true;
			} else
				return false;
		} else if(String.fromCharCode(keyCode) == decSign) {
			var tempVal = event.srcElement.value;
			if(tempVal.indexOf(decSign, 0) == -1) {
				if(isReal == 'true')
					return true;
				else
					return false;
			} else
				return false;
		} else
			return false;
	} else
		return false;
		
}

function NumericBox_IE_Paste(e) {
	var pasteData = window.clipboardData.getData("Text");
	var expr = event.srcElement.valExpr;
	if(expr == null)
		expr = event.srcElement.attributes[NumericBox_IE_FindAttributeIndex(event.srcElement, "expr")].value;
	
	eval("var re = /" + expr + "/;");	
	
	if(re.test(pasteData) || pasteData.length == 0) {
		event.srcElement.value = pasteData;
		return false;
	} else
		return false;
}

function NumericBox_IE_ParseAdd(box, dollarSign, dollarSignPlace, commaSign, decimalSign) {
	var currentValue = box.value;
	var parseValue = '';
	var newValue = '';
	var getDecimal = false;
	var addNegative = false;
	if(currentValue.indexOf('-') >= 0) {
		addNegative = true;
		currentValue = currentValue.replace('-', '');
	}
	if(currentValue != '' && currentValue.indexOf(decimalSign) > 0) {
		parseValue = currentValue.substr(0, currentValue.indexOf(decimalSign));
		getDecimal = true;
	} else {
		parseValue = currentValue;
		getDecimal = false;
	}
	var rotations = parseInt(parseValue.length / 3);
	if(parseValue.length % 3 == 0)
		rotations--;
	for(var i=0; i<rotations; i++)
		newValue = commaSign + parseValue.substr(parseValue.length - ((i + 1) * 3), 3) + newValue;
	newValue = parseValue.substr(0, parseValue.length - ((rotations) * 3)) + newValue;		
	if(getDecimal)
		newValue = newValue + currentValue.substr(currentValue.indexOf(decimalSign));
	if(newValue.length > 0) {
		if(addNegative) {
			if (dollarSignPlace == "Left")
				newValue = dollarSign + '-' + newValue;
			else
				newValue = '-' + newValue + dollarSign;
		}
		else {
			if (dollarSignPlace == "Left")
				newValue = dollarSign + newValue;
			else
				newValue = newValue + dollarSign;
		}
	}
	box.value = newValue;
}

function NumericBox_IE_ParseRemove(box, dollarSign, dollarSignPlace, commaSign) {
	var currentValue = box.value;
	var newValue = currentValue;
	while(newValue.indexOf(dollarSign) > -1)
		newValue = newValue.replace(dollarSign, '');
	while(newValue.indexOf(commaSign) > -1)
		newValue = newValue.replace(commaSign, '');
	box.value = newValue;
	box.select();
}

function NumericBox_IE_FindAttributeIndex(element, attName) {
	var attIndex = -1;
	if(element != null) {
		for(var i=0; i<element.attributes.length; i++) {
			if(element.attributes[i].name.toLowerCase() == attName) {
				attIndex = i;
				i = element.attributes.length;
			}
		}
	}
	return attIndex;
}

//@&@&@&@&@SupportedNS
/*************************************************************************
* Upper Browser Javascript (NS)
*************************************************************************/
function NumericBox_NS_AddNumericItem(e, id, isPos, isReal, decPlaces, decSign, placesBeforeDec) {
	var keyCode = e.which;
	if((keyCode >= 48 && keyCode <= 57) || keyCode == 13 || keyCode == 8 || keyCode == 0) {
		if(decPlaces == -1 || isReal == false || keyCode == 13 || keyCode == 8) {
			var tempVal = document.getElementById(id).value;
			if(tempVal.indexOf('-', 0) == 0)
				tempVal = tempVal.replace('-', '');
			if(tempVal.indexOf(decSign, 0) == -1) {
				if(tempVal.length < placesBeforeDec || placesBeforeDec == -1)
					return true;
				else
					e.preventDefault();
			} else {
				return true;
			}
		} else {
			var tempVal = document.getElementById(id).value;
			if(tempVal.indexOf('-', 0) == 0)
				tempVal = tempVal.replace('-', '');
			if(tempVal.indexOf(decSign, 0) == -1) {
				if(tempVal.length < placesBeforeDec || placesBeforeDec == -1)
					return true;
				else
					e.preventDefault();
			} else {
				if(tempVal.indexOf(decSign, 0) == -1)
					return true;
				else {
					if(keyCode == 0 || (tempVal.length - tempVal.indexOf(decSign, 0)) <= decPlaces)
						return true;
					else
						e.preventDefault();
				}
			}
		}
	} else if(e.ctrlKey && keyCode == 118)
		return true;	
	else if(keyCode == 45 || keyCode == 46 || keyCode == 44) {
		if(keyCode == 45) {
			var tempVal = document.getElementById(id).value + "-";
			if(tempVal.indexOf("-") == 0 && tempVal.indexOf("-", 1) == -1) {
				if(isPos)
					e.preventDefault();
				else
					return true;
			} else
				e.preventDefault();
		} else if(String.fromCharCode(keyCode) == decSign) {
			var tempVal = document.getElementById(id).value;
			if(tempVal.indexOf(decSign, 0) == -1) {
				if(isReal)
					return true;
				else
					e.preventDefault();
			} else
				e.preventDefault();
		} else
			e.preventDefault();
	} else
		e.preventDefault();
}

function NumericBox_NS_ParseAdd(box, dollarSign, dollarSignPlace, commaSign, decimalSign) {
	var currentValue = box.value;
	var parseValue = '';
	var newValue = '';
	var getDecimal = false;
	var addNegative = false;
	if(currentValue.indexOf('-') >= 0) {
		addNegative = true;
		currentValue = currentValue.replace('-', '');
	}
	if(currentValue != '' && currentValue.indexOf(decimalSign) > 0) {
		parseValue = currentValue.substr(0, currentValue.indexOf(decimalSign));
		getDecimal = true;
	} else {
		parseValue = currentValue;
		getDecimal = false;
	}
	var rotations = parseInt(parseValue.length / 3);
	if(parseValue.length % 3 == 0)
		rotations--;
	for(var i=0; i<rotations; i++)
		newValue = commaSign + parseValue.substr(parseValue.length - ((i + 1) * 3), 3) + newValue;
	newValue = parseValue.substr(0, parseValue.length - ((rotations) * 3)) + newValue;		
	if(getDecimal)
		newValue = newValue + currentValue.substr(currentValue.indexOf(decimalSign));
	if(newValue.length > 0) {
		if(addNegative) {
			if (dollarSignPlace == "Left")
				newValue = dollarSign + '-' + newValue;
			else
				newValue = '-' + newValue + dollarSign;
		}
		else {
			if (dollarSignPlace == "Left")
				newValue = dollarSign + newValue;
			else
				newValue = newValue + dollarSign;
		}
	}
	box.value = newValue;
}

function NumericBox_NS_ParseRemove(box, dollarSign, dollarSignPlace, commaSign) {
	var currentValue = box.value;
	var newValue = currentValue;
	while(newValue.indexOf(dollarSign) > -1)
		newValue = newValue.replace(dollarSign, '');
	while(newValue.indexOf(commaSign) > -1)
		newValue = newValue.replace(commaSign, '');
	box.value = newValue;
	box.select();
}