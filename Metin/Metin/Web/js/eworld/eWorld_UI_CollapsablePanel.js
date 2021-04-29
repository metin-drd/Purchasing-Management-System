/*************************************************************************
* Excentrics World Collapsable Panel Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.9
* Date Last Updated: January 27, 2003
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@SupportedIE
/*************************************************************************
* Upper Browser Javascript (IE)
*************************************************************************/
var CollapsablePanel_ActivePanel = null;
var CollapsablePanel_ActiveHeight = 0;
var CollapsablePanel_ActiveTotalHeight = 0;
var CollapsablePanel_ActiveLinesToDisplay = 20;
var CollapsablePanel_TimerID = 0;

function CollapsablePanel_IE_ExpandCollapse(hideThis, changeThis, setThis, exText, colText, slide, height, speed, lines, styleID, isCollapseClass, isExpandClass, collapsedStyle, expandedStyle, clientID, customFunc) {
	var el = document.getElementById(hideThis);
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	var isCollapsing = false;
	
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
		
	if(CollapsablePanel_ActivePanel != null)
		slide = false;
	
	if(el.style.display == '') {
		isCollapsing = true;
		if(!slide) {
			document.getElementById(hideThis).style.display = 'none';
		} else {
			CollapsablePanel_ActivePanel = el;
			CollapsablePanel_ActiveHeight = height;
			CollapsablePanel_ActiveLinesToDisplay = lines;
			
			CollapsablePanel_TimerID = setInterval(CollapsablePanel_IE_HideTimer, speed);
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
	} else {
		isCollapsing = false;
		if(!slide) {
			el.style.display = '';
		} else {
			CollapsablePanel_ActivePanel = el;
			CollapsablePanel_ActiveHeight = 0;
			CollapsablePanel_ActiveTotalHeight = height;
			CollapsablePanel_ActiveLinesToDisplay = lines;
			
			el.style.height = '0px';
			el.style.display = '';
			
			CollapsablePanel_TimerID = setInterval(CollapsablePanel_IE_ShowTimer, speed);
		}
		if(document.getElementById(changeThis) != null)
			document.getElementById(changeThis).innerHTML = colText;
		if(isExpandClass) {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftClassId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightClassId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkClassId, expandedStyle);
		} else {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftStyleId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightStyleId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkStyleId, expandedStyle);
		}
		document.getElementById(setThis).value = 'false';
	}
	
	if(customFunc != "")
		eval(customFunc + "('" + clientID + "', " + isCollapsing + ");");
}

function CollapsablePanel_IE_ExpandCollapseImage(hideThis, changeThis, setThis, expandUrl, collapseUrl, exText, colText, slide, height, speed, lines, styleID, isCollapseClass, isExpandClass, collapsedStyle, expandedStyle, clientID, customFunc) {
	var el = document.getElementById(hideThis);	
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	var isCollapsing = false;
	
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
	
	if(CollapsablePanel_ActivePanel != null)
		slide = false;
	
	if(document.getElementById(hideThis).style.display == '') {
		isCollapsaing = true;
		if(!slide) {
			document.getElementById(hideThis).style.display = 'none';
		} else {
			CollapsablePanel_ActivePanel = el;
			CollapsablePanel_ActiveHeight = height;
			CollapsablePanel_ActiveLinesToDisplay = lines;
			
			CollapsablePanel_TimerID = setInterval(CollapsablePanel_IE_HideTimer, speed);
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
	} else {
		isCollapsing = false;
		if(!slide) {
			el.style.display = '';
		} else {
			CollapsablePanel_ActivePanel = el;
			CollapsablePanel_ActiveHeight = 0;
			CollapsablePanel_ActiveTotalHeight = height;
			CollapsablePanel_ActiveLinesToDisplay = lines;
			
			el.style.height = '0px';
			el.style.display = '';
			
			CollapsablePanel_TimerID = setInterval(CollapsablePanel_IE_ShowTimer, speed);
		}
		if(document.getElementById(changeThis) != null) {
			document.getElementById(changeThis).src = collapseUrl;
			document.getElementById(changeThis).alt = colText;
		}
		if(isExpandClass) {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftClassId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightClassId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkClassId, expandedStyle);
		} else {
			CollapsablePanel_IE_SetStyle(elStyleLeft, leftStyleId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleRight, rightStyleId, expandedStyle);
			CollapsablePanel_IE_SetStyle(elStyleLink, linkStyleId, expandedStyle);
		}
		document.getElementById(setThis).value = 'false';
	}
	
	if(customFunc != "")
		eval(customFunc + "('" + clientID + "', " + isCollapsing + ");");
}

function CollapsablePanel_IE_DoNothing() {}

function CollapsablePanel_IE_ShowTimer() {
	if(CollapsablePanel_ActiveHeight < CollapsablePanel_ActiveTotalHeight) {
		CollapsablePanel_ActiveHeight += CollapsablePanel_ActiveLinesToDisplay;
		if(CollapsablePanel_ActiveHeight > CollapsablePanel_ActiveTotalHeight)
			CollapsablePanel_ActiveHeight = CollapsablePanel_ActiveTotalHeight;
		if(CollapsablePanel_ActivePanel != null) {
			CollapsablePanel_ActivePanel.style.height = (CollapsablePanel_ActiveHeight) + 'px';
		}		
	}
	else {
		clearInterval(CollapsablePanel_TimerID);
		CollapsablePanel_ActivePanel = null;
		CollapsablePanel_ActiveHeight = 0;
		CollapsablePanel_ActiveTotalHeight = 0;
		CollapsablePanel_TimerID = 0;
	}
}

