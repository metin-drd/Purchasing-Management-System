/*************************************************************************
* Excentrics World Time Picker Javascript Code
*
* Code should not be used or extracted in any other form.  Any
* changes to the javascript code is NOT supported by Excentrics World.
*
* Version: 1.3
* Date Last Updated: January 27, 2004
* URL: http://www.eworldui.net
*
*************************************************************************/

//@&@&@&@&@Supported
/*************************************************************************
* Upper Browser Javascript (IE, NN6 +)
*************************************************************************/
var TimePicker_curPicker = '';
var TimePicker_curPickerID = '';

if (navigator.appName == 'Netscape') { document.captureEvents(Event.CLICK); }

function TimePicker_Up_LostFocus(e) { 
	TimePicker_Up_HideNonCurrentPicker('', ''); 
}

/////////////////////////////////////////////////////////////////////////
// input : time -- string value to validate
function validateTime(time, mask, nullable)
{
	// Boþsa null
	if ((time == null || time == "") && nullable)
		return true;
		
	// delcare the variables
	var hours = -1;
	var mins  = -1;

	// Run the regular expression
	time_tokens = time.match(mask);

	// If the match was successful, time_tokens will not be null,
	// and the first element will be an exact match of the value
	if( time_tokens && time_tokens[0] == time)
	{
		// The values will be in the time_tokens object
		hours = time_tokens[1];
		mins  = time_tokens[2];

		// Check to make sure the hours value is not
		//greater than 23
		if(hours >= 24)
		hours = -1;
	}

	// See if we have good values.  If they are good, then you
	//are successful
	return (hours >= 0  &&  mins >= 0)
}

function TimePicker_CheckTime(box, mask, nullable, dvalue) {
	var val = box.value;
	if (!validateTime(val, mask, nullable)) {
		box.value = dvalue;
	}
}

function TimePicker_Up_HideNonCurrentPicker(divName) {
	if(TimePicker_curPicker != '') {
		document.getElementById(TimePicker_curPicker).style.visibility = 'hidden';
		document.getElementById(TimePicker_curPicker).innerHTML = '';
		if(eval(TimePicker_curPickerID) == true)
			TimePicker_Up_ShowHideDDL('visible');
	}
	if(divName != '')
		TimePicker_curPicker = divName;
}

function TimePicker_Up_ShowHideDDL(visibility) {
	for(j=0;j<document.forms.length;j++) {
		for(i=0;i<document.forms[j].elements.length;i++) {
			if(document.forms[j].elements[i].type != null) {
				if(document.forms[j].elements[i].type.indexOf('select') == 0)
					document.forms[j].elements[i].style.visibility = visibility;
			}
		}
	}
}

function TimePicker_Up_findPosX(obj)
{
	var curleft = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curleft += obj.offsetLeft;
			obj = obj.offsetParent;
		}
	}
	else if (obj.x)
		curleft += obj.x;
	return curleft;
}

function TimePicker_Up_findPosY(obj)
{
	var curtop = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curtop += obj.offsetTop;
			obj = obj.offsetParent;
		}
	}
	else if (obj.y)
		curtop += obj.y;
	return curtop;
}

