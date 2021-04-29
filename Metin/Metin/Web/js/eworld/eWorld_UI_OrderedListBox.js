/*************************************************************************
* Excentrics World Ordered List Box Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.4
* Date Last Updated: January 27, 2004
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@Supported
/*************************************************************************
* Upper Browser Javascript (IE & NS6+)
*************************************************************************/
function BuildMoveItem(curIndex, value, text) {
	this.currentIndex = curIndex;
	this.value = value;
	this.text = text;
}

function OrderedListBox_MoveUp(lbName, hidName, hidLoadName, moveMultiple) {
	var listBox = document.getElementById(lbName);
	var hiddenField = document.getElementById(hidName);
	var hiddenLoadField = document.getElementById(hidLoadName);
	var optionArray = new Array();
	var selectedArray = OrderedListBox_RetrieveSelected(listBox, moveMultiple);
	
	for(var i=0; i<selectedArray.length; i++) {
		if(selectedArray[i].currentIndex > 0)
			OrderedListBox_CreateItem(listBox, selectedArray[i].currentIndex, true);
		else
			i = selectedArray.length;
	}
	
	OrderedListBox_Reselect(listBox, selectedArray);
	OrderedListBox_SetValues(listBox, hiddenField, hiddenLoadField);
}

function OrderedListBox_MoveDown(lbName, hidName, hidLoadName, moveMultiple) {
	var listBox = document.getElementById(lbName);
	var hiddenField = document.getElementById(hidName);
	var hiddenLoadField = document.getElementById(hidLoadName);
	var optionArray = new Array();
	var selectedArray = OrderedListBox_RetrieveSelected(listBox, moveMultiple);
	
	for(var i=selectedArray.length - 1; i>=0; i--) {
		if(selectedArray[i].currentIndex < listBox.options.length - 1)
			OrderedListBox_CreateItem(listBox, selectedArray[i].currentIndex, false);
		else
			i = -1;
	}
	
	OrderedListBox_Reselect(listBox, selectedArray);
	OrderedListBox_SetValues(listBox, hiddenField, hiddenLoadField);
}

function OrderedListBox_Reselect(listBox, selectedArray) {
	for(var i=0; i<selectedArray.length; i++) {
		for(var j=0; j<listBox.options.length; j++) {
			if(listBox.options[j].value == selectedArray[i].value) {
				listBox.options[j].selected = true;
				break;
			}
		}
	}
}

function OrderedListBox_RetrieveSelected(listBox, moveMultiple) {
	var selectedArray = new Array();
	if(moveMultiple) {
		for(var i=0; i<listBox.options.length; i++) {
			if(listBox.options[i].selected)
				selectedArray[selectedArray.length] = new BuildMoveItem(i, listBox.options[i].value, listBox.options[i].text);
		}
	} else {
		var selIndex = listBox.selectedIndex;
		if(selIndex >= 0)
			selectedArray[0] = new BuildMoveItem(selIndex, listBox.options[selIndex].value, listBox.options[selIndex].text);
	}
	return selectedArray;
}

function OrderedListBox_CreateItem(listBox, oldPos, moveUp) {
	var newPos, text, value;
	var itemArray = new Array(listBox.options.length);
	if(moveUp) {
		newPos = oldPos - 1;
		// read the items to the new position
		for(var i=0; i<newPos; i++)
			itemArray[i] = new Option(listBox.options[i].text, listBox.options[i].value);
		// add the currently selected item
		itemArray[newPos] = new Option(listBox.options[oldPos].text, listBox.options[oldPos].value);
		// add the item prior to the selected item
		itemArray[oldPos] = new Option(listBox.options[newPos].text, listBox.options[newPos].value);
		// read the items from the old position to the end
		for(var i=oldPos + 1; i<listBox.options.length; i++)
			itemArray[i] = new Option(listBox.options[i].text, listBox.options[i].value);
	} else {
		newPos = oldPos + 1;
		// read the items to the old position
		for(var i=0; i<oldPos; i++) {
			itemArray[i] = new Option(listBox.options[i].text, listBox.options[i].value);
		}
		// add the item after the selected item
		itemArray[oldPos] = new Option(listBox.options[newPos].text, listBox.options[newPos].value);
		// add the currently selected item
		itemArray[newPos] = new Option(listBox.options[oldPos].text, listBox.options[oldPos].value);
		// read the items from the new position to the end
		for(var i=newPos + 1; i<listBox.options.length; i++)
			itemArray[i] = new Option(listBox.options[i].text, listBox.options[i].value);
	}
	// reorder the items
	for(var i=0; i<itemArray.length; i++)
		listBox.options[i] = itemArray[i];
}

function OrderedListBox_MoveItem(lbFromName, lbToName, hidFromName, hidLoadFromName, hidToName, hidLoadToName, isCopy, moveMultiple) {
	var listBoxFrom = document.getElementById(lbFromName);
	var listBoxTo = document.getElementById(lbToName);
	var hiddenFromField = document.getElementById(hidFromName);
	var hiddenLoadFrom = document.getElementById(hidLoadFromName);
	var hiddenToField = document.getElementById(hidToName);
	var hiddenLoadTo = document.getElementById(hidLoadToName);
	var itemExists = false;
	if(hiddenToField != null && hiddenLoadTo != null) {	
		var selectedArray = OrderedListBox_RetrieveSelected(listBoxFrom, moveMultiple);
		// move the items
		for(var i=0; i<selectedArray.length; i++) {
			for(var j=0; j<listBoxTo.options.length; j++) {
				if(listBoxTo.options[j].value == selectedArray[i].value) {
					itemExists = true;
					j=listBoxTo.options.length;
				}
			}
			if(!itemExists)
				listBoxTo.options[listBoxTo.options.length] = new Option(selectedArray[i].text, selectedArray[i].value);
			itemExists = false;
		}
		// remove the items
		if(!isCopy) {
			listBoxTo.selectedIndex = -1;
			for(var i=0; i<selectedArray.length; i++) {
				for(var j=0; j<listBoxFrom.options.length; j++) {
					if(listBoxFrom.options[j].value == selectedArray[i].value)
						listBoxFrom.options[j] = null;
				}
				for(var j=0; j<listBoxTo.options.length; j++) {
					if(listBoxTo.options[j].value == selectedArray[i].value)
						listBoxTo.options[j].selected = true;
				}
			}
		}
		// set the values
		OrderedListBox_SetValues(listBoxFrom, hiddenFromField, hiddenLoadFrom);
		OrderedListBox_SetValues(listBoxTo, hiddenToField, hiddenLoadTo);
	}
}
function OrderedListBox_SetValues(listBox, hiddenField, hiddenLoadField) {
	hiddenField.value = '';
	for(var i=0; i<listBox.options.length; i++) {
		if(hiddenField.value != '')
			hiddenField.value += '\x01';
		hiddenField.value += listBox.options[i].text + '\x02' + listBox.options[i].value + '\x02' + listBox.options[i].selected;
	}
	hiddenLoadField.value = 'true';
}