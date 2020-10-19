$(document).ready(function () {
    /**
    * Author: NKĐạt
    * Date: 28/9/2020
    * Timeout Event Responsive Menu
    * */
    var timeout;
    $(window).resize(function () {
        if (timeout) clearTimeout(timeout);
        timeout = setTimeout(menu_responsive, 10);
    });

    $(document).keydown(function (event) {

        if (!(event.which == 83 && event.ctrlKey) && !(event.which == 19)) return true;
        event.preventDefault();
        alert("Ctrl-S pressed");
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
            this.selectId = null;
        } catch (e) {
            console.log(e);
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Gán các sự kiện thành phần
    * */
    initEvents() {
        //Các nút và thành phần thêm, sửa, xóa, hủy bỏ.
        $('#btnAdd').click(this.btnAddOnClick.bind(this));
        $('#btnEdit').click(this.btnEditOnClick.bind(this));
        $('#btnDelete').click(this.btnDeleteOnClick.bind(this));
        $('#btnReset').click(this.loadData.bind(this));
        $('#btnClose').click(this.closeDialogOnClick.bind(this));
        $('#btnSave').click(this.btnSaveOnClick.bind(this));
        $('#btnCancel').click(this.closeDialogOnClick.bind(this));
        $('input[required]').blur(this.validateRequired.bind(this));
        $('#btnHelpDialog').blur(this.returnFocus);
        //Select Hàng
        $("table tbody").on("click", "tr", this.rowOnSelect);
        //Responsive Menu
        $('#slideMenu').click(this.slideOnClick.bind(this));
        $('.main').click(this.mainPageOnClick.bind(this));
        //Ẩn Dialog
        $('.dialog-modal').click(this.closeAllDialogOnClick.bind(this));
        //Dialog xác nhận 
        $('#btnCloseConfirm').click(this.closeDialogConfirmOnClick.bind(this));
        $('#btnConfirmAnnounce').click(this.closeDialogAnnounceOnClick.bind(this));
        $('#btnAgreeConfirm').click(this.agreeOnClick.bind(this));
        $('#btnCancelConfirm').click(this.closeDialogConfirmOnClick.bind(this));
        //Dialog thông báo
        $('#btnCloseAnnounce').click(this.closeDialogAnnounceOnClick.bind(this));
        //Dialog cảnh báo
        $('#btnCloseWarning').click(this.closeDialogWarningOnClick.bind(this));
        $('#btnConfirmWarning').click(this.closeDialogWarningOnClick.bind(this));
        //Event Keyup Format Money
        $('#txtMoneyTax').on('blur, focus, keyup', this.formatMoneyKeyup);
        $('#txtSalary').on('blur, focus, keyup', this.formatMoneyKeyup);

    }

    getData() {
        this.Data = [];
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Lấy dữ liệu và Binding dữ liệu lên trên UI
    * */
    loadData() {
        try {
            // Đọc thông tin các cột dữ liệu:
            var fields = $('#tblListData thead th');
            // Lấy dữ liệu:
            var data = this.Data;
            var self = this;
            $('#tblListData tbody').empty();
            //console.log(data);
            $.each(data, function (index, item) {
                var tr = $(`<tr></tr>`);
                $.each(fields, function (index, field) {
                    //Lấy dữ liệu từ các cột
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    var value = item[fieldName];
                    if (format == "Date") {
                        var checkDate = "";
                        if (dateToDMY(new Date(value)) != "31/12/1699") //giá trị mặc định 
                            checkDate = dateToDMY(new Date(value));
                        value = checkDate;
                        var td = $(`<td style="text-align: center;">` + value + `</td>`);
                    } else if (format == "Money") {
                        var td = $(`<td style="text-align: right;">` + value.formatMoney() + `</td>`);
                    } else {
                        var td = $(`<td>` + value + `</td>`);
                    }
                    $(tr).append(td);
                    $(tr).data('key', item[Object.keys(item)[0]]);
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
     * @param {object} objInput
     * @param {string} method
     * Call ajax hàm postdata
     */
    postData(objInput, method) { };

    /**
     * Author: NKĐạt
     * @param {string} selectDel
     * Call ajax hàm deletedata
     */
    deleteData(selectDel) { };

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Hiển thị dialog chi tiết thông tin
    * */
    btnAddOnClick() {
        this.FormMode = "add";
        this.showDialogDetail();
        this.getNewEmployeeCode();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Check và lưu dữ liệu
    * */
    btnSaveOnClick() {
        try {
            //Vaildate dữ liệu nhập vào (Kiểm tra dữ liệu có đúng hay không)
            var inputRequireds = $("[required]");
            var isValid = true;
            var self = this;
            var method = "POST";
            var nameId = Object.keys(self.Data[0])[0];
            nameId = upperCaseFirstLetter(nameId);
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
                var objInput = new Object();
                objInput[nameId] = "00000000-0000-0000-0000-000000000000";
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    var format = $(field).attr('format');
                    if (format == "Int") {
                        objInput[fieldName] = parseInt($(field).val());
                    }
                    else
                        objInput[fieldName] = $(field).val();
                    if (format == "Money") {
                        if (objInput[fieldName] == "") {
                            objInput[fieldName] = parseFloat(0);
                        } else {
                            objInput[fieldName] = parseFloat($(field).val().replaceAll('.', ''));
                        }
                    } else if (format == "Date") {
                        if (objInput[fieldName] == "") {
                            objInput[fieldName] = new Date('1700/01/01');
                        } else {
                            objInput[fieldName] = $(field).val();
                        }
                    }
                })
                //Thực hiện cất dữ liệu vào DataBase;
                if (self.FormMode == "edit") {
                    method = "PUT";
                    objInput[nameId] = self.selectId;
                }
                console.log(objInput);
                self.postData(objInput, method);
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 3/10/2020
    * Sửa dữ liệu
    * */
    btnEditOnClick() {
        this.FormMode = "edit";
        // Lấy dữ liệu của nhân viên tương ứng đã chọn:
        // 1. Xác định nhân viên nào được chọn:
        var trSelected = $("#tblListData tr.row-selected");
        var self = this;
        // 2. Lấy thông tin Mã nhân viên:
        if (trSelected.length > 0) {
            self.showDialogDetail();
            self.selectId = trSelected.data('key');
            // 3. Gọi api service để lấy dữ liệu chi tiết của nhân viên với mã tương ứng:
            self.getDataDetail(self.selectId);
            var objDetail = self.DataDetail;
            if (!objDetail) {
                self.showDialogWarning('none');
            } else {
                // bindding các thông tin của nhân viên lên form:
                var fields = $('.dialog input, .dialog select, .dialog textarea');
                $.each(fields, function (index, field) {
                    var fieldName = $(field).attr('fieldName');
                    fieldName = lowerCaseFirstLetter(fieldName);
                    var format = $(field).attr('format');
                    if (format == "Money") {
                        field.value = objDetail[fieldName].formatMoney();
                    } else if (format == "Date") {
                        field.value = dateToYMD(new Date(objDetail[fieldName]));
                    } else {
                        field.value = objDetail[fieldName];
                    }
                })
            }
        } else {
            self.showDialogWarning('no-select');
        }
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Xóa dữ liệu
    * */
    btnDeleteOnClick() {
        try {
            var self = this;
            self.checkRequired = false;
            // Lấy mã nhân viên được chọn:
            var trSelected = $("#tblListData tr.row-selected");
            // Gọi API service thực hiện:
            var listDel = [];
            if (trSelected.length > 0) {
                trSelected.each((i, e) => {
                    listDel.push($(e).data('key'));
                })

                self.selectDel = listDel.join();
                if (trSelected.length == 1)
                    self.showDialogConfirm('del-1');
                else
                    self.showDialogConfirm('del-n');
            } else {
                self.showDialogWarning('no-select');
            }
        } catch (e) {
            console.log(e)
        }
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Button Agree Dialog Confirm
    * */
    agreeOnClick() {
        self.deleteData(self.selectDel);
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Hiện dialog thông báo
    * @param {string} check
    * */
    checkDialogConfirm(check) {
        $('.dialog-confirm').hide();
        if (check == true) {
            $('#txtTitleAnnounce').text('Xóa thành công!');
        } else {
            $('#txtTitleAnnounce').text('Không có nhân viên với mã tương ứng!');
        }
        $('.dialog-announce').show();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Event Ẩn Dialog
    * */
    closeAllDialogOnClick() {
        this.hideDialogDetail();
        this.hideDialogAnnounce();
        this.hideDialogConfirm();
        this.hideDialogWarning();
    }

    closeDialogOnClick() {
        this.hideDialogDetail();
    }

    closeDialogConfirmOnClick() {
        this.hideDialogConfirm();
    }

    closeDialogAnnounceOnClick() {
        this.hideDialogAnnounce();
    }

    closeDialogWarningOnClick() {
        this.hideDialogWarning();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Hiện Dialog Khi Click
    * */
    showDialogDetail() {
        $('.dialog input, .dialog textarea, .dialog select').val(null);
        $('.dialog-modal').show();
        $('.dialog').show();
        $('#txtCustomerCode').focus();
        var selects = $(".dialog select");
        $.each(selects, function (index, select) {
            $("option:first-child").prop("selected", true);
        })
    }

    showDialogConfirm(checkValue) {
        $('.dialog-modal').show();
        if (checkValue == 'del-1') {
            $('#txtTitleConfirm').text('Bạn chắc chắn muốn xóa Nhân viên <<>> không ?');
        } else if (checkValue == 'del-n') {
            $('#txtTitleConfirm').text('Bạn chắc chắn muốn xóa những Nhân viên đã chọn không ?');
        }
        $('.dialog-confirm').show();
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Hiện Dialog Thông Báo
    * @param {string} checkValue
    * */
    showDialogAnnounce(checkValue) {
        $('.dialog-modal').show();
        if (checkValue == 'POST') {
            $('#txtTitleAnnounce').text('Thêm thành công!');
        } else if (checkValue == 'PUT') {
            $('#txtTitleAnnounce').text('Sửa thành công!');
        }
        $('.dialog-announce').show();
    }

    /**
    * Author: NKĐạt
    * Date: 19/10/2020
    * Hiện Dialog Cảnh Báo
    * @param {string} checkValue
    * */
    showDialogWarning(checkValue) {
        $('.dialog-modal').show();
        if (checkValue == 'none') {
            $('#txtTitleWarning').text('Không có nhân viên với mã tương ứng!');
        } else if (checkValue == 'no-select') {
            $('#txtTitleWarning').text('Bạn chưa chọn nhân viên nào!');
        }
        $('.dialog-warning').show();
    }

    /**
    * Author: NKĐạt
    * Date: 30/9/2020
    * Ẩn Dialog Khi Click
    * */
    hideDialogDetail() {
        $('.dialog-modal').hide();
        $('.dialog').hide();
        $('input').removeClass('required-error');
        $('input').removeClass("title");
        $('input').removeAttr("placeholder");
    }

    hideDialogConfirm() {
        $('.dialog-modal').hide();
        $('.dialog-confirm').hide();
    }

    hideDialogWarning() {
        $('.dialog-modal').hide();
        $('.dialog-warning').hide();
    }

    hideDialogAnnounce() {
        $('.dialog-modal').hide();
        $('.dialog-announce').hide();
    }

    /**
    * Author: NKĐạt
    * Date: 2/10/2020
    * Check các thông tin bắt buộc nhập
    * @param {this} sender
    * */
    validateRequired(sender) {
        validData.validateRequired(sender.currentTarget);
    }

    validateCustom() {
        return true;
    };

    /**
    * Author: NKĐạt
    * Date: 25/9/2020
    * Select hàng
    * */
    rowOnSelect(event) {

        if (event.ctrlKey) {
            $(this).toggleClass('row-selected');
        }
        else {
            $(this).siblings().removeClass('row-selected');
            $(this).addClass('row-selected');
        }
    }

    /**
    * Author: NKĐạt
    * Date: 28/9/2020
    * Responsive Menu
    * */
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
    * Date: 28/9/2020
    * Responsive Menu Close
    * */
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
    * Date: 29/9/2020
    * Return Key Press Tab
    * */
    returnFocus() {
        $('#txtEmployeeCode').focus();
        $('#txtCustomerCode').focus();
    }

    /**
    * Author: NKĐạt
    * Date: 6/10/2020
    * Format Money Keyup
    * */
    formatMoneyKeyup() {
        var value = parseInt(this.value.replaceAll('.', ''));
        this.value = value.formatMoney();
    }
}

/**
* Author: NKĐạt
* Date: 28/9/2020
* Responesive Menu
* */
function menu_responsive() {
    if ($(window).width() > 768) {
        var x = document.getElementById("menu-id");
        x.className = "menu";
    }
}


