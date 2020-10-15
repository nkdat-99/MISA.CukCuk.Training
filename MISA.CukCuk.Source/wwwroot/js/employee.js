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
    * Date: 6/10/2020
    * */
    //Lấy data từ DATABASE
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
    * Date: 6/10/2020
    * @param {string} employeeId
    * */
    //Lấy data chi tiết từ DATABASE
    getDataDetail(employeeId) {
        var self = this;
        $.ajax({
            url: "/api/employee/" + employeeId,
            method: "GET",
            async: false
        }).done(function (res) {
            self.DataDetail = res;
        }).fail(function (res) {
            console.log(res);
        })
    }

    getId() {
        var Id = $("#tblListData tr.row-selected[employeeId]");
        return Id;
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * @param {object} employee
    * @param {string} method
    * */
    //Thêm data vào DATABASE
    postData(employee, method, id) {
        self = this;
        var url = "/api/employee";
        if (method == "PUT") {
            url += '/' + id;
        }
        $.ajax({
            url: url,
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
        });
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * @param {string} employeeId
    * */
    //Xóa data
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

    validateCustom() {
        return true;
    };
}
