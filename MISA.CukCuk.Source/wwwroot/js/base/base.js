$(document).ready(function () {
    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    // Timeout Event Responsive Menu
    var timeout;
    $(window).resize(function () {
        //debugger
        if (timeout) clearTimeout(timeout);
        timeout = setTimeout(menu_responsive, 10);
    });
})

class BaseJS {
    constructor() {
        try {
            this.getData();
            this.loadData();
            this.initEvents();
            this.FormMode = null;
            this.checkRequired = null;
        } catch (e) {
            console.log(e);
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    // Gán các sự kiện thành phần
    initEvents() {
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#btnClose').click(this.closeDialogOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCancel').click(this.closeDialogOnClick.bind(this));
        $('input[required]').blur(this.validateRequired.bind(this));
        $('#btnHelpDialog').blur(this.returnFocus);
        $("table tbody").on("click", "tr", this.rowOnSelect);
        $('#slideMenu').click(this.slideOnClick.bind(this));
        $('.main').click(this.mainPageOnClick.bind(this));
        $('.dialog-modal').click(this.closeDialogOnClick.bind(this));
        //Btn Confirm Delete
        $('#btnAgreeDelete').click(this.btnConfirmOnClick.bind(this));
        $('#btnCancelDelete').click(this.closeDialogOnClick.bind(this));
    }

    getData() {
        this.Data = [];
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    // Lấy dữ liệu và Binding dữ liệu lên trên UI
    loadData() {
        try {
            // Đọc thông tin các cột dữ liệu:
            var fields = $('#tblListData thead td');
            // Lấy dữ liệu:
            var data = this.Data;
            var self = this;
            $('#tblListData tbody').empty();
            $.each(data, function (index, item) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    //Lấy dữ liệu từ các cột
                    var fieldName = $(field).attr('fieldName');    
                    var value = item[fieldName];
                    if (fieldName == "customerBirthday") {
                        var checkDate = "";
                        if (dateToDMY(new Date(value)) != "01/01/1700") //giá trị mặc định 
                            checkDate = dateToDMY(new Date(value));
                        value = checkDate;
                        var td = $(`<td style="text-align: center;">` + value + `</td>`);
                    } else if (fieldName == "customerMoney") {
                        var td = $(`<td style="text-align: right;">` + value.formatMoney() + `</td>`);
                    } else {
                        var td = $(`<td>` + value + `</td>`);
                    }
                    $(tr).append(td);
                    //console.log(item[Object.keys(item)[0]]);
                    //$(tr).data('key', item[Object.keys(item)[0]]);
                })
                // Binding dữ liệu lên trên UI
                $('#tblListData tbody').append(tr);
            });
        } catch (e) {
            console.log(e)
        }
    }

    /**
     * Author: NKĐạt
     * @param {object} customer
     * @param {string} method
     */
    postData(customer, method) { };