function TimePicker_Up_DisplayPicker(tpIdFlag, tbName, lblName, lblTemp, divName, stStyle, tStyle, ctStyle, formatNum, amDescriptor, pmDescriptor, interval, enableHide, lBound, uBound, btnName, locQuad, offsetX, offsetY, showClear, clearText, colNum, dispUnselTimes, postbackFunc, round, nullText, customFunc) {
	var div, tb;
	TimePicker_curPickerID = tpIdFlag;
	div = document.getElementById(divName);
	tb = document.getElementById(tbName);
	if(div.style.visibility != 'hidden') {
		div.style.visibility = 'hidden';
		if(enableHide)
			TimePicker_Up_ShowHideDDL('visible');
	} else {
		TimePicker_Up_HideNonCurrentPicker(divName)
		if(enableHide)
			TimePicker_Up_ShowHideDDL('hidden');
		div.style.position = 'absolute';
		var obj;
		if(lblTemp != '')
			obj = document.getElementById(lblTemp);
		else if(lblName != '')
			obj = document.getElementById(lblName);
		else
			obj = tb;
		var y = TimePicker_Up_findPosY(obj);
		var x = TimePicker_Up_findPosX(obj);
		switch(locQuad) {
			case 1:
				y += (obj.offsetHeight + 1);
				break;
			case 2:
				x -= (div.offsetWidth - 2);
				break;
			case 3:
				x += (obj.offsetWidth + 1);
				break;
			case 4:
				y -= (div.offsetHeight - 1);
				break;
			default:
				y = TimePicker_Up_findPosY(document.getElementById(btnName));
				x = TimePicker_Up_findPosX(document.getElementById(btnName)) - 3;
				break;
		}
		div.style.top = y + offsetY + 'px';
		div.style.left = x + offsetX + 'px';
		div.style.border = 'black 1px solid';
		div.innerHTML = TimePicker_Up_ShowPicker(tbName, lblName, divName, stStyle, tStyle, ctStyle, formatNum, amDescriptor, pmDescriptor, interval, enableHide, lBound, uBound, btnName, showClear, clearText, colNum, dispUnselTimes, postbackFunc, round, nullText, customFunc);
		div.style.visibility = 'visible';
	}
}

