/*************************************************************************
* Excentrics World FAQ Repeater Javascript Code
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
* Upper Browser Javascript (IE, NN6 +)
*************************************************************************/
function FaqRepeater_ExpandCollapse(hideThis) {
	var tr = document.getElementById(hideThis);
	if(tr != null) {
		if(tr.style.display == '')
			tr.style.display = 'none';
		else
			tr.style.display = '';
	}
}

function FaqRepeater_ExpandAll(cbId, rows) {
	if(rows != '') {
		var rowArr = rows.split(',');
		var disp = '';
		if(document.getElementById(cbId) != null) {
			if(!document.getElementById(cbId).checked)
				disp = 'none';
		} else
			disp = 'none';
		for(var i=0;i<rowArr.length;i++)
			document.getElementById(rowArr[i]).style.display = disp;
	}
}