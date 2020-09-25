$(document).ready(function () {
    var customerJS = new CustomerJS();
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
})

class CustomerJS {
    constructor() {
        this.loadData();
        this.initEvents();
        this.FormMode = null;
    }

    initEvents() {
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        //$('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#btnClose').click(this.btnCloseOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCancel').click(this.btnCancelOnClick.bind(this));
        $('input[required]').blur(this.checkRequired);
        $('#btnHelpDialog').focus(this.returnFocus);
        $("table tbody").on("click", "tr", this.rowOnSelect);
        $('#slideMenu').click(this.slideOnClick.bind(this));
    }

    loadData() {
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
            //$('.gird tbody').empty();
            $.each(response, function (index, item) {
                var trHTML = $(`<tr>
            <td>` + item.customerCode + `</td>
            <td>` + item.customerName + `</td>
            <td>` + item.customerCompany + `</td>
            <td>` + item.customerTax + `</td>
            <td>` + item.customerAddress + `</td>
            <td>` + item.customerMobile + `</td>
            <td>` + item.customerEmail + `</td>
        </tr>`);
                $('.gird tbody').append(trHTML);
            })
        }).fail(function (response) {
        })
        
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
        //var method = "POST"
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
            customer.CustomerCompany = $("#txtCustomerCompany").val();
            customer.CustomerTax = $("#txtCustomerTax").val();
            customer.CustomerAddress = $("#txtCustomerAddress").val();
            customer.CustomerMobile = $("#txtCustomerMobile").val();
            customer.CustomerEmail = $("#txtCustomerEmail").val();

            // Thực hiện cất dữ liệu vào DataBase;
            //if (self.FormMode == "edit") {
            //    method = "PUT"
            //}
            //console.log(customer);
            debugger
            $.ajax({
                url: "/api/customer",
                method: "POST",
                data: JSON.stringify(customer),
                contentType: "application/json",
                dataType: "json"
            }).done(function (res) {
                debugger
                //Load lại dữ liệu
                self.loadData();
                self.hideDialogDetail();
                self.FormMode = null;
                console.log("1");
            }).fail(function (res) {
                debugger
                console.log(res);
            });
        }
    }

    //btnEditOnClick() {
    //    this.FormMode = "edit";
    //    // Lấy dữ liệu của nhân viên tương ứng đã chọn:
    //    // 1. Xác định nhân viên nào được chọn:
    //    var trSelected = $("#tbEmployees tr.row-selected");
    //    // 2. Lấy thông tin Mã nhân viên:
    //    if (trSelected.length > 0) {
    //        this.showDialogDetail();
    //        var employeeCode = $(trSelected).children()[0].textContent;

    //        // 3. Gọi api service để lấy dữ liệu chi tiết của nhân viên với mã tương ứng:
    //        $.ajax({
    //            url: "/employees/" + employeeCode,
    //            method: "GET"
    //        }).done(function (employee) {
    //            if (!employee) {
    //                alert("Không có nhân viên với mã tương ứng")
    //            } else {
    //                // bindding các thông tin của nhân viên lên form:
    //                $("#txtEmployeeCode").val(employee["EmployeeCode"]);
    //                $("#txtEmployeeName").val(employee["EmployeeName"]);
    //                $("#txtEmail").val(employee["EmployeeEmail"]);
    //                $("#txtMobile").val(employee["EmployeeMobile"]);
    //                $("#txtEmployeeCompany").val(employee["EmployeeCompany"]);
    //            }
    //        }).fail(function () {
    //        })
    //    } else {
    //        alert("Bạn chưa chọn nhân viên nào!")
    //    }
    //}

    btnDeleteOnClick() {
        var self = this;
        // Lấy mã nhân viên được chọn:
        var trSelected = $("#tblCustomers tr.row-selected");
        // Gọi API service thực hiện:
        if (trSelected.length > 0) {
            var customerCode = $(trSelected).children()[0].textContent;
            // Gọi api service để lấy dữ liệu chi tiết của khách hàng với mã tương ứng:
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

    btnCancelOnClick() {
        this.hideDialogDetail();
    }

    btnCloseOnClick() {
        this.hideDialogDetail();
    }

    showDialogDetail() {
        $('.dialog input').val(null);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
    }

    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
    }

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
    };

    //Return nút Tab
    returnFocus() {
        $('#txtCustomerCode').focus();
    }
}

//var customer = [
//    {
//        CustomerCode: "KH0001",
//        CustomerName: "Lại Thị Huyền",
//        CustomerCompany: "BKAV",
//        CustomerTax: "012345",
//        CustomerAddress: "Hà Đông, Hà Nội",
//        CustomerMobile: "0359434106",
//        CustomerEmail: "huyenlai99@gmail.com"
//    },
//    {
//        CustomerCode: "KH0001",
//        CustomerName: "Lại Thị Huyền",
//        CustomerCompany: "BKAV",
//        CustomerTax: "012345",
//        CustomerAddress: "Hà Đông, Hà Nội",
//        CustomerMobile: "0359434106",
//        CustomerEmail: "huyenlai99@gmail.com"
//    },
//    {
//        CustomerCode: "KH0001",
//        CustomerName: "Lại Thị Huyền",
//        CustomerCompany: "BKAV",
//        CustomerTax: "012345",
//        CustomerAddress: "Hà Đông, Hà Nội",
//        CustomerMobile: "0359434106",
//        CustomerEmail: "huyenlai99@gmail.com"
//    }
//]