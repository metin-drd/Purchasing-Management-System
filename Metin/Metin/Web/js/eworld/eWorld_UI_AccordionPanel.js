/*************************************************************************
* Excentrics World Accordion Panel Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.0
* Date Last Updated: January 27, 2003
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@SupportedIE
/*************************************************************************
* Upper Browser Javascript (IE)
*************************************************************************/
var AccordionPanel_ActivePanel = null;
var AccordionPanel_ActiveHeight = 0;
var AccordionPanel_ActiveTotalHeight = 0;
var AccordionPanel_ActiveLinesToDisplay = 20;
var AccordionPanel_TimerID = 0;

function AccordionPanel_IE_Object(clientID, groupName) {
	this.ClientID = clientID;
	this.GroupName = groupName;
}

function AccordionPanel_IE_OnToggleBubble(clientID, isCollapsing) {
	var groupName = '';
	if(AccordionPanel_IDArray != null) {
		// find the group name
		for(var i=0; i<AccordionPanel_IDArray.length; i++) {
			if(AccordionPanel_IDArray[i].ClientID == clientID) {
				groupName = AccordionPanel_IDArray[i].GroupName;
				i = AccordionPanel_IDArray.length;
			}
		}
		// find all accordion panels in this group
		for(var i=0; i<AccordionPanel_IDArray.length; i++) {
			if(AccordionPanel_IDArray[i].ClientID != clientID && AccordionPanel_IDArray[i].GroupName == groupName) {
				eval(AccordionPanel_IDArray[i].ClientID + "_HidePanel();");
			}
		}
	}
}

function AccordionPanel_IE_Collapse(hideThis, changeThis, setThis, exText, slide, height, speed, lines, styleID, isCollapseClass, collapsedStyle) {
	var el = document.getElementById(hideThis);
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	
	if(styleID.indexOf(';') > 0) {
		elStyleLeft = document.getElementById(styleID.split(';')[0]);
		elStyleRight = document.getElementById(styleID.split(';')[1]);
		if(styleID.split(';').length == 3)
			elStyleLink = document.getElementById(styleID.split(';')[2]);
	} else {
		elStyleLeft = document.getElementById(styleID);
	}
	
	var leftClassId = CollapsablePanel_IE_FindAttributeIndex(elStyleLeft, 'class');
	var rightClassId = CollapsablePanel_IE_FindAttributeIndex(elStyleRight, 'class');
	var linkClassId = CollapsablePanel_IE_FindAttributeIndex(elStyleLink, 'class');
	var leftStyleId = CollapsablePanel_IE_FindAttributeIndex(elStyleLeft, 'style');
	var rightStyleId = CollapsablePanel_IE_FindAttributeIndex(elStyleRight, 'style');
	var linkStyleId = CollapsablePanel_IE_FindAttributeIndex(elStyleLink, 'style');
		
	if(AccordionPanel_ActivePanel != null)
		slide = false;
	
	if(el.style.display == '') {
		if(!slide) {
			document.getElementById(hideThis).style.display = 'none';
		} else {
			AccordionPanel_ActivePanel = el;
			AccordionPanel_ActiveHeight = height;
			AccordionPanel_ActiveLinesToDisplay = lines;
			
			AccordionPanel_TimerID = setInterval(AccordionPanel_IE_HideTimer, speed);
		}
		if(document.getElementById(changeThis) != null)
			document.getElementById(changeThis).innerHTML = exText;
		if(isCollapseClass) {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftClassId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightClassId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkClassId, collapsedStyle);
		} else {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftStyleId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightStyleId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkStyleId, collapsedStyle);
		}
		document.getElementById(setThis).value = 'true';
	}
}

function AccordionPanel_IE_CollapseImage(hideThis, changeThis, setThis, expandUrl, exText, slide, height, speed, lines, styleID, isCollapseClass, collapsedStyle) {
	var el = document.getElementById(hideThis);	
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	
	if(styleID.indexOf(';') > 0) {
		elStyleLeft = document.getElementById(styleID.split(';')[0]);
		elStyleRight = document.getElementById(styleID.split(';')[1]);
		if(styleID.split(';').length == 3)
			elStyleLink = document.getElementById(styleID.split(';')[2]);
	} else {
		elStyleLeft = document.getElementById(styleID);
	}
	
	var leftClassId = CollapsablePanel_IE_FindAttributeIndex(elStyleLeft, 'class');
	var rightClassId = CollapsablePanel_IE_FindAttributeIndex(elStyleRight, 'class');
	var linkClassId = CollapsablePanel_IE_FindAttributeIndex(elStyleLink, 'class');
	var leftStyleId = CollapsablePanel_IE_FindAttributeIndex(elStyleLeft, 'style');
	var rightStyleId = CollapsablePanel_IE_FindAttributeIndex(elStyleRight, 'style');
	var linkStyleId = CollapsablePanel_IE_FindAttributeIndex(elStyleLink, 'style');
	
	if(AccordionPanel_ActivePanel != null)
		slide = false;
	
	if(document.getElementById(hideThis).style.display == '') {
		if(!slide) {
			document.getElementById(hideThis).style.display = 'none';
		} else {
			AccordionPanel_ActivePanel = el;
			AccordionPanel_ActiveHeight = height;
			AccordionPanel_ActiveLinesToDisplay = lines;
			
			AccordionPanel_TimerID = setInterval(AccordionPanel_IE_HideTimer, speed);
		}
		if(document.getElementById(changeThis) != null) {
			document.getElementById(changeThis).src = expandUrl;
			document.getElementById(changeThis).alt = exText;
		}
		if(isCollapseClass) {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftClassId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightClassId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkClassId, collapsedStyle);
		} else {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftStyleId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightStyleId, collapsedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkStyleId, collapsedStyle);
		}
		document.getElementById(setThis).value = 'true';
	}
}

