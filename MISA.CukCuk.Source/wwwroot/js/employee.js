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
    * Date: 20/10/2020
    * Lấy data từ DATABASE
    * */
    getDataCount() {
        self = this;
        $.ajax({
            url: "/api/employee/count", // Đường dẫn địa chỉ
            method: "GET", // Phương thức
            data: "", // Tham số sẽ truyền qua body request
            contentType: "application/json", // Kiểu dữ liệu trả về
            dataType: "", // Kiểu dữ liệu của tham số
            async: false
        }).done(function (response) {
            self.DataCount = response;
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 4/10/2020
    * Lấy data từ DATABASE theo paging
    * */
    getDataPaging(page, size) {
        self = this;
        $.ajax({
            url: "/api/employee/paging?page=" + page + "&size=" + size,
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: "",
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
    * Date: 5/10/2020
    * Lấy data bảng Position từ DATABASE
    * */
    getPosition() {
        $.ajax({
            url: "/api/position",
            method: "GET",
            contentType: "application/json",
        }).done(function (res) {
            $.each(res, function (index, data) {
                var option = "<option value=" + data.positionId + ">" + data.positionName + "</option>"
                $("#txtPositionId").append(option);
            })
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 5/10/2020
    * Lấy data bảng Department từ DATABASE
    * */
    getDepartment() {
        $.ajax({
            url: "/api/department",
            method: "GET",
            contentType: "application/json",
        }).done(function (res) {
            $.each(res, function (index, data) {
                var option = "<option value=" + data.departmentId + ">" + data.departmentName + "</option>"
                $("#txtDepartmentId").append(option);
            })
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
            self.getDataCount();
            self.getDataPaging(self.offset, self.pageSize);
            self.loadData();
            self.closeDialogOnClick();
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
        var self = this;
        var check = false;
        $.ajax({
            url: "/api/employee/" + employeeCode,
            method: "DELETE",
            async: false
        }).done(function (res) {
            if (res) {
                check = true;
            }
            self.getDataCount();
            self.getDataPaging(self.offset, self.pageSize);
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
