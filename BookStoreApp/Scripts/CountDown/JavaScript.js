

var c = document.getElementById("Count").value;

var d = new Array(c);
var h = new Array(c);
var m = new Array(c);
var s = new Array(c);

var days = new Array(c);
var hours = new Array(c);
var min = new Array(c);
var sec = new Array(c);
/*var Interval = new Array(c);*/
for (i = 0; i < c; i++) {
    d[i] = document.getElementById("days_" + i);
    h[i] = document.getElementById("hours_" + i);
    m[i] = document.getElementById("minutes_" + i);
    s[i] = document.getElementById("seconds_" + i);

    days[i] = parseInt(d[i].innerHTML);
    hours[i] = parseInt(h[i].innerHTML);
    min[i] = parseInt(m[i].innerHTML);
    sec[i] = parseInt(s[i].innerHTML);
}
var Interval = setInterval(SetTime, 1000);

function SetTime() {
    for (i = 0; i < c; i++) {
        if (sec[i] == 0 && hours[i] == 0 && min[i] == 0) {
            sec[i] = 59;
            min[i] = 59;
            hours[i] = 24;
            days[i]--;
        }
        else if (sec[i] == 0 && min[i] == 0) {
            sec[i] = 59;
            min[i] = 59;
            hours[i]--;
        }
        else if (sec[i] == 0) {
            sec[i] = 59;
            min[i]--;
        }
        else {
            sec[i]--;
        }
        s[i].innerHTML = SetType(sec[i]);
        m[i].innerHTML = SetType(min[i]);
        h[i].innerHTML = SetType(hours[i]);
        d[i].innerHTML = SetType(days[i]);

    }
}


function SetType(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}






