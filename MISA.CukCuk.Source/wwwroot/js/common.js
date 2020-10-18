/**
* Author: NKĐạt
* Date: 30/9/2020
* Format Money
* */
Number.prototype.formatMoney = function () {
    return this.toString().replace(/(.)(?=(\d{3})+$)/g, '$1.');
}

/**
* Author: NKĐạt
* Date: 3/10/2020
* Format Date Year Month Day
* */
function dateToYMD(date) {
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + y + '-' + (m <= 9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
}

/**
* Author: NKĐạt
* Date: 3/10/2020
* Format Date Day Month Year
* */
function dateToDMY(date) {
    var d = date.getDate();
    var m = date.getMonth() + 1; //Month from 0 to 11
    var y = date.getFullYear();
    return '' + (d <= 9 ? '0' + d : d) + '/' + (m <= 9 ? '0' + m : m) + '/' + y;
}

/**
* Author: NKĐạt
* Date: 4/10/2020
* Lower Case First Letter
* */
function lowerCaseFirstLetter(string) {
    return string.charAt(0).toLowerCase() + string.slice(1);
}

function upperCaseFirstLetter(string) {
    return string.charAt(0).toUpperCase() + string.slice(1);
}