function TimePicker_Up_ShowPicker(tbName, lblName, divName, stStyle, tStyle, ctStyle, formatNum, amDescriptor, pmDescriptor, interval, enableHide, lBound, uBound, btnName, showClear, clearText, colNum, dispUnselTimes, postbackFunc, round, nullText, customFunc) {
	var out = '<table border=0 cellspacing=0px cellpadding=2px>';
	var i = 1;
	var cont = true;
	var theTime = new Date();
	theTime.setHours(0, 0);
	var enteredTime = TimePicker_Up_SplitTime(tbName, document.getElementById(tbName).value, formatNum, amDescriptor, pmDescriptor, interval, round);
	var lowerTime = TimePicker_Up_SplitTime('', lBound, formatNum, amDescriptor, pmDescriptor, interval, false);
	var upperTime = TimePicker_Up_SplitTime('', uBound, formatNum, amDescriptor, pmDescriptor, interval, false);
	while(cont) {
		var doIncrement = true;
		var tempOut = '';
		var selTime = TimePicker_Up_GetTime(theTime, formatNum, amDescriptor, pmDescriptor);
		if(theTime.getHours() >= lowerTime.getHours() && theTime.getHours() <= upperTime.getHours()) {
			if(theTime.getHours() != lowerTime.getHours() && theTime.getHours() != upperTime.getHours()) {
				if(enteredTime != null && theTime.getHours() == enteredTime.getHours() && theTime.getMinutes() == enteredTime.getMinutes())
					tempOut += '<td align=\"center\" ' + stStyle + '><a href=\"javascript:TimePicker_Up_SelectTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', \'' + selTime + '\', ' + enableHide + ',\'' + postbackFunc + '\',\'' + customFunc + '\')\" ' + stStyle + '>' + selTime + '</a></td>';
				else
					tempOut += '<td align=\"center\" ' + tStyle + '><a href=\"javascript:TimePicker_Up_SelectTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', \'' + selTime + '\', ' + enableHide + ',\'' + postbackFunc + '\',\'' + customFunc + '\')\" ' + tStyle + '>' + selTime + '</a></td>';
			} else {
				if(theTime.getHours() == lowerTime.getHours() && theTime.getMinutes() >= lowerTime.getMinutes()) {
					if(enteredTime != null && theTime.getHours() == enteredTime.getHours() && theTime.getMinutes() == enteredTime.getMinutes())
						tempOut += '<td align=\"center\" ' + stStyle + '><a href=\"javascript:TimePicker_Up_SelectTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', \'' + selTime + '\', ' + enableHide + ',\'' + postbackFunc + '\',\'' + customFunc + '\')\" ' + stStyle + '>' + selTime + '</a></td>';
					else
						tempOut += '<td align=\"center\" ' + tStyle + '><a href=\"javascript:TimePicker_Up_SelectTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', \'' + selTime + '\', ' + enableHide + ',\'' + postbackFunc + '\',\'' + customFunc + '\')\" ' + tStyle + '>' + selTime + '</a></td>';
				} else {
					if(theTime.getHours() == upperTime.getHours() && theTime.getMinutes() <= upperTime.getMinutes()) {
						if(enteredTime != null && theTime.getHours() == enteredTime.getHours() && theTime.getMinutes() == enteredTime.getMinutes())
							tempOut += '<td align=\"center\" ' + stStyle + '><a href=\"javascript:TimePicker_Up_SelectTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', \'' + selTime + '\', ' + enableHide + ',\'' + postbackFunc + '\',\'' + customFunc + '\')\" ' + stStyle + '>' + selTime + '</a></td>';
						else
							tempOut += '<td align=\"center\" ' + tStyle + '><a href=\"javascript:TimePicker_Up_SelectTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', \'' + selTime + '\', ' + enableHide + ',\'' + postbackFunc + '\',\'' + customFunc + '\')\" ' + tStyle + '>' + selTime + '</a></td>';
					} else {
						if(dispUnselTimes)
							tempOut += '<td align=\"center\" ' + tStyle + '>' + selTime + '</td>';
						else
							doIncrement = false;
					}
				}
			} 
		} else {
			if(dispUnselTimes)
				tempOut += '<td align=\"center\" ' + tStyle + '>' + selTime + '</td>';
			else
				doIncrement = false;
		}
		
		if(i==1 && doIncrement)
			out += '<tr>';
		
		if(tempOut != '')
			out += tempOut;
			
		if(i==colNum) {
			out += '</tr>';
			i = 0;
		}
		
		if(doIncrement)
			i++;
	
		var dateInMs = theTime.getTime();
		dateInMs += interval * 60 * 1000;
		theTime.setTime(dateInMs);
		if(theTime.getHours() == 0 && theTime.getMinutes() == 0)
			cont = false;
	}
	if(i>1 && i<=colNum) {
		while(i<=colNum) {
			out += '<td ' + tStyle + '></td>';
			if(i==colNum)
				out += '</tr>';
			i++;
		}
	}
	if(showClear)
		out += '<tr><td colspan=\"' + colNum + '\" align=\"center\" ' + ctStyle + '><a href=\"javascript:TimePicker_Up_ClearTime(\'' + tbName + '\', \'' + lblName + '\', \'' + divName + '\', ' + enableHide + ',\'' + postbackFunc + '\', \'' + nullText + '\',\'' + customFunc + '\')\" ' + ctStyle + '>' + clearText + '</td></tr>';
	out += '</table>';
	return out;
}

function TimePicker_Up_SplitTime(tbName, inTime, formatNum, amDescriptor, pmDescriptor, interval, round) {
	var curSelTime = inTime;
	var theTime = new Date();
	var h, m;
	if(curSelTime == '')
		return null;
	else {
		switch(formatNum) {
			case 1:
			case 6:
				h = curSelTime.substr(0, curSelTime.indexOf(':'));
				m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
				if(curSelTime.indexOf(pmDescriptor) > -1) {
					if(parseInt(h) != 12)
						h = parseInt(h) + 12;
				} else {
					if(parseInt(h) == 12)
						h = 0;
				}
				break;
			case 2:
			case 3:
				h = curSelTime.substr(0, curSelTime.indexOf(':'));
				m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
				break;
			case 4:
			case 5:
				var startIndex;
				if(curSelTime.indexOf(amDescriptor) > -1)
					startIndex = amDescriptor.length;
				else
					startIndex = pmDescriptor.length;
				h = curSelTime.substr(startIndex, curSelTime.indexOf(':'))
				m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
				break;
			case 7:
				h = curSelTime.substr(0, curSelTime.indexOf('.'));
				m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
				if(curSelTime.indexOf(pmDescriptor) > -1) {
					if(parseInt(h) != 12)
						h = parseInt(h) + 12;
				} else {
					if(parseInt(h) == 12)
						h = 0;
				}
				break;
			case 8:
				h = curSelTime.substr(0, curSelTime.indexOf(':'));
				m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
				break;
			case 9:
				break;
		}
		if(!isNaN(parseInt(m)))
		{
			if(round) {
				while((m % interval) != 0)
					m++;
			}
			
			theTime.setHours(h);
			theTime.setMinutes(m);
			if(tbName != '')
				document.getElementById(tbName).value = TimePicker_Up_GetTime(theTime, formatNum, amDescriptor, pmDescriptor);
		}
		return theTime;
	}
}

