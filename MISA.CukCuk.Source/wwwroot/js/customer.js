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
    * Date: 30/9/2020
    * */
    //Thêm data vào DATABASE
    postData(customer, method) {
        self = this;
        $.ajax({
            url: "/api/customer",
            method: method,
            data: JSON.stringify(customer),
            contentType: "application/json",
            dataType: "json"
        }).done(function (res) {
            //Load lại dữ liệu
            self.getData();
            self.loadData();
            self.hideDialogDetail();
        }).fail(function (res) {
            console.log(res);
        });
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Xóa data
    deleteData(customerCode) {
        $.ajax({
            url: "/api/customer/" + customerCode,
            method: "DELETE"
        }).done(function (res) {
            if (res) {
                alert("Xóa thành công");
            } else {
                alert("Không có nhân viên với mã tương ứng");
            }
            //Load lại dữ liệu
            self.getData();
            self.loadData();
        }).fail(function () {
        })
    }
}
