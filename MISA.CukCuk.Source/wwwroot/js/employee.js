﻿$(document).ready(function () {
    try {
        employeeJS = new EmployeeJS();
    } catch (e) {
        console.log(e);
    }
});

class EmployeeJS extends BaseJS {
    constructor() {
        super('employee');

    }

    /**
    * Author: NKĐạt
    * Date: 4/10/2020
    * Lấy data từ DATABASE
    * */
    getData() {
        self = this;
        $.ajax({
            url: "/api/employee", // Đường dẫn địa chỉ
            method: "GET", // Phương thức
            data: "", // Tham số sẽ truyền qua body request
            contentType: "application/json", // Kiểu dữ liệu trả về
            dataType: "", // Kiểu dữ liệu của tham số
            async: false
        }).done(function (response) {
            self.Data = response;
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 17/10/2020
    * Lấy data bản ghi cuối cùng từ DATABASE
    * */
    getNewCode(check) {
        self = this;
        $.ajax({
            url: "/api/employee/newemployeecode",
            method: "GET",
            contentType: "application/json",
            async: check
        }).done(function (response) {
            $('#txtEmployeeCode').val(response);
            self.newCode = response;
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 5/10/2020
    * Lấy data chi tiết từ DATABASE
    * @param {string} employeeId
    * */
    getDataDetail(employeeId) {
        var self = this;
        $.ajax({
            url: "/api/employee/" + employeeId,
            method: "GET",
            contentType: "application/json",
            async: false
        }).done(function (res) {
            self.DataDetail = res;
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Thêm data vào DATABASE
    * @param {object} employee
    * @param {string} method
    * */
    postData(employee, method) {
        self = this;
        $.ajax({
            url: "/api/employee",
            method: method,
            data: JSON.stringify(employee),
            contentType: "application/json",
        }).done(function (res) {
            //Load lại dữ liệu
            self.getData();
            self.loadData();
            self.hideDialogDetail();
            self.showDialogAnnounce(method);
        }).fail(function (res) {
            if (res.responseJSON.msg != "Sai email" && res.responseJSON.msg != "Mã bị trùng") {
                self.checkValidate = res.responseJSON.msg;
                self.showDialogWarning('validate');
            }
            if (res.responseJSON.msg == "Sai email") {
                self.showDialogWarning('checkEmail');
            }
            if (res.responseJSON.msg == "Mã bị trùng") {
                self.checkByCode = res.responseJSON.data.employeeCode;
                self.checkByName = res.responseJSON.data.employeeName;
                self.showDialogWarning('checkCode');
            }
        });
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Xóa data
    * @param {string} employeeCode
    * */
    deleteData(employeeCode) {
        var check = false;
        $.ajax({
            url: "/api/employee/" + employeeCode,
            method: "DELETE",
            async: false
        }).done(function (res) {
            if (res) {
                check = true;
            }
            //Load lại dữ liệu
            self.getData();
            self.loadData();
            self.checkDialogConfirm(check);
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 8/10/2020
    * Custom yêu cầu nhập dữ liệu
    * */
    validateCustom() {
        return true;
    };
}
