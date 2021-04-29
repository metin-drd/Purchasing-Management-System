/*************************************************************************
* Excentrics World Masked Textbox Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.8
* Date Last Updated: January 27, 2004
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@SupportedIE
/*************************************************************************
* Upper Browser Javascript (IE)
*************************************************************************/
function MaskedTextBox_IE_addEvent(id) {
	document.getElementById(id).onkeypress = MaskedTextBox_IE_VerifyMask;
}

function MaskedTextBox_IE_FocusMask(e) {
	if(event.srcElement.value == '') {
		var i=1;
		var mask = event.srcElement.mask;
		if(mask == null)
			mask = event.target.attributes[event.target.attributes.length - 1].value;
		var maskChar = mask.substr(0, 1);
		var charCode = maskChar.toLowerCase().charCodeAt(0);
		while((charCode != 57) && ((charCode < 48) || (charCode > 57)) && (charCode != 99)) {
			event.srcElement.value = event.srcElement.value + maskChar;
			maskChar = mask.substr(i, 1);
			charCode = maskChar.toLowerCase().charCodeAt(0);
			i++;
		}
		if(event.srcElement.createTextRange) {
			var range = event.srcElement.createTextRange();
			
			range.moveStart('character', event.srcElement.value.length);
			range.collapse();
			range.select();
		}
	}
}

function MaskedTextBox_IE_VerifyMask(e) {
	if(document.selection != null) {
		if(document.selection.createRange().text != '')
			document.selection.clear();
	}
	var keyCode = event.keyCode;
	var autoFill = event.srcElement.autofill;
	if(autoFill == null)
		autoFill = event.target.attributes[event.target.attributes.length - 2].value;
	var mask = event.srcElement.mask;
	if(mask == null)
		mask = event.target.attributes[event.target.attributes.length - 1].value;
	var val = event.srcElement.value;
	var retValue = false;
	
	if(mask.length == 0 || keyCode == 13 || keyCode == 8 || keyCode == 0) {
		retValue = true;
	} else {
	
		var maskChar = mask.substr(val.length, 1);
		var nextMaskChar = '';
		if((val.length + 1) <= mask.length)
			nextMaskChar = mask.substr(val.length + 1, 1);
	
		if ((maskChar.charCodeAt(0) == 57) && (keyCode >= 48) && (keyCode <= 57)) // digit
			retValue = true;
		else if((maskChar.toLowerCase().charCodeAt(0) == 99) && (((keyCode >= 65) && (keyCode <=90)) || ((keyCode >= 97) && (keyCode <= 122)))) //&& (((keyCode >= 65) && (keyCode <= 90)) || ((keyCode >= 99) && (keyCode <= 122))))
			retValue = true;
		else if(maskChar == String.fromCharCode(keyCode)) // special
			retValue = true;
		else
			retValue = false;
			
		if(retValue && autoFill == 'true') {
			var i=1;
			var addedKey = false;
			while(nextMaskChar != '') {
				if((val.length + i) <= mask.length)
					nextMaskChar = mask.substr(val.length + i, 1);
				if(nextMaskChar.toLowerCase() == '9' || nextMaskChar.toLowerCase() == 'c')
					nextMaskChar = '';
				var charCode = nextMaskChar.toLowerCase().charCodeAt(0);
				if((charCode != 57) && ((charCode < 48) || (charCode > 57)) && (charCode != 99)) {
					if(!addedKey) {
						event.srcElement.value = event.srcElement.value + String.fromCharCode(keyCode) + nextMaskChar;
						addedKey = true;
					} else
						event.srcElement.value = event.srcElement.value + nextMaskChar;
					retValue = false;
				}
				i++;
			}
		}
	}
	
	return retValue;
}

//@&@&@&@&@SupportedNS
/*************************************************************************
* Upper Browser Javascript (NS6)
*************************************************************************/
function MaskedTextBox_NS_FocusMask(e, id, mask) {
	if(document.getElementById(id).value == '') {
		var i=1;
		var maskChar = mask.substr(0, 1);
		var charCode = maskChar.toLowerCase().charCodeAt(0);
		while((charCode != 57) && ((charCode < 48) || (charCode > 57)) && (charCode != 99)) {
			document.getElementById(id).value = document.getElementById(id).value + maskChar;
			maskChar = mask.substr(i, 1);
			charCode = maskChar.toLowerCase().charCodeAt(0);
			i++;
		}
	}
}

function MaskedTextBox_NS_VerifyMask(e, id, mask, autoFill) {
	var keyCode = e.which;
	var val = document.getElementById(id).value;
	var retValue = false;
	
	if(mask.length == 0 || keyCode == 13 || keyCode == 8 || keyCode == 0) {
		retValue = true;
	} else {
	
		var maskChar = mask.substr(val.length, 1);
		var nextMaskChar = '';
		if((val.length + 1) <= mask.length)
			nextMaskChar = mask.substr(val.length + 1, 1);
	
		if ((maskChar.charCodeAt(0) == 57) && (keyCode >= 48) && (keyCode <= 57)) // digit
			retValue = true;
		else if(e.ctrlKey && keyCode == 118)
			retValue = true;
		else if((maskChar.toLowerCase().charCodeAt(0) == 99) && (((keyCode >= 65) && (keyCode <=90)) || ((keyCode >= 97) && (keyCode <= 122)))) //&& (((keyCode >= 65) && (keyCode <= 90)) || ((keyCode >= 99) && (keyCode <= 122))))
			retValue = true;
		else if(maskChar == String.fromCharCode(keyCode)) // special
			retValue = true;
		else
			retValue = false;
			
		if(retValue && autoFill) {
			var i=1;
			var addedKey = false;
			while(nextMaskChar != '') {
				if((val.length + i) <= mask.length)
					nextMaskChar = mask.substr(val.length + i, 1);
				if(nextMaskChar.toLowerCase() == '9' || nextMaskChar.toLowerCase() == 'c')
					nextMaskChar = '';
				var charCode = nextMaskChar.toLowerCase().charCodeAt(0);
				if((charCode != 57) && ((charCode < 48) || (charCode > 57)) && (charCode != 99)) {
					if(!addedKey) {
						document.getElementById(id).value = document.getElementById(id).value + String.fromCharCode(keyCode) + nextMaskChar;
						addedKey = true;
					} else
						document.getElementById(id).value = document.getElementById(id).value + nextMaskChar;
					retValue = false;
				}
				i++;
			}
		}
	}
	if(!retValue)
		e.preventDefault();
	return retValue;
}