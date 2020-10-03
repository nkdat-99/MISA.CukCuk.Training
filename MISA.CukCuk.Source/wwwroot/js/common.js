//format Money
Number.prototype.formatMoney = function() {
    return this.toString().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1.");
}

//format Date
function dateToYMD(date) {
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + y + '-' + (m <= 9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
}

//format Date
function dateToDMY(date) {
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + (d <= 9 ? '0' + d : d) + '/' + (m <= 9 ? '0' + m : m) + '/' + y;
}

function lowerCaseFirstLetter(string) { 
    return string.charAt(0).toLowerCase() + string.slice(1);
}