function TimePicker_Up_GetTime(theTime, formatNum, amDescriptor, pmDescriptor) {
	var outDate = '';
	var h, m;
	h = theTime.getHours();
	m = theTime.getMinutes();
	switch(formatNum) {
		case 1:
			outDate = TimePicker_Up_GetNonMilitary(h, true, true) + ':' + TimePicker_Up_GetNonMilitary(m, false, true);
			if(h < 12)
				outDate += ' ' + amDescriptor;
			else
				outDate += ' ' + pmDescriptor;
			break;
		case 2:
			outDate = TimePicker_Up_GetMilitary(h, false) + ':' + TimePicker_Up_GetNonMilitary(m, false, true);
			break;
		case 3:
			outDate = TimePicker_Up_GetMilitary(h, true) + ':' + TimePicker_Up_GetNonMilitary(m, false, true);
			break;
		case 4:
			if(h < 12)
				outDate = amDescriptor;
			else
				outDate = pmDescriptor;
			outDate += ' ' + TimePicker_Up_GetNonMilitary(h, true, true) + ':' + TimePicker_Up_GetNonMilitary(m, false, true);
			break;
		case 5:
			if(h < 12)
				outDate = amDescriptor;
			else
				outDate = pmDescriptor;
			outDate += ' ' + TimePicker_Up_GetNonMilitary(h, true, false) + ':' + TimePicker_Up_GetNonMilitary(m, false, true);
			break;
		case 6:
			outDate = TimePicker_Up_GetNonMilitary(h, true, false) + ':' + TimePicker_Up_GetNonMilitary(m, false, true);
			if(h < 12)
				outDate += ' ' + amDescriptor;
			else
				outDate += ' ' + pmDescriptor;
			break;
		case 7:
			outDate = TimePicker_Up_GetMilitary(h, false) + '.' + TimePicker_Up_GetNonMilitary(m, false, true);
			break;
		case 8:
			outDate = TimePicker_Up_GetNonMilitary(h, true, false) + '.' + TimePicker_Up_GetNonMilitary(m, false, true);
			if(h < 12)
				outDate += '.' + amDescriptor;
			else
				outDate += '.' + pmDescriptor;
			break;
		case 9:
			outDate = TimePicker_Up_GetMilitary(h, true) + '.' + TimePicker_Up_GetNonMilitary(m, false, true);
			break;
	}
	return outDate;
}

function TimePicker_Up_GetNonMilitary(inVal, isHour, pad) {
	var out = '';
	if(isHour) {
		if(inVal > 11)
			inVal -= 12;
		if(inVal < 10 && inVal > 0 && pad)
			out += '0';
		if(inVal == 0)
			out += '12';
		else
			out += inVal;
	} else {
		if(inVal < 10 && pad)
			out += '0';
		out += inVal;
	}
	return out;
}

function TimePicker_Up_GetMilitary(inVal, pad) {
	var out = '';
	if(inVal < 10 && pad)
		out += '0';
	out += inVal;
	return out;
}

function TimePicker_Up_SelectTime(tbName, lblName, divName, selTime, enableHide, postbackFunc, customFunc) {
	document.getElementById(tbName).value = selTime;
	if(lblName != '')
		document.getElementById(lblName).innerHTML = selTime;
	document.getElementById(divName).style.visibility = 'hidden';
	if(enableHide)
		TimePicker_Up_ShowHideDDL('visible');
	if(customFunc != "")
		eval(customFunc + "('" + selTime + "', '" + tbName + "');");
	eval(postbackFunc + "();");
}

