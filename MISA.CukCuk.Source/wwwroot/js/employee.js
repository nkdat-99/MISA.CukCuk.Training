$(document).ready(function () {
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
    getNewEmployeeCode() {
        self = this;
        $.ajax({
            url: "/api/employee/newemployeecode",
            method: "POST",
            contentType: "application/json",
            async: true
        }).done(function (response) {
            $('#txtEmployeeCode').val(response);
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
            console.log(res);
            //console.log(res.responseJSON.msg[0]);
            //console.log(res.responseJSON);
        });
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Xóa data
    * @param {string} employeeId
    * */
    deleteData(employeeId) {
        var check = false;
        $.ajax({
            url: "/api/employee/" + employeeId,
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
