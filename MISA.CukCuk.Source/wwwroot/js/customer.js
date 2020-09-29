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

    getData() {
        self = this;
        $.ajax({
            url: "/api/customer", // Đường dẫn địa chỉ
            method: "GET", // Phương thức
            data: "", // Tham số sẽ truyền qua body request
            contentType: "application/json", // Kiểu dữ liệu trả về
            dataType: "", // Kiểu dữ liệu của tham số
            async: false
            //success: function () {

            //},
            //done: function () {

            //}
        }).done(function (response) {
            self.Data = response;
        }).fail(function (res) {
            console.log(res);
        })
    }

    makeTrHTML(item) {
        var checkDate = "";
        if (dateToDMY(new Date(item.customerBirthday)) != "01/01/1700") //giá trị mặc định 
            checkDate = dateToDMY(new Date(item.customerBirthday));
        var trHTML = $(`<tr>
                    <td>` + item.customerCode + `</td>
                    <td>` + item.customerName + `</td>
                    <td style="text-align: center;">` + checkDate + `</td>
                    <td>` + item.customerCompany + `</td>
                    <td>` + item.customerTax + `</td>
                    <td style="text-align: right;">` + item.customerMoney.formatMoney() + `</td>
                    <td>` + item.customerAddress + `</td>
                    <td>` + item.customerMobile + `</td>
                    <td>` + item.customerEmail + `</td>
                </tr>`);
        return trHTML;
    }
}