function CollapsablePanel_IE_HideTimer() {
	CollapsablePanel_ActiveHeight -= CollapsablePanel_ActiveLinesToDisplay;
	if(CollapsablePanel_ActiveHeight > 0) {
		if(CollapsablePanel_ActivePanel != null) {
			CollapsablePanel_ActivePanel.style.height = (CollapsablePanel_ActiveHeight) + 'px';
		}
		
	}
	else {
		clearInterval(CollapsablePanel_TimerID);
		if(CollapsablePanel_ActivePanel != null) {
			CollapsablePanel_ActivePanel.style.display = 'none';
		}
		CollapsablePanel_ActivePanel = null;
		CollapsablePanel_ActiveHeight = 0;
		CollapsablePanel_ActiveTotalHeight = 0;
		CollapsablePanel_TimerID = 0;
	}
}

function CollapsablePanel_IE_FindAttributeIndex(element, attName) {
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

function CollapsablePanel_IE_SetStyle(element, attNumber, style) {
	if(element != null) {
		if(attNumber >= 0 && element.attributes[attNumber].value != 'null') {
			element.attributes[attNumber].value = style;
		}
	}
}

//@&@&@&@&@SupportedNS
/*************************************************************************
* Upper Browser Javascript (NS 6+)
*************************************************************************/
function CollapsablePanel_NS_ExpandCollapse(hideThis, changeThis, setThis, exText, colText, slide, height, speed, lines, styleID, isCollapseClass, isExpandClass, collapsedStyle, expandedStyle, clientID, customFunc) {
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	var isCollapsing = false;
	
	if(styleID.indexOf(';') > 0) {
		elStyleLeft = document.getElementById(styleID.split(';')[0]);
		elStyleRight = document.getElementById(styleID.split(';')[1]);
		if(styleID.split(';').length == 3)
			elStyleLink = document.getElementById(styleID.split(';')[2]);
	} else {
		elStyleLeft = document.getElementById(styleID);
	}
	
	if(document.getElementById(hideThis).style.display == '') {
		isCollapsing = true;
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
	} else {
		isCollapsing = false;
		document.getElementById(hideThis).style.display = '';
		if(document.getElementById(changeThis) != null)
			document.getElementById(changeThis).innerHTML = colText;
		if(isExpandClass) {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['class'].value != null) {
					elStyleLeft.attributes['class'].value = expandedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['class'].value != null) {
					elStyleRight.attributes['class'].value = expandedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['class'].value != null) {
					elStyleLink.attributes['class'].value = expandedStyle;
				}
			}
		} else {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['style'].value != null) {
					elStyleLeft.attributes['style'].value = expandedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['style'].value != null) {
					elStyleRight.attributes['style'].value = expandedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['style'].value != null) {
					elStyleLink.attributes['style'].value = expandedStyle;
				}
			}
		}
		document.getElementById(setThis).value = 'false';
	}
	
	if(customFunc != "")
		eval(customFunc + "('" + clientID + "', " + isCollapsing + ");");
}

function CollapsablePanel_NS_ExpandCollapseImage(hideThis, changeThis, setThis, expandUrl, collapseUrl, exText, colText, slide, height, speed, lines, styleID, isCollapseClass, isExpandClass, collapsedStyle, expandedStyle, clientID, customFunc) {
	var elStyleLeft = null;
	var elStyleRight = null;
	var elStyleLink = null;
	var isCollapsing = false;
	
	if(styleID.indexOf(';') > 0) {
		elStyleLeft = document.getElementById(styleID.split(';')[0]);
		elStyleRight = document.getElementById(styleID.split(';')[1]);
		if(styleID.split(';').length == 3)
			elStyleLink = document.getElementById(styleID.split(';')[2]);
	} else {
		elStyleLeft = document.getElementById(styleID);
	}
	
	if(document.getElementById(hideThis).style.display == '') {
		isCollapsing = true;
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
	} else {
		isCollapsing = false;
		document.getElementById(hideThis).style.display = '';
		if(document.getElementById(changeThis) != null) {
			document.getElementById(changeThis).src = collapseUrl;
			document.getElementById(changeThis).alt = colText;
		}
		if(isExpandClass) {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['class'].value != 'null') {
					elStyleLeft.attributes['class'].value = expandedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['class'].value != 'null') {
					elStyleRight.attributes['class'].value = expandedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['class'].value != 'null') {
					elStyleLink.attributes['class'].value = expandedStyle;
				}
			}
		} else {
			if(elStyleLeft != null) {
				if(elStyleLeft.attributes['style'].value != 'null') {
					elStyleLeft.attributes['style'].value = expandedStyle;
				}
			}
			if(elStyleRight != null) {
				if(elStyleRight.attributes['style'].value != 'null') {
					elStyleRight.attributes['style'].value = expandedStyle;
				}
			}
			if(elStyleLink != null) {
				if(elStyleLink.attributes['style'].value != 'null') {
					elStyleLink.attributes['style'].value = expandedStyle;
				}
			}
		}
		document.getElementById(setThis).value = 'false';
	}
	
	if(customFunc != "")
		eval(customFunc + "('" + clientID + "', " + isCollapsing + ");");
}

function CollapsablePanel_NS_DoNothing() {}