function TimePicker_Up_ClearTime(tbName, lblName, divName, enableHide, postbackFunc, nullText, customFunc) {
	document.getElementById(tbName).value = '';
	if(lblName != '')
		document.getElementById(lblName).innerHTML = nullText;
	document.getElementById(divName).style.visibility = 'hidden';
	if(enableHide)
		TimePicker_Up_ShowHideDDL('visible');
	if(customFunc != "")
		eval(customFunc + "('', '" + tbName + "');");
	eval(postbackFunc + "();");
}

//@&@&@&@&@Unsupported
/*************************************************************************
* Downlevel Browser Javascript (NS4)
*************************************************************************/
function TimePicker_Dn_DisplayPicker(tbName, stStyle, tStyle, ctStyle, formatNum, amDescriptor, pmDescriptor, interval, lBound, uBound, ssLocation, width, height, showClear, clearText, colNum, dispUnselTimes, postbackFunc, round, customFunc) {
	var out = "";
    var ss = "";
    if(ssLocation != "")
		ss = '<link rel=\"stylesheet\" href=\"' + ssLocation + '\">';
    out = "<html><head>" + ss + "</head><body>" + TimePicker_Dn_ShowPicker(tbName, stStyle, tStyle, ctStyle, formatNum, amDescriptor, pmDescriptor, interval, lBound, uBound, showClear, clearText, colNum, dispUnselTimes, postbackFunc, round, customFunc); + "<br></body></html>";
    var tpWin = window.open("", "timeWindow", "scrollbars=yes,resizeable=yes,height=" + height + ",width=" + width);
	tpWin.focus();
    tpWin.document.write(out);
    tpWin.document.close();
    return false;
}

