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
    * Lấy data từ DATABASE
    * Date: 30/9/2020
    * */
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
    * Lấy data chi tiết từ DATABASE
    * @param {string} customerId
    * */
    getDataDetail(customerId) {
        var self = this;
        $.ajax({
            url: "/api/customer/" + customerId,
            contentType: "application/json",
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
    * Thêm data vào DATABASE
    * @param {object} customer
    * @param {string} method
    * */
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
    * Xóa data
    * @param {string} customerId
    * */
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

    /**
    * Author: NKĐạt
    * Date: 8/10/2020
    * Custom yêu cầu nhập dữ liệu
    * */
    validateCustom() {
        return true;
    };
}