    /**
     * Author: NKĐạt
     * @param {string} customerCode
     */
    deleteData(selectDel) { };

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    // Hiển thị dialog chi tiết thông tin
    btnAddOnClick() {
        this.FormMode = "add";
        this.showDialogDetail();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Check và lưu dữ liệu
    btnSaveOnClick() {
        try {
            //Vaildate dữ liệu nhập vào (Kiểm tra dữ liệu có đúng hay không)
            var inputRequireds = $("[required]");
            var isValid = true;
            var self = this;
            var method = "POST";
            $.each(inputRequireds, function (index, input) {
                if (!validData.validateRequired(input)) {
                    isValid = false;
                }
            })
            if (isValid) {
                isValid = self.validateCustom();
            }
            if (isValid) {
                // Đọc thông tin các ô dữ liệu:
                var fields = $('.dialog input, .dialog select, .dialog textarea');
                var customer = new Object();
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    customer[fieldName] = $(field).val();
                    if (format == "Money") {
                        if (customer[fieldName] == "") {
                            customer[fieldName] = parseFloat(0);
                        } else {
                            customer[fieldName] = parseFloat($(field).val());
                        }
                    } else if (format == "Date") {
                        if (customer[fieldName] == "") {
                            customer[fieldName] = new Date('1700/01/01');
                        } else {
                            customer[fieldName] = $(field).val();
                        }
                    } else {
                        if (customer[fieldName] == null) customer[fieldName] = "";
                    }    
                })

                //Thực hiện cất dữ liệu vào DataBase;
                if (self.FormMode == "edit") {
                    method = "PUT"
                }
                self.postData(customer, method);
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    ////Sửa dữ liệu
    btnEditOnClick() {
        //    this.FormMode = "edit";
        //    // Lấy dữ liệu của nhân viên tương ứng đã chọn:
        //    // 1. Xác định nhân viên nào được chọn:
        //    var trSelected = $("#tblCustomers tr.row-selected");
        //    var self = this;
        //    // 2. Lấy thông tin Mã nhân viên:
        //    if (trSelected.length > 0) {
        //        this.showDialogDetail();
        //        var customerCode = $(trSelected).children()[0].textContent;
        //        // 3. Gọi api service để lấy dữ liệu chi tiết của nhân viên với mã tương ứng:
        //        $.ajax({
        //            url: "/api/customer/" + customerCode,
        //            method: "GET"
        //        }).done(function (customer) {
        //            if (!customer) {
        //                alert("Không có nhân viên với mã tương ứng")
        //            } else {
        //                // bindding các thông tin của nhân viên lên form:
        //                $("#txtCustomerCode").val(customer.customerCode);
        //                $("#txtCustomerName").val(customer.customerName);
        //                $("#dtCustomerBirthday").val(dateToYMD(new Date(customer.customerBirthday)));
        //                $("#txtCustomerCompany").val(customer.customerCompany);
        //                $("#txtCustomerTax").val(customer.customerTax);
        //                $("#txtCustomerAddress").val(customer.customerAddress);
        //                $("#txtCustomerMobile").val(customer.customerMobile);
        //                $("#txtCustomerEmail").val(customer.customerEmail);
        //            }
        //        }).fail(function () {
        //        })
        //    } else {
        //        alert("Bạn chưa chọn nhân viên nào!")
        //    }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    ////Xóa dữ liệu
    btnDeleteOnClick() {
        try {
            var self = this;
            self.checkRequired = false;
            // Lấy mã nhân viên được chọn:
            var trSelected = $("#tblListData tr.row-selected");
            // Gọi API service thực hiện:
            if (trSelected.length > 0) {
                self.showDialogDeleteConfirm();
                if (true) {
                    var selectDel = $(trSelected).children()[0].textContent;
                    // Gọi api service xóa dữ liệu của khách hàng với mã tương ứng:
                    self.deleteData(selectDel);
                }
            } else {
                alert("Bạn chưa chọn nhân viên nào!")
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Ẩn Dialog Khi Click
    closeDialogOnClick() {
        this.hideDialogDetail();
    }

    btnConfirmOnClick() {
        this.checkRequired = true;
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Hiện Dialog
    showDialogDetail() {
        $('.dialog input, .dialog textarea, .dialog select').val(null);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
    }

    showDialogDeleteConfirm() {
        $('.dialog-modal').show();
        $('.dialog-delete-confirm').show();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Ẩn Dialog
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog-delete-confirm').hide();
        $('.dialog').hide();
        $('input').removeClass('required-error');
        $('input').removeClass("title");
        $('input').removeAttr("placeholder");
    }

    /**
    * Author: NKĐạt
    * Date: 2/10/2020
    * */
    //Check các thông tin bắt buộc nhập
    validateRequired(sender) {
        validData.validateRequired(sender.currentTarget);
    }

    validateCustom() {
        return true;
    };

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Select hàng
    rowOnSelect() {
        $(this).siblings().removeClass('row-selected');
        $(this).addClass('row-selected');
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Responsive Menu
    slideOnClick() {
        var x = document.getElementById("menu-id");
        if ($(window).width() <= 768) {
            if (x.className === "menu") {
                x.className = "menu-responsive";
            } else {
                x.className = "menu";
            }
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Responsive Menu Close
    mainPageOnClick() {
        var x = document.getElementById("menu-id");
        if ($(window).width() <= 768) {
            if (x.className === "menu-responsive") {
                x.className = "menu";
            }
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
    //Return Key Press Tab
    returnFocus() {
        $('#txtCustomerCode').focus();
    }
}
/**
    * Author: NKĐạt
    * Date: 30/9/2020
    * */
// Responesive Menu 
function menu_responsive() {
    if ($(window).width() > 768) {
        var x = document.getElementById("menu-id");
        x.className = "menu";
    }
}


