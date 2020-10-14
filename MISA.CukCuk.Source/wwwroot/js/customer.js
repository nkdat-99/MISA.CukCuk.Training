$(document).ready(function () {
    try {
        customerJS = new CustomerJS();
    } catch (e) {
        console.log(e);
    }
});

class CustomerJS extends BaseJS {
    constructor() {
        super('customer');
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Lấy data từ DATABASE
    getData() {
        self = this;
        $.ajax({
            url: "/api/customer", // Đường dẫn địa chỉ
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
    * @param {string} customerId
    * */
    //Lấy data chi tiết từ DATABASE
    getDataDetail(customerId) {
        var self = this;
        $.ajax({
            url: "/api/customer/" + customerId,
            method: "GET",
            async: false
        }).done(function (res) {
            self.DataDetail = res;
        }).fail(function (res) {
            console.log(res);
        })
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * @param {object} employee
    * @param {string} method
    * */
    //Thêm data vào DATABASE
    postData(customer, method) {
        self = this;
        $.ajax({
            url: "/api/customer",
            method: method,
            data: JSON.stringify(customer),
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
    * Date: 30/9/2020
    * @param {string} customerId
    * */
    //Xóa data
    deleteData(customerId) {
        var check = false;
        $.ajax({
            url: "/api/customer/" + customerId,
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