function TimePicker_Dn_ShowPicker(tbName, stStyle, tStyle, ctStyle, formatNum, amDescriptor, pmDescriptor, interval, lBound, uBound, showClear, clearText, colNum, dispUnselTimes, postbackFunc, round, customFunc) {
        var out = '<table style=\"border: black 1px solid;\" border=0 cellspacing=0px cellpadding=2px>';
        var i = 1;
        var cont = true;
        var theTime = new Date();
        theTime.setHours(0, 0);
        var enteredTime = TimePicker_Dn_SplitTime(tbName, document.forms[0][tbName].value, formatNum, amDescriptor, pmDescriptor, interval, round);
        var lowerTime = TimePicker_Dn_SplitTime('', lBound, formatNum, amDescriptor, pmDescriptor, interval, false);
        var upperTime = TimePicker_Dn_SplitTime('', uBound, formatNum, amDescriptor, pmDescriptor, interval, false);
        while(cont) {
                var doIncrement = true;
                var tempOut = '';
                var selTime = TimePicker_Dn_GetTime(theTime, formatNum, amDescriptor, pmDescriptor);
                if(theTime.getHours() >= lowerTime.getHours() && theTime.getHours() <= upperTime.getHours()) {
                        if(theTime.getHours() != lowerTime.getHours() && theTime.getHours() != upperTime.getHours()) {
                                if(enteredTime != null && theTime.getHours() == enteredTime.getHours() && theTime.getMinutes() == enteredTime.getMinutes())
                                        tempOut += '<td align=\"center\" ' + stStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_SelectTime(\'' + tbName + '\', \'' + selTime + '\',\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + stStyle + '>' + selTime + '</a></td>';
                                else
                                        tempOut += '<td align=\"center\" ' + tStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_SelectTime(\'' + tbName + '\', \'' + selTime + '\',\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + tStyle + '>' + selTime + '</a></td>';
                        } else {
                                if(theTime.getHours() == lowerTime.getHours() && theTime.getMinutes() >= lowerTime.getMinutes()) {
                                        if(enteredTime != null && theTime.getHours() == enteredTime.getHours() && theTime.getMinutes() == enteredTime.getMinutes())
                                                tempOut += '<td align=\"center\" ' + stStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_SelectTime(\'' + tbName + '\', \'' + selTime + '\',,\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + stStyle + '>' + selTime + '</a></td>';
                                        else
                                                tempOut += '<td align=\"center\" ' + tStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_SelectTime(\'' + tbName + '\', \'' + selTime + '\',\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + tStyle + '>' + selTime + '</a></td>';
                                } else {
                                        if(theTime.getHours() == upperTime.getHours() && theTime.getMinutes() <= upperTime.getMinutes()) {
                                                if(enteredTime != null && theTime.getHours() == enteredTime.getHours() && theTime.getMinutes() == enteredTime.getMinutes())
                                                        tempOut += '<td align=\"center\" ' + stStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_SelectTime(\'' + tbName + '\', \'' + selTime + '\',\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + stStyle + '>' + selTime + '</a></td>';
                                                else
                                                        tempOut += '<td align=\"center\" ' + tStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_SelectTime(\'' + tbName + '\', \'' + selTime + '\',\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + tStyle + '>' + selTime + '</a></td>';
                                        } else {
                                                if(dispUnselTimes)
                                                        tempOut += '<td align=\"center\" ' + tStyle + '>' + selTime + '</td>';
                                                else
                                                        doIncrement = false;
                                        }
                                }
                        } 
                } else {
                        if(dispUnselTimes)
                                tempOut += '<td align=\"center\" ' + tStyle + '>' + selTime + '</td>';
                        else
                                doIncrement = false;
                }
                
                if(i==1 && doIncrement)
                        out += '<tr>';
                
                if(tempOut != '')
                        out += tempOut;
                        
                if(i==colNum) {
                        out += '</tr>';
                        i = 0;
                }
                
                if(doIncrement)
                        i++;
        
                var dateInMs = theTime.getTime();
                dateInMs += interval * 60 * 1000;
                theTime.setTime(dateInMs);
                if(theTime.getHours() == 0 && theTime.getMinutes() == 0)
                        cont = false;
        }
        if(i>1 && i<=colNum) {
                while(i<=colNum) {
                        out += '<td ' + tStyle + '></td>';
                        if(i==colNum)
                                out += '</tr>';
                        i++;
                }
        }
        if(showClear)
                out += '<tr><td colspan=\"' + colNum + '\" align=\"center\" ' + ctStyle + '><a href=\"javascript:window.opener.TimePicker_Dn_ClearTime(\'' + tbName + '\',\'' + postbackFunc + '\',\'' + customFunc + '\');window.close();\" ' + ctStyle + '>' + clearText + '</td></tr>';
        out += '</table>';
        return out;
}

function TimePicker_Dn_SplitTime(tbName, inTime, formatNum, amDescriptor, pmDescriptor, interval, round) {
        var curSelTime = inTime;
        var theTime = new Date();
        var h, m;
        if(curSelTime == '')
                return null;
        else {
                switch(formatNum) {
                        case 1:
                        case 6:
                                h = curSelTime.substr(0, curSelTime.indexOf(':'));
                                m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
                                if(curSelTime.indexOf(pmDescriptor) > -1) {
                                        if(parseInt(h) != 12)
                                                h = parseInt(h) + 12;
                                } else {
                                        if(parseInt(h) == 12)
                                                h = 0;
                                }
                                break;
                        case 2:
                        case 3:
                                h = curSelTime.substr(0, curSelTime.indexOf(':'));
                                m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
                                break;
                        case 4:
                        case 5:
                                var startIndex;
                                if(curSelTime.indexOf(amDescriptor) > -1)
                                        startIndex = amDescriptor.length;
                                else
                                        startIndex = pmDescriptor.length;
                                h = curSelTime.substr(startIndex, curSelTime.indexOf(':'))
                                m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
                                break;
                        case 7:
                                h = curSelTime.substr(0, curSelTime.indexOf('.'));
                                m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
                                if(curSelTime.indexOf(pmDescriptor) > -1) {
                                        if(parseInt(h) != 12)
                                                h = parseInt(h) + 12;
                                } else {
                                        if(parseInt(h) == 12)
                                                h = 0;
                                }
                                break;
                        case 8:
                                h = curSelTime.substr(0, curSelTime.indexOf(':'));
                                m = curSelTime.substr((curSelTime.indexOf(':') + 1), 2);
                                break;
                        case 9:
                                break;
                }
                
                if(!isNaN(parseInt(m)))
				{
					if(round) {
							while((m % interval) != 0)
									m++;
					}
	                        
					theTime.setHours(h);
					theTime.setMinutes(m);
					if(tbName != '')
							document.forms[0][tbName].value = TimePicker_Dn_GetTime(theTime, formatNum, amDescriptor, pmDescriptor);
				}
                
                return theTime;
        }
}

function TimePicker_Dn_GetTime(theTime, formatNum, amDescriptor, pmDescriptor) {
        var outDate = '';
        var h, m;
        h = theTime.getHours();
        m = theTime.getMinutes();
        switch(formatNum) {
                case 1:
                        outDate = TimePicker_Dn_GetNonMilitary(h, true, true) + ':' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        if(h < 12)
                                outDate += ' ' + amDescriptor;
                        else
                                outDate += ' ' + pmDescriptor;
                        break;
                case 2:
                        outDate = TimePicker_Dn_GetMilitary(h, false) + ':' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        break;
                case 3:
                        outDate = TimePicker_Dn_GetMilitary(h, true) + ':' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        break;
                case 4:
                        if(h < 12)
                                outDate = amDescriptor;
                        else
                                outDate = pmDescriptor;
                        outDate += ' ' + TimePicker_Dn_GetNonMilitary(h, true, true) + ':' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        break;
                case 5:
                        if(h < 12)
                                outDate = amDescriptor;
                        else
                                outDate = pmDescriptor;
                        outDate += ' ' + TimePicker_Dn_GetNonMilitary(h, true, false) + ':' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        break;
                case 6:
                        outDate = TimePicker_Dn_GetNonMilitary(h, true, false) + ':' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        if(h < 12)
                                outDate += ' ' + amDescriptor;
                        else
                                outDate += ' ' + pmDescriptor;
                        break;
                case 7:
                        outDate = TimePicker_Dn_GetMilitary(h, false) + '.' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        break;
                case 8:
                        outDate = TimePicker_Dn_GetNonMilitary(h, true, false) + '.' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        if(h < 12)
                                outDate += '.' + amDescriptor;
                        else
                                outDate += '.' + pmDescriptor;
                        break;
                case 9:
                        outDate = TimePicker_Dn_GetMilitary(h, true) + '.' + TimePicker_Dn_GetNonMilitary(m, false, true);
                        break;
        }
        return outDate;
}

function TimePicker_Dn_GetNonMilitary(inVal, isHour, pad) {
        var out = '';
        if(isHour) {
                if(inVal > 11)
                        inVal -= 12;
                if(inVal < 10 && inVal > 0 && pad)
                        out += '0';
                if(inVal == 0)
                        out += '12';
                else
                        out += inVal;
        } else {
                if(inVal < 10 && pad)
                        out += '0';
                out += inVal;
        }
        return out;
}

function TimePicker_Dn_GetMilitary(inVal, pad) {
        var out = '';
        if(inVal < 10 && pad)
                out += '0';
        out += inVal;
        return out;
}

function TimePicker_Dn_SelectTime(tbName, selTime, postbackFunc, customFunc) {
    document.forms[0][tbName].value = selTime;
    if(customFunc != "")
		eval(customFunc + "('" + selTime + "', '" + tbName + "');");
    eval(postbackFunc + "();");
}

function TimePicker_Dn_ClearTime(tbName, postbackFunc, customFunc) {
    document.forms[0][tbName].value = '';
    if(customFunc != "")
		eval(customFunc + "('', '" + tbName + "');");
    eval(postbackFunc + "();");
}