function AccordionPanel_IE_HideTimer() {
	AccordionPanel_ActiveHeight -= AccordionPanel_ActiveLinesToDisplay;
	if(AccordionPanel_ActiveHeight > 0) {
		if(AccordionPanel_ActivePanel != null) {
			AccordionPanel_ActivePanel.style.height = (AccordionPanel_ActiveHeight) + 'px';
		}
		
	}
	else {
		clearInterval(AccordionPanel_TimerID);
		if(AccordionPanel_ActivePanel != null) {
			AccordionPanel_ActivePanel.style.display = 'none';
		}
		AccordionPanel_ActivePanel = null;
		AccordionPanel_ActiveHeight = 0;
		AccordionPanel_ActiveTotalHeight = 0;
		AccordionPanel_TimerID = 0;
	}
}

//@&@&@&@&@SupportedNS
/*************************************************************************
* Upper Browser Javascript (NS)
*************************************************************************/
function AccordionPanel_NS_Object(clientID, groupName) {
	this.ClientID = clientID;
	this.GroupName = groupName;
}

function AccordionPanel_NS_OnToggleBubble(clientID, isCollapsing) {
	var groupName = '';
	if(AccordionPanel_IDArray != null) {
		// find the group name
		for(var i=0; i<AccordionPanel_IDArray.length; i++) {
			if(AccordionPanel_IDArray[i].ClientID == clientID) {
				groupName = AccordionPanel_IDArray[i].GroupName;
				i = AccordionPanel_IDArray.length;
			}
		}
		// find all accordion panels in this group
		for(var i=0; i<AccordionPanel_IDArray.length; i++) {
			if(AccordionPanel_IDArray[i].ClientID != clientID && AccordionPanel_IDArray[i].GroupName == groupName) {
				eval(AccordionPanel_IDArray[i].ClientID + "_HidePanel();");
			}
		}
	}
}

function AccordionPanel_NS_Collapse(hideThis, changeThis, setThis, exText, slide, height, speed, lines, styleID, isCollapseClass, collapsedStyle) {
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	
	if(styleID.indexOf(';') > 0) {
		elStyleLeft = document.getElementById(styleID.split(';')[0]);
		elStyleRight = document.getElementById(styleID.split(';')[1]);
		if(styleID.split(';').length == 3)
			elStyleLink = document.getElementById(styleID.split(';')[2]);
	} else {
		elStyleLeft = document.getElementById(styleID);
	}
	
	if(document.getElementById(hideThis).style.display == '') {
		document.getElementById(hideThis).style.display = 'none';
		if(document.getElementById(changeThis) != null)
			document.getElementById(changeThis).innerHTML = exText;
		if(isCollapseClass) {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['class'].value != null) {
					elStyleLeft.attributes['class'].value = collapsedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['class'].value != null) {
					elStyleRight.attributes['class'].value = collapsedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['class'].value != null) {
					elStyleLink.attributes['class'].value = collapsedStyle;
				}
			}
		} else {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['style'] != null) {
					elStyleLeft.attributes['style'].value = collapsedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['style'].value != null) {
					elStyleRight.attributes['style'].value = collapsedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['style'].value != null) {
					elStyleLink.attributes['style'].value = collapsedStyle;
				}
			}
		}
		document.getElementById(setThis).value = 'true';
	}
}

function AccordionPanel_NS_CollapseImage(hideThis, changeThis, setThis, expandUrl, exText, slide, height, speed, lines, styleID, isCollapseClass, collapsedStyle) {
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	
	if(styleID.indexOf(';') > 0) {
		elStyleLeft = document.getElementById(styleID.split(';')[0]);
		elStyleRight = document.getElementById(styleID.split(';')[1]);
		if(styleID.split(';').length == 3)
			elStyleLink = document.getElementById(styleID.split(';')[2]);
	} else {
		elStyleLeft = document.getElementById(styleID);
	}
	
	if(document.getElementById(hideThis).style.display == '') {
		document.getElementById(hideThis).style.display = 'none';
		if(document.getElementById(changeThis) != null) {
			document.getElementById(changeThis).src = expandUrl;
			document.getElementById(changeThis).alt = exText;
		}
		if(isCollapseClass) {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['class'].value != 'null') {
					elStyleLeft.attributes['class'].value = collapsedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['class'].value != 'null') {
					elStyleRight.attributes['class'].value = collapsedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['class'].value != 'null') {
					elStyleLink.attributes['class'].value = collapsedStyle;
				}
			}
		} else {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['style'].value != 'null') {
					elStyleLeft.attributes['style'].value = collapsedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['style'].value != 'null') {
					elStyleRight.attributes['style'].value = collapsedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['style'].value != 'null') {
					elStyleLink.attributes['style'].value = collapsedStyle;
				}
			}
		}
		document.getElementById(setThis).value = 'true';
	}
}