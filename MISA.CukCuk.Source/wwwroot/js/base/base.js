$(document).ready(function () {
    var baseJS = new BaseJS();

    //#region "ABC"
    //$(window).resize(function () {
    //    //debugger
    //    if ($(window).width() > 800) {
    //        var x = document.getElementById("menu-id")
    //        x.className === "menu"
    //    }
    //});
    //$('body').on('click', function (e) {
    //    $('#slideMenu').click()
    //});
    //#endregion "ABC"
})

class BaseJS {
    constructor() {
        try {
            this.getData();
            this.loadData();
            this.initEvents();
            this.FormMode = null;
        } catch (e) {
            console.log("error")
        }  
    }

    initEvents() {
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#btnClose').click(this.btnCloseOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('input[required]').blur(this.checkRequired);
        $('#btnHelpDialog').focus(this.returnFocus);
        $("table tbody").on("click", "tr", this.rowOnSelect);
        $('#slideMenu').click(this.slideOnClick.bind(this));
    }

    getData() {
        this.Data = [];

    }

    loadData() {
        self = this;
        $.ajax({
            url: "/api/customer", // Đường dẫn địa chỉ
            method: "GET", // Phương thức
            data: "", // Tham số sẽ truyền qua body request
            contentType: "application/json", // Kiểu dữ liệu trả về
            dataType: "" // Kiểu dữ liệu của tham số
            //success: function () {

            //},
            //done: function () {

            //}
        }).done(function (response) {
            $('.gird tbody').empty();
            $.each(response, function (index, item) {
                var checkDate = "";
                if (dateToDMY(new Date(item.customerBirthday)) != "01/01/1970") //giá trị mặc định - set trong sql
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
                $('.gird tbody').append(trHTML);
            })
        }).fail(function (res) {
            console.log(res);
        })
    }

    makeTrHTML() {
        return '';
    }

    // Hiển thị dialog chi tiết thông tin
    btnAddOnClick() {
        this.FormMode = "add";
        this.showDialogDetail();
    }

    //Check và lưu dữ liệu
    btnSaveOnClick() {
        //debugger
        //Vaildate dữ liệu nhập vào (Kiểm tra dữ liệu có đúng hay không)
        var inputRequireds = $("[required]");
        var isValid = true;
        var method = "POST"
        var self = this;
        $.each(inputRequireds, function (index, input) {
            var valid = $(input).trigger("blur");
            if (isValid && valid.hasClass("required-error")) {
                isValid = false;
            }
        })
        if (isValid) {
            // Thu thập thông tin nhập trên form:
            var customer = {};
            customer.CustomerCode = $("#txtCustomerCode").val();
            customer.CustomerName = $("#txtCustomerName").val();
            customer.CustomerBirthday = $("#dtCustomerBirthday").val() || new Date("");
            customer.CustomerCompany = $("#txtCustomerCompany").val();
            customer.CustomerTax = $("#txtCustomerTax").val();
            customer.CustomerAddress = $("#txtCustomerAddress").val();
            customer.CustomerMobile = $("#txtCustomerMobile").val();
            customer.CustomerEmail = $("#txtCustomerEmail").val();

            //Thực hiện cất dữ liệu vào DataBase;
            if (self.FormMode == "edit") {
                method = "PUT"
            }
            $.ajax({
                url: "/api/customer",
                method: method,
                data: JSON.stringify(customer),
                contentType: "application/json",
                dataType: "json"
            }).done(function (res) {
                //Load lại dữ liệu
                self.loadData();
                self.hideDialogDetail();
                self.FormMode = null;
            }).fail(function (res) {
                console.log(res);
            });
        }
    }

    //Sửa dữ liệu
    btnEditOnClick() {
        this.FormMode = "edit";
        // Lấy dữ liệu của nhân viên tương ứng đã chọn:
        // 1. Xác định nhân viên nào được chọn:
        var trSelected = $("#tblCustomers tr.row-selected");
        var self = this;
        // 2. Lấy thông tin Mã nhân viên:
        if (trSelected.length > 0) {
            this.showDialogDetail();
            var customerCode = $(trSelected).children()[0].textContent;
            // 3. Gọi api service để lấy dữ liệu chi tiết của nhân viên với mã tương ứng:
            $.ajax({
                url: "/api/customer/" + customerCode,
                method: "GET"
            }).done(function (customer) {
                if (!customer) {
                    alert("Không có nhân viên với mã tương ứng")
                } else {
                    // bindding các thông tin của nhân viên lên form:
                    $("#txtCustomerCode").val(customer.customerCode);
                    $("#txtCustomerName").val(customer.customerName);
                    $("#dtCustomerBirthday").val(dateToYMD(new Date(customer.customerBirthday)));
                    $("#txtCustomerCompany").val(customer.customerCompany);
                    $("#txtCustomerTax").val(customer.customerTax);
                    $("#txtCustomerAddress").val(customer.customerAddress);
                    $("#txtCustomerMobile").val(customer.customerMobile);
                    $("#txtCustomerEmail").val(customer.customerEmail);
                }
            }).fail(function () {
            })
        } else {
            alert("Bạn chưa chọn nhân viên nào!")
        }
    }

    //Xóa dữ liệu
    btnDeleteOnClick() {
        var self = this;
        // Lấy mã nhân viên được chọn:
        var trSelected = $("#tblCustomers tr.row-selected");
        // Gọi API service thực hiện:
        if (trSelected.length > 0) {
            var customerCode = $(trSelected).children()[0].textContent;
            // Gọi api service xóa dữ liệu của khách hàng với mã tương ứng:
            $.ajax({
                url: "/api/customer/" + customerCode,
                method: "DELETE"
            }).done(function (customer) {
                if (customer) {
                    alert("Xóa thành công");
                } else {
                    alert("Không có nhân viên với mã tương ứng");
                }
                self.loadData();
            }).fail(function () {
            })
        } else {
            alert("Bạn chưa chọn nhân viên nào!")
        }
    }

    //Nút Cancel
    btnCancelOnClick() {
        this.hideDialogDetail();
    }

    //Nút Close
    btnCloseOnClick() {
        this.hideDialogDetail();
    }

    //Hiện Dialog
    showDialogDetail() {
        $('.dialog input').val(null);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
    }

    //Ẩn Dialog
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
    }

    //Check các thông tin bắt buộc nhập
    checkRequired() {
        var value = this.value;
        if (!value) {
            $(this).addClass('required-error');
            $(this).attr("title", "Bạn phải nhập thông tin này");
            $(this).attr("placeholder", "Bạn phải nhập thông tin này");
        } else {
            $(this).removeClass('required-error');
            $(this).removeClass("title");
        }
    }

    //Select hàng
    rowOnSelect() {
        $(this).siblings().removeClass('row-selected');
        $(this).addClass('row-selected');
    }

    //Responsive Menu
    slideOnClick() {
        var x = document.getElementById("menu-id");
        if ($(window).width() <= 800) {
            if (x.className === "menu") {
                x.className = "menu-responsive";
            } else {
                x.className = "menu";
            }
        }
    }

    //Return nút Tab
    returnFocus() {
        $('#txtCustomerCode').focus();
    